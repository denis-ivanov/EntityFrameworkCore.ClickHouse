using System;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseDate32DbFunctionsExtensions
{
    public static DateOnly ToDate32(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static DateOnly ToDate32(this DbFunctions _, uint expr)
    {
        throw new InvalidOperationException();
    }

    public static DateOnly ToDate32OrZero(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static DateOnly? ToDate32OrNull(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }
    
    public static DateOnly ToDate32OrDefault(this DbFunctions _, string expr)
    {
        throw new InvalidOperationException();
    }

    public static DateOnly ToDate32OrDefault(this DbFunctions _, string expr, DateOnly defaultValue)
    {
        throw new InvalidOperationException();
    }
}
