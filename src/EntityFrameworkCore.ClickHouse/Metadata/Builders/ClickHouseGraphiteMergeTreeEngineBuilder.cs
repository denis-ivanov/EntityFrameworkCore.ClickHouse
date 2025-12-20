using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ClickHouse.EntityFrameworkCore.Metadata.Builders;

public class ClickHouseGraphiteMergeTreeEngineBuilder : ClickHouseEngineBuilder
{
    public ClickHouseGraphiteMergeTreeEngineBuilder(IMutableAnnotatable builder) : base(builder)
    {
    }

    public ClickHouseGraphiteMergeTreeEngineBuilder WithPartitionBy([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetPartitionBy(columns);

        return this;
    }

    public ClickHouseGraphiteMergeTreeEngineBuilder WithOrderBy([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetOrderBy(columns);

        return this;
    }

    public ClickHouseGraphiteMergeTreeEngineBuilder WithSampleBy([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetSampleBy(columns);

        return this;
    }

    public override void SpecifyEngine(MigrationCommandListBuilder builder, TableOperation table, ISqlGenerationHelper sql)
    {
        var configSection = sql.DelimitIdentifier(table.GetGraphiteMergeTreeConfigSection());

        builder.Append($" ENGINE = GraphiteMergeTree({configSection})").AppendLine();

        AddOrderBy(builder, table.GetOrderBy(), sql);
        AddPartitionBy(builder, table.GetPartitionBy(), sql);
        AddSampleBy(builder, table.GetSampleBy(), sql);
    }
}
