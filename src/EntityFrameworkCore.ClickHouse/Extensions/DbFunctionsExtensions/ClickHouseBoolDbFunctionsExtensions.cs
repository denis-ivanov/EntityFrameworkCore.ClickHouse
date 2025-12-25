using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseBoolDbFunctionsExtensions
{
    /// <param name="_">DbFunctions instance.</param>
    extension(DbFunctions _)
    {
        /// <summary>
        /// Converts an input value to a value of type Bool. Throws an exception in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string.</param>
        /// <returns>Returns <c>true</c> or <c>false</c> based on evaluation of the argument.</returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#tobool</remarks>
        public bool ToBool(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to a value of type Bool. Throws an exception in case of an error.
        /// </summary>
        /// <param name="expr">Expression returning a number or a string.</param>
        /// <returns>Returns <c>true</c> or <c>false</c> based on evaluation of the argument.</returns>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#tobool</remarks>
        public bool ToBool<TNumber>(TNumber expr) where TNumber: INumber<TNumber>
        {
            throw new InvalidOperationException();
        }
    }
}
