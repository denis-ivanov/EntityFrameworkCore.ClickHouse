﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;

namespace ClickHouse.EntityFrameworkCore.Metadata.Builders;

public class ClickHouseLogEngineBuilder : ClickHouseEngineBuilder
{
    public ClickHouseLogEngineBuilder(IMutableAnnotatable builder) : base(builder)
    {
    }

    public override void SpecifyEngine(MigrationCommandListBuilder builder, TableOperation table, ISqlGenerationHelper sql)
    {
        builder.AppendLine(" ENGINE = Log;");
    }
}
