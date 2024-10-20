using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseEntityTypeBuilderExtensions
{
    public static ClickHouseMergeTreeEngineBuilder HasMergeTreeEngine([NotNull] this TableBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var engine = new ClickHouseMergeTreeEngineBuilder(builder.Metadata);
        builder.Metadata.SetMergeTreeTableEngine();

        return engine;
    }

    public static ClickHouseReplacingMergeTreeEngineBuilder HasReplacingMergeTreeEngine([NotNull] this TableBuilder builder)
    {
        return HasReplacingMergeTreeEngine(builder, null, null);
    }

    public static ClickHouseReplacingMergeTreeEngineBuilder HasReplacingMergeTreeEngine(
        [NotNull] this TableBuilder builder,
        string version)
    {
        return HasReplacingMergeTreeEngine(builder, version, null);
    }

    public static ClickHouseReplacingMergeTreeEngineBuilder HasReplacingMergeTreeEngine(
        [NotNull] this TableBuilder builder,
        string version,
        string isDeleted)
    {
        ArgumentNullException.ThrowIfNull(builder);

        if (string.IsNullOrEmpty(version) && !string.IsNullOrEmpty(isDeleted))
        {
            throw new ArgumentException("isDeleted must be null");
        }

        var engine = new ClickHouseReplacingMergeTreeEngineBuilder(builder.Metadata);
        builder.Metadata.SetReplacingMergeTreeTableEngine(version, isDeleted);

        return engine;
    }

    public static ClickHouseSummingMergeTreeEngineBuilder HasSummingMergeTreeEngine([NotNull] this TableBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var engine = new ClickHouseSummingMergeTreeEngineBuilder(builder.Metadata);
        builder.Metadata.SetSummingMergeTreeTableEngine();

        return engine;
    }

    public static ClickHouseAggregatingMergeTreeEngineBuilder HasAggregatingMergeTreeEngine([NotNull] this TableBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var engine = new ClickHouseAggregatingMergeTreeEngineBuilder(builder.Metadata);
        builder.Metadata.SetAggregatingMergeTreeTableEngine();

        return engine;
    }

    public static ClickHouseCollapsingMergeTreeEngineBuilder HasCollapsingMergeTreeEngine([NotNull] this TableBuilder builder, string sign)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentException.ThrowIfNullOrWhiteSpace(sign);

        var engine = new ClickHouseCollapsingMergeTreeEngineBuilder(builder.Metadata);
        builder.Metadata.SetCollapsingMergeTreeTableEngine(sign);

        return engine;
    }

    public static ClickHouseVersionedCollapsingMergeTreeEngineBuilder HasVersionedCollapsingMergeTreeEngine(
        [NotNull] this TableBuilder builder,
        string sign,
        string version)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentException.ThrowIfNullOrEmpty(sign);
        ArgumentException.ThrowIfNullOrEmpty(version);

        var engine = new ClickHouseVersionedCollapsingMergeTreeEngineBuilder(builder.Metadata);
        builder.Metadata.SetVersionedCollapsingMergeTreeTableEngine(sign, version);

        return engine;
    }

    public static ClickHouseStripeLogEngineBuilder HasStripeLogEngine([NotNull] this TableBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var engine = new ClickHouseStripeLogEngineBuilder(builder.Metadata);
        builder.Metadata.SetStripeLogTableEngine();

        return engine;
    }
}
