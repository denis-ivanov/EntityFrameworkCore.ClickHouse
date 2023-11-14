﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickHouse.EntityFrameworkCore.Storage.Engines;

public class StripeLogEngine : ClickHouseEngine
{
    public override void SpecifyEngine(MigrationCommandListBuilder builder, IModel model)
    {
        builder.AppendLine(" ENGINE = StripeLog;");
    }
}
