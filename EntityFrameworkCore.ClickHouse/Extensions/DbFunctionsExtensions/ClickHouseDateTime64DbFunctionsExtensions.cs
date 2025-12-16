using System;
using System.ComponentModel.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseDateTime64DbFunctionsExtensions
{
    /// <summary>
    /// Converts an input value to a value of type DateTime64.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified datetime64 object.</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified datetime64 object.</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified datetime64 object.</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size (precision).</param>
    /// <param name="timeZone">Time zone of the specified datetime64 object.</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size</param>
    /// <param name="timeZone">Time zone of the specified datetime64 object.</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size</param>
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
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">The value.</param>
    /// <param name="scale">Tick size</param>
    /// <param name="timeZone">Time zone of the specified DateTime64 object.</param>
    /// <returns>A calendar date and time of day, with sub-second precision, otherwise the minimum value of DateTime64: 1970-01-01 01:00:00.000</returns>
    /// <exception cref="InvalidOperationException">
    /// <see cref="ToDateTime64OrZero(DbFunctions, float, byte, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
    /// </exception>
    public static DateTime ToDateTime64OrZero(this DbFunctions _, float expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    public static DateTime? ToDateTime64OrNull(this DbFunctions _, string expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrNull(this DbFunctions _, string expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrNull(this DbFunctions _, uint expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrNull(this DbFunctions _, uint expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrNull(this DbFunctions _, DateTime expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrNull(this DbFunctions _, DateTime expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }
    
    public static DateTime ToDateTime64OrNull(this DbFunctions _, float expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrNull(this DbFunctions _, float expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    public static DateTime? ToDateTime64OrDefault(this DbFunctions _, string expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrDefault(this DbFunctions _, string expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrDefault(this DbFunctions _, uint expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrDefault(this DbFunctions _, uint expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrDefault(this DbFunctions _, DateTime expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrDefault(this DbFunctions _, DateTime expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }
    
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, float expr, [Range(0, 9)] byte scale)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrDefault(this DbFunctions _, float expr, [Range(0, 9)] byte scale, string timeZone)
    {
        throw new InvalidOperationException();
    }
    
    public static DateTime? ToDateTime64OrDefault(this DbFunctions _, string expr, [Range(0, 9)] byte scale, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrDefault(this DbFunctions _, string expr, [Range(0, 9)] byte scale, string timeZone, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrDefault(this DbFunctions _, uint expr, [Range(0, 9)] byte scale, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrDefault(this DbFunctions _, uint expr, [Range(0, 9)] byte scale, string timeZone, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrDefault(this DbFunctions _, DateTime expr, [Range(0, 9)] byte scale, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrDefault(this DbFunctions _, DateTime expr, [Range(0, 9)] byte scale, string timeZone, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }
    
    public static DateTime ToDateTime64OrDefault(this DbFunctions _, float expr, [Range(0, 9)] byte scale, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }

    public static DateTime ToDateTime64OrDefault(this DbFunctions _, float expr, [Range(0, 9)] byte scale, string timeZone, DateTime defaultValue)
    {
        throw new InvalidOperationException();
    }
}
