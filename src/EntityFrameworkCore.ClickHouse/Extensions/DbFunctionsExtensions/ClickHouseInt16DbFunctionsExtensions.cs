using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseInt16DbFunctionsExtensions
{
    /// <summary>
    /// Converts an input value to a value of type <see cref="short"/>. Throws an exception in case of an error.
    /// </summary>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint16</remarks>
    public static short ToInt16<TNumber>(this DbFunctions _, TNumber expr) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type <see cref="short"/>. Throws an exception in case of an error.
    /// </summary>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint16</remarks>
    public static short ToInt16(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToInt16"/>, this function converts an input value to a value of type <see cref="short"/>
    /// but returns <c>0</c> in case of an error.
    /// </summary>
    /// <param name="expr">A String representation of a number.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static short ToInt16OrZero(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToInt16"/>, this function converts an input value to a value of type <see cref="short" />
    /// but returns <c>null</c> in case of an error.
    /// </summary>
    /// <param name="expr">A String representation of a number.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint16ornull</remarks>
    public static short? ToInt16OrNull(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToInt16"/>, this function converts an input value to a value of type <see cref="short"/>
    /// but returns the default value in case of an error. If no default value is passed then <c>0</c> is returned in case of an error.
    /// </summary>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint16ordefault</remarks>
    public static short ToInt16OrDefault(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToInt16"/>, this function converts an input value to a value of type <see cref="short"/>
    /// but returns the default value in case of an error. If no default value is passed then <c>0</c> is returned in case of an error.
    /// </summary>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <param name="defaultValue">The default value to return if parsing to type <see cref="short"/> is unsuccessful.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint16ordefault</remarks>
    public static short ToInt16OrDefault(this DbFunctions _, string expr, short defaultValue)
    {
        throw new InvalidOperationException();
    }
}
