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
    private static readonly Dictionary<MemberInfo, string> Members = new()
    {
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Year))!, "toYear" },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Month))!, "toMonth" },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Day))!, "toDayOfMonth" },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Hour))!, "toHour" },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.DayOfYear))!, "toDayOfYear" },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Minute))!, "toMinute" },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Second))!, "toSecond" },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.Millisecond))!, "toMillisecond" },
        { typeof(DateTime).GetRuntimeProperty(nameof(DateTime.DayOfWeek))!, "toDayOfWeek" }
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
            return _sqlExpressionFactory.Convert(
                _sqlExpressionFactory.Function(
                    function,
                    new[] { instance },
                    nullable: true,
                    argumentsPropagateNullability: [true],
                    returnType),
                typeof(int)
            );
        }

        return null;
    }
}
