using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseInt32DbFunctionsExtensions
{
    /// <param name="_">DbFunctions instance.</param>
    extension(DbFunctions _)
    {
        /// <summary>
        /// Converts an input value to a value of type <see cref="int"/>. Throws an exception in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <typeparam name="TNumber"></typeparam>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint32</remarks>
        public int ToInt32<TNumber>(TNumber expr) where TNumber : INumber<TNumber>
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to a value of type <see cref="int"/>. Throws an exception in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint32</remarks>
        public int ToInt32(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt32"/>, this function converts an input value to a value of type <see cref="int"/>
        /// but returns <c>0</c> in case of an error.
        /// </summary>
        /// <param name="expr">A String representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint32orzero</remarks>
        public int ToInt32OrZero(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt32"/>, this function converts an input value to a value of type <see cref="int"/>
        /// but returns <c>null</c> in case of an error.
        /// </summary>
        /// <param name="expr">A String representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint32ornull</remarks>
        public int? ToInt32OrNull(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt32"/>, this function converts an input value to a value of type <see cref="int"/>
        /// but returns the default value in case of an error. If no default value is passed then <c>0</c>
        /// is returned in case of an error.
        /// </summary>
        /// <param name="expr">A String representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint32ordefault</remarks>
        public int ToInt32OrDefault(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt32"/>, this function converts an input value to a value of type <see cref="int"/>
        /// but returns the default value in case of an error. If no default value is passed then <c>0</c>
        /// is returned in case of an error.
        /// </summary>
        /// <param name="expr">A String representation of a number.</param>
        /// <param name="defaultValue">The default value to return if parsing to type <see cref="int"/> is unsuccessful.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint32ordefault</remarks>
        public int ToInt32OrDefault(string expr, int defaultValue)
        {
            throw new InvalidOperationException();
        }
    }
}
