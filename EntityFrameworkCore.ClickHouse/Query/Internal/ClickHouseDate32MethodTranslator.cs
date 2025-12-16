using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseDate32MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseDate32MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
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
            nameof(ClickHouseDate32DbFunctionsExtensions.ToDate32) when method.DeclaringType == typeof(ClickHouseDate32DbFunctionsExtensions)
                => _sqlExpressionFactory.ToDate32(arguments[1]),

            nameof(ClickHouseDate32DbFunctionsExtensions.ToDate32OrZero) when method.DeclaringType == typeof(ClickHouseDate32DbFunctionsExtensions)
                => _sqlExpressionFactory.ToDate32OrZero(arguments[1]),

            nameof(ClickHouseDate32DbFunctionsExtensions.ToDate32OrNull) when method.DeclaringType == typeof(ClickHouseDate32DbFunctionsExtensions)
                => _sqlExpressionFactory.ToDate32OrNull(arguments[1]),

            nameof(ClickHouseDateTimeDbFunctionsExtensions.ToDateTimeOrDefault) when method.DeclaringType == typeof(ClickHouseDate32DbFunctionsExtensions)
                => arguments.Count == 2
                    ? _sqlExpressionFactory.ToDate32OrDefault(arguments[1])
                    : _sqlExpressionFactory.ToDate32OrDefault(arguments[1], arguments[2]),

            _ => null
        };
    }
}
