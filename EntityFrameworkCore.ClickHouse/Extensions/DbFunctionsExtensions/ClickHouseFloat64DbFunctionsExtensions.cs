using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseFloat64DbFunctionsExtensions
{
    public static double ToFloat64<TNumber>(this DbFunctions _, TNumber expr) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    public static double ToFloat64(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static double ToFloat64OrZero(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static double? ToFloat64OrNull(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static double ToFloat64OrDefault(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static double ToFloat64OrDefault(this DbFunctions _, string expr, double defaultValue)
    {
        throw new InvalidOperationException();
    }
}
