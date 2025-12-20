using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseInt128MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseInt128MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseInt128DbFunctionsExtensions))
        {
            return null;
        }

        switch (method)
        {
            case { Name: nameof(ClickHouseInt128DbFunctionsExtensions.ToInt128) }:
                return _sqlExpressionFactory.ToInt128(arguments[1]);
            
            case { Name: nameof(ClickHouseInt128DbFunctionsExtensions.ToInt128OrZero) }:
                return _sqlExpressionFactory.ToInt128OrZero(arguments[1]);
            
            case { Name: nameof(ClickHouseInt128DbFunctionsExtensions.ToInt128OrNull) }:
                return _sqlExpressionFactory.ToInt128OrNull(arguments[1]);
            
            case { Name: nameof(ClickHouseInt128DbFunctionsExtensions.ToInt128OrDefault) }:
                return arguments.Count == 2
                    ? _sqlExpressionFactory.ToInt128OrDefault(arguments[1])
                    : _sqlExpressionFactory.ToInt128OrDefault(arguments[1], arguments[2]);
            
            default:
                return null;
        }
    }
}
