using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseEntityTypeBuilderExtensions
{
    public static ClickHouseMergeTreeEngineBuilder UseMergeTreeEngine(this TableBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var engine = new ClickHouseMergeTreeEngineBuilder(builder.Metadata);
        builder.Metadata.SetMergeTreeTableEngine();

        return engine;
    }

    public static ClickHouseReplacingMergeTreeEngineBuilder UseReplacingMergeTreeEngine(this TableBuilder builder)
    {
        return UseReplacingMergeTreeEngine(builder, null, null);
    }

    public static ClickHouseReplacingMergeTreeEngineBuilder UseReplacingMergeTreeEngine(this TableBuilder builder, string version)
    {
        return UseReplacingMergeTreeEngine(builder, version, null);
    }

    public static ClickHouseReplacingMergeTreeEngineBuilder UseReplacingMergeTreeEngine(this TableBuilder builder, string? version, string? isDeleted)
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

    public static ClickHouseSummingMergeTreeEngineBuilder UseSummingMergeTreeEngine(this TableBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var engine = new ClickHouseSummingMergeTreeEngineBuilder(builder.Metadata);
        builder.Metadata.SetSummingMergeTreeTableEngine(null);

        return engine;
    }

    public static ClickHouseSummingMergeTreeEngineBuilder UseSummingMergeTreeEngine(this TableBuilder builder, string[] columns)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var engine = new ClickHouseSummingMergeTreeEngineBuilder(builder.Metadata);
        builder.Metadata.SetSummingMergeTreeTableEngine(columns);

        return engine;
    }

    public static ClickHouseAggregatingMergeTreeEngineBuilder UseAggregatingMergeTreeEngine(this TableBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var engine = new ClickHouseAggregatingMergeTreeEngineBuilder(builder.Metadata);
        builder.Metadata.SetAggregatingMergeTreeTableEngine();

        return engine;
    }

    public static ClickHouseCollapsingMergeTreeEngineBuilder UseCollapsingMergeTreeEngine(this TableBuilder builder, string sign)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentException.ThrowIfNullOrWhiteSpace(sign);

        var engine = new ClickHouseCollapsingMergeTreeEngineBuilder(builder.Metadata);
        builder.Metadata.SetCollapsingMergeTreeTableEngine(sign);

        return engine;
    }

    public static ClickHouseVersionedCollapsingMergeTreeEngineBuilder UseVersionedCollapsingMergeTreeEngine(this TableBuilder builder, string sign, string version)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentException.ThrowIfNullOrEmpty(sign);
        ArgumentException.ThrowIfNullOrEmpty(version);

        var engine = new ClickHouseVersionedCollapsingMergeTreeEngineBuilder(builder.Metadata);
        builder.Metadata.SetVersionedCollapsingMergeTreeTableEngine(sign, version);

        return engine;
    }

    public static ClickHouseGraphiteMergeTreeEngineBuilder UseGraphiteMergeTreeEngine(this TableBuilder builder, string configSection)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentException.ThrowIfNullOrWhiteSpace(configSection);

        var engine = new ClickHouseGraphiteMergeTreeEngineBuilder(builder.Metadata);
        builder.Metadata.SetGraphiteMergeTreeTableEngine(configSection);

        return engine;
    }

    public static ClickHouseTinyLogEngineBuilder UseTinyLogEngine(this TableBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var engine = new ClickHouseTinyLogEngineBuilder(builder.Metadata);
        builder.Metadata.SetTinyLogTableEngine();

        return engine;
    }

    public static ClickHouseStripeLogEngineBuilder UseStripeLogEngine(this TableBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var engine = new ClickHouseStripeLogEngineBuilder(builder.Metadata);
        builder.Metadata.SetStripeLogTableEngine();

        return engine;
    }

    public static ClickHouseStripeLogEngineBuilder UseLogEngine(this TableBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var engine = new ClickHouseStripeLogEngineBuilder(builder.Metadata);
        builder.Metadata.SetLogTableEngine();

        return engine;
    }
}
