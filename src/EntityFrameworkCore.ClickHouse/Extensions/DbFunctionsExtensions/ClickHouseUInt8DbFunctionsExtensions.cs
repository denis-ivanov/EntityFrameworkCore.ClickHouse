using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseUInt8DbFunctionsExtensions
{
    /// <param name="_">DbFunctions instance.</param>
    extension(DbFunctions _)
    {
        /// <summary>
        /// Converts an input value to a value of type <see cref="byte"/>.
        /// Throws an exception in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <typeparam name="TNumber"></typeparam>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#touint8</remarks>
        public byte ToUInt8<TNumber>(TNumber expr) where TNumber : INumber<TNumber>
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to a value of type <see cref="byte"/>.
        /// Throws an exception in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string representation of a number.</param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#touint8</remarks>
        public byte ToUInt8(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToUInt8"/>, this function converts an input value to a value of type <see cref="byte"/>
        /// but returns <c>0</c> in case of an error.
        /// </summary>
        /// <param name="expr">A String representation of a number.</param>
        /// <returns></returns>
        public byte ToUInt8OrZero(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToUInt8"/>, this function converts an input value to a value of type <see cref="byte"/>
        /// but returns <c>null</c> in case of an error.
        /// </summary>
        /// <param name="expr">A String representation of a number.</param>
        /// <returns></returns>
        public byte? ToUInt8OrNull(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToUInt8"/>, this function converts an input value to a value of type <see cref="byte"/>
        /// but returns the default value in case of an error.
        /// If no default value is passed then <c>0</c> is returned in case of an error.
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#touint8ordefault</remarks>
        public byte ToUInt8OrDefault(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like <see cref="ToUInt8"/>, this function converts an input value to a value of type <see cref="byte"/>
        /// but returns the default value in case of an error.
        /// If no default value is passed then <c>0</c> is returned in case of an error.
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#touint8ordefault</remarks>
        public byte ToUInt8OrDefault(string expr, byte defaultValue)
        {
            throw new InvalidOperationException();
        }
    }
}