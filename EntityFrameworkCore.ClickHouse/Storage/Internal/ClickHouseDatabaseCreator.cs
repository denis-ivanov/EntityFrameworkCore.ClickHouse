using ClickHouse.Driver;
using ClickHouse.Driver.ADO;
using ClickHouse.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal;

public class ClickHouseDatabaseCreator : RelationalDatabaseCreator
{
    private const int DatabaseDoesNotExist = 81;

    private readonly IClickHouseRelationalConnection _connection;
    private readonly IRawSqlCommandBuilder _rawSqlCommandBuilder;
    private readonly ISqlGenerationHelper _sql;

    public ClickHouseDatabaseCreator(
        RelationalDatabaseCreatorDependencies dependencies,
        IClickHouseRelationalConnection connection,
        IRawSqlCommandBuilder rawSqlCommandBuilder,
        ISqlGenerationHelper sql) : base(dependencies)
    {
        _connection = connection;
        _rawSqlCommandBuilder = rawSqlCommandBuilder;
        _sql = sql;
    }

    public override bool Exists()
    {
        try
        {
            _connection.Open();

            var databaseName = new ClickHouseConnectionStringBuilder(_connection.ConnectionString).Database;
            var command = _connection.DbConnection.CreateCommand();
            command.CommandText = "EXISTS DATABASE " + _sql.DelimitIdentifier(databaseName);

            return Convert.ToBoolean(command.ExecuteScalar());
        }
        catch (ClickHouseServerException e)
        {
            if (e.ErrorCode == DatabaseDoesNotExist)
            {
                return false;
            }

            throw;
        }
    }

    public override bool HasTables()
    {
        return Dependencies.ExecutionStrategy
            .Execute(
                _connection,
                connection => 1 == (byte) CreateHasTablesCommand()
                    .ExecuteScalar(
                        new RelationalCommandParameterObject(
                            connection,
                            null,
                            null,
                            Dependencies.CurrentContext.Context,
                            Dependencies.CommandLogger)));
    }

    public override void Create()
    {
        Dependencies.MigrationCommandExecutor.ExecuteNonQuery(
            CreateCreateOperations(),
            _connection.CreateMasterConnection());
    }

    public override void Delete()
    {
        using var masterConnection = _connection.CreateMasterConnection();
        Dependencies.MigrationCommandExecutor.ExecuteNonQuery(CreateDropCommands(), masterConnection);
    }

    public override async Task DeleteAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        await using var masterConnection = _connection.CreateMasterConnection();
        await Dependencies.MigrationCommandExecutor.ExecuteNonQueryAsync(CreateDropCommands(), masterConnection, cancellationToken);
    }

    IReadOnlyList<MigrationCommand> CreateCreateOperations()
    {
        var operations = new[]
        {
            new ClickHouseCreateDatabaseOperation
            {
                Name = _connection.DbConnection.Database
            }
        };
        return Dependencies.MigrationsSqlGenerator.Generate(operations);
    }

    IReadOnlyList<MigrationCommand> CreateDropCommands()
    {
        var operations = new MigrationOperation[]
        {
            new ClickHouseDropDatabaseOperation
            {
                Name = _connection.DbConnection.Database
            }
        };

        return Dependencies.MigrationsSqlGenerator.Generate(operations);
    }
        
    IRelationalCommand CreateHasTablesCommand()
    {
        var sql = $@"
SELECT if(COUNT() = 0, 0, 1)
FROM system.tables
WHERE database = '{Dependencies.Connection.DbConnection.Database}';";

        return _rawSqlCommandBuilder.Build(sql);
    }
}