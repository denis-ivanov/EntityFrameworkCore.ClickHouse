using ClickHouse.Client.ADO;
using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Diagnostics;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;

public class ClickHouseTestStore : RelationalTestStore
{
    public ClickHouseTestStore(string name, bool shared) : base(name, shared)
    {
        ConnectionString = CreateConnectionString(name);
        var clickHouseDbConnection = new ClickHouseDbConnection(ConnectionString);
        clickHouseDbConnection.CustomSettings.Add("allow_create_index_without_type", "1");

        Connection = clickHouseDbConnection;
    }

    public override DbContextOptionsBuilder AddProviderOptions(DbContextOptionsBuilder builder)
    {
        builder.LogTo(s => Debug.WriteLine(s));
        return builder.UseClickHouse(Connection);
    }

    public override void Clean(DbContext context)
    {
        context.Database.EnsureClean();
    }

    public static ClickHouseTestStore GetExisting(string name)
        => new(name, false);
    
    private static string CreateConnectionString(string dbName)
    {
        return new ClickHouseConnectionStringBuilder(TestEnvironment.DefaultConnection)
        {
            Database = dbName
        }.ConnectionString;
    }
}
