using ClickHouse.EntityFrameworkCore.Metadata;
using ClickHouse.EntityFrameworkCore.Storage.Engines;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ClickHouse.EntityFrameworkCore.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<T> HasMergeTreeEngine<T>(
        [NotNull] this EntityTypeBuilder<T> builder,
        [NotNull] string orderBy) where T : class
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(orderBy);

        return builder.HasMergeTreeEngine(orderBy, e => { });
    }

    public static EntityTypeBuilder<T> HasMergeTreeEngine<T>(
        [NotNull] this EntityTypeBuilder<T> builder,
        [NotNull] string orderBy,
        [NotNull] Action<MergeTreeEngine<T>> configure) where T : class
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(orderBy);
        ArgumentNullException.ThrowIfNull(configure);

        var engine = new MergeTreeEngine<T>(orderBy);
        configure(engine);

        builder.Metadata.SetOrRemoveAnnotation(ClickHouseAnnotationNames.Engine, engine);
        return builder;
    }

    public static EntityTypeBuilder<T> HasStripeLogEngine<T>([NotNull] this EntityTypeBuilder<T> builder)
        where T : class
    {
        ArgumentNullException.ThrowIfNull(builder);

        var engine = new StripeLogEngine();
        builder.Metadata.SetOrRemoveAnnotation(ClickHouseAnnotationNames.Engine, engine);
        return builder;
    }
}
