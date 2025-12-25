using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseInt16DbFunctionsExtensions
{
    /// <param name="_">DbFunctions instance.</param>
    extension(DbFunctions _)
    {
        /// <summary>
        /// Converts an input value to a value of type <see cref="short"/>. Throws an exception in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint16</remarks>
        public short ToInt16<TNumber>(TNumber expr) where TNumber : INumber<TNumber>
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to a value of type <see cref="short"/>. Throws an exception in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint16</remarks>
        public short ToInt16(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt16"/>, this function converts an input value to a value of type <see cref="short"/>
        /// but returns <c>0</c> in case of an error.
        /// </summary>
        /// <param name="expr">A String representation of a number.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public short ToInt16OrZero(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt16"/>, this function converts an input value to a value of type <see cref="short" />
        /// but returns <c>null</c> in case of an error.
        /// </summary>
        /// <param name="expr">A String representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint16ornull</remarks>
        public short? ToInt16OrNull(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt16"/>, this function converts an input value to a value of type <see cref="short"/>
        /// but returns the default value in case of an error. If no default value is passed then <c>0</c> is returned in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint16ordefault</remarks>
        public short ToInt16OrDefault(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToInt16"/>, this function converts an input value to a value of type <see cref="short"/>
        /// but returns the default value in case of an error. If no default value is passed then <c>0</c> is returned in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <param name="defaultValue">The default value to return if parsing to type <see cref="short"/> is unsuccessful.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint16ordefault</remarks>
        public short ToInt16OrDefault(string expr, short defaultValue)
        {
            throw new InvalidOperationException();
        }
    }
}
