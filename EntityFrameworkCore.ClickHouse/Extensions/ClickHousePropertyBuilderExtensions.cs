using ClickHouse.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ClickHouse.EntityFrameworkCore.Extensions;

public static class ClickHousePropertyBuilderExtensions
{
    public static PropertyBuilder<string> FixedString(this PropertyBuilder<string> builder, int n)
    {
        ArgumentNullException.ThrowIfNull(builder);

        return builder.HasColumnType($"FixedString({n})")
            .HasMaxLength(n)
            .IsUnicode()
            .IsFixedLength()
            .IsRequired();
    }

    public static PropertyBuilder Ttl(this PropertyBuilder builder, string ttl)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentException.ThrowIfNullOrWhiteSpace(ttl);

        return builder.HasAnnotation(ClickHouseAnnotationNames.ColumnTtl, ttl);
    }

    public static string GetTtl<T>(this PropertyBuilder<T> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        return (string)builder.Metadata.FindAnnotation(ClickHouseAnnotationNames.ColumnTtl)?.Value;
    }
}
