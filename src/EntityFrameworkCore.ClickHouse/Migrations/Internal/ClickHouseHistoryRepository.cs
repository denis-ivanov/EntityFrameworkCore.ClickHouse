using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        var script = GetCreateScript();
        return script.Insert(script.IndexOf("CREATE TABLE", StringComparison.Ordinal) + 12, " IF NOT EXISTS");
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

    public override IMigrationsDatabaseLock AcquireDatabaseLock()
    {
        return new ClickHouseMigrationDatabaseLock(this);
    }

    public override Task<IMigrationsDatabaseLock> AcquireDatabaseLockAsync(CancellationToken cancellationToken = new())
    {
        return Task.FromResult<IMigrationsDatabaseLock>(new ClickHouseMigrationDatabaseLock(this));
    }

    protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
    {
        history.Property<string>(h => h.MigrationId).HasMaxLength(150);
        history.Property<string>(h => h.ProductVersion).HasMaxLength(32).IsRequired();
        history.ToTable("__EFMigrationsHistory", table => table
            .HasMergeTreeEngine()
            .WithPrimaryKey("MigrationId"));
    }

    public override string GetEndIfScript()
        => new StringBuilder()
            .Append("END")
            .AppendLine(SqlGenerationHelper.StatementTerminator)
            .ToString();

    public override LockReleaseBehavior LockReleaseBehavior => LockReleaseBehavior.Connection;

    protected override string ExistsSql
        => "EXISTS " +
           SqlGenerationHelper.DelimitIdentifier(TableName, TableSchema)
           + SqlGenerationHelper.StatementTerminator;
}