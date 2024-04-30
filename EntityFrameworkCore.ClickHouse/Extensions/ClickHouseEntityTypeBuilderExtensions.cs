using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseEntityTypeBuilderExtensions
{
    public static ClickMergeTreeEngineBuilder HasMergeTreeEngine([NotNull] this TableBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var engine = new ClickMergeTreeEngineBuilder(builder.Metadata);

        builder.Metadata.SetMergeTreeTableEngine();

        return engine;
    }

    public static ClickStripeLogEngineBuilder HasStripeLogEngine([NotNull] this TableBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var engine = new ClickStripeLogEngineBuilder(builder.Metadata);

        builder.Metadata.SetStripeLogTableEngine();

        return engine;
    }
}
