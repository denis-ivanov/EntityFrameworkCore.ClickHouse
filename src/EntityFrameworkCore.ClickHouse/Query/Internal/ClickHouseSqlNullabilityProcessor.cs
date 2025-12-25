using ClickHouse.EntityFrameworkCore.Query.Expressions.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseSqlNullabilityProcessor : SqlNullabilityProcessor
{
    public ClickHouseSqlNullabilityProcessor(
        RelationalParameterBasedSqlProcessorDependencies dependencies,
        RelationalParameterBasedSqlProcessorParameters parameters)
        : base(dependencies, parameters)
    {
    }

    protected override SqlExpression VisitSqlBinary(SqlBinaryExpression sqlBinaryExpression, bool allowOptimizedExpansion, out bool nullable)
    {
        return sqlBinaryExpression switch
        {
            {
                OperatorType: ExpressionType.Equal or ExpressionType.NotEqual,
                Left: ClickHouseRowValueExpression leftRowValue,
                Right: ClickHouseRowValueExpression rightRowValue
            }
            => VisitRowValueComparison(sqlBinaryExpression.OperatorType, leftRowValue, rightRowValue, out nullable),

            _ => base.VisitSqlBinary(sqlBinaryExpression, allowOptimizedExpansion, out nullable)
        };

        SqlExpression VisitRowValueComparison(
            ExpressionType operatorType,
            ClickHouseRowValueExpression leftRowValue,
            ClickHouseRowValueExpression rightRowValue,
            out bool nullable)
        {
            Debug.Assert(leftRowValue.Values.Count == rightRowValue.Values.Count, "left.Values.Count == right.Values.Count");
            var count = leftRowValue.Values.Count;

            SqlExpression expandedExpression = null;
            List<SqlExpression> visitedLeftValues = null;
            List<SqlExpression> visitedRightValues = null;

            for (var i = 0; i < count; i++)
            {
                var leftValue = leftRowValue.Values[i];
                var rightValue = rightRowValue.Values[i];
                var visitedLeftValue = Visit(leftRowValue.Values[i], out var leftNullable);
                var visitedRightValue = Visit(rightRowValue.Values[i], out var rightNullable);

                if (!leftNullable && !rightNullable
                    || allowOptimizedExpansion && operatorType is ExpressionType.Equal && (!leftNullable || !rightNullable))
                {
                    if (visitedLeftValue != leftValue && visitedLeftValues is null)
                    {
                        visitedLeftValues = SliceToList(leftRowValue.Values, count, i);
                    }

                    visitedLeftValues?.Add(visitedLeftValue);

                    if (visitedRightValue != rightValue && visitedRightValues is null)
                    {
                        visitedRightValues = SliceToList(rightRowValue.Values, count, i);
                    }

                    visitedRightValues?.Add(visitedRightValue);

                    continue;
                }

                var valueBinaryExpression = Visit(
                    Dependencies.SqlExpressionFactory.MakeBinary(
                        operatorType, visitedLeftValue, visitedRightValue, typeMapping: null, existingExpression: sqlBinaryExpression)!,
                    allowOptimizedExpansion,
                    out _);

                if (expandedExpression is null)
                {
                    visitedLeftValues = SliceToList(leftRowValue.Values, count, i);
                    visitedRightValues = SliceToList(rightRowValue.Values, count, i);

                    expandedExpression = valueBinaryExpression;
                }
                else
                {
                    expandedExpression = operatorType switch
                    {
                        ExpressionType.Equal => Dependencies.SqlExpressionFactory.AndAlso(expandedExpression, valueBinaryExpression),
                        ExpressionType.NotEqual => Dependencies.SqlExpressionFactory.OrElse(expandedExpression, valueBinaryExpression),
                        _ => throw new UnreachableException()
                    };
                }
            }

            nullable = false;

            if (expandedExpression is null)
            {
                return visitedLeftValues is null && visitedRightValues is null
                    ? sqlBinaryExpression
                    : Dependencies.SqlExpressionFactory.MakeBinary(
                        operatorType,
                        visitedLeftValues is null
                            ? leftRowValue
                            : new ClickHouseRowValueExpression(visitedLeftValues, leftRowValue.Type, leftRowValue.TypeMapping),
                        visitedRightValues is null
                            ? rightRowValue
                            : new ClickHouseRowValueExpression(visitedRightValues, leftRowValue.Type, leftRowValue.TypeMapping),
                        typeMapping: null,
                        existingExpression: sqlBinaryExpression)!;
            }

            if (visitedLeftValues.Count is 0)
            {
                return expandedExpression;
            }

            var unexpandedExpression = visitedLeftValues.Count is 1
                ? Dependencies.SqlExpressionFactory.MakeBinary(operatorType, visitedLeftValues[0], visitedRightValues[0], typeMapping: null)!
                : Dependencies.SqlExpressionFactory.MakeBinary(
                    operatorType,
                    new ClickHouseRowValueExpression(visitedLeftValues, leftRowValue.Type, leftRowValue.TypeMapping),
                    new ClickHouseRowValueExpression(visitedRightValues, rightRowValue.Type, rightRowValue.TypeMapping),
                    typeMapping: null)!;

            return Dependencies.SqlExpressionFactory.MakeBinary(
                operatorType: operatorType switch
                {
                    ExpressionType.Equal => ExpressionType.AndAlso,
                    ExpressionType.NotEqual => ExpressionType.OrElse,
                    _ => throw new UnreachableException()
                },
                unexpandedExpression,
                expandedExpression,
                typeMapping: null)!;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static List<SqlExpression> SliceToList(IReadOnlyList<SqlExpression> source, int capacity, int count)
            {
                var list = new List<SqlExpression>(capacity);

                for (var i = 0; i < count; i++)
                {
                    list.Add(source[i]);
                }

                return list;
            }
        }
    }

    protected override SqlExpression VisitCustomSqlExpression(
        SqlExpression sqlExpression,
        bool allowOptimizedExpansion,
        out bool nullable)
        => sqlExpression switch
        {
            ClickHouseTrimExpression e => VisitTrim(e, allowOptimizedExpansion, out nullable),
            ClickHouseRowValueExpression e => VisitRowValueExpression(e, allowOptimizedExpansion, out nullable),

            _ => base.VisitCustomSqlExpression(sqlExpression, allowOptimizedExpansion, out nullable)
        };

    protected virtual SqlExpression VisitTrim(
        ClickHouseTrimExpression trimExpression,
        bool allowOptimizedExpansion,
        out bool nullable)
    {
        var inputString = Visit(trimExpression.InputString, out var inputStringNullable);
        var trimCharacters = Visit(trimExpression.TrimCharacters, out var trimCharactersNullable);
        nullable = inputStringNullable || trimCharactersNullable;

        SqlExpression updated = trimExpression.Update(inputString, trimCharacters);

        return updated;
    }

    protected virtual SqlExpression VisitRowValueExpression(
        ClickHouseRowValueExpression rowValueExpression,
        bool allowOptimizedExpansion,
        out bool nullable)
    {
        SqlExpression[] newValues = null;

        for (var i = 0; i < rowValueExpression.Values.Count; i++)
        {
            var value = rowValueExpression.Values[i];

            var newValue = Visit(value, allowOptimizedExpansion: false, out _);
            if (newValue != value && newValues is null)
            {
                newValues = new SqlExpression[rowValueExpression.Values.Count];
                for (var j = 0; j < i; j++)
                {
                    newValues[j] = rowValueExpression.Values[j];
                }
            }

            if (newValues is not null)
            {
                newValues[i] = newValue;
            }
        }

        nullable = false;

        return rowValueExpression.Update(newValues ?? rowValueExpression.Values);
    }
}
