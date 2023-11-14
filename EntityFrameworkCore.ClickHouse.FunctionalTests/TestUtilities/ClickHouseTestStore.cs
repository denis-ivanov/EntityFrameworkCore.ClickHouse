using ClickHouse.Client.ADO;
using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;

public class ClickHouseTestStore : RelationalTestStore
{
    public ClickHouseTestStore(string name, bool shared) : base(name, shared)
    {
        ConnectionString = CreateConnectionString(name);
        Connection = new ClickHouseDbConnection(ConnectionString);
    }

    public override DbContextOptionsBuilder AddProviderOptions(DbContextOptionsBuilder builder)
    {
        return builder.UseClickHouse(Connection);
    }

    public override void Clean(DbContext context)
    {
        context.Database.EnsureClean();
    }

    private static string CreateConnectionString(string dbName)
    {
        return new ClickHouseConnectionStringBuilder(TestEnvironment.DefaultConnection)
        {
            Database = dbName
        }.ConnectionString;
    }
}
