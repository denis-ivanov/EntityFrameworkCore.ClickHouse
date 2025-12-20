using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseInt16MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseInt16MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseInt16DbFunctionsExtensions))
        {
            return null;
        }

        switch (method)
        {
            case { Name: nameof(ClickHouseInt16DbFunctionsExtensions.ToInt16) }:
                return _sqlExpressionFactory.ToInt16(arguments[1]);
            
            case { Name: nameof(ClickHouseInt16DbFunctionsExtensions.ToInt16OrZero) }:
                return _sqlExpressionFactory.ToInt16OrZero(arguments[1]);
            
            case { Name: nameof(ClickHouseInt16DbFunctionsExtensions.ToInt16OrNull) }:
                return _sqlExpressionFactory.ToInt16OrNull(arguments[1]);
            
            case { Name: nameof(ClickHouseInt16DbFunctionsExtensions.ToInt16OrDefault) }:
                return arguments.Count == 2
                    ? _sqlExpressionFactory.ToInt16OrDefault(arguments[1])
                    : _sqlExpressionFactory.ToInt16OrDefault(arguments[1], arguments[2]);
            
            default:
                return null;
        }
    }
}
