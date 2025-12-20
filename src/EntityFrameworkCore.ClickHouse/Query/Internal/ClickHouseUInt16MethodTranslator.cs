using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseUInt16MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseUInt16MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }
    
    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseUInt16DbFunctionsExtensions))
        {
            return null;
        }

        switch (method)
        {
            case { Name: nameof(ClickHouseUInt16DbFunctionsExtensions.ToUInt16) }:
                return _sqlExpressionFactory.ToUInt16(arguments[1]);

            case { Name: nameof(ClickHouseUInt16DbFunctionsExtensions.ToUInt16OrZero) }:
                return _sqlExpressionFactory.ToUInt16OrZero(arguments[1]);

            case { Name: nameof(ClickHouseUInt16DbFunctionsExtensions.ToUInt16OrNull) }:
                return _sqlExpressionFactory.ToUInt16OrNull(arguments[1]);

            case { Name: nameof(ClickHouseUInt16DbFunctionsExtensions.ToUInt16OrDefault) }:
                return arguments.Count == 2
                    ? _sqlExpressionFactory.ToUInt16OrDefault(arguments[1])
                    : _sqlExpressionFactory.ToUInt16OrDefault(arguments[1], arguments[2]);

            default:
                return null;
        }
    }
}
