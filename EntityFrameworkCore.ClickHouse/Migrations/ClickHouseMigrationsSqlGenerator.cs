using System;
using ClickHouse.EntityFrameworkCore.Metadata;
using ClickHouse.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ClickHouse.EntityFrameworkCore.Migrations
{
    public class ClickHouseMigrationsSqlGenerator : MigrationsSqlGenerator
    {
        public ClickHouseMigrationsSqlGenerator(MigrationsSqlGeneratorDependencies dependencies) : base(dependencies)
        {
        }

        protected override void ColumnDefinition(string schema, string table, string name, ColumnOperation operation, IModel model,
            MigrationCommandListBuilder builder)
        {
            var columnType = operation.ColumnType ?? GetColumnType(schema, table, name, operation, model);
            builder
                .Append(Dependencies.SqlGenerationHelper.DelimitIdentifier(name))
                .Append(" ")
                .Append(operation.IsNullable ? $" Nullable({columnType})" : columnType);
        }
        
        protected override void Generate(MigrationOperation operation, IModel model, MigrationCommandListBuilder builder)
        {
            if (operation is ClickHouseCreateDatabaseOperation cdo)
            {
                Generate(cdo, model, builder);
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

        protected override void Generate(CreateTableOperation operation, IModel model, MigrationCommandListBuilder builder, bool terminate = true)
        {
            base.Generate(operation, model, builder, false);
            
            var engine = operation.FindAnnotation(ClickHouseAnnotationNames.Engine);

            if (engine?.Value == null)
            {
                throw new InvalidOperationException("Specify engine in table configuration.");
            }

            if (engine.Value is string engineValue)
            {
                builder.AppendLine("ENGINE = " + engineValue);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
