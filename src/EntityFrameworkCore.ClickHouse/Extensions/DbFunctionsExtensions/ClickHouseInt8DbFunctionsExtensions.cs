using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseInt8DbFunctionsExtensions
{
    /// <summary>
    /// Converts an input value to a value of type <see cref="sbyte"/>. Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <typeparam name="TNumber"></typeparam>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint8</remarks>
    public static sbyte ToInt8<TNumber>(this DbFunctions _, TNumber expr) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type <see cref="sbyte"/>. Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint8</remarks>
    public static sbyte ToInt8(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToInt8"/>, this function converts an input value to a value of type <see cref="sbyte"/> but returns <c>0</c> in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr"> A String representation of a number.</param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint8orzero</remarks>
    public static sbyte ToInt8OrZero(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToInt8"/>, this function converts an input value to a value of type Int8 but returns
    /// <c>null</c> in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">A String representation of a number.</param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toInt8OrNull</remarks>
    public static sbyte? ToInt8OrNull(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToInt8"/>, this function converts an input value to a value of type <see cref="sbyte"/>
    /// but returns the default value in case of an error. If no default value is passed then
    /// <c>0</c> is returned in case of an error.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="expr"></param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint8ordefault</remarks>
    public static sbyte ToInt8OrDefault(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToInt8"/>, this function converts an input value to a value of type <see cref="sbyte"/>
    /// but returns the default value in case of an error. If no default value is passed then
    /// <c>0</c> is returned in case of an error.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="expr"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toint8ordefault</remarks>
    public static sbyte ToInt8OrDefault(this DbFunctions _, string expr, sbyte defaultValue)
    {
        throw new InvalidOperationException();
    }
}
