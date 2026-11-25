using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

internal sealed class ClickHouseDateTimeOffsetTranslator(
    ISqlExpressionFactory sql,
    IRelationalTypeMappingSource typeMappings) : IMemberTranslator, IMethodCallTranslator
{
    public SqlExpression? Translate(
        SqlExpression? instance,
        MemberInfo member,
        Type returnType,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (instance?.TypeMapping?.Converter is not DateTimeOffsetToStringConverter
            || member.DeclaringType != typeof(DateTimeOffset)
            || member.Name is not (nameof(DateTimeOffset.DateTime) or nameof(DateTimeOffset.UtcDateTime) or nameof(DateTimeOffset.LocalDateTime)))
        {
            return null;
        }

        SqlExpression text = instance;
        if (member.Name == nameof(DateTimeOffset.DateTime))
        {
            // Remove the fixed-width signed UTC offset to preserve the wall-clock date.
            SqlExpression length = sql.Function("length", [instance], nullable: true, [true], typeof(long));
            text = sql.Function(
                "substring", [instance, sql.Constant(1), sql.Subtract(length, sql.Constant(6L))],
                nullable: true, [true, false, true], typeof(string), typeMappings.FindMapping(typeof(string)));
        }

        RelationalTypeMapping? dateTimeMapping = typeMappings.FindMapping(typeof(DateTime), "DateTime64(7)");
        SqlExpression dateTime = sql.Function(
            "parseDateTime64BestEffortOrNull", [text, sql.Constant(7), sql.Constant("UTC")],
            nullable: true, [true, false, false], typeof(DateTime), dateTimeMapping);

        if (member.Name != nameof(DateTimeOffset.LocalDateTime))
        {
            return dateTime;
        }

        return sql.Function(
            "toTimeZone", [dateTime, sql.Constant(GetLocalZone())], nullable: true, [true, false],
            typeof(DateTime), dateTimeMapping);
    }

    public SqlExpression? Translate(
        SqlExpression? instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (instance?.TypeMapping?.Converter is not DateTimeOffsetToStringConverter
            || method.DeclaringType != typeof(DateTimeOffset)
            || method.Name != nameof(DateTimeOffset.ToOffset)
            || arguments is not [SqlConstantExpression { Value: TimeSpan offset }]
            || !IsValidOffset(offset))
        {
            return null;
        }

        RelationalTypeMapping? mapping = typeMappings.FindMapping(typeof(DateTime), "DateTime64(7)");
        SqlExpression instant = sql.Function(
            "parseDateTime64BestEffortOrNull", [instance, sql.Constant(7), sql.Constant("UTC")],
            nullable: true, [true, false, false], typeof(DateTime), mapping);
        SqlExpression wallClock = sql.Function(
            "addMinutes", [instant, sql.Constant((int)offset.TotalMinutes)],
            nullable: true, [true, false], typeof(DateTime), mapping);

        return ToStoredValue(wallClock, sql.Constant(FormatOffset(offset)), instance.TypeMapping);
    }

    internal SqlExpression? FromDateTime(SqlExpression dateTime, TimeSpan? offset)
    {
        if (typeMappings.FindMapping(typeof(DateTimeOffset)) is not { Converter: DateTimeOffsetToStringConverter } mapping
            || (offset is TimeSpan explicitOffset && !IsValidOffset(explicitOffset)))
        {
            return null;
        }

        RelationalTypeMapping? temporalMapping = typeMappings.FindMapping(typeof(DateTime), "DateTime64(7)");
        SqlExpression wallClock = sql.Function(
            "toDateTime64", [dateTime, sql.Constant(7)], nullable: true, [true, false], typeof(DateTime), temporalMapping);

        // ClickHouse columns have no CLR DateTimeKind. The constructor treats an unspecified offset as UTC.
        return ToStoredValue(wallClock, sql.Constant(FormatOffset(offset ?? TimeSpan.Zero)), mapping);
    }

    private SqlExpression ToStoredValue(SqlExpression clock, SqlExpression offset, RelationalTypeMapping mapping)
        => sql.Function("concat", [FormatClock(clock), offset], nullable: true, [true, true], typeof(DateTimeOffset), mapping);

    private SqlExpression FormatClock(SqlExpression clock)
        => sql.Function(
            "replaceRegexpOne",
            [sql.Function("toString", [clock], nullable: true, [true], typeof(string)), sql.Constant(@"\\.?0+$"), sql.Constant("")],
            nullable: true, [true, false, false], typeof(string), typeMappings.FindMapping(typeof(string)));

    private static bool IsValidOffset(TimeSpan offset)
        => offset.Ticks % TimeSpan.TicksPerMinute == 0 && Math.Abs(offset.TotalHours) <= 14;

    private static string FormatOffset(TimeSpan offset)
        => (offset < TimeSpan.Zero ? "-" : "+") + offset.Duration().ToString(@"hh\:mm", CultureInfo.InvariantCulture);

    private static string GetLocalZone()
    {
        string localZone = TimeZoneInfo.Local.Id;
        return TimeZoneInfo.TryConvertWindowsIdToIanaId(localZone, out string? ianaId) ? ianaId : localZone;
    }
}
