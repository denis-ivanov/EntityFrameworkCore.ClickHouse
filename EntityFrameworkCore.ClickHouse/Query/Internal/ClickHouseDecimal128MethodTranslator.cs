using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseDecimal128MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseDecimal128MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseDecimal128DbFunctionsExtensions))
        {
            return null;
        }

        return method.Name switch
        {
            nameof(ClickHouseDecimal128DbFunctionsExtensions.ToDecimal128) => _sqlExpressionFactory.ToDecimal128(arguments[1], arguments[2]),
            nameof(ClickHouseDecimal128DbFunctionsExtensions.ToDecimal128OrZero) => _sqlExpressionFactory.ToDecimal128OrZero(arguments[1], arguments[2]),
            nameof(ClickHouseDecimal128DbFunctionsExtensions.ToDecimal128OrNull) => _sqlExpressionFactory.ToDecimal128OrNull(arguments[1], arguments[2]),
            nameof(ClickHouseDecimal128DbFunctionsExtensions.ToDecimal128OrDefault) => arguments.Count == 3
                ? _sqlExpressionFactory.ToDecimal128OrDefault(arguments[1], arguments[2])
                : _sqlExpressionFactory.ToDecimal128OrDefault(arguments[1], arguments[2], arguments[3]),
            _ => null
        };
    }
}
