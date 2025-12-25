using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseDecimal256MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseDecimal256MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }

    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseDecimal256DbFunctionsExtensions))
        {
            return null;
        }

        return method.Name switch
        {
            nameof(ClickHouseDecimal256DbFunctionsExtensions.ToDecimal256) => _sqlExpressionFactory.ToDecimal256(arguments[1], arguments[2]),
            nameof(ClickHouseDecimal256DbFunctionsExtensions.ToDecimal256OrZero) => _sqlExpressionFactory.ToDecimal256OrZero(arguments[1], arguments[2]),
            nameof(ClickHouseDecimal256DbFunctionsExtensions.ToDecimal256OrNull) => _sqlExpressionFactory.ToDecimal256OrNull(arguments[1], arguments[2]),
            nameof(ClickHouseDecimal256DbFunctionsExtensions.ToDecimal256OrDefault) => arguments.Count == 3
                ? _sqlExpressionFactory.ToDecimal256OrDefault(arguments[1], arguments[2])
                : _sqlExpressionFactory.ToDecimal256OrDefault(arguments[1], arguments[2], arguments[3]),
            nameof(ClickHouseDecimal256DbFunctionsExtensions.DivideDecimal) => 
                arguments.Count == 3
                    ? _sqlExpressionFactory.DivideDecimal(arguments[1], arguments[2])
                    : _sqlExpressionFactory.DivideDecimal(arguments[1], arguments[2], arguments[3]),
            _ => null
        };
    }
}
