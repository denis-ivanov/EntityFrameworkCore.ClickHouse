using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseBoolDbFunctionsExtensions
{
    /// <summary>
    /// Converts an input value to a value of type Bool. Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">Expression returning a number or a string.</param>
    /// <returns>Returns <c>true</c> or <c>false</c> based on evaluation of the argument.</returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#tobool</remarks>
    public static bool ToBool(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type Bool. Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">Expression returning a number or a string.</param>
    /// <returns>Returns <c>true</c> or <c>false</c> based on evaluation of the argument.</returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#tobool</remarks>
    public static bool ToBool<TNumber>(this DbFunctions _, TNumber expr) where TNumber: INumber<TNumber>
    {
        throw new InvalidOperationException();
    }
}
