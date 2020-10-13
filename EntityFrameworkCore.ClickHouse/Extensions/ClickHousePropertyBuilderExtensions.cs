using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClickHouse.EntityFrameworkCore.Extensions
{
    public static class ClickHousePropertyBuilderExtensions
    {
        public static PropertyBuilder<string> FixedString(this PropertyBuilder<string> builder, int n)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.HasColumnType($"FixedString({n})")
                .HasMaxLength(n)
                .IsUnicode()
                .IsFixedLength()
                .IsRequired();
        }
    }
}