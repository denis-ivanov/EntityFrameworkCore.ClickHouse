using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ClickHouse.EntityFrameworkCore.Metadata.Builders;

public class ClickHouseSummingMergeTreeEngineBuilder : ClickHouseEngineBuilder
{
    public ClickHouseSummingMergeTreeEngineBuilder(IMutableAnnotatable builder) : base(builder)
    {
    }

    public ClickHouseSummingMergeTreeEngineBuilder WithPartitionBy([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetPartitionBy(columns);

        return this;
    }

    public ClickHouseSummingMergeTreeEngineBuilder WithPrimaryKey([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetPrimaryKey(columns);

        return this;
    }

    public ClickHouseSummingMergeTreeEngineBuilder WithOrderBy([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetOrderBy(columns);

        return this;
    }

    public ClickHouseSummingMergeTreeEngineBuilder WithSampleBy([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetSampleBy(columns);

        return this;
    }

    public override void SpecifyEngine(MigrationCommandListBuilder builder, TableOperation table, ISqlGenerationHelper sql)
    {
        var column = table.GetSummingMergeTreeColumn();
        string engineArg = null;

        if (!string.IsNullOrEmpty(column))
        {
            engineArg = IsFunctionCall(column) ? column : sql.DelimitIdentifier(column);
        }

        builder.Append($" ENGINE = SummingMergeTree({engineArg})").AppendLine();

        AddPartitionBy(builder, table.GetPartitionBy(), sql);
        AddOrderBy(builder, table.GetOrderBy(), sql);
        AddSampleBy(builder, table.GetSampleBy(), sql);
    }
}
