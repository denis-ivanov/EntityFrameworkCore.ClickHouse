using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Query.Expressions;
using ClickHouse.EntityFrameworkCore.Query.Expressions.Internal;
using ClickHouse.EntityFrameworkCore.Storage.Internal;
using ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public partial class ClickHouseQuerySqlGenerator : QuerySqlGenerator
{
    private static readonly ClickHouseStringTypeMapping s_stringTypeMapping = new();
    private bool _hasOuterJoin;
    private bool _aliasJoinedProjection;
    private string? _deleteAlias;
    private readonly Stack<SelectExpression> _selectScopes = new();

    public ClickHouseQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies)
        : base(dependencies)
    {
    }

    protected override void GenerateRootCommand(Expression queryExpression)
    {
        _hasOuterJoin = false;
        base.GenerateRootCommand(queryExpression);

        if (queryExpression is SelectExpression && _hasOuterJoin)
        {
            // EF uses SQL NULL to identify the missing side of an outer join.
            Sql.AppendLine().Append("SETTINGS join_use_nulls = 1");
        }
    }

    protected override Expression VisitExtension(Expression extensionExpression)
    {
        _hasOuterJoin |= extensionExpression is LeftJoinExpression or RightJoinExpression;
#if NET11_0_OR_GREATER
        _hasOuterJoin |= extensionExpression is FullJoinExpression;
#endif

        return extensionExpression switch
        {
            ClickHouseTrimExpression e => VisitTrim(e),
            ClickHouseRowValueExpression e => VisitRowValue(e),

            _ => base.VisitExtension(extensionExpression)
        };
    }

    protected override Expression VisitJsonScalar(JsonScalarExpression jsonScalarExpression)
    {
        if (jsonScalarExpression.Path.Count == 0)
        {
            if (jsonScalarExpression is { IsNullable: true, TypeMapping: ClickHouseJsonTypeMapping { StoreType: "String" } })
            {
                Sql.Append("nullIf(");
                Visit(jsonScalarExpression.Json);
                Sql.Append(", '')");
            }
            else
            {
                Visit(jsonScalarExpression.Json);
            }

            return jsonScalarExpression;
        }

        if (jsonScalarExpression.TypeMapping is not { } typeMapping || typeMapping is ClickHouseJsonTypeMapping)
        {
            return base.VisitJsonScalar(jsonScalarExpression);
        }

        bool extractsJsonText = typeMapping.StoreType == "String" && typeMapping.ElementTypeMapping != null;
        if (extractsJsonText)
        {
            Sql.Append("nullIf(JSONExtractRaw(");
        }
        else
        {
            Sql.Append("JSONExtract(");
        }

        bool nativeJson = string.Equals(jsonScalarExpression.Json.TypeMapping?.StoreType, "Json", StringComparison.OrdinalIgnoreCase);

        if (nativeJson)
        {
            Sql.Append("toJSONString(");
        }

        Visit(jsonScalarExpression.Json);

        if (nativeJson)
        {
            Sql.Append(")");
        }

        foreach (PathSegment segment in jsonScalarExpression.Path)
        {
            Sql.Append(", ");

            if (segment.PropertyName is string propertyName)
            {
                string escapedName = propertyName.Replace(@"\", @"\\", StringComparison.Ordinal);
                Sql.Append(s_stringTypeMapping.GenerateSqlLiteral(escapedName));
            }
            else
            {
                // EF Core's JSON path indexes are zero-based. ClickHouse uses one-based indexes.
                Sql.Append("(CAST(");
                Visit(segment.ArrayIndex!);
                Sql.Append(" AS Int64) + 1)");
            }
        }

        if (extractsJsonText)
        {
            Sql.Append("), '')");
        }
        else
        {
            string returnType = jsonScalarExpression.IsNullable
                ? typeMapping.StoreType.GetNullableType()!
                : typeMapping.StoreType;

            Sql.Append(", ").Append(s_stringTypeMapping.GenerateSqlLiteral(returnType)).Append(")");
        }

        return jsonScalarExpression;
    }

    protected override Expression VisitSelect(SelectExpression selectExpression)
    {
        bool parentAliases = _aliasJoinedProjection;
        var parentOrderingJoins = _orderingJoins;
        _aliasJoinedProjection = selectExpression.Alias != null && selectExpression.Tables.Count > 1;
        _selectScopes.Push(selectExpression);
        _orderingJoins = FindCorrelatedOrderingJoins(selectExpression);
        try
        {
            return base.VisitSelect(selectExpression);
        }
        finally
        {
            _selectScopes.Pop();
            _aliasJoinedProjection = parentAliases;
            _orderingJoins = parentOrderingJoins;
        }
    }

    protected override Expression VisitScalarSubquery(ScalarSubqueryExpression scalarSubqueryExpression)
    {
        if (_orderingJoins?.TryGetValue(scalarSubqueryExpression, out CorrelatedOrderingJoin? orderingJoin) == true)
        {
            DelimitIdentifier(orderingJoin.Alias);
            Sql.Append(".");
            DelimitIdentifier(CorrelatedResultColumn);

            return scalarSubqueryExpression;
        }

        SelectExpression subquery = scalarSubqueryExpression.Subquery;
        if (subquery.Projection is
            [{
                Expression: SqlFunctionExpression
                {
                    Name: "COALESCE",
                    Arguments: [SqlFunctionExpression { Name: "SUM" }, SqlConstantExpression fallback]
                }
            }])
        {
            // A correlated aggregate can yield NULL for an unmatched outer row even when its own result is coalesced.
            Sql.Append("coalesce(");
            base.VisitScalarSubquery(scalarSubqueryExpression);
            Sql.Append(", ");
            Visit(fallback);
            Sql.Append(")");

            return scalarSubqueryExpression;
        }

        if (subquery is
            {
                Tables: [TableExpression source],
                Projection: [{ Expression: ColumnExpression selected }],
                Offset: null,
                Limit: SqlConstantExpression { Value: 1 },
                GroupBy.Count: 0,
                Having: null,
                Predicate: { } predicate
            }
            && selected.TableAlias == source.Alias
            && GetMatchingColumn(predicate, selected) is ColumnExpression outer
            && IsGroupKeyFromSameTable(outer, selected, source))
        {
            // The grouped input already contains a row with this key, and the subquery selects that same key.
            Visit(outer);
            return scalarSubqueryExpression;
        }

        return base.VisitScalarSubquery(scalarSubqueryExpression);
    }

    protected override void GenerateSetOperation(SetOperationBase setOperation)
    {
        if (setOperation is not UnionExpression { IsDistinct: true })
        {
            base.GenerateSetOperation(setOperation);
            return;
        }

        GenerateSetOperationOperand(setOperation, setOperation.Source1);
        Sql.AppendLine().AppendLine("UNION DISTINCT");
        GenerateSetOperationOperand(setOperation, setOperation.Source2);
    }

    protected override Expression VisitOrdering(OrderingExpression orderingExpression)
    {
        base.VisitOrdering(orderingExpression);

        if (orderingExpression is { IsAscending: true, Expression: ColumnExpression { IsNullable: true } column }
            && _selectScopes.TryPeek(out SelectExpression? select)
            && select.Tables.OfType<SelectExpression>().Any(table => table.Alias == column.TableAlias
                && table.Projection.Any(projection => projection.Alias == column.Name && projection.Expression is ScalarSubqueryExpression)))
        {
            Sql.Append(" NULLS FIRST");
        }

        return orderingExpression;
    }

    private bool IsGroupKeyFromSameTable(ColumnExpression outer, ColumnExpression selected, TableExpression source)
        => _selectScopes.SelectMany(static scope => scope.Tables.OfType<SelectExpression>())
            .Any(group => group.Alias == outer.TableAlias
                && group.Tables is [TableExpression groupSource]
                && groupSource.Name == source.Name
                && groupSource.Schema == source.Schema
                && group.Projection.Any(projection => projection.Alias == outer.Name
                    && projection.Expression is ColumnExpression groupingColumn
                    && groupingColumn.TableAlias == groupSource.Alias
                    && groupingColumn.Name == selected.Name
                    && group.GroupBy.Contains(groupingColumn)));

    private static ColumnExpression? GetMatchingColumn(SqlExpression predicate, ColumnExpression selected)
    {
        SqlBinaryExpression? equality = predicate is
            SqlBinaryExpression { OperatorType: ExpressionType.OrElse, Left: SqlBinaryExpression first }
                ? first
                : predicate as SqlBinaryExpression;

        if (equality is not { OperatorType: ExpressionType.Equal, Left: ColumnExpression left, Right: ColumnExpression right })
        {
            return null;
        }

        ColumnExpression? outer = SameColumn(left, selected) ? right : SameColumn(right, selected) ? left : null;
        if (outer == null || ReferenceEquals(predicate, equality))
        {
            return outer;
        }

        return predicate is SqlBinaryExpression
            {
                Right: SqlBinaryExpression { OperatorType: ExpressionType.AndAlso, Left: var firstNull, Right: var secondNull }
            }
            && ((IsNull(firstNull, selected) && IsNull(secondNull, outer)) || (IsNull(firstNull, outer) && IsNull(secondNull, selected)))
                ? outer
                : null;

        static bool SameColumn(ColumnExpression first, ColumnExpression second)
            => first.Name == second.Name && first.TableAlias == second.TableAlias;

        static bool IsNull(SqlExpression expression, ColumnExpression column)
            => expression is SqlUnaryExpression { OperatorType: ExpressionType.Equal, Operand: ColumnExpression operand }
                && SameColumn(operand, column);
    }

    protected override Expression VisitDelete(DeleteExpression deleteExpression)
    {
        SelectExpression select = deleteExpression.SelectExpression;
        if (select.Tables.Count != 1
            || select.Offset != null
            || select.Limit != null
            || select.GroupBy.Count != 0
            || select.Having != null)
        {
            return base.VisitDelete(deleteExpression);
        }

        TableExpression table = deleteExpression.Table;
        Sql.Append("ALTER TABLE ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(table.Name, table.Schema))
            .Append(" DELETE WHERE ");

        if (select.Predicate != null)
        {
            _deleteAlias = table.Alias;
            try
            {
                Visit(select.Predicate);
            }
            finally
            {
                _deleteAlias = null;
            }
        }
        else
        {
            Sql.Append("1");
        }

        Sql.Append(" SETTINGS mutations_sync = 1");
        return deleteExpression;
    }

    protected override Expression VisitColumn(ColumnExpression columnExpression)
    {
        if (_deleteAlias != null && columnExpression.TableAlias == _deleteAlias)
        {
            Sql.Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(columnExpression.Name));
            return columnExpression;
        }

        return base.VisitColumn(columnExpression);
    }

    protected override Expression VisitProjection(ProjectionExpression projectionExpression)
    {
        if (projectionExpression.Expression is ColumnExpression
            {
                IsNullable: true,
                TypeMapping: ClickHouseJsonTypeMapping { StoreType: "String" }
            } jsonColumn)
        {
            Sql.Append("nullIf(");
            Visit(jsonColumn);
            Sql.Append(", '')");

            string alias = projectionExpression.Alias.Length > 0 ? projectionExpression.Alias : jsonColumn.Name;
            Sql.Append(AliasSeparator).Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(alias));

            return projectionExpression;
        }

        if (_aliasJoinedProjection
            && projectionExpression.Expression is ColumnExpression column
            && projectionExpression.Alias == column.Name)
        {
            // ClickHouse may export a qualified name for an unaliased column in a joined subquery.
            Visit(column);
            Sql.Append(AliasSeparator).Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(projectionExpression.Alias));

            return projectionExpression;
        }

        return base.VisitProjection(projectionExpression);
    }

    protected override Expression VisitSqlUnary(SqlUnaryExpression sqlUnaryExpression)
    {
        if (sqlUnaryExpression.OperatorType == ExpressionType.Convert
            && sqlUnaryExpression.Operand.Type == typeof(char)
            && sqlUnaryExpression.TypeMapping is { } mapping
            && (mapping.StoreType.StartsWith("Int", StringComparison.OrdinalIgnoreCase)
                || mapping.StoreType.StartsWith("UInt", StringComparison.OrdinalIgnoreCase)))
        {
            Sql.Append("CAST(reinterpretAsUInt16(convertCharset(");
            Visit(sqlUnaryExpression.Operand);
            Sql.Append(", 'UTF-8', 'UTF-16LE')) AS ").Append(mapping.StoreType).Append(")");

            return sqlUnaryExpression;
        }

        return base.VisitSqlUnary(sqlUnaryExpression);
    }

    protected override void GenerateValues(ValuesExpression valuesExpression)
    {
        if (valuesExpression.RowValues is not { Count: > 0 } rows)
        {
            base.GenerateValues(valuesExpression);
            return;
        }

        for (int row = 0; row < rows.Count; row++)
        {
            Sql.Append(row == 0 ? "SELECT " : " UNION ALL SELECT ");
            IReadOnlyList<SqlExpression> values = rows[row].Values;

            for (int column = 0; column < values.Count; column++)
            {
                if (column != 0)
                {
                    Sql.Append(", ");
                }

                Visit(values[column]);

                if (row == 0)
                {
                    Sql.Append(AliasSeparator);
                    Sql.Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(valuesExpression.ColumnNames[column]));
                }
            }
        }
    }

    protected override Expression VisitCrossApply(CrossApplyExpression crossApplyExpression)
    {
        if (TableReferenceVisitor.IsCorrelated(crossApplyExpression.Table))
        {
            return base.VisitCrossApply(crossApplyExpression);
        }

        Sql.Append("CROSS JOIN ");
        Visit(crossApplyExpression.Table);

        return crossApplyExpression;
    }

#if NET11_0_OR_GREATER
    protected override Expression VisitTableValuedFunction(TableValuedFunctionExpression tableValuedFunctionExpression)
    {
        if (tableValuedFunctionExpression.Name != ClickHouseQueryableMethodTranslatingExpressionVisitor.JsonArrayRows)
        {
            return base.VisitTableValuedFunction(tableValuedFunctionExpression);
        }

        Sql.Append("(SELECT toInt32(tupleElement(__json_entry, 1)) - 1 AS ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(ClickHouseQueryableMethodTranslatingExpressionVisitor.JsonArrayOrdinal))
            .Append(", tupleElement(__json_entry, 2) AS ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(ClickHouseQueryableMethodTranslatingExpressionVisitor.JsonArrayValue))
            .Append(" FROM (SELECT arrayJoin(arrayZip(arrayEnumerate(");
        Visit(tableValuedFunctionExpression.Arguments[0]);
        Sql.Append("), ");
        Visit(tableValuedFunctionExpression.Arguments[0]);
        Sql.Append(")) AS __json_entry))")
            .Append(AliasSeparator)
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(tableValuedFunctionExpression.Alias));

        return tableValuedFunctionExpression;
    }
#endif

    protected override Expression VisitOuterApply(OuterApplyExpression outerApplyExpression)
    {
        if (TableReferenceVisitor.IsCorrelated(outerApplyExpression.Table))
        {
            return base.VisitOuterApply(outerApplyExpression);
        }

        _hasOuterJoin = true;
        Sql.Append("LEFT JOIN ");
        Visit(outerApplyExpression.Table);
        Sql.Append(" ON 1 = 1");

        return outerApplyExpression;
    }

    protected override void GenerateLimitOffset(SelectExpression selectExpression)
    {
        switch (selectExpression)
        {
            case { Limit: not null, Offset: not null }:
                Sql.AppendLine().Append("LIMIT ");
                Visit(selectExpression.Limit);
                Sql.Append(" OFFSET ");
                Visit(selectExpression.Offset);
                break;

            case { Limit: not null }:
                Sql.AppendLine().Append("LIMIT ");
                Visit(selectExpression.Limit);
                break;

            case { Offset: not null }:
                Sql.AppendLine().Append($"LIMIT {uint.MaxValue} OFFSET ");
                Visit(selectExpression.Offset);
                break;
        }
    }

    protected override Expression VisitSqlParameter(SqlParameterExpression sqlParameterExpression)
    {
        var parameterNameInCommand = Dependencies.SqlGenerationHelper.GenerateParameterName(sqlParameterExpression.Name);

        if (Sql.Parameters
            .All(p => p.InvariantName != sqlParameterExpression.Name))
        {
            Sql.AddParameter(
                sqlParameterExpression.Name,
                parameterNameInCommand,
                sqlParameterExpression.TypeMapping!,
                sqlParameterExpression.IsNullable);
        }

        Sql.Append(Dependencies.SqlGenerationHelper.GenerateParameterName(sqlParameterExpression.Name, sqlParameterExpression.TypeMapping!.StoreType));
        return sqlParameterExpression;
    }

    protected virtual Expression VisitTrim(ClickHouseTrimExpression trimExpression)
    {
        Sql.Append("trim(")
            .Append(trimExpression.TrimMode switch
            {
                ClickHouseStringTrimMode.Both => "BOTH ",
                ClickHouseStringTrimMode.Leading => "LEADING ",
                ClickHouseStringTrimMode.Trailing => "TRAILING ",
                _ => throw new InvalidEnumArgumentException("Invalid trim mode", (int)trimExpression.TrimMode, typeof(ClickHouseStringTrimMode))
            });

        Visit(trimExpression.TrimCharacters);

        Sql.Append(" FROM ");
        Visit(trimExpression.InputString);
        Sql.Append(")");

        return trimExpression;
    }

    protected virtual Expression VisitRowValue(ClickHouseRowValueExpression rowValueExpression)
    {
        Sql.Append("(");

        var values = rowValueExpression.Values;
        var count = values.Count;

        for (var i = 0; i < count; i++)
        {
            Visit(values[i]);

            if (i < count - 1)
            {
                Sql.Append(", ");
            }
        }

        Sql.Append(")");

        return rowValueExpression;
    }

    private sealed class TableReferenceVisitor : ExpressionVisitor
    {
        private readonly Stack<HashSet<string>> _scopes = new();
        private bool _hasOuterReference;

        public static bool IsCorrelated(TableExpressionBase table)
        {
            TableReferenceVisitor visitor = new();
            visitor.Visit(table);

            return visitor._hasOuterReference;
        }

        public static bool UsesOnlyLocalColumns(SqlExpression expression, string tableAlias)
        {
            TableReferenceVisitor visitor = new();
            visitor._scopes.Push(new HashSet<string>(StringComparer.Ordinal) { tableAlias });
            visitor.Visit(expression);

            return !visitor._hasOuterReference;
        }

        protected override Expression VisitExtension(Expression node)
        {
            if (node is SelectExpression select)
            {
                HashSet<string> aliases = new(StringComparer.Ordinal);

                foreach (TableExpressionBase table in select.Tables)
                {
                    TableExpressionBase source = table is JoinExpressionBase join ? join.Table : table;

                    if (source.Alias is string alias)
                    {
                        aliases.Add(alias);
                    }
                }

                _scopes.Push(aliases);
                Expression result = base.VisitExtension(node);
                _scopes.Pop();

                return result;
            }

            if (node is ColumnExpression column)
            {
                _hasOuterReference |= !_scopes.Any(scope => scope.Contains(column.TableAlias));
            }

            return base.VisitExtension(node);
        }
    }
}
