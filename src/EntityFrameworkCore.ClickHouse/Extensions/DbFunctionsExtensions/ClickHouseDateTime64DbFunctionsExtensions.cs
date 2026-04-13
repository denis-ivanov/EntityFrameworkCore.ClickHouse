using System;
using System.ComponentModel.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseDateTime64DbFunctionsExtensions
{
    /// <summary>
    /// Converts an input value to a value of type DateTime64.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision.</returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64</remarks>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64(DbFunctions, string, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64(this DbFunctions _, string expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type DateTime64.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified datetime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision.</returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64</remarks>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64(DbFunctions, string, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64(this DbFunctions _, string expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type DateTime64.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision.</returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64</remarks>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64(DbFunctions, uint, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64(this DbFunctions _, uint expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type DateTime64.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified datetime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision.</returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64</remarks>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64(DbFunctions, uint, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64(this DbFunctions _, uint expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type DateTime64.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision.</returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64</remarks>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64(DbFunctions, DateOnly, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64(this DbFunctions _, DateOnly expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type DateTime64.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified datetime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision.</returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64</remarks>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64(DbFunctions, DateOnly, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64(this DbFunctions _, DateOnly expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type DateTime64.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision.</returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64</remarks>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64(DbFunctions, float, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64(this DbFunctions _, float expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Converts an input value to a value of type DateTime64.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified datetime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision.</returns>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64</remarks>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64(DbFunctions, float, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64(this DbFunctions _, float expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns the min value of DateTime64 if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64: 1970-01-01 01:00:00.000</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrZero(DbFunctions, string, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64OrZero(this DbFunctions _, string expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns the min value of DateTime64 if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified datetime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64: 1970-01-01 01:00:00.000</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrZero(DbFunctions, string, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64OrZero(this DbFunctions _, string expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns the min value of DateTime64 if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64: 1970-01-01 01:00:00.000</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrZero(DbFunctions, uint, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64OrZero(this DbFunctions _, uint expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns the min value of DateTime64 if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64: 1970-01-01 01:00:00.000</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrZero(DbFunctions, uint, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64OrZero(this DbFunctions _, uint expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns the min value of DateTime64 if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64: 1970-01-01 01:00:00.000</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrZero(DbFunctions, DateTime, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64OrZero(this DbFunctions _, DateTime expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns the min value of DateTime64 if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64: 1970-01-01 01:00:00.000</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrZero(DbFunctions, string, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64OrZero(this DbFunctions _, DateTime expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns the min value of DateTime64 if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64: 1970-01-01 01:00:00.000</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrZero(DbFunctions, float, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64OrZero(this DbFunctions _, float expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns the min value of DateTime64 if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64: 1970-01-01 01:00:00.000</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrZero(DbFunctions, float, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64OrZero(this DbFunctions _, float expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns <c>null</c> if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise <c>null</c>.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrNull(DbFunctions, string, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.</exception>
    public static DateTime? ToDateTime64OrNull(this DbFunctions _, string expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns <c>null</c> if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise <c>null</c>.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrNull(DbFunctions, string, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.</exception>
    public static DateTime? ToDateTime64OrNull(this DbFunctions _, string expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns <c>null</c> if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise <c>null</c>.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrNull(DbFunctions, uint, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.</exception>
    public static DateTime? ToDateTime64OrNull(this DbFunctions _, uint expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns <c>null</c> if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise <c>null</c>.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrNull(DbFunctions, uint, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.</exception>
    public static DateTime? ToDateTime64OrNull(this DbFunctions _, uint expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns <c>null</c> if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise <c>null</c>.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrNull(DbFunctions, DateTime, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.</exception>
    public static DateTime? ToDateTime64OrNull(this DbFunctions _, DateTime expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns <c>null</c> if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise <c>null</c>.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrNull(DbFunctions, DateTime, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.</exception>
    public static DateTime? ToDateTime64OrNull(this DbFunctions _, DateTime expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns <c>null</c> if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise <c>null</c>.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrNull(DbFunctions, float, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.</exception>
    public static DateTime? ToDateTime64OrNull(this DbFunctions _, float expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value of type DateTime64
    /// but returns <c>null</c> if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise <c>null</c>.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrNull(DbFunctions, float, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime? ToDateTime64OrNull(this DbFunctions _, float expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, string, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime? ToDateTime64OrDefault(this DbFunctions _, string expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, string, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, string expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, uint, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, uint expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, uint, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, uint expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, DateTime, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, DateTime expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, DateTime, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, DateTime expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, float, byte)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, float expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, float, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, float expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="defaultValue">Default value to return if an invalid argument is received.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, string, byte, DateTime)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime? ToDateTime64OrDefault(this DbFunctions _, string expr, [Range(0, 9)] byte scale, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="defaultValue">Default value to return if an invalid argument is received.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, string, byte, string, DateTime)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, string expr, [Range(0, 9)] byte scale, string timeZone, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="defaultValue">Default value to return if an invalid argument is received.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, uint, byte, DateTime)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, uint expr, [Range(0, 9)] byte scale, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="defaultValue">Default value to return if an invalid argument is received.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, uint, byte, string, DateTime)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, uint expr, [Range(0, 9)] byte scale, string timeZone, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="defaultValue">Default value to return if an invalid argument is received.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, DateTime, byte, DateTime)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, DateTime expr, [Range(0, 9)] byte scale, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="defaultValue">Default value to return if an invalid argument is received.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, DateTime, byte, string, DateTime)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, DateTime expr, [Range(0, 9)] byte scale, string timeZone, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="defaultValue">Default value to return if an invalid argument is received.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, float, byte, DateTime)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, float expr, [Range(0, 9)] byte scale, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Like <see cref="ToDateTime64(DbFunctions, string, byte)"/>, this function converts an input value to a value
    /// of type DateTime64, but returns either the default value of DateTime64 or the provided default
    /// if an invalid argument is received.
    /// </summary>
    /// <param name="expr">The value. </param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <param name="defaultValue">Default value to return if an invalid argument is received.</param>
    /// <param name="_">DbFunctions instance.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64 or the default value if provided.</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrDefault(DbFunctions, float, byte, DateTime)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todatetime64ordefault</remarks>
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, float expr, [Range(0, 9)] byte scale, string timeZone, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }
}
