using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    [sqlExpression],
                    false,
                    [false],
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
                    [sqlExpression],
                    false,
                    [false],
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
                    [sqlExpression],
                    false,
                    [false],
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

    protected override Expression VisitMethodCall(MethodCallExpression methodCallExpression)
    {
        if (IsAnyTrim(methodCallExpression, out var trimMode))
        {
            var methodArgs = methodCallExpression.Arguments;
            SqlExpression trimArg = null;

            if (methodArgs[0].Type == typeof(char))
            {
                trimArg = Translate(methodArgs[0]);
            }
            else if (methodArgs[0] is NewArrayExpression newArrayExpression)
            {
                trimArg = Dependencies.SqlExpressionFactory.Function(
                    "concat",
                    newArrayExpression.Expressions.Select(e => Translate(e)),
                    true,
                    Enumerable.Repeat(true, methodArgs.Count),
                    typeof(string),
                    Dependencies.TypeMappingSource.FindMapping(typeof(string)));
            }
            else
            {
                trimArg = Dependencies.SqlExpressionFactory.Function(
                    "arrayStringConcat",
                    [Translate(methodArgs[0])],
                    true,
                    [true],
                    typeof(string),
                    Dependencies.TypeMappingSource.FindMapping(typeof(string)));
            }

            var trimInstance = Translate(methodCallExpression.Object);

            var trimMapping = Dependencies.TypeMappingSource.FindMapping(methodCallExpression.Method.DeclaringType);

            return new ClickHouseTrimFunction([trimArg, trimInstance], trimMapping, trimMode);
        }

        return base.VisitMethodCall(methodCallExpression);
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

    private static bool IsAnyTrim(MethodCallExpression methodCallExpression, out byte mode)
    {
        mode = byte.MaxValue;

        if (methodCallExpression.Method.DeclaringType != typeof(string))
        {
            return false;
        }

        if (methodCallExpression.Method.Name == nameof(string.TrimStart) &&
            methodCallExpression.Arguments.Count > 0)
        {
            mode = ClickHouseTrimFunction.Leading;
            return true;
        }

        if (methodCallExpression.Method.Name == nameof(string.TrimEnd) &&
            methodCallExpression.Arguments.Count > 0)
        {
            mode = ClickHouseTrimFunction.Trailing;
            return true;
        }

        if (methodCallExpression.Method.Name == nameof(string.Trim) &&
            methodCallExpression.Arguments.Count > 0)
        {
            mode = ClickHouseTrimFunction.Both;
            return true;
        }

        return false;
    }
}
