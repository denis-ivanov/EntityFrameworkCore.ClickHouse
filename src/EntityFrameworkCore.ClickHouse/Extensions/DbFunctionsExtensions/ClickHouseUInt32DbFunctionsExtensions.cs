using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseUInt32DbFunctionsExtensions
{
    /// <summary>
    /// Converts an input value to a value of type <see cref="uint"/>.
    /// Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <typeparam name="TNumber"></typeparam>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toUInt32</remarks>
    public static uint ToUInt32<TNumber>(this DbFunctions _, TNumber expr) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type <see cref="uint"/>.
    /// Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toUInt32</remarks>
    public static uint ToUInt32(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToUInt32"/>, this function converts an input value to a value of type <see cref="uint"/>
    /// but returns <c>0</c> in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">A String representation of a number.</param>
    /// <returns></returns>
    public static uint ToUInt32OrZero(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToUInt32"/>, this function converts an input value to a value of type <see cref="uint"/>
    /// but returns <c>null</c> in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">A String representation of a number.</param>
    /// <returns></returns>
    public static uint? ToUInt32OrNull(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToUInt32"/>, this function converts an input value to a value of type <see cref="uint"/>
    /// but returns the default value in case of an error.
    /// If no default value is passed then <c>0</c> is returned in case of an error.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="expr"></param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toUInt32ordefault</remarks>
    public static uint ToUInt32OrDefault(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToUInt32"/>, this function converts an input value to a value of type <see cref="uint"/>
    /// but returns the default value in case of an error.
    /// If no default value is passed then <c>0</c> is returned in case of an error.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="expr"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toUInt32ordefault</remarks>
    public static uint ToUInt32OrDefault(this DbFunctions _, string expr, uint defaultValue)
    {
        throw new InvalidOperationException();
    }
}
