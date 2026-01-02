using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseAggregateDbFunctionsExtensions
{
    /// <summary>
    /// Returns any value of the column. 
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="column">The column.</param>
    /// <typeparam name="T">The type of the column.</typeparam>
    /// <returns>Any value of the column.</returns>
    public static T Any<T>(this DbFunctions _, IEnumerable<T> column)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Returns any value of the column, respecting nulls.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="column">The column.</param>
    /// <typeparam name="T">The type of the column.</typeparam>
    /// <returns>Any value of the column.</returns>
    public static T AnyRespectNulls<T>(this DbFunctions _, IEnumerable<T> column)
    {
        throw new InvalidOperationException();
    }
}
