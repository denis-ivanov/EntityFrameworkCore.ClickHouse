﻿using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.IO;
using System.Text;

namespace ClickHouse.EntityFrameworkCore.Migrations.Internal;

public class ClickHouseHistoryRepository : HistoryRepository
{
    public ClickHouseHistoryRepository(HistoryRepositoryDependencies dependencies) : base(dependencies)
    {
    }

    protected override bool InterpretExistsResult(object value)
        => value != null && value != DBNull.Value && (byte)value == 1;

    public override string GetCreateIfNotExistsScript()
    {
        var builder = new StringBuilder();
        var isFirstLine = true;

        using (var reader = new StringReader(GetCreateScript()))
        {
            while (reader.ReadLine() is { } line)
            {
                if (!isFirstLine)
                {
                    builder.AppendLine();
                }
                isFirstLine = false;

                if (!string.IsNullOrWhiteSpace(line))
                {
                    builder.Append("    ").Append(line);
                }
            }
        }

        return builder.ToString();
    }

    public override string GetBeginIfNotExistsScript(string migrationId)
    {
        var stringTypeMapping = Dependencies.TypeMappingSource.GetMapping(typeof(string));

        return new StringBuilder()
            .AppendLine("IF NOT EXISTS (")
            .Append("    SELECT * FROM ")
            .AppendLine(SqlGenerationHelper.DelimitIdentifier(TableName, TableSchema))
            .Append("    WHERE ")
            .Append(SqlGenerationHelper.DelimitIdentifier(MigrationIdColumnName))
            .Append(" = ").AppendLine(stringTypeMapping.GenerateSqlLiteral(migrationId))
            .AppendLine(")")
            .Append("BEGIN")
            .ToString();
    }

    public override string GetBeginIfExistsScript(string migrationId)
    {
        var stringTypeMapping = Dependencies.TypeMappingSource.GetMapping(typeof(string));

        return new StringBuilder()
            .AppendLine("IF EXISTS (")
            .Append("    SELECT * FROM ")
            .AppendLine(SqlGenerationHelper.DelimitIdentifier(TableName, TableSchema))
            .Append("    WHERE ")
            .Append(SqlGenerationHelper.DelimitIdentifier(MigrationIdColumnName))
            .Append(" = ")
            .AppendLine(stringTypeMapping.GenerateSqlLiteral(migrationId))
            .AppendLine(")")
            .Append("BEGIN")
            .ToString();
    }

    public override string GetEndIfScript()
        => new StringBuilder()
            .Append("END")
            .AppendLine(SqlGenerationHelper.StatementTerminator)
            .ToString();

    protected override string ExistsSql
        => "EXISTS " +
           SqlGenerationHelper.DelimitIdentifier(TableName, TableSchema)
           + SqlGenerationHelper.StatementTerminator;
}
