using ClickHouse.Client.ADO;
using ClickHouse.Client.Utility;
using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Data.Common;
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

    public int ExecuteNonQuery(string sql, params object[] parameters)
    {
        using var command = CreateCommand(sql, parameters);
        return command.ExecuteNonQuery();
    }

    public static ClickHouseTestStore GetExisting(string name)
        => new(name, true);

    public static ClickHouseTestStore Create(string name)
        => new(name, shared: false);

    private static string CreateConnectionString(string dbName)
    {
        return new ClickHouseConnectionStringBuilder(TestEnvironment.DefaultConnection)
        {
            Database = dbName
        }.ConnectionString;
    }

    private DbCommand CreateCommand(string commandText, object[] parameters)
    {
        var command = (ClickHouseCommand)Connection.CreateCommand();

        command.CommandText = commandText;

        for (var i = 0; i < parameters.Length; i++)
        {
            command.AddParameter("@p" + i, parameters[i]);
        }

        return command;
    }
}
