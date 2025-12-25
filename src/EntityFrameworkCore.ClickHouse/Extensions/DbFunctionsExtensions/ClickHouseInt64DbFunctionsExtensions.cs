using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseInt64DbFunctionsExtensions
{
    /// <summary>
    /// Converts an input value to a value of type <see cref="long"/>. Throws an exception in case of an error.
    /// </summary>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <typeparam name="TNumber"></typeparam>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint64</remarks>
    public static long ToInt64<TNumber>(this DbFunctions _, TNumber expr) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type <see cref="long"/>. Throws an exception in case of an error.
    /// </summary>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint64</remarks>
    public static long ToInt64(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToInt64"/>, this function converts an input value to a value of type <see cref="long"/>
    /// but returns <c>0</c> in case of an error.
    /// </summary>
    /// <param name="expr">A String representation of a number</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint64orzero</remarks>
    public static long ToInt64OrZero(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToInt64"/>, this function converts an input value to a value of type <see cref="long"/>
    /// but returns <c>null</c> in case of an error.
    /// </summary>
    /// <param name="expr">A String representation of a number.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint64ornull</remarks>
    public static long? ToInt64OrNull(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToInt64"/>, this function converts an input value to a value of type <see cref="long"/>
    /// but returns the default value in case of an error. If no default value is passed
    /// then <c>0</c> is returned in case of an error.
    /// </summary>
    /// <param name="expr">A String representation of a number.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint64ordefault</remarks>
    public static long ToInt64OrDefault(this DbFunctions _, string expr)
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
    /// <param name="_">DbFunctions instance.</param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint64ordefault</remarks>
    public static long ToInt64OrDefault(this DbFunctions _, string expr, long defaultValue)
    {
        throw new InvalidOperationException();
    }
}
