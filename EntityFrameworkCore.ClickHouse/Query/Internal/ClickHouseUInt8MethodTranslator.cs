using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseUInt8MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseUInt8MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseUInt8DbFunctionsExtensions))
        {
            return null;
        }

        switch (method)
        {
            case { Name: nameof(ClickHouseUInt8DbFunctionsExtensions.ToUInt8) }:
                return _sqlExpressionFactory.ToUInt8(arguments[1]);

            case { Name: nameof(ClickHouseUInt8DbFunctionsExtensions.ToUInt8OrZero) }:
                return _sqlExpressionFactory.ToUInt8OrZero(arguments[1]);

            case { Name: nameof(ClickHouseUInt8DbFunctionsExtensions.ToUInt8OrNull) }:
                return _sqlExpressionFactory.ToUInt8OrNull(arguments[1]);

            case { Name: nameof(ClickHouseUInt8DbFunctionsExtensions.ToUInt8OrDefault) }:
                return arguments.Count == 2
                    ? _sqlExpressionFactory.ToUInt8OrDefault(arguments[1])
                    : _sqlExpressionFactory.ToUInt8OrDefault(arguments[1], arguments[2]);

            default:
                return null;
        }
    }
}
