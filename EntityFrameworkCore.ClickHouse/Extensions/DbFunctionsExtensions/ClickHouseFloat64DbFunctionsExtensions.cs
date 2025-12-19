using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseFloat64DbFunctionsExtensions
{
    /// <summary>
    /// Converts an input value to a value of type Float64. Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <typeparam name="TNumber"></typeparam>
    /// <returns>Returns a 64-bit floating point value.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToFloat64{TNumber}(DbFunctions, TNumber)"/> is used for converting string representations of numbers to Float64.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toFloat64</remarks>
    public static double ToFloat64<TNumber>(this DbFunctions _, TNumber expr) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type Float64. Throws an exception in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <returns>Returns a 64-bit floating point value.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToFloat64(DbFunctions, string)"/> is used for converting string representations of numbers to Float64.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toFloat64</remarks>
    public static double ToFloat64(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type Float64 but returns 0 in case of an error. Like <see cref="ToFloat64(DbFunctions, string)"/>
    /// but returns 0 instead of throwing an exception on conversion errors.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <returns>Returns a 64-bit floating point value.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToFloat64OrZero(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toFloat64OrZero</remarks>
    public static double ToFloat64OrZero(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type Float64 but returns <c>null</c> in case of an error.
    /// Like <see cref="ToFloat64(DbFunctions, string)"/> but returns <c>null</c> instead of throwing an exception on conversion errors.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">A string representation of a number.</param>
    /// <returns>Returns a 64-bit Float value if successful, otherwise <c>null</c>.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToFloat64OrNull(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toFloat64OrNull</remarks>
    public static double? ToFloat64OrNull(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToFloat64(DbFunctions, string)"/>, this function converts an input value to a value of type
    /// Float64 but returns the default value in case of an error.
    /// If no default value is passed then <c>0</c> is returned in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <returns>Returns a value of type Float64 if successful, otherwise returns the default value if passed or <c>0</c> if not.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToFloat64OrDefault(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toFloat64OrDefault</remarks>
    public static double ToFloat64OrDefault(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToFloat64(DbFunctions, string)"/>, this function converts an input value to a value of type
    /// Float64 but returns the default value in case of an error.
    /// If no default value is passed then <c>0</c> is returned in case of an error.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">Expression returning a number or a string representation of a number.</param>
    /// <returns>Returns a value of type Float64 if successful, otherwise returns the default value if passed or <c>0</c> if not.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToFloat64OrDefault(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toFloat64OrDefault</remarks>
    public static double ToFloat64OrDefault(this DbFunctions _, string expr, double defaultValue)
    {
        throw new InvalidOperationException();
    }
}
