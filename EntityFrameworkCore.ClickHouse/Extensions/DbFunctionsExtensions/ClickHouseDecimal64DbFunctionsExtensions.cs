using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseDecimal64DbFunctionsExtensions
{
    /// <summary>
    /// Converts an input value to a value of type Decimal(18, S) with scale of S. Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">Expression returning a number or a string representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 18, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal ToDecimal64(this DbFunctions _, string number, [Range(0, 18)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type Decimal(18, S) with scale of S. Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">Expression returning a number or a string representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 18, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal ToDecimal64<TNumber>(this DbFunctions _, TNumber number, [Range(0, 18)] byte scale) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal64"/>, this function converts an input value to a value of type Decimal(18, S)
    /// but returns <c>0</c> in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 18, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal ToDecimal64OrZero(this DbFunctions _, string number, [Range(0, 18)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal64"/>, this function converts an input value to a value of type Nullable(Decimal(18, S))
    /// but returns <c>null</c> in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 18, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal? ToDecimal64OrNull(this DbFunctions _, string number, [Range(0, 18)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal64"/>, this function converts an input value to a value of type Decimal(18, S) but returns the default value in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 18, specifying how many digits the fractional part of a number can have. </param>
    /// <returns></returns>
    public static decimal ToDecimal64OrDefault(this DbFunctions _, string number, [Range(0, 18)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal64"/>, this function converts an input value to a value of type Decimal(18, S) but returns the default value in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 18, specifying how many digits the fractional part of a number can have. </param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static decimal ToDecimal64OrDefault(this DbFunctions _, string number, [Range(0, 18)] byte scale, decimal defaultValue)
    {
        throw new InvalidOperationException();
    }
}
