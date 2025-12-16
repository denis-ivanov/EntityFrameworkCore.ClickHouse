using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseDateOnlyMethodTranslator : IMethodCallTranslator
{
    private static readonly Type DateFunctions = typeof(ClickHouseDateDbFunctionsExtensions);

    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseDateOnlyMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }

    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        return method.Name switch
        {
            nameof(DateOnly.FromDateTime) when method.DeclaringType == typeof(DateOnly) => _sqlExpressionFactory.ToDate(arguments[0]),
            nameof(ClickHouseDateDbFunctionsExtensions.ToDate) when method.DeclaringType == DateFunctions
                => arguments.Count == 2
                    ? _sqlExpressionFactory.ToDate(arguments[1])
                    : _sqlExpressionFactory.ToDate(arguments[1], arguments[2]),
            nameof(ClickHouseDateDbFunctionsExtensions.ToDateOrZero) when method.DeclaringType == DateFunctions
                => _sqlExpressionFactory.ToDateOrZero(arguments[1]),
            nameof(ClickHouseDateDbFunctionsExtensions.ToDateOrNull) when method.DeclaringType == DateFunctions
                => _sqlExpressionFactory.ToDateOrNull(arguments[1]),
            nameof(ClickHouseDateDbFunctionsExtensions.ToDateOrDefault) when method.DeclaringType == DateFunctions
                => arguments.Count == 2
                    ? _sqlExpressionFactory.ToDateOrDefault(arguments[1])
                    : _sqlExpressionFactory.ToDateOrDefault(arguments[1], arguments[2]),
            _ => null
        };
    }
}
