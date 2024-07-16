using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseDateTimeMemberTranslator : IMemberTranslator
{
    private static readonly Dictionary<MemberInfo, Tuple<string, bool>> Members = new()
    {
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Year))!, Tuple.Create("toYear", true) },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Month))!, Tuple.Create("toMonth", true) },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Day))!, Tuple.Create("toDayOfMonth", true) },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Hour))!, Tuple.Create("toHour", true) },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.DayOfYear))!, Tuple.Create("toDayOfYear", true) },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Minute))!, Tuple.Create("toMinute", true) },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Second))!, Tuple.Create("toSecond", true) },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Millisecond))!, Tuple.Create("toMillisecond", true) },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.DayOfWeek))!, Tuple.Create("toDayOfWeek", false) },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Date))!, Tuple.Create("toDate", false) }
    };

    private static readonly Dictionary<PropertyInfo, string> ClassMembers = new()
    {
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.UtcNow))!, "UTCTimestamp" },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Now))!, "now" }
    };

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseDateTimeMemberTranslator([NotNull] ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression Translate(
        SqlExpression instance,
        MemberInfo member,
        Type returnType,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (Members.TryGetValue(member, out var function))
        {
            var expression = _sqlExpressionFactory.Function(
                function.Item1,
                [instance],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType);

            return function.Item2
                ? _sqlExpressionFactory.Convert(expression, returnType)
                : expression;
        }

        if (member is PropertyInfo pi && ClassMembers.TryGetValue(pi, out var f))
        {
            return _sqlExpressionFactory.Function(
                f,
                [],
                false,
                argumentsPropagateNullability: [],
                returnType: returnType);
        }

        return null;
    }
}
