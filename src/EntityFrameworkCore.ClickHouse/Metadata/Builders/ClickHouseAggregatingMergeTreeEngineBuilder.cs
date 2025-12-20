using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ClickHouse.EntityFrameworkCore.Metadata.Builders;

public class ClickHouseAggregatingMergeTreeEngineBuilder : ClickHouseEngineBuilder
{
    public ClickHouseAggregatingMergeTreeEngineBuilder(IMutableAnnotatable builder) : base(builder)
    {
    }

    public ClickHouseAggregatingMergeTreeEngineBuilder WithPartitionBy([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetPartitionBy(columns);

        return this;
    }

    public ClickHouseAggregatingMergeTreeEngineBuilder WithOrderBy([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetOrderBy(columns);

        return this;
    }

    public ClickHouseAggregatingMergeTreeEngineBuilder WithSampleBy([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetSampleBy(columns);

        return this;
    }

    public override void SpecifyEngine(MigrationCommandListBuilder builder, TableOperation table, ISqlGenerationHelper sql)
    {
        builder.Append(" ENGINE = AggregatingMergeTree()").AppendLine();

        AddPartitionBy(builder, table.GetPartitionBy(), sql);
        AddOrderBy(builder, table.GetOrderBy(), sql);
        AddSampleBy(builder, table.GetSampleBy(), sql);
    }
}
