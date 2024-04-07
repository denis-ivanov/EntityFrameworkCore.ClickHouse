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
}
