using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseInt64MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseInt64MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseInt64DbFunctionsExtensions))
        {
            return null;
        }

        switch (method)
        {
            case { Name: nameof(ClickHouseInt64DbFunctionsExtensions.ToInt64) }:
                return _sqlExpressionFactory.ToInt64(arguments[1]);
            
            case { Name: nameof(ClickHouseInt64DbFunctionsExtensions.ToInt64OrZero) }:
                return _sqlExpressionFactory.ToInt64OrZero(arguments[1]);
            
            case { Name: nameof(ClickHouseInt64DbFunctionsExtensions.ToInt64OrNull) }:
                return _sqlExpressionFactory.ToInt64OrNull(arguments[1]);
            
            case { Name: nameof(ClickHouseInt64DbFunctionsExtensions.ToInt64OrDefault) }:
                return arguments.Count == 2
                    ? _sqlExpressionFactory.ToInt64OrDefault(arguments[1])
                    : _sqlExpressionFactory.ToInt64OrDefault(arguments[1], arguments[2]);
            
            default:
                return null;
        }
    }
}
