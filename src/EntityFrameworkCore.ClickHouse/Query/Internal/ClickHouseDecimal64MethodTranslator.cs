using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseDecimal64MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseDecimal64MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseDecimal64DbFunctionsExtensions))
        {
            return null;
        }

        return method.Name switch
        {
            nameof(ClickHouseDecimal64DbFunctionsExtensions.ToDecimal64) => _sqlExpressionFactory.ToDecimal64(arguments[1], arguments[2]),
            nameof(ClickHouseDecimal64DbFunctionsExtensions.ToDecimal64OrZero) => _sqlExpressionFactory.ToDecimal64OrZero(arguments[1], arguments[2]),
            nameof(ClickHouseDecimal64DbFunctionsExtensions.ToDecimal64OrNull) => _sqlExpressionFactory.ToDecimal64OrNull(arguments[1], arguments[2]),
            nameof(ClickHouseDecimal64DbFunctionsExtensions.ToDecimal64OrDefault) => arguments.Count == 3
                ? _sqlExpressionFactory.ToDecimal64OrDefault(arguments[1], arguments[2])
                : _sqlExpressionFactory.ToDecimal64OrDefault(arguments[1], arguments[2], arguments[3]),
            _ => null
        };
    }
}
