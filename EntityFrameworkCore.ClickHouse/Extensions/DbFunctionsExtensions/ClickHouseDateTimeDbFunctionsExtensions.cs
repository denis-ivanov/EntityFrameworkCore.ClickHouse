using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseDateTimeDbFunctionsExtensions
{
    public static DateTime ToDateTime<TNumber>(this DbFunctions _, TNumber expr) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime(this DbFunctions _, DateOnly expr)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime<TNumber>(this DbFunctions _, TNumber expr, string timeZone) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime(this DbFunctions _, string expr, string timeZone)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime(this DbFunctions _, DateOnly expr, string timeZone)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTimeOrZero(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static DateTime? ToDateTimeOrNull(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTimeOrDefault(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTimeOrDefault(this DbFunctions _, string expr, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }
}
