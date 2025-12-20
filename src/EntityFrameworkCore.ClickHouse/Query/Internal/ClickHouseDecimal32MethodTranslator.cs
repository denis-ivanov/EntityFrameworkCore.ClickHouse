using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseDecimal32MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseDecimal32MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseDecimal32DbFunctionsExtensions))
        {
            return null;
        }

        return method.Name switch
        {
            nameof(ClickHouseDecimal32DbFunctionsExtensions.ToDecimal32) => _sqlExpressionFactory.ToDecimal32(arguments[1], arguments[2]),
            nameof(ClickHouseDecimal32DbFunctionsExtensions.ToDecimal32OrZero) => _sqlExpressionFactory.ToDecimal32OrZero(arguments[1], arguments[2]),
            nameof(ClickHouseDecimal32DbFunctionsExtensions.ToDecimal32OrNull) => _sqlExpressionFactory.ToDecimal32OrNull(arguments[1], arguments[2]),
            nameof(ClickHouseDecimal32DbFunctionsExtensions.ToDecimal32OrDefault) => arguments.Count == 3
                ? _sqlExpressionFactory.ToDecimal32OrDefault(arguments[1], arguments[2])
                : _sqlExpressionFactory.ToDecimal32OrDefault(arguments[1], arguments[2], arguments[3]),
            _ => null
        };
    }
}
