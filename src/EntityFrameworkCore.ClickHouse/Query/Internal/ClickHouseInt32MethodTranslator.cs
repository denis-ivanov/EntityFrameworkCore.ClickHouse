using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseInt32MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseInt32MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseInt32DbFunctionsExtensions))
        {
            return null;
        }

        switch (method)
        {
            case { Name: nameof(ClickHouseInt32DbFunctionsExtensions.ToInt32) }:
                return _sqlExpressionFactory.ToInt32(arguments[1]);
            
            case { Name: nameof(ClickHouseInt32DbFunctionsExtensions.ToInt32OrZero) }:
                return _sqlExpressionFactory.ToInt32OrZero(arguments[1]);
            
            case { Name: nameof(ClickHouseInt32DbFunctionsExtensions.ToInt32OrNull) }:
                return _sqlExpressionFactory.ToInt32OrNull(arguments[1]);
            
            case { Name: nameof(ClickHouseInt32DbFunctionsExtensions.ToInt32OrDefault) }:
                return arguments.Count == 2
                    ? _sqlExpressionFactory.ToInt32OrDefault(arguments[1])
                    : _sqlExpressionFactory.ToInt32OrDefault(arguments[1], arguments[2]);
            
            default:
                return null;
        }
    }
}
