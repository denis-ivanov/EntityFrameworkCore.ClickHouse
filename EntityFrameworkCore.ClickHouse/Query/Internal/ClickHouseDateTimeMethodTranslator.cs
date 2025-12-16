using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseDateTimeMethodTranslator : IMethodCallTranslator
{
    private static readonly Dictionary<MethodInfo, string> Methods = new()
    {
        { typeof(DateTime).GetRuntimeMethod(nameof(DateTime.AddYears), [typeof(int)])!, "addYears" },
        { typeof(DateTime).GetRuntimeMethod(nameof(DateTime.AddMonths), [typeof(int)])!, "addMonths" },
        { typeof(DateTime).GetRuntimeMethod(nameof(DateTime.AddDays), [typeof(double)])!, "addDays" },
        { typeof(DateTime).GetRuntimeMethod(nameof(DateTime.AddHours), [typeof(double)])!, "addHours" },
        { typeof(DateTime).GetRuntimeMethod(nameof(DateTime.AddMinutes), [typeof(double)])!, "addMinutes" },
        { typeof(DateTime).GetRuntimeMethod(nameof(DateTime.AddSeconds), [typeof(double)])!, "addSeconds" },
    };

    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseDateTimeMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }

    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (Methods.TryGetValue(method, out var function))
        {
            return _sqlExpressionFactory.Function(
                function,
                arguments.Prepend(instance),
                nullable: false,
                argumentsPropagateNullability: [false, false],
                returnType: method.ReturnType);
        }

        // TODO Add functional tests.
        return method.Name switch
        {
            nameof(ClickHouseDateTimeDbFunctionsExtensions.ToDateTime) when method.DeclaringType == typeof(ClickHouseDateTimeDbFunctionsExtensions)
                => arguments.Count == 2
                    ? _sqlExpressionFactory.ToDateTime(arguments[1])
                    : _sqlExpressionFactory.ToDateTime(arguments[1], arguments[2]),
            nameof(ClickHouseDateTimeDbFunctionsExtensions.ToDateTimeOrZero) when method.DeclaringType == typeof(ClickHouseDateTimeDbFunctionsExtensions)
                => _sqlExpressionFactory.ToDateTimeOrZero(arguments[1]),
            nameof(ClickHouseDateTimeDbFunctionsExtensions.ToDateTimeOrNull) when method.DeclaringType == typeof(ClickHouseDateTimeDbFunctionsExtensions)
                => _sqlExpressionFactory.ToDateTimeOrNull(arguments[1]),
            nameof(ClickHouseDateTimeDbFunctionsExtensions.ToDateTimeOrDefault) when method.DeclaringType == typeof(ClickHouseDateTimeDbFunctionsExtensions)
                => arguments.Count == 2
                    ? _sqlExpressionFactory.ToDateTimeOrDefault(arguments[1])
                    : _sqlExpressionFactory.ToDateTimeOrDefault(arguments[1], arguments[2]),
            _ => null
        };
    }
}
