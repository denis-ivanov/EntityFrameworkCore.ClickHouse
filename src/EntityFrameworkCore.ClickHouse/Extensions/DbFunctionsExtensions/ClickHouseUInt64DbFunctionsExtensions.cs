using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseUInt64DbFunctionsExtensions
{
    /// <param name="_">DbFunctions instance.</param>
    extension(DbFunctions _)
    {
        /// <summary>
        /// Converts an input value to a value of type <see cref="ulong"/>.
        /// Throws an exception in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <typeparam name="TNumber"></typeparam>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toUInt64</remarks>
        public ulong ToUInt64<TNumber>(TNumber expr) where TNumber : INumber<TNumber>
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to a value of type <see cref="ulong"/>.
        /// Throws an exception in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toUInt64</remarks>
        public ulong ToUInt64(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToUInt64"/>, this function converts an input value to a value of type <see cref="ulong"/>
        /// but returns <c>0</c> in case of an error.
        /// </summary>
        /// <param name="expr">A String representation of a number.</param>
        /// <returns></returns>
        public ulong ToUInt64OrZero(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToUInt64"/>, this function converts an input value to a value of type <see cref="ulong"/>
        /// but returns <c>null</c> in case of an error.
        /// </summary>
        /// <param name="expr">A String representation of a number.</param>
        /// <returns></returns>
        public ulong? ToUInt64OrNull(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToUInt64"/>, this function converts an input value to a value of type <see cref="ulong"/>
        /// but returns the default value in case of an error.
        /// If no default value is passed then <c>0</c> is returned in case of an error.
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toUInt64ordefault</remarks>
        public ulong ToUInt64OrDefault(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToUInt64"/>, this function converts an input value to a value of type <see cref="ulong"/>
        /// but returns the default value in case of an error.
        /// If no default value is passed then <c>0</c> is returned in case of an error.
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toUInt64ordefault</remarks>
        public ulong ToUInt64OrDefault(string expr, ulong defaultValue)
        {
            throw new InvalidOperationException();
        }
    }
}
