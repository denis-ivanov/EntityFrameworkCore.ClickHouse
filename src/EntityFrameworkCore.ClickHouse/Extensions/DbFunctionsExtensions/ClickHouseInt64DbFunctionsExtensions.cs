using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseInt64DbFunctionsExtensions
{
    /// <param name="_">DbFunctions instance.</param>
    extension(DbFunctions _)
    {
        /// <summary>
        /// Converts an input value to a value of type <see cref="long"/>. Throws an exception in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <typeparam name="TNumber"></typeparam>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint64</remarks>
        public long ToInt64<TNumber>(TNumber expr) where TNumber : INumber<TNumber>
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to a value of type <see cref="long"/>. Throws an exception in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint64</remarks>
        public long ToInt64(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt64"/>, this function converts an input value to a value of type <see cref="long"/>
        /// but returns <c>0</c> in case of an error.
        /// </summary>
        /// <param name="expr">A String representation of a number</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint64orzero</remarks>
        public long ToInt64OrZero(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt64"/>, this function converts an input value to a value of type <see cref="long"/>
        /// but returns <c>null</c> in case of an error.
        /// </summary>
        /// <param name="expr">A String representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint64ornull</remarks>
        public long? ToInt64OrNull(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt64"/>, this function converts an input value to a value of type <see cref="long"/>
        /// but returns the default value in case of an error. If no default value is passed
        /// then <c>0</c> is returned in case of an error.
        /// </summary>
        /// <param name="expr">A String representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint64ordefault</remarks>
        public long ToInt64OrDefault(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt64"/>, this function converts an input value to a value of type <see cref="long"/>
        /// but returns the default value in case of an error. If no default value is passed
        /// then <c>0</c> is returned in case of an error.
        /// </summary>
        /// <param name="expr">A String representation of a number.</param>
        /// <param name="defaultValue">The default value to return if parsing to type <see cref="long"/> is unsuccessful.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint64ordefault</remarks>
        public long ToInt64OrDefault(string expr, long defaultValue)
        {
            throw new InvalidOperationException();
        }
    }
}
