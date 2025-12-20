using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseUInt32MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseUInt32MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseUInt32DbFunctionsExtensions))
        {
            return null;
        }

        switch (method)
        {
            case { Name: nameof(ClickHouseUInt32DbFunctionsExtensions.ToUInt32) }:
                return _sqlExpressionFactory.ToUInt32(arguments[1]);

            case { Name: nameof(ClickHouseUInt32DbFunctionsExtensions.ToUInt32OrZero) }:
                return _sqlExpressionFactory.ToUInt32OrZero(arguments[1]);

            case { Name: nameof(ClickHouseUInt32DbFunctionsExtensions.ToUInt32OrNull) }:
                return _sqlExpressionFactory.ToUInt32OrNull(arguments[1]);

            case { Name: nameof(ClickHouseUInt32DbFunctionsExtensions.ToUInt32OrDefault) }:
                return arguments.Count == 2
                    ? _sqlExpressionFactory.ToUInt32OrDefault(arguments[1])
                    : _sqlExpressionFactory.ToUInt32OrDefault(arguments[1], arguments[2]);

            default:
                return null;
        }
    }
}
