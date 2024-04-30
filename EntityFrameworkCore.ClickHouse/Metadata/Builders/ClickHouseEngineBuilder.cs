using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace ClickHouse.EntityFrameworkCore.Metadata.Builders;

public abstract class ClickHouseEngineBuilder
{
    public ClickHouseEngineBuilder(IMutableAnnotatable builder)
    {
        Builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    protected IMutableAnnotatable Builder { get; }

    public abstract void SpecifyEngine(MigrationCommandListBuilder builder, TableOperation table,
        ISqlGenerationHelper sql);
}
