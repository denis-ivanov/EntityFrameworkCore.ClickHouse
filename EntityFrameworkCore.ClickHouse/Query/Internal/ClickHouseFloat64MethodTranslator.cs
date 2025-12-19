using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseFloat64MethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseFloat64MethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }

    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseFloat64DbFunctionsExtensions))
        {
            return null;
        }

        switch (method.Name)
        {
            case nameof(ClickHouseFloat64DbFunctionsExtensions.ToFloat64):
                return _sqlExpressionFactory.ToFloat64(arguments[1]);

            case nameof(ClickHouseFloat64DbFunctionsExtensions.ToFloat64OrZero):
                return _sqlExpressionFactory.ToFloat64OrZero(arguments[1]);

            case nameof(ClickHouseFloat64DbFunctionsExtensions.ToFloat64OrNull):
                return _sqlExpressionFactory.ToFloat64OrNull(arguments[1]);

            case nameof(ClickHouseFloat64DbFunctionsExtensions.ToFloat64OrDefault):
                return arguments.Count == 2
                    ? _sqlExpressionFactory.ToFloat64OrDefault(arguments[1])
                    : _sqlExpressionFactory.ToFloat64OrDefault(arguments[1], arguments[2]);

            default:
                return null;
        }
    }
}
