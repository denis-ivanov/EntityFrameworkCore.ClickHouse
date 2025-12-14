using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseDecimalMethodTranslator : IMethodCallTranslator
{
    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseDecimalMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }

    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseDecimalDbFunctionsExtensions))
        {
            return null;
        }

        switch (method)
        {
            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal32) }:
                return _sqlExpressionFactory.ToDecimal32(arguments[1], arguments[2]);

            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal32OrZero) }:
                return _sqlExpressionFactory.ToDecimal32OrZero(arguments[1], arguments[2]);

            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal32OrNull) }:
                return _sqlExpressionFactory.ToDecimal32OrNull(arguments[1], arguments[2]);

            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal32OrDefault) }:
                return arguments.Count == 3
                    ? _sqlExpressionFactory.ToDecimal32OrDefault(arguments[1], arguments[2])
                    : _sqlExpressionFactory.ToDecimal32OrDefault(arguments[1], arguments[2], arguments[3]);

            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal64) }:
                return _sqlExpressionFactory.ToDecimal64(arguments[1], arguments[2]);

            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal64OrZero) }:
                return _sqlExpressionFactory.ToDecimal64OrZero(arguments[1], arguments[2]);

            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal64OrNull) }:
                return _sqlExpressionFactory.ToDecimal64OrNull(arguments[1], arguments[2]);

            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal64OrDefault) }:
                return arguments.Count == 3
                    ? _sqlExpressionFactory.ToDecimal64OrDefault(arguments[1], arguments[2])
                    : _sqlExpressionFactory.ToDecimal64OrDefault(arguments[1], arguments[2], arguments[3]);
            
            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal128) }:
                return _sqlExpressionFactory.ToDecimal128(arguments[1], arguments[2]);

            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal128OrZero) }:
                return _sqlExpressionFactory.ToDecimal128OrZero(arguments[1], arguments[2]);

            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal128OrNull) }:
                return _sqlExpressionFactory.ToDecimal128OrNull(arguments[1], arguments[2]);

            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal128OrDefault) }:
                return arguments.Count == 3
                    ? _sqlExpressionFactory.ToDecimal128OrDefault(arguments[1], arguments[2])
                    : _sqlExpressionFactory.ToDecimal128OrDefault(arguments[1], arguments[2], arguments[3]);
            
            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal256) }:
                return _sqlExpressionFactory.ToDecimal256(arguments[1], arguments[2]);

            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal256OrZero) }:
                return _sqlExpressionFactory.ToDecimal256OrZero(arguments[1], arguments[2]);

            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal256OrNull) }:
                return _sqlExpressionFactory.ToDecimal256OrNull(arguments[1], arguments[2]);

            case { Name: nameof(ClickHouseDecimalDbFunctionsExtensions.ToDecimal256OrDefault) }:
                return arguments.Count == 3
                    ? _sqlExpressionFactory.ToDecimal256OrDefault(arguments[1], arguments[2])
                    : _sqlExpressionFactory.ToDecimal256OrDefault(arguments[1], arguments[2], arguments[3]);
        }

        return null;
    }
}
