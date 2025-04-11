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

    protected override Expression VisitBinary(BinaryExpression binaryExpression)
    {
        if (binaryExpression.NodeType == ExpressionType.Add &&
            binaryExpression.Type == typeof(string))
        {
            return Dependencies.SqlExpressionFactory.Function(
                name: "concat",
                arguments: [Translate(binaryExpression.Left), Translate(binaryExpression.Right)],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(string),
                typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(string)));
        }

        return base.VisitBinary(binaryExpression);
    }

    public override SqlExpression GenerateGreatest(IReadOnlyList<SqlExpression> expressions, Type resultType)
    {
        var resultTypeMapping = ExpressionExtensions.InferTypeMapping(expressions);

        return Dependencies.SqlExpressionFactory.Function("greatest", expressions, nullable: true, Enumerable.Repeat(true, expressions.Count), resultType, resultTypeMapping);
    }

    public override SqlExpression GenerateLeast(IReadOnlyList<SqlExpression> expressions, Type resultType)
    {
        var resultTypeMapping = ExpressionExtensions.InferTypeMapping(expressions);

        return Dependencies.SqlExpressionFactory.Function("least", expressions, nullable: true, Enumerable.Repeat(true, expressions.Count), resultType, resultTypeMapping);
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