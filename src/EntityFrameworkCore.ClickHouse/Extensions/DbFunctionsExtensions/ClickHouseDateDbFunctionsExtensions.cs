using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseDateDbFunctionsExtensions
{
    /// <summary>
    /// Converts an input value to type Date. Supports conversion from String, FixedString, DateTime, or numeric types.
    /// </summary>
    /// <param name="expr">Input value to convert.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <typeparam name="TNumber"></typeparam>
    /// <returns>Returns the converted input value.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDate{TNumber}(DbFunctions, TNumber)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDate</remarks>
    public static DateOnly ToDate<TNumber>(this DbFunctions _, TNumber expr) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to type Date. Supports conversion from String, FixedString, DateTime, or numeric types.
    /// </summary>
    /// <param name="expr">Input value to convert.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>Returns the converted input value.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDate(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDate</remarks>
    public static DateOnly ToDate(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to type Date. Supports conversion from String, FixedString, DateTime, or numeric types.
    /// </summary>
    /// <param name="expr">Input value to convert.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>Returns the converted input value.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDate(DbFunctions, DateTime)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDate</remarks>
    public static DateOnly ToDate(this DbFunctions _, DateTime expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to type Date. Supports conversion from String, FixedString, DateTime, or numeric types.
    /// </summary>
    /// <param name="expr">Input value to convert.</param>
    /// <param name="timeZone">Time zone of the specified Date object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <typeparam name="TNumber"></typeparam>
    /// <returns>Returns the converted input value.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDate{TNumber}(DbFunctions, TNumber, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDate</remarks>
    public static DateOnly ToDate<TNumber>(this DbFunctions _, TNumber expr, string timeZone) where TNumber : INumber<TNumber>
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to type Date. Supports conversion from String, FixedString, DateTime, or numeric types.
    /// </summary>
    /// <param name="expr">Input value to convert.</param>
    /// <param name="timeZone">Time zone of the specified Date object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>Returns the converted input value.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDate(DbFunctions, string, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDate</remarks>
    public static DateOnly ToDate(this DbFunctions _, string expr, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to type Date. Supports conversion from String, FixedString, DateTime, or numeric types.
    /// </summary>
    /// <param name="expr">Input value to convert.</param>
    /// <param name="timeZone">Time zone of the specified Date object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>Returns the converted input value.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDate(DbFunctions, string, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDate</remarks>
    public static DateOnly ToDate(this DbFunctions _, DateTime expr, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type Date but returns the lower boundary of Date if an invalid argument
    /// is received. The same as toDate but returns lower boundary of Date if an invalid argument is received.
    /// </summary>
    /// <param name="expr">A string representation of a date.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>Returns the converted input value.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateOrZero(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDateOrZero</remarks>
    public static DateOnly ToDateOrZero(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type Date but returns <c>null</c> if an invalid argument is received.
    /// The same as toDate but returns <c>null</c> if an invalid argument is received.
    /// </summary>
    /// <param name="expr">A string representation of a date.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>Returns the converted input value.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateOrNull(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDateOrNull</remarks>
    public static DateOnly? ToDateOrNull(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDate(DbFunctions, string)"/> but if unsuccessful, returns a default value which is either
    /// the second argument (if specified), or otherwise the lower boundary of Date.
    /// </summary>
    /// <param name="expr">A string representation of a date.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>Value of type Date if successful, otherwise returns the default value if passed or 1970-01-01 if not.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateOrDefault(DbFunctions, string, DateOnly)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateOnly ToDateOrDefault(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDate(DbFunctions, string)"/> but if unsuccessful, returns a default value which is either
    /// the second argument (if specified), or otherwise the lower boundary of Date.
    /// </summary>
    /// <param name="expr">A string representation of a date.</param>
    /// <param name="defaultValue">The default value to return if parsing is unsuccessful.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>Value of type Date if successful, otherwise returns the default value if passed or 1970-01-01 if not.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateOrDefault(DbFunctions, string, DateOnly)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateOnly ToDateOrDefault(this DbFunctions _, string expr, DateOnly defaultValue)
    {
        throw new InvalidOperationException();
    }
}
