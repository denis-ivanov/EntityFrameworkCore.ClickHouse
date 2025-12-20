using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ClickHouse.EntityFrameworkCore.Metadata.Builders;

public class ClickHouseReplacingMergeTreeEngineBuilder : ClickHouseEngineBuilder
{
    public ClickHouseReplacingMergeTreeEngineBuilder(IMutableAnnotatable builder) : base(builder)
    {
    }

    public ClickHouseReplacingMergeTreeEngineBuilder WithPartitionBy([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetPartitionBy(columns);

        return this;
    }

    public ClickHouseReplacingMergeTreeEngineBuilder WithOrderBy([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetOrderBy(columns);

        return this;
    }

    public ClickHouseReplacingMergeTreeEngineBuilder WithPrimaryKey([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetPrimaryKey(columns);

        return this;
    }

    public ClickHouseReplacingMergeTreeEngineBuilder WithSampleBy([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetSampleBy(columns);

        return this;
    }

    public override void SpecifyEngine(MigrationCommandListBuilder builder, TableOperation table, ISqlGenerationHelper sql)
    {
        var version = table.GetReplacingMergeTreeVersion();
        var isDeleted = table.GetReplacingMergeTreeIsDeleted();
        var engineArg = string.Join(", ", (new[] { version, isDeleted }).Where(e => !string.IsNullOrEmpty(e)));

        builder.Append($" ENGINE = ReplacingMergeTree({engineArg})").AppendLine();

        AddPartitionBy(builder, table.GetPartitionBy(), sql);
        AddOrderBy(builder, table.GetOrderBy(), sql);
        AddPrimaryKey(builder, table.GetPrimaryKey(), sql);
        AddSampleBy(builder, table.GetSampleBy(), sql);
    }
}
