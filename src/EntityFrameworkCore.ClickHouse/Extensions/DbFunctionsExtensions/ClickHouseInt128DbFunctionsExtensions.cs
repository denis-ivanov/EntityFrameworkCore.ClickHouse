using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseInt128DbFunctionsExtensions
{
    /// <param name="_">DbFunctions instance.</param>
    extension(DbFunctions _)
    {
        /// <summary>
        /// Converts an input value to a value of type <see cref="Int128"/>. Throws an exception in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <typeparam name="TNumber"></typeparam>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint128</remarks>
        public Int128 ToInt128<TNumber>(TNumber expr) where TNumber : INumber<TNumber>
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to a value of type <see cref="Int128"/>. Throws an exception in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <typeparam name="TNumber"></typeparam>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint128</remarks>
        public Int128 ToInt128(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt128"/>, this function converts an input value to a value of type <see cref="Int128"/>
        /// but returns <c>0</c> in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint128orzero</remarks>
        public Int128 ToInt128OrZero(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt128"/>, this function converts an input value to a value of type <see cref="Int128"/>
        /// but returns <c>null</c> in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint128ornull</remarks>
        public Int128? ToInt128OrNull(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt128"/>, this function converts an input value to a value of type <see cref="Int128"/>
        /// but returns the default value in case of an error. If no default value is passed then <c>0</c> is returned in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint128ordefault</remarks>
        public Int128 ToInt128OrDefault(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt128"/>, this function converts an input value to a value of type <see cref="Int128"/>
        /// but returns the default value in case of an error. If no default value is passed then <c>0</c> is returned in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <param name="defaultValue">The default value to return if parsing to type <see cref="Int128"/> is unsuccessful.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint128ordefault</remarks>
        public Int128 ToInt128OrDefault(string expr, Int128 defaultValue)
        {
            throw new InvalidOperationException();
        }
    }
}
