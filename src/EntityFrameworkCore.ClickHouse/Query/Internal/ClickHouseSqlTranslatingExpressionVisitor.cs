using ClickHouse.EntityFrameworkCore.Query.Expressions.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

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

    public override SqlExpression GenerateLeast(IReadOnlyList<SqlExpression> expressions, Type resultType)
    {
        var resultTypeMapping = ExpressionExtensions.InferTypeMapping(expressions);

        return Dependencies.SqlExpressionFactory.Function("least", expressions, nullable: true, Enumerable.Repeat(true, expressions.Count), resultType, resultTypeMapping);
    }

    public override SqlExpression GenerateGreatest(IReadOnlyList<SqlExpression> expressions, Type resultType)
    {
        var resultTypeMapping = ExpressionExtensions.InferTypeMapping(expressions);

        return Dependencies.SqlExpressionFactory.Function("greatest", expressions, nullable: true, Enumerable.Repeat(true, expressions.Count), resultType, resultTypeMapping);
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

    protected override Expression VisitNew(NewExpression newExpression)
    {
        var visitedNewExpression = base.VisitNew(newExpression);

        if (visitedNewExpression != QueryCompilationContext.NotTranslatedExpression)
        {
            return visitedNewExpression;
        }

        if (newExpression.Type.IsAssignableTo(typeof(ITuple)))
        {
            return TryTranslateArguments(out var sqlArguments)
                ? new ClickHouseRowValueExpression(sqlArguments, newExpression.Type)
                : QueryCompilationContext.NotTranslatedExpression;
        }
        
        return QueryCompilationContext.NotTranslatedExpression;
        
        bool TryTranslateArguments(out SqlExpression[] sqlArguments)
        {
            sqlArguments = new SqlExpression[newExpression.Arguments.Count];
            for (var i = 0; i < sqlArguments.Length; i++)
            {
                var argument = newExpression.Arguments[i];
                if (TranslationFailed(argument, Visit(argument), out var sqlArgument))
                {
                    return false;
                }

                sqlArguments[i] = sqlArgument!;
            }

            return true;
        }
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
    
    [DebuggerStepThrough]
    private static bool TranslationFailed(Expression original, Expression translation, out SqlExpression castTranslation)
    {
        if (original is not null && !(translation is SqlExpression))
        {
            castTranslation = null;
            return true;
        }

        castTranslation = translation as SqlExpression;
        return false;
    }
}
