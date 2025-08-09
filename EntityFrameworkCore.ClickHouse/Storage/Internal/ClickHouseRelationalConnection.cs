using ClickHouse.Driver.ADO;
using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal;

public class ClickHouseRelationalConnection : RelationalConnection, IClickHouseRelationalConnection
{
    public ClickHouseRelationalConnection(RelationalConnectionDependencies dependencies) : base(dependencies)
    {
    }

    protected override DbConnection CreateDbConnection()
    {
        return new ClickHouseDbConnection(ConnectionString);
    }

    public IClickHouseRelationalConnection CreateReadOnlyConnection()
    {
        throw new System.NotImplementedException();
    }

    public IClickHouseRelationalConnection CreateMasterConnection()
    {
        var connectionStringBuilder = new ClickHouseConnectionStringBuilder(ConnectionString)
        {
            Database = "default"
        };

        var contextOptions = new DbContextOptionsBuilder()
            .UseClickHouse(connectionStringBuilder.ConnectionString)
            .Options;

        return new ClickHouseRelationalConnection(Dependencies with { ContextOptions = contextOptions });
    }

    public override IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel)
    {
        return new ClickHouseTransaction();
    }

    public override IDbContextTransaction BeginTransaction()
    {
        return BeginTransaction(IsolationLevel.Unspecified);
    }

    public override async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return await BeginTransactionAsync(IsolationLevel.Unspecified, cancellationToken);
    }

    public override Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult<IDbContextTransaction>(new ClickHouseTransaction());
    }
}
