using System;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseUuidDbFunctionsExtensions
{
    /// <summary>
    /// Converts a String value to a UUID value.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="expr">UUID as a string.</param>
    /// <returns></returns>
    public static Guid ToUuid(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static Guid ToUuidOrZero(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static Guid? ToUuidOrNull(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static Guid ToUuidOrDefault(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static Guid ToUuidOrDefault(this DbFunctions _, string expr, Guid defaultValue)
    {
        throw new InvalidOperationException();
    }
}
