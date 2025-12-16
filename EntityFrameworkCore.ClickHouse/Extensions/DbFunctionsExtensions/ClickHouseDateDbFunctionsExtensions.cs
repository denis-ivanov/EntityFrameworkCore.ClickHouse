using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseDateDbFunctionsExtensions
{
    public static DateOnly ToDate<TNumber>(this DbFunctions _, TNumber expr) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }
    
    public static DateOnly ToDate(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static DateOnly ToDate(this DbFunctions _, DateTime expr)
    {
        throw new InvalidOperationException();
    }

    public static DateOnly ToDate<TNumber>(this DbFunctions _, TNumber expr, string timeZone) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    public static DateOnly ToDate(this DbFunctions _, string expr, string timeZone)
    {
        throw new InvalidOperationException();
    }

    public static DateOnly ToDate(this DbFunctions _, DateTime expr, string timeZone)
    {
        throw new InvalidOperationException();
    }
    
    public static DateOnly ToDateOrZero(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static DateOnly? ToDateOrNull(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }
    
    public static DateOnly ToDateOrDefault(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static DateOnly ToDateOrDefault(this DbFunctions _, string expr, DateOnly defaultValue)
    {
        throw new InvalidOperationException();
    }
}
