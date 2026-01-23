using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseEnumerable
{
    public static TResult Any<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        throw new InvalidOperationException();
    }

    public static TResult? AnyRespectNulls<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult?> selector)
    {
        throw new InvalidOperationException();
    }
}
