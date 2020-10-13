using System.Data;
using System.Data.Common;
using ClickHouse.Client.ADO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal
{
    public class ClickHouseRelationalConnection : RelationalConnection, IClickHouseRelationalConnection
    {
        public ClickHouseRelationalConnection(RelationalConnectionDependencies dependencies) : base(dependencies)
        {
        }

        protected override DbConnection CreateDbConnection()
        {
            return new ClickHouseConnection(ConnectionString);
        }

        public IClickHouseRelationalConnection CreateReadOnlyConnection()
        {
            throw new System.NotImplementedException();
        }

        public IClickHouseRelationalConnection CreateMasterConnection()
        {
            var csb = new ClickHouseConnectionStringBuilder(ConnectionString)
            {
                Database = ""
            };

            var relationalOptions = RelationalOptionsExtension.Extract(Dependencies.ContextOptions);
            var connectionString = csb.ToString();

            relationalOptions = relationalOptions.WithConnectionString(connectionString);
            var optionsBuilder = new DbContextOptionsBuilder();
            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(relationalOptions);

            return new ClickHouseRelationalConnection(Dependencies.With(optionsBuilder.Options));
        }

        public override IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return new ClickHouseTransaction();
        }
    }
}