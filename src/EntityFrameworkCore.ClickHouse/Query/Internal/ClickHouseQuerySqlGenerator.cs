using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Query.Expressions;
using ClickHouse.EntityFrameworkCore.Query.Expressions.Internal;
using ClickHouse.EntityFrameworkCore.Storage.Internal;
using ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseQuerySqlGenerator : QuerySqlGenerator
{
    private static readonly ClickHouseStringTypeMapping s_stringTypeMapping = new();

    public ClickHouseQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies)
        : base(dependencies)
    {
    }

    protected override Expression VisitExtension(Expression extensionExpression)
        => extensionExpression switch
        {
            ClickHouseTrimExpression e => VisitTrim(e),
            ClickHouseRowValueExpression e => VisitRowValue(e),

            _ => base.VisitExtension(extensionExpression)
        };

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

        return base.VisitProjection(projectionExpression);
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
}
