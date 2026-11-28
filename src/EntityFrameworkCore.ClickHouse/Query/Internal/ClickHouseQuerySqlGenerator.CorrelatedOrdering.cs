using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public partial class ClickHouseQuerySqlGenerator
{
    private const string CorrelatedKeyColumn = "__ch_key";
    private const string CorrelatedResultColumn = "__ch_value";
    private const string CorrelatedOrderColumn = "__ch_order";
    private const string CorrelatedRowColumn = "__ch_row";
    private Dictionary<ScalarSubqueryExpression, CorrelatedOrderingJoin>? _orderingJoins;

    protected override void GenerateFrom(SelectExpression selectExpression)
    {
        base.GenerateFrom(selectExpression);

        if (_orderingJoins is not { } joins)
        {
            return;
        }

        foreach ((ScalarSubqueryExpression scalar, CorrelatedOrderingJoin join) in joins)
        {
            _hasOuterJoin = true;
            Sql.AppendLine().Append("LEFT JOIN (SELECT ");
            DelimitIdentifier(CorrelatedKeyColumn);
            Sql.Append(", ");
            DelimitIdentifier(CorrelatedResultColumn);
            Sql.Append(" FROM (SELECT ");
            DelimitIdentifier(CorrelatedKeyColumn);
            Sql.Append(", ");
            DelimitIdentifier(CorrelatedResultColumn);
            Sql.Append(", row_number() OVER (PARTITION BY ");
            DelimitIdentifier(CorrelatedKeyColumn);
            Sql.Append(" ORDER BY ");
            DelimitIdentifier(CorrelatedOrderColumn);
            Sql.Append(join.Ascending ? " ASC" : " DESC");
            if (join.Ascending
                && scalar.Subquery.Orderings[0].Expression is ColumnExpression { IsNullable: true }
                && join.Ordering is ScalarSubqueryExpression)
            {
                Sql.Append(" NULLS FIRST");
            }
            Sql.Append(") AS ");
            DelimitIdentifier(CorrelatedRowColumn);
            Sql.Append(" FROM (SELECT ");
            Visit(join.InnerKey);
            Sql.Append(AliasSeparator);
            DelimitIdentifier(CorrelatedKeyColumn);
            Sql.Append(", ");
            Visit(join.Value);
            Sql.Append(AliasSeparator);
            DelimitIdentifier(CorrelatedResultColumn);
            Sql.Append(", ");
            Visit(join.Ordering);
            Sql.Append(AliasSeparator);
            DelimitIdentifier(CorrelatedOrderColumn);
            Sql.Append(" FROM ");
            Visit(join.Source);
            Sql.Append(")) WHERE ");
            DelimitIdentifier(CorrelatedRowColumn);
            Sql.Append(" = 1)").Append(AliasSeparator);
            DelimitIdentifier(join.Alias);
            Sql.Append(" ON ");
            Visit(join.OuterKey);
            Sql.Append(" = ");
            DelimitIdentifier(join.Alias);
            Sql.Append(".");
            DelimitIdentifier(CorrelatedKeyColumn);
        }
    }

    private Dictionary<ScalarSubqueryExpression, CorrelatedOrderingJoin>? FindCorrelatedOrderingJoins(SelectExpression select)
    {
        Dictionary<ScalarSubqueryExpression, CorrelatedOrderingJoin>? joins = null;
        int index = 0;

        foreach (ProjectionExpression projection in select.Projection)
        {
            // ClickHouse cannot decorrelate a scalar subquery whose ordering contains another correlated query.
            // Compute the same first row per key independently and join it back to the outer row.
            if (projection.Expression is not ScalarSubqueryExpression scalar
                || scalar.Subquery is not
                {
                    Tables: [SelectExpression inner],
                    Projection: [{ Expression: ColumnExpression selected }],
                    Orderings: [{ Expression: ColumnExpression ordered } ordering],
                    Limit: SqlConstantExpression { Value: 1 },
                    Offset: null,
                    Predicate: null,
                    IsDistinct: false,
                    GroupBy.Count: 0,
                    Having: null
                }
                || inner is not
                {
                    Tables: [TableExpression source],
                    Predicate: SqlBinaryExpression { OperatorType: ExpressionType.Equal, Left: ColumnExpression left, Right: ColumnExpression right },
                    Offset: null,
                    Limit: null,
                    IsDistinct: false,
                    GroupBy.Count: 0,
                    Having: null
                }
                || selected.TableAlias != inner.Alias
                || ordered.TableAlias != inner.Alias)
            {
                continue;
            }

            ColumnExpression innerKey = left.TableAlias == source.Alias ? left : right;
            ColumnExpression outerKey = ReferenceEquals(innerKey, left) ? right : left;
            if (innerKey.TableAlias != source.Alias || outerKey.TableAlias == source.Alias
                || !select.Tables.Any(table => (table is JoinExpressionBase join ? join.Table : table).Alias == outerKey.TableAlias))
            {
                continue;
            }

            SqlExpression? result = inner.Projection.FirstOrDefault(p => p.Alias == selected.Name)?.Expression;
            SqlExpression? orderingValue = inner.Projection.FirstOrDefault(p => p.Alias == ordered.Name)?.Expression;
            if (result == null || orderingValue == null
                || !TableReferenceVisitor.UsesOnlyLocalColumns(result, source.Alias)
                || !TableReferenceVisitor.UsesOnlyLocalColumns(orderingValue, source.Alias))
            {
                continue;
            }

            string alias;
            do
            {
                alias = "__ch_ranked_" + index++;
            }
            while (_selectScopes.Any(scope =>
                scope.Tables.Any(table => (table is JoinExpressionBase join ? join.Table : table).Alias == alias)));

            joins ??= new(ReferenceEqualityComparer.Instance);
            joins.TryAdd(scalar, new CorrelatedOrderingJoin(alias, source, innerKey, outerKey, result, orderingValue, ordering.IsAscending));
        }

        return joins;
    }

    private void DelimitIdentifier(string name)
        => Sql.Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(name));

    private sealed record CorrelatedOrderingJoin(
        string Alias,
        TableExpression Source,
        ColumnExpression InnerKey,
        ColumnExpression OuterKey,
        SqlExpression Value,
        SqlExpression Ordering,
        bool Ascending);
}
