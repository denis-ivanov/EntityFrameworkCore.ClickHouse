using System;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseUuidDbFunctionsExtensions
{
    /// <param name="_">DbFunctions instance.</param>
    extension(DbFunctions _)
    {
        /// <summary>
        /// Converts a String value to a UUID value.
        /// </summary>
        /// <param name="expr">UUID as a string.</param>
        /// <returns>Returns a UUID from the string representation of the UUID.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToUuid(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        /// <remarks>https://clickhouse.com/docs/sql-reference/functions/type-conversion-functions#toUUID</remarks>
        public Guid ToUuid(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts an input value to a value of type UUID but returns zero UUID in case of an error.
        /// Like <see cref="ToUuid(DbFunctions, string)"/> but returns zero UUID (00000000-0000-0000-0000-000000000000)
        /// instead of throwing an exception on conversion errors.
        /// </summary>
        /// <param name="expr">A string representation of a UUID.</param>
        /// <returns>Returns a UUID value if successful, otherwise zero UUID (00000000-0000-0000-0000-000000000000).</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToUuid(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        public Guid ToUuidOrZero(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts a String value to a UUID value or returns <c>null</c> if the string representation is invalid.
        /// </summary>
        /// <param name="expr">UUID as a string.</param>
        /// <returns>Returns a UUID from the string representation of the UUID, or <c>null</c> if conversion fails.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToUuidOrNull(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        public Guid? ToUuidOrNull(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts a String value to a UUID value or returns a default UUID if conversion is not possible.
        /// </summary>
        /// <param name="expr">UUID as a string.</param>
        /// <returns>Returns a UUID from the string representation of the UUID or a default UUID if the input is invalid.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToUuidOrDefault(DbFunctions, string)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        public Guid ToUuidOrDefault(string expr)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts a string value to a UUID value or returns the provided default value if the conversion is not possible.
        /// </summary>
        /// <param name="expr">The string representation of the UUID.</param>
        /// <param name="defaultValue">The default value to return if the conversion is not possible.</param>
        /// <returns>Returns a UUID parsed from the string representation, or the default value if the conversion fails.</returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ToUuidOrDefault(DbFunctions, string, Guid)"/> is only intended for use via SQL translation as part of an EF Core LINQ query.
        /// </exception>
        public Guid ToUuidOrDefault(string expr, Guid defaultValue)
        {
            throw new InvalidOperationException();
        }
    }
}
