using System.Collections.Generic;
using ClickHouse.Client;
using ClickHouse.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal
{
    public class ClickHouseDatabaseCreator : RelationalDatabaseCreator
    {
        private const int DatabaseDoesNotExist = 81;
        
        private readonly IClickHouseRelationalConnection _connection;
        
        private readonly IRawSqlCommandBuilder _rawSqlCommandBuilder;

        public ClickHouseDatabaseCreator(
            RelationalDatabaseCreatorDependencies dependencies,
            IClickHouseRelationalConnection connection,
            IRawSqlCommandBuilder rawSqlCommandBuilder) : base(dependencies)
        {
            _connection = connection;
            _rawSqlCommandBuilder = rawSqlCommandBuilder;
        }

        public override bool Exists()
        {
            try
            {
                _connection.Open();
                return true;
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
            return Dependencies.ExecutionStrategyFactory
                .Create()
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

        public override void CreateTables()
        {
            base.CreateTables();
        }
/*
        protected override IReadOnlyList<MigrationCommand> GetCreateTablesCommands()
        {
            var commands = base.GetCreateTablesCommands();
            return commands;
        }
*/
        public override void Delete()
        {
            throw new System.NotImplementedException();
        }

        IReadOnlyList<MigrationCommand> CreateCreateOperations()
            => Dependencies.MigrationsSqlGenerator.Generate(new[]
            {
                new ClickHouseCreateDatabaseOperation
                {
                    Name = _connection.DbConnection.Database
                }
            });

        IRelationalCommand CreateHasTablesCommand()
        {
            var sql = $@"
SELECT if(COUNT() = 0, 0, 1)
FROM system.tables
WHERE database = '{Dependencies.Connection.DbConnection.Database}';";

            return _rawSqlCommandBuilder.Build(sql);
        }
    }
}
