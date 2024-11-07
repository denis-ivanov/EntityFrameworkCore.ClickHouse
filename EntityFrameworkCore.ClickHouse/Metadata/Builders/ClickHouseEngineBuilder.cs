using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;

namespace ClickHouse.EntityFrameworkCore.Metadata.Builders;

public abstract class ClickHouseEngineBuilder
{
    private const string OrderByOption = "ORDER BY";
    private const string PartitionByOption = "PARTITION BY";
    private const string PrimaryKeyOption = "PRIMARY KEY";
    private const string SampleByOption = "SAMPLE BY";

    public ClickHouseEngineBuilder(IMutableAnnotatable builder)
    {
        Builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    protected IMutableAnnotatable Builder { get; }

    public abstract void SpecifyEngine(
        MigrationCommandListBuilder builder,
        TableOperation table,
        ISqlGenerationHelper sql);

    protected void AddOrderBy(MigrationCommandListBuilder builder, string[] columns, ISqlGenerationHelper sql)
    {
        AddOption(builder, OrderByOption, columns, sql);
    }

    protected void AddPartitionBy(MigrationCommandListBuilder builder, string[] columns, ISqlGenerationHelper sql)
    {
        AddOption(builder, PartitionByOption, columns, sql);
    }

    protected void AddPrimaryKey(MigrationCommandListBuilder builder, string[] columns, ISqlGenerationHelper sql)
    {
        AddOption(builder, PrimaryKeyOption, columns, sql);
    }

    protected void AddSampleBy(MigrationCommandListBuilder builder, string[] columns, ISqlGenerationHelper sql)
    {
        AddOption(builder, SampleByOption, columns, sql);
    }

    private void AddOption(MigrationCommandListBuilder builder, string optionName, string[] columns, ISqlGenerationHelper sql)
    {
        if (columns is { Length: > 0 })
        {
            builder.AppendLine($"{optionName} ({ConcatColumns(columns, sql)})");
        }
    }

    private static string ConcatColumns(string[] columns, ISqlGenerationHelper sql)
    {
        return string.Join(", ", columns.Select(column => IsFunctionCall(column) ? column : sql.DelimitIdentifier(column)));
    }

    protected static bool IsFunctionCall(string expression)
    {
        return !string.IsNullOrWhiteSpace(expression) &&
               expression.Contains('(') &&
               expression.Contains(')');
    }
}
