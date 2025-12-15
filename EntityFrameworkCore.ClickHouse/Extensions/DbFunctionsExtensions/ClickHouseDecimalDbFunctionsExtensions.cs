using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseDecimalDbFunctionsExtensions
{
    /// <summary>
    /// Converts an input value to a value of type Decimal(9, S) with scale of S.
    /// Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">Expression returning a number or a string representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 9, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal ToDecimal32(this DbFunctions _, string number, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type Decimal(9, S) with scale of S.
    /// Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">Expression returning a number or a string representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 9, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal ToDecimal32<TNumber>(this DbFunctions _, TNumber number, [Range(0, 9)] byte scale) where TNumber: INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal32" />, this function converts an input value to a value of type Decimal(9, S)
    /// but returns <c>0</c> in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number. </param>
    /// <param name="scale">Scale parameter between 0 and 9, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal ToDecimal32OrZero(this DbFunctions _, string number, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal32"/>, this function converts an input value to a value of type Decimal(9, S)
    /// but returns <c>null</c> in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 9, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal? ToDecimal32OrNull(this DbFunctions _, string number, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal32" />, this function converts an input value to a value of type Decimal(9, S)
    /// but returns the default value in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 9, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static decimal ToDecimal32OrDefault(this DbFunctions _, string number, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal32" />, this function converts an input value to a value of type Decimal(9, S)
    /// but returns the default value in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 9, specifying how many digits the fractional part of a number can have.</param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static decimal ToDecimal32OrDefault(this DbFunctions _, string number, [Range(0, 9)] byte scale, decimal defaultValue)
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

    /// <summary>
    /// Converts an input value to a value of type Decimal(38, S) with scale of S. Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">Expression returning a number or a string representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 38, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal ToDecimal128(this DbFunctions _, string number, [Range(0, 38)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type Decimal(38, S) with scale of S. Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">Expression returning a number or a string representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 38, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal ToDecimal128<TNumber>(this DbFunctions _, TNumber number, [Range(0, 38)] byte scale) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal128" />, this function converts an input value to a value of type Decimal(38, S) but returns <c>0</c> in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 38, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal ToDecimal128OrZero(this DbFunctions _, string number, [Range(0, 38)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal128"/>, this function converts an input value to a value of type
    /// Nullable(Decimal(38, S)) but returns <c>null</c> in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 38, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static decimal? ToDecimal128OrNull(this DbFunctions _, string number, [Range(0, 38)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal128"/>, this function converts an input value to a value of type Decimal(38, S) but returns the default value in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 38, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal ToDecimal128OrDefault(this DbFunctions _, string number, [Range(0, 38)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal128"/>, this function converts an input value to a value of type Decimal(38, S) but returns the default value in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 38, specifying how many digits the fractional part of a number can have.</param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static decimal ToDecimal128OrDefault(this DbFunctions _, string number, [Range(0, 38)] byte scale, decimal defaultValue)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type Decimal(76, S) with scale of S. Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">Expression returning a number or a string representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 76, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal ToDecimal256(this DbFunctions _, string number, [Range(0, 76)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type Decimal(76, S) with scale of S. Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">Expression returning a number or a string representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 76, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal ToDecimal256<TNumber>(this DbFunctions _, TNumber number, [Range(0, 76)] byte scale) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal256"/>, this function converts an input value to a value of type Decimal(76, S) but returns <c>0</c> in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 76, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static decimal ToDecimal256OrZero(this DbFunctions _, string number, [Range(0, 76)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal256"/>, this function converts an input value to a value of type Nullable(Decimal(76, S)) but returns <c>null</c> in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 76, specifying how many digits the fractional part of a number can have.</param>
    /// <returns></returns>
    public static decimal? ToDecimal256OrNull(this DbFunctions _, string number, [Range(0, 76)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal256"/>, this function converts an input value to a value of type Decimal(76, S) but returns the default value in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 76, specifying how many digits the fractional part of a number can have. </param>
    /// <returns></returns>
    public static decimal? ToDecimal256OrDefault(this DbFunctions _, string number, [Range(0, 76)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDecimal256"/>, this function converts an input value to a value of type Decimal(76, S) but returns the default value in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="number">A String representation of a number.</param>
    /// <param name="scale">Scale parameter between 0 and 76, specifying how many digits the fractional part of a number can have. </param>
    /// <param name="defaultValue">The default value to return if parsing to type Decimal256(S) is unsuccessful.</param>
    /// <returns></returns>
    public static decimal? ToDecimal256OrDefault(this DbFunctions _, string number, [Range(0, 76)] byte scale, decimal defaultValue)
    {
        throw new InvalidOperationException();
    }
}
