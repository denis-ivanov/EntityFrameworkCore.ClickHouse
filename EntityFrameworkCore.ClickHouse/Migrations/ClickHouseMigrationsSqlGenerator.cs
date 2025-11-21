using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Text;

namespace ClickHouse.EntityFrameworkCore.Migrations;

public class ClickHouseMigrationsSqlGenerator : MigrationsSqlGenerator
{
    private readonly RelationalTypeMapping _stringTypeMapping;

    public ClickHouseMigrationsSqlGenerator(MigrationsSqlGeneratorDependencies dependencies) : base(dependencies)
    {
        _stringTypeMapping = dependencies.TypeMappingSource.FindMapping(typeof(string));
    }

    protected override void ComputedColumnDefinition(
        string schema,
        string table,
        string name,
        ColumnOperation operation,
        IModel model,
        MigrationCommandListBuilder builder)
    {
        var defaultValueType = operation.IsStored == true ? " MATERIALIZED " : " ALIAS ";

        var columnType = operation.ColumnType ?? GetColumnType(schema, table, name, operation, model);

        builder
            .Append(" ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(name))
            .Append(operation.IsNullable && !operation.ClrType.IsArray ? columnType.GetNullableType() : columnType)
            .Append(defaultValueType)
            .Append(operation.ComputedColumnSql!);
    }

    protected override void ColumnDefinition(
        string schema,
        string table,
        string name,
        ColumnOperation operation,
        IModel model,
        MigrationCommandListBuilder builder)
    {
        if (!string.IsNullOrEmpty(operation.ComputedColumnSql))
        {
            ComputedColumnDefinition(schema, table, name, operation, model, builder);
            return;
        }

        var columnType = operation.ColumnType ?? GetColumnType(schema, table, name, operation, model);
        builder
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(name))
            .Append(" ")
            .Append(operation.IsNullable && !operation.ClrType.IsArray ? columnType.GetNullableType() : columnType);

        var defaultValue = operation.DefaultValueSql;

        if (string.IsNullOrWhiteSpace(defaultValue) && operation.DefaultValue != null)
        {
            var typeMapping = (columnType != null
                                  ? Dependencies.TypeMappingSource.FindMapping(operation.DefaultValue.GetType(), columnType)
                                  : null)
                              ?? Dependencies.TypeMappingSource.GetMappingForValue(operation.DefaultValue);

            defaultValue = typeMapping.GenerateSqlLiteral(operation.DefaultValue);
        }

        if (!string.IsNullOrWhiteSpace(defaultValue))
        {
            builder.Append(" DEFAULT ").Append(defaultValue);
        }
    }

    protected override void Generate(MigrationOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        if (operation is ClickHouseCreateDatabaseOperation cdo)
        {
            Generate(cdo, model, builder);
            return;
        }

        if (operation is ClickHouseDropDatabaseOperation ddo)
        {
            Generate(ddo, model, builder);
            return;
        }
            
        base.Generate(operation, model, builder);
    }

    protected virtual void Generate(ClickHouseCreateDatabaseOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        builder
            .Append("CREATE DATABASE ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name))
            .AppendLine(";");
        EndStatement(builder, true);
    }

    protected virtual void Generate(ClickHouseDropDatabaseOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        builder.Append("DROP DATABASE ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name))
            .AppendLine(";");
        EndStatement(builder, true);
    }

    protected override void CreateTableConstraints(CreateTableOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        CreateTableCheckConstraints(operation, model, builder);
    }

    protected override void Generate(CreateTableOperation operation, IModel model, MigrationCommandListBuilder builder, bool terminate = true)
    {
        base.Generate(operation, model, builder, false);

        var engineBuilder = operation.GetEngineBuilder();
        engineBuilder.SpecifyEngine(builder, operation, Dependencies.SqlGenerationHelper);

        builder.AppendLine(Dependencies.SqlGenerationHelper.StatementTerminator);
        EndStatement(builder);

        if (!string.IsNullOrEmpty(operation.Comment))
        {
            ModifyComment(operation, builder);
        }

        operation.Columns
            .FindAll(e => !string.IsNullOrEmpty(e.Comment))
            .ForEach(e => ModifyComment(e, builder));
    }

    protected override void Generate(InsertDataOperation operation, IModel model, MigrationCommandListBuilder builder, bool terminate = true)
    {
        foreach (var modificationCommand in GenerateModificationCommands(operation, model))
        {
            var sqlBuilder = new StringBuilder();

            SqlGenerator.AppendInsertOperation(
                sqlBuilder,
                modificationCommand,
                0);

            builder.Append(sqlBuilder.ToString());

            EndStatement(builder);
        }
    }

    protected override void Generate(AlterColumnOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        builder
            .Append("ALTER TABLE ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Table))
            .Append(" MODIFY COLUMN ");

        ColumnDefinition(operation.Schema, operation.Table, operation.Name, operation, model, builder);

        EndStatement(builder);

        if (!string.IsNullOrEmpty(operation.Comment) ||
            (!string.IsNullOrEmpty(operation.OldColumn.Comment) && string.IsNullOrEmpty(operation.Comment)))
        {
            ModifyComment(operation, builder);
        }
    }

    protected override void Generate(RenameTableOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        builder
            .Append("RENAME TABLE ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name))
            .Append(" TO ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.NewName));

        EndStatement(builder);
    }

    protected override void Generate(RenameColumnOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        builder
            .Append("ALTER TABLE ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Table))
            .Append(" RENAME COLUMN ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name))
            .Append(" TO ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.NewName));

        EndStatement(builder);
    }

    protected override void Generate(AddColumnOperation operation, IModel model, MigrationCommandListBuilder builder, bool terminate = true)
    {
        builder
            .Append("ALTER TABLE ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Table, operation.Schema))
            .Append(" ADD COLUMN ");

        ColumnDefinition(operation, model, builder);

        EndStatement(builder);

        if (!string.IsNullOrWhiteSpace(operation.Comment))
        {
            builder
                .Append("ALTER TABLE ")
                .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Table))
                .Append(" COMMENT COLUMN ")
                .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name))
                .Append($"'{operation.Comment}'");

            EndStatement(builder);
        }
    }

    protected override void Generate(DropIndexOperation operation, IModel model, MigrationCommandListBuilder builder, bool terminate = true)
    {
        builder
            .Append("ALTER TABLE ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Table))
            .Append(" DROP INDEX ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name));

        EndStatement(builder);
    }

    protected override void Generate(AlterTableOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        base.Generate(operation, model, builder);

        if (!string.IsNullOrEmpty(operation.Comment) ||
            (!string.IsNullOrEmpty(operation.OldTable.Comment) && string.IsNullOrEmpty(operation.Comment)))
        {
            ModifyComment(operation, builder);
        }
    }

    protected override void Generate(
        DropPrimaryKeyOperation operation,
        IModel model,
        MigrationCommandListBuilder builder,
        bool terminate = true)
    {
    }

    protected override void Generate(
        AddPrimaryKeyOperation operation,
        IModel model,
        MigrationCommandListBuilder builder,
        bool terminate = true)
    {
    }

    private void ModifyComment(TableOperation operation, MigrationCommandListBuilder builder)
    {
        builder
            .Append("ALTER TABLE ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name))
            .Append(" MODIFY COMMENT ")
            .Append(_stringTypeMapping.GenerateSqlLiteral(operation.Comment ?? string.Empty));

        EndStatement(builder);
    }

    private void ModifyComment(ColumnOperation operation, MigrationCommandListBuilder builder)
    {
        builder
            .Append("ALTER TABLE ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Table))
            .Append(" COMMENT COLUMN ")
            .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(operation.Name))
            .Append(_stringTypeMapping.GenerateSqlLiteral(operation.Comment ?? string.Empty));

        EndStatement(builder);
    }

    protected override void Generate(DropSequenceOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        throw new NotSupportedException(ClickHouseExceptions.DoesNotSupportSequences);
    }

    protected override void Generate(AlterSequenceOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        throw new NotSupportedException(ClickHouseExceptions.DoesNotSupportSequences);
    }

    protected override void Generate(CreateSequenceOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        throw new NotSupportedException(ClickHouseExceptions.DoesNotSupportSequences);
    }

    protected override void Generate(RenameSequenceOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        throw new NotSupportedException(ClickHouseExceptions.DoesNotSupportSequences);
    }

    protected override void Generate(RestartSequenceOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        throw new NotSupportedException(ClickHouseExceptions.DoesNotSupportSequences);
    }

    protected override void Generate(EnsureSchemaOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        throw new NotSupportedException(ClickHouseExceptions.DoesNotSupportSchemas);
    }

    protected override void Generate(DropSchemaOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        throw new NotSupportedException(ClickHouseExceptions.DoesNotSupportSchemas);
    }

    protected override void Generate(AddUniqueConstraintOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        throw new NotSupportedException(ClickHouseExceptions.DoesNotSupportUniqueConstraints);
    }

    protected override void Generate(DropUniqueConstraintOperation operation, IModel model, MigrationCommandListBuilder builder)
    {
        throw new NotSupportedException(ClickHouseExceptions.DoesNotSupportUniqueConstraints);
    }

    protected override void Generate(CreateIndexOperation operation, IModel model, MigrationCommandListBuilder builder,
        bool terminate = true)
    {
        if (operation.IsUnique)
        {
            throw new NotSupportedException(ClickHouseExceptions.DoesNotSupportUniqueIndexes);
        }
        
        base.Generate(operation, model, builder, terminate);
    }
}
