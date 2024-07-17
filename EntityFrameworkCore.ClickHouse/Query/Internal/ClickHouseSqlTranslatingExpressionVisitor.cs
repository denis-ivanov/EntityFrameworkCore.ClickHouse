using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseSqlTranslatingExpressionVisitor : RelationalSqlTranslatingExpressionVisitor
{
    private static readonly Dictionary<string, string> DateDiffUnits = new()
    {
        [nameof(TimeSpan.TotalDays)] = "days",
        [nameof(TimeSpan.TotalHours)] = "hours",
        [nameof(TimeSpan.TotalMicroseconds)] = "microseconds",
        [nameof(TimeSpan.TotalMilliseconds)] = "milliseconds",
        [nameof(TimeSpan.TotalMinutes)] = "minutes",
        [nameof(TimeSpan.TotalNanoseconds)] = "nanoseconds",
        [nameof(TimeSpan.TotalSeconds)] = "seconds"
    };

    public ClickHouseSqlTranslatingExpressionVisitor(RelationalSqlTranslatingExpressionVisitorDependencies dependencies, QueryCompilationContext queryCompilationContext, QueryableMethodTranslatingExpressionVisitor queryableMethodTranslatingExpressionVisitor) : base(dependencies, queryCompilationContext, queryableMethodTranslatingExpressionVisitor)
    {
    }

    public override SqlExpression TranslateCount(SqlExpression sqlExpression)
    {
        return Dependencies.SqlExpressionFactory.Convert(
            Dependencies.SqlExpressionFactory.ApplyDefaultTypeMapping(
                Dependencies.SqlExpressionFactory.Function(
                    "COUNT",
                    new [] { sqlExpression },
                    false,
                    new[] { false },
                    typeof(long)
                )
            ),
            typeof(int),
            Dependencies.TypeMappingSource.FindMapping(typeof(int))
        );
    }

    public override SqlExpression TranslateLongCount(SqlExpression sqlExpression)
    {
        return Dependencies.SqlExpressionFactory.Convert(
            Dependencies.SqlExpressionFactory.ApplyDefaultTypeMapping(
                Dependencies.SqlExpressionFactory.Function(
                    "COUNT",
                    new [] { sqlExpression },
                    false,
                    new[] { false },
                    typeof(ulong)
                )
            ),
            typeof(int),
            Dependencies.TypeMappingSource.FindMapping(typeof(int))
        );
    }

    public override SqlExpression TranslateSum(SqlExpression sqlExpression)
    {
        return Dependencies.SqlExpressionFactory.Convert(
            Dependencies.SqlExpressionFactory.ApplyDefaultTypeMapping(
                Dependencies.SqlExpressionFactory.Function(
                    "SUM",
                    new [] { sqlExpression },
                    false,
                    new[] { false },
                    typeof(long)
                )
            ),
            typeof(int),
            Dependencies.TypeMappingSource.FindMapping(typeof(int))
        );
    }

    protected override Expression VisitMember(MemberExpression memberExpression)
    {
        if (IsDateDiffExpression(memberExpression, out var left, out var right, out var unit))
        {
            return Dependencies.SqlExpressionFactory.Convert(
                Dependencies.SqlExpressionFactory.Function(
                    "dateDiff",
                    [
                        Dependencies.SqlExpressionFactory.Constant(unit),
                        Translate(right),
                        Translate(left)
                    ],
                    false,
                    [false, false, false],
                    typeof(int)),
                typeof(double));
        }

        return base.VisitMember(memberExpression);
    }

    private static bool IsDateDiffExpression(MemberExpression memberExpression, out Expression left, out Expression right, out string unit)
    {
        left = null;
        right = null;
        unit = null;

        if (memberExpression.Expression is BinaryExpression binaryExpression)
        {
            left = binaryExpression.Left;
            right = binaryExpression.Right;

            return IsDate(left) &&
                   IsDate(right) &&
                   binaryExpression.NodeType == ExpressionType.Subtract &&
                   DateDiffUnits.TryGetValue(memberExpression.Member.Name, out unit);
        }

        return false;
    }

    private static bool IsDate(Expression expression)
    {
        var type = expression.Type;
        return type == typeof(DateOnly) ||
               type == typeof(DateTime) ||
               type == typeof(DateTimeOffset);
    }
}
