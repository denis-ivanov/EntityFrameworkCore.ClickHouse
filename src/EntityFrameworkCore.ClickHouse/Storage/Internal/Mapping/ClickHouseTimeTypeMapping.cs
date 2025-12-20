using ClickHouse.Driver.ADO.Readers;
using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Storage.ValueConversation;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Data.Common;
using System.Globalization;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseTimeTypeMapping : RelationalTypeMapping
{
    internal const int MaxPrecision = 9;

    public ClickHouseTimeTypeMapping(Type clrType, string storeType, int? precision = null)
        : base(
            new RelationalTypeMappingParameters(
                new CoreTypeMappingParameters(
                    clrType,
                    jsonValueReaderWriter: clrType == typeof(TimeSpan)
                        ? JsonTimeSpanReaderWriter.Instance
                        : clrType == typeof(TimeOnly)
                            ? JsonTimeOnlyReaderWriter.Instance
                            : throw new ArgumentException("Argument type must be TimeSpan or TimeOnly",
                                nameof(clrType)),
                    converter: clrType == typeof(TimeSpan)
                        ? null
                        : new ClickHouseTimeOnlyToTimeSpanValueConverter()),
                storeType,
                StoreTypePostfix.Precision,
                System.Data.DbType.Time,
                precision: ValidatePrecision(precision, storeType)))
    {
    }

    public override MethodInfo GetDataReaderMethod()
    {
        return typeof(DbDataReader).GetRuntimeMethod(nameof(ClickHouseDataReader.GetValue), [typeof(int)])!;
    }

    protected ClickHouseTimeTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseTimeTypeMapping(parameters);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        parameter.SetStoreType(StoreType);
    }

    protected override string GenerateNonNullSqlLiteral(object value)
    {
        return value switch
        {
            TimeSpan ts => "'" + ToClickHouseTime(ts, Precision ?? MaxPrecision) + "'",
            TimeOnly to => "'" + ToClickHouseTime(to, Precision ?? MaxPrecision) + "'",
            _ => throw new ArgumentException("Argument type must be TimeSpan or TimeOnly", nameof(value))
        };
    }

    private static string ToClickHouseTime(TimeSpan value, int precision)
    {
        var sign = value < TimeSpan.Zero ? "-" : "";
        var abs = value.Duration();

        long totalHours = (long)abs.TotalHours;
        int minutes = abs.Minutes;
        int seconds = abs.Seconds;

        long ticksInSecond = abs.Ticks % TimeSpan.TicksPerSecond;

        if (precision == 0)
        {
            return string.Create(CultureInfo.InvariantCulture, $"{sign}{totalHours}:{minutes:00}:{seconds:00}");
        }

        var tickFractionStr = ticksInSecond.ToString("D7", CultureInfo.InvariantCulture);
        var fracStr = precision <= 7
            ? tickFractionStr.Substring(0, precision)
            : tickFractionStr + new string('0', precision - 7);

        return string.Create(CultureInfo.InvariantCulture, $"{sign}{totalHours}:{minutes:00}:{seconds:00}.{fracStr}");
    }

    private static string ToClickHouseTime(TimeOnly value, int precision)
    {
        int hours = value.Hour;
        int minutes = value.Minute;
        int seconds = value.Second;

        if (precision == 0)
        {
            return string.Create(CultureInfo.InvariantCulture, $"{hours}:{minutes:00}:{seconds:00}");
        }

        int divisor = (int)Math.Pow(10, 9 - precision);
        int frac = value.Nanosecond / divisor;

        return string.Create(
            CultureInfo.InvariantCulture,
            $"{hours}:{minutes:00}:{seconds:00}.{frac.ToString(new string('0', precision), CultureInfo.InvariantCulture)}"
        );
    }
    
    private static int? ValidatePrecision(int? precision, string storeType)
    {
        if (!precision.HasValue)
        {
            return null;
        }

        if (string.Equals("Time", storeType, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new ArgumentException("Precision is not supported for Time type", nameof(precision));
        }

        if (precision is < 0 or > 9)
        {
            throw new ArgumentOutOfRangeException(nameof(precision), "Precision must be in [0..9].");
        }

        return precision;
    }
}
