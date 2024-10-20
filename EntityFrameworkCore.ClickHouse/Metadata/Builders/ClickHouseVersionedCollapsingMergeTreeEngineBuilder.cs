using System;
using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;

namespace ClickHouse.EntityFrameworkCore.Metadata.Builders;

public class ClickHouseVersionedCollapsingMergeTreeEngineBuilder : ClickHouseCollapsingMergeTreeEngineBuilder
{
    public ClickHouseVersionedCollapsingMergeTreeEngineBuilder(IMutableAnnotatable builder) : base(builder)
    {
    }

    public override ClickHouseCollapsingMergeTreeEngineBuilder WithPartitionBy(params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetPartitionBy(columns);

        return this;
    }

    public override ClickHouseCollapsingMergeTreeEngineBuilder WithOrderBy(params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetOrderBy(columns);

        return this;
    }

    public override ClickHouseCollapsingMergeTreeEngineBuilder WithSampleBy(params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetSampleBy(columns);

        return this;
    }

    public override void SpecifyEngine(MigrationCommandListBuilder builder, TableOperation table, ISqlGenerationHelper sql)
    {
        var sign = sql.DelimitIdentifier(table.GetVersionedCollapsingMergeTreeSign());
        var version = sql.DelimitIdentifier(table.GetVersionedCollapsingMergeTreeVersion());

        builder.Append($" ENGINE = VersionedCollapsingMergeTree({sign}, {version})").AppendLine();

        AddPartitionBy(builder, table.GetPartitionBy(), sql);
        AddOrderBy(builder, table.GetOrderBy(), sql);
        AddSampleBy(builder, table.GetSampleBy(), sql);
    }
}
