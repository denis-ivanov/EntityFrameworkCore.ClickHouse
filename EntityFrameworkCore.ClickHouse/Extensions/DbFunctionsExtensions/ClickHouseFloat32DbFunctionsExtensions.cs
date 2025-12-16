using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseFloat32DbFunctionsExtensions
{
    public static float ToFloat32<TNumber>(this DbFunctions _, TNumber expr) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    public static float ToFloat32(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static float ToFloat32OrZero(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static float? ToFloat32OrNull(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static float ToFloat32OrDefault(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static float ToFloat32OrDefault(this DbFunctions _, string expr, float defaultValue)
    {
        throw new InvalidOperationException();
    }
}
