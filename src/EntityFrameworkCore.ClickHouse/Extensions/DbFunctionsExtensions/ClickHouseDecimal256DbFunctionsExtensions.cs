using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseDecimal256DbFunctionsExtensions
{
    /// <param name="_">DbFunctions instance.</param>
    extension(DbFunctions _)
    {
        /// <summary>
        /// Converts an input value to a value of type Decimal(76, S) with scale of S. Throws an exception in case of an error.
        /// </summary>
        /// <param name="number">Expression returning a number or a string representation of a number.</param>
        /// <param name="scale">Scale parameter between 0 and 76, specifying how many digits the fractional part of a number can have.</param>
        /// <returns></returns>
        public decimal ToDecimal256(string number, [Range(0, 76)] byte scale)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to a value of type Decimal(76, S) with scale of S. Throws an exception in case of an error.
        /// </summary>
        /// <param name="number">Expression returning a number or a string representation of a number.</param>
        /// <param name="scale">Scale parameter between 0 and 76, specifying how many digits the fractional part of a number can have.</param>
        /// <returns></returns>
        public decimal ToDecimal256<TNumber>(TNumber number, [Range(0, 76)] byte scale) where TNumber : INumber<TNumber>
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToDecimal256"/>, this function converts an input value to a value of type Decimal(76, S) but returns <c>0</c> in case of an error.
        /// </summary>
        /// <param name="number">A String representation of a number.</param>
        /// <param name="scale">Scale parameter between 0 and 76, specifying how many digits the fractional part of a number can have.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public decimal ToDecimal256OrZero(string number, [Range(0, 76)] byte scale)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToDecimal256"/>, this function converts an input value to a value of type Nullable(Decimal(76, S)) but returns <c>null</c> in case of an error.
        /// </summary>
        /// <param name="number">A String representation of a number.</param>
        /// <param name="scale">Scale parameter between 0 and 76, specifying how many digits the fractional part of a number can have.</param>
        /// <returns></returns>
        public decimal? ToDecimal256OrNull(string number, [Range(0, 76)] byte scale)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToDecimal256"/>, this function converts an input value to a value of type Decimal(76, S) but returns the default value in case of an error.
        /// </summary>
        /// <param name="number">A String representation of a number.</param>
        /// <param name="scale">Scale parameter between 0 and 76, specifying how many digits the fractional part of a number can have. </param>
        /// <returns></returns>
        public decimal? ToDecimal256OrDefault(string number, [Range(0, 76)] byte scale)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToDecimal256"/>, this function converts an input value to a value of type Decimal(76, S) but returns the default value in case of an error.
        /// </summary>
        /// <param name="number">A String representation of a number.</param>
        /// <param name="scale">Scale parameter between 0 and 76, specifying how many digits the fractional part of a number can have. </param>
        /// <param name="defaultValue">The default value to return if parsing to type Decimal256(S) is unsuccessful.</param>
        /// <returns></returns>
        public decimal? ToDecimal256OrDefault(string number, [Range(0, 76)] byte scale, decimal defaultValue)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Performs division on two decimals. Result value will be of type Decimal256.
        /// </summary>
        /// <param name="x">First value.</param>
        /// <param name="y">Second value.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="DivideDecimal(DbFunctions, decimal, decimal)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/arithmetic-functions#divideDecimal</remarks>
        public decimal DivideDecimal(decimal x, decimal y)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Performs division on two decimals. Result value will be of type Decimal256.
        /// </summary>
        /// <param name="x">First value.</param>
        /// <param name="y">Second value.</param>
        /// <param name="scale">Scale of result.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="DivideDecimal(DbFunctions, decimal, decimal, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/arithmetic-functions#divideDecimal</remarks>
        public decimal DivideDecimal(decimal x, decimal y, [Range(0, 76)] byte scale)
        {
            throw new InvalidOperationException();
        }
    }
}
