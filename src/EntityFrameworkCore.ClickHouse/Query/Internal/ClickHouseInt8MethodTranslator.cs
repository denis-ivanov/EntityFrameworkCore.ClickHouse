using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseInt8MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseInt8MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseInt8DbFunctionsExtensions))
        {
            return null;
        }

        switch (method)
        {
            case { Name: nameof(ClickHouseInt8DbFunctionsExtensions.ToInt8) }:
                return _sqlExpressionFactory.ToInt8(arguments[1]);

            case { Name: nameof(ClickHouseInt8DbFunctionsExtensions.ToInt8OrZero) }:
                return _sqlExpressionFactory.ToInt8OrZero(arguments[1]);

            case { Name: nameof(ClickHouseInt8DbFunctionsExtensions.ToInt8OrNull) }:
                return _sqlExpressionFactory.ToInt8OrNull(arguments[1]);

            case { Name: nameof(ClickHouseInt8DbFunctionsExtensions.ToInt8OrDefault) }:
                return arguments.Count == 2
                    ? _sqlExpressionFactory.ToInt8OrDefault(arguments[1])
                    : _sqlExpressionFactory.ToInt8OrDefault(arguments[1], arguments[2]);

            default:
                return null;
        }
    }
}
