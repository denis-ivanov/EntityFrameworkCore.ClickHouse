using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseDateTimeDbFunctionsExtensions
{
    /// <param name="_">DbFunctions instance.</param>
    extension(DbFunctions _)
    {
        /// <summary>
        /// Converts an input value to type DateTime.
        /// </summary>
        /// <param name="expr">The value.</param>
        /// <typeparam name="TNumber"></typeparam>
        /// <returns>Returns a date time.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDateTime{TNumber}(DbFunctions, TNumber)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDateTime</remarks>
        public DateTime ToDateTime<TNumber>(TNumber expr) where TNumber : INumber<TNumber>
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to type DateTime.
        /// </summary>
        /// <param name="expr">The value.</param>
        /// <returns>Returns a date time.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDateTime(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDateTime</remarks>
        public DateTime ToDateTime(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to type DateTime.
        /// </summary>
        /// <param name="expr">The value.</param>
        /// <returns>Returns a date time.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDateTime(DbFunctions, DateOnly)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDateTime</remarks>
        public DateTime ToDateTime(DateOnly expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to type DateTime.
        /// </summary>
        /// <param name="expr">The value.</param>
        /// <param name="timeZone">Time zone.</param>
        /// <returns>Returns a date time.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDateTime{TNumber}(DbFunctions, TNumber, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDateTime</remarks>
        public DateTime ToDateTime<TNumber>(TNumber expr, string timeZone) where TNumber : INumber<TNumber>
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to type DateTime.
        /// </summary>
        /// <param name="expr">The value.</param>
        /// <param name="timeZone">Time zone.</param>
        /// <returns>Returns a date time.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDateTime(DbFunctions, string, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDateTime</remarks>
        public DateTime ToDateTime(string expr, string timeZone)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to type DateTime.
        /// </summary>
        /// <param name="expr">The value.</param>
        /// <param name="timeZone">Time zone.</param>
        /// <returns>Returns a date time.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDateTime(DbFunctions, DateOnly, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDateTime</remarks>
        public DateTime ToDateTime(DateOnly expr, string timeZone)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to a value of type DateTime but returns the lower boundary of DateTime
        /// if an invalid argument is received.
        /// The same as toDateTime but returns lower boundary of DateTime if an invalid argument is received.
        /// </summary>
        /// <param name="expr">The value.</param>
        /// <returns>Returns a date time.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDateTimeOrZero(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDateTimeOrZero</remarks>
        public DateTime ToDateTimeOrZero(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to a value of type DateTime but returns <c>null</c> if an invalid argument is received.
        /// The same as <see cref="ToDateTime(DbFunctions, string)"/> but returns <c></c> if an invalid argument is received.
        /// </summary>
        /// <param name="expr">The value.</param>
        /// <returns>Returns a date time.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDateTimeOrNull(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDateTimeOrNull</remarks>
        public DateTime? ToDateTimeOrNull(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like toDateTime but if unsuccessful, returns a default value which is either the third argument (if specified),
        /// or otherwise the lower boundary of DateTime.
        /// </summary>
        /// <param name="expr">The value.</param>
        /// <returns>Returns a date time.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDateTimeOrNull(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDateTimeOrDefault</remarks>
        public DateTime ToDateTimeOrDefault(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like toDateTime but if unsuccessful, returns a default value which is either the third argument (if specified),
        /// or otherwise the lower boundary of DateTime.
        /// </summary>
        /// <param name="expr">The value.</param>
        /// <param name="timeZone">Time zone.</param>
        /// <returns>Returns a date time.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDateTimeOrNull(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDateTimeOrDefault</remarks>
        public DateTime ToDateTimeOrDefault(string expr, string timeZone)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Like toDateTime but if unsuccessful, returns a default value which is either the third argument (if specified),
        /// or otherwise the lower boundary of DateTime.
        /// </summary>
        /// <param name="expr">The value.</param>
        /// <param name="timeZone">Time zone.</param>
        /// <param name="defaultValue">The default value to return if parsing is unsuccessful.</param>
        /// <returns>Returns a date time.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDateTimeOrNull(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDateTimeOrDefault</remarks>
        public DateTime ToDateTimeOrDefault(string expr, string timeZone, DateTime defaultValue)
        {
            throw new InvalidOperationException();
        }
    }
}
