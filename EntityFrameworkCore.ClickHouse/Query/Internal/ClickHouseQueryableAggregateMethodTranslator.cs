using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseQueryableAggregateMethodTranslator : IAggregateMethodCallTranslator
{
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseQueryableAggregateMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression Translate(
        MethodInfo method,
        EnumerableExpression source,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType == typeof(Queryable))
        {
            var methodInfo = method.IsGenericMethod
                ? method.GetGenericMethodDefinition()
                : method;
            switch (methodInfo.Name)
            {
                case nameof(Queryable.Average)
                    when (QueryableMethods.IsAverageWithoutSelector(methodInfo)
                        || QueryableMethods.IsAverageWithSelector(methodInfo))
                    && source.Selector is SqlExpression averageSqlExpression:
                    var averageInputType = averageSqlExpression.Type;
                    if (averageInputType == typeof(int)
                        || averageInputType == typeof(long))
                    {
                        averageSqlExpression = _sqlExpressionFactory.ApplyDefaultTypeMapping(
                            _sqlExpressionFactory.Convert(averageSqlExpression, typeof(double)));
                    }

                    averageSqlExpression = CombineTerms(source, averageSqlExpression);

                    return _sqlExpressionFactory.Convert(
                            _sqlExpressionFactory.Function(
                                "AVG",
                                new[] { averageSqlExpression },
                                nullable: true,
                                argumentsPropagateNullability: new[] { false },
                                typeof(double)),
                            averageSqlExpression.Type,
                            averageSqlExpression.TypeMapping);

                case nameof(Queryable.Count)
                    when methodInfo == QueryableMethods.CountWithoutPredicate
                    || methodInfo == QueryableMethods.CountWithPredicate:
                    var countSqlExpression = (source.Selector as SqlExpression) ?? _sqlExpressionFactory.Fragment("*");
                    countSqlExpression = CombineTerms(source, countSqlExpression);
                    return _sqlExpressionFactory.Convert(
                        _sqlExpressionFactory.Function(
                            "COUNT",
                            new[] { countSqlExpression },
                            nullable: false,
                            argumentsPropagateNullability: new[] { false },
                            typeof(int)),
                        typeof(int));

                case nameof(Queryable.LongCount)
                    when methodInfo == QueryableMethods.LongCountWithoutPredicate
                    || methodInfo == QueryableMethods.LongCountWithPredicate:
                    var longCountSqlExpression = (source.Selector as SqlExpression) ?? _sqlExpressionFactory.Fragment("*");
                    longCountSqlExpression = CombineTerms(source, longCountSqlExpression);
                    var longCountFunction = _sqlExpressionFactory.Function(
                        "COUNT",
                        new[] { longCountSqlExpression },
                        nullable: false,
                        argumentsPropagateNullability: new[] { false },
                        typeof(long));

                    return _sqlExpressionFactory.Convert(
                        longCountFunction,
                        longCountSqlExpression.Type,
                        longCountSqlExpression.TypeMapping);

                case nameof(Queryable.Max)
                    when (methodInfo == QueryableMethods.MaxWithoutSelector
                        || methodInfo == QueryableMethods.MaxWithSelector)
                    && source.Selector is SqlExpression maxSqlExpression:
                    maxSqlExpression = CombineTerms(source, maxSqlExpression);
                    var maxFunction = _sqlExpressionFactory.Function(
                        "MAX",
                        new[] { maxSqlExpression },
                        nullable: true,
                        argumentsPropagateNullability: new[] { false },
                        maxSqlExpression.Type,
                        maxSqlExpression.TypeMapping);

                    return _sqlExpressionFactory.Convert(
                        maxFunction,
                        maxSqlExpression.Type,
                        maxSqlExpression.TypeMapping);

                case nameof(Queryable.Min)
                    when (methodInfo == QueryableMethods.MinWithoutSelector
                        || methodInfo == QueryableMethods.MinWithSelector)
                    && source.Selector is SqlExpression minSqlExpression:
                    minSqlExpression = CombineTerms(source, minSqlExpression);

                    var minFunction = _sqlExpressionFactory.Function(
                        "MIN",
                        new[] { minSqlExpression },
                        nullable: true,
                        argumentsPropagateNullability: new[] { false },
                        minSqlExpression.Type,
                        minSqlExpression.TypeMapping);

                    return _sqlExpressionFactory.Convert(
                        minFunction,
                        minSqlExpression.Type,
                        minSqlExpression.TypeMapping);

                case nameof(Queryable.Sum)
                    when (QueryableMethods.IsSumWithoutSelector(methodInfo)
                        || QueryableMethods.IsSumWithSelector(methodInfo))
                    && source.Selector is SqlExpression sumSqlExpression:
                    sumSqlExpression = CombineTerms(source, sumSqlExpression);
                    var sumInputType = sumSqlExpression.Type;
                    return _sqlExpressionFactory.Convert(
                            _sqlExpressionFactory.Function(
                                "SUM",
                                new[] { sumSqlExpression },
                                nullable: true,
                                argumentsPropagateNullability: new[] { false },
                                sumInputType,
                                sumSqlExpression.TypeMapping),
                            sumInputType,
                            sumSqlExpression.TypeMapping);
            }
        }

        return null;
    }

    private SqlExpression CombineTerms(EnumerableExpression enumerableExpression, SqlExpression sqlExpression)
    {
        if (enumerableExpression.Predicate != null)
        {
            if (sqlExpression is SqlFragmentExpression)
            {
                sqlExpression = _sqlExpressionFactory.Constant(1);
            }

            sqlExpression = _sqlExpressionFactory.Case(
                new List<CaseWhenClause> { new(enumerableExpression.Predicate, sqlExpression) },
                elseResult: null);
        }

        if (enumerableExpression.IsDistinct)
        {
            sqlExpression = new DistinctExpression(sqlExpression);
        }

        return sqlExpression;
    }
}
