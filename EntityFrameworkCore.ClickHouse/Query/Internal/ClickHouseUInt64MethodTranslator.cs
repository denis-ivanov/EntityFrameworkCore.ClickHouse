using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseUInt64MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseUInt64MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseUInt64DbFunctionsExtensions))
        {
            return null;
        }

        switch (method)
        {
            case { Name: nameof(ClickHouseUInt64DbFunctionsExtensions.ToUInt64) }:
                return _sqlExpressionFactory.ToUInt64(arguments[1]);

            case { Name: nameof(ClickHouseUInt64DbFunctionsExtensions.ToUInt64OrZero) }:
                return _sqlExpressionFactory.ToUInt64OrZero(arguments[1]);

            case { Name: nameof(ClickHouseUInt64DbFunctionsExtensions.ToUInt64OrNull) }:
                return _sqlExpressionFactory.ToUInt64OrNull(arguments[1]);

            case { Name: nameof(ClickHouseUInt64DbFunctionsExtensions.ToUInt64OrDefault) }:
                return arguments.Count == 2
                    ? _sqlExpressionFactory.ToUInt64OrDefault(arguments[1])
                    : _sqlExpressionFactory.ToUInt64OrDefault(arguments[1], arguments[2]);

            default:
                return null;
        }
    }
}
