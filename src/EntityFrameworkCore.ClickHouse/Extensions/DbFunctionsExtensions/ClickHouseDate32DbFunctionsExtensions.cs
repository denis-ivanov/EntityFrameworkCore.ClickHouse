using System;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseDate32DbFunctionsExtensions
{
    /// <param name="_">DbFunctions instance.</param>
    extension(DbFunctions _)
    {
        /// <summary>
        /// Converts the argument to the Date32 data type. If the value is outside the range,
        /// toDate32 returns the border values supported by Date32. If the argument is of type Date, it's bounds are taken into
        /// </summary>
        /// <param name="expr">The value to convert.</param>
        /// <returns>Returns a calendar date.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDate32(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDate32</remarks>
        public DateOnly ToDate32(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts the argument to the Date32 data type. If the value is outside the range,
        /// toDate32 returns the border values supported by Date32. If the argument is of type Date, it's bounds are taken into
        /// </summary>
        /// <param name="expr">The value to convert.</param>
        /// <returns>Returns a calendar date.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDate32(DbFunctions, uint)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toDate32</remarks>
        public DateOnly ToDate32(uint expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// The same as <see cref="ToDate32(DbFunctions, string)"/> but returns the min value of Date32 if an invalid argument is received.
        /// </summary>
        /// <param name="expr">The value to convert.</param>
        /// <returns>Returns a calendar date.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDate32OrZero(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todate32orzero</remarks>
        public DateOnly ToDate32OrZero(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// The same as <see cref="ToDate32(DbFunctions, string)"/> but returns <c>null</c> if an invalid argument is received.
        /// </summary>
        /// <param name="expr">The value to convert.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDate32OrNull(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todate32ornull</remarks>
        public DateOnly? ToDate32OrNull(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts the argument to the Date32 data type.
        /// If the value is outside the range, toDate32OrDefault returns the lower border value supported by Date32.
        /// If the argument has Date type, it's borders are taken into account.
        /// Returns default value if an invalid argument is received.
        /// </summary>
        /// <param name="expr">The value to convert.</param>
        /// <returns>Returns a calendar date.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDate32OrDefault(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todate32ordefault</remarks>
        public DateOnly ToDate32OrDefault(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts the argument to the Date32 data type.
        /// If the value is outside the range, toDate32OrDefault returns the lower border value supported by Date32.
        /// If the argument has Date type, it's borders are taken into account.
        /// Returns default value if an invalid argument is received.
        /// </summary>
        /// <param name="expr">The value to convert.</param>
        /// <param name="defaultValue"></param>
        /// <returns>Returns a calendar date.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToDate32OrDefault(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#todate32ordefault</remarks>
        public DateOnly ToDate32OrDefault(string expr, DateOnly defaultValue)
        {
            throw new InvalidOperationException();
        }
    }
}
