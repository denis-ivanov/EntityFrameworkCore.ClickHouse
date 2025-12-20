using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseUInt128MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseUInt128MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseUInt128DbFunctionsExtensions))
        {
            return null;
        }

        switch (method)
        {
            case { Name: nameof(ClickHouseUInt128DbFunctionsExtensions.ToUInt128) }:
                return _sqlExpressionFactory.ToUInt128(arguments[1]);

            case { Name: nameof(ClickHouseUInt128DbFunctionsExtensions.ToUInt128OrZero) }:
                return _sqlExpressionFactory.ToUInt128OrZero(arguments[1]);

            case { Name: nameof(ClickHouseUInt128DbFunctionsExtensions.ToUInt128OrNull) }:
                return _sqlExpressionFactory.ToUInt128OrNull(arguments[1]);

            case { Name: nameof(ClickHouseUInt128DbFunctionsExtensions.ToUInt128OrDefault) }:
                return arguments.Count == 2
                    ? _sqlExpressionFactory.ToUInt128OrDefault(arguments[1])
                    : _sqlExpressionFactory.ToUInt128OrDefault(arguments[1], arguments[2]);

            default:
                return null;
        }
    }
}
