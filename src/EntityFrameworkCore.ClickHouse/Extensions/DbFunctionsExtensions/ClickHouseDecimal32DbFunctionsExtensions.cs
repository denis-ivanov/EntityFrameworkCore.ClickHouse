using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseDecimal32DbFunctionsExtensions
{
    /// <param name="_">DbFunctions instance.</param>
    extension(DbFunctions _)
    {
        /// <summary>
        /// Converts an input value to a value of type Decimal(9, S) with scale of S.
        /// Throws an exception in case of an error.
        /// </summary>
        /// <param name="number">Expression returning a number or a string representation of a number.</param>
        /// <param name="scale">Scale parameter between 0 and 9, specifying how many digits the fractional part of a number can have.</param>
        /// <returns></returns>
        public decimal ToDecimal32(string number, [Range(0, 9)] byte scale)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to a value of type Decimal(9, S) with scale of S.
        /// Throws an exception in case of an error.
        /// </summary>
        /// <param name="number">Expression returning a number or a string representation of a number.</param>
        /// <param name="scale">Scale parameter between 0 and 9, specifying how many digits the fractional part of a number can have.</param>
        /// <returns></returns>
        public decimal ToDecimal32<TNumber>(TNumber number, [Range(0, 9)] byte scale) where TNumber: INumber<TNumber>
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToDecimal32" />, this function converts an input value to a value of type Decimal(9, S)
        /// but returns <c>0</c> in case of an error.
        /// </summary>
        /// <param name="number">A String representation of a number. </param>
        /// <param name="scale">Scale parameter between 0 and 9, specifying how many digits the fractional part of a number can have.</param>
        /// <returns></returns>
        public decimal ToDecimal32OrZero(string number, [Range(0, 9)] byte scale)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToDecimal32"/>, this function converts an input value to a value of type Decimal(9, S)
        /// but returns <c>null</c> in case of an error.
        /// </summary>
        /// <param name="number">A String representation of a number.</param>
        /// <param name="scale">Scale parameter between 0 and 9, specifying how many digits the fractional part of a number can have.</param>
        /// <returns></returns>
        public decimal? ToDecimal32OrNull(string number, [Range(0, 9)] byte scale)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToDecimal32" />, this function converts an input value to a value of type Decimal(9, S)
        /// but returns the default value in case of an error.
        /// </summary>
        /// <param name="number">A String representation of a number.</param>
        /// <param name="scale">Scale parameter between 0 and 9, specifying how many digits the fractional part of a number can have.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public decimal ToDecimal32OrDefault(string number, [Range(0, 9)] byte scale)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToDecimal32" />, this function converts an input value to a value of type Decimal(9, S)
        /// but returns the default value in case of an error.
        /// </summary>
        /// <param name="number">A String representation of a number.</param>
        /// <param name="scale">Scale parameter between 0 and 9, specifying how many digits the fractional part of a number can have.</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public decimal ToDecimal32OrDefault(string number, [Range(0, 9)] byte scale, decimal defaultValue)
        {
            throw new InvalidOperationException();
        }
    }
}
