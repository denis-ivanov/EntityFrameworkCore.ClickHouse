using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseFloat32MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseFloat32MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseFloat32DbFunctionsExtensions))
        {
            return null;
        }

        switch (method)
        {
            case { Name: nameof(ClickHouseFloat32DbFunctionsExtensions.ToFloat32) }:
                return _sqlExpressionFactory.ToFloat32(arguments[1]);
            
            case { Name: nameof(ClickHouseFloat32DbFunctionsExtensions.ToFloat32OrZero) }:
                return _sqlExpressionFactory.ToFloat32OrZero(arguments[1]);
            
            case { Name: nameof(ClickHouseFloat32DbFunctionsExtensions.ToFloat32OrNull) }:
                return _sqlExpressionFactory.ToFloat32OrNull(arguments[1]);
            
            case { Name: nameof(ClickHouseFloat32DbFunctionsExtensions.ToFloat32OrDefault) }:
                return arguments.Count == 2
                    ? _sqlExpressionFactory.ToFloat32OrDefault(arguments[1])
                    : _sqlExpressionFactory.ToFloat32OrDefault(arguments[1], arguments[2]);
            
            default:
                return null;
        }
    }
}
