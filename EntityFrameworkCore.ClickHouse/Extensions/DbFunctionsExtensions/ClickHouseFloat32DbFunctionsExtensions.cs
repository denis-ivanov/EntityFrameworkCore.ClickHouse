using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseFloat32DbFunctionsExtensions
{
    /// <summary>
    /// Converts an input value to a value of type Float32. Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <typeparam name="TNumber"></typeparam>
    /// <returns>32-bit floating point value.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToFloat32{TNumber}(DbFunctions, TNumber)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#tofloat32</remarks>
    public static float ToFloat32<TNumber>(this DbFunctions _, TNumber expr) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type Float32. Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <returns>32-bit floating point value.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToFloat32{TNumber}(DbFunctions, TNumber)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#tofloat32</remarks>
    public static float ToFloat32(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToFloat32(DbFunctions, string)"/>, this function converts an input value to a value
    /// of type Float32 but returns <c>0</c> in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">A String representation of a number.</param>
    /// <returns>32-bit Float value if successful, otherwise <c>0</c>.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToFloat32OrZero(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#tofloat32orzero</remarks>
    public static float ToFloat32OrZero(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToFloat32(DbFunctions, string)"/>, this function converts an input value to a value
    /// of type Float32 but returns <c>null</c> in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">A String representation of a number.</param>
    /// <returns>32-bit Float value if successful, otherwise <c>null</c>.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToFloat32OrNull(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#tofloat32ornull</remarks>
    public static float? ToFloat32OrNull(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToFloat32(DbFunctions, string)"/>, this function converts an input value to a value of type Float32
    /// but returns the default value in case of an error. If no default value is passed
    /// then <c>0</c> is returned in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">A String representation of a number.</param>
    /// <returns>32-bit Float value if successful, otherwise returns the default value if passed or 0 if not.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToFloat32OrDefault(DbFunctions,string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#tofloat32ordefault</remarks>
    public static float ToFloat32OrDefault(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToFloat32(DbFunctions, string)"/>, this function converts an input value to a value of type Float32
    /// but returns the default value in case of an error. If no default value is passed
    /// then <c>0</c> is returned in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">A String representation of a number.</param>
    /// <param name="defaultValue">The default value to return if parsing to type Float32 is unsuccessful.</param>
    /// <returns>32-bit Float value if successful, otherwise returns the default value if passed or 0 if not.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToFloat32OrDefault(DbFunctions,string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#tofloat32ordefault</remarks>
    public static float ToFloat32OrDefault(this DbFunctions _, string expr, float defaultValue)
    {
        throw new InvalidOperationException();
    }
}
