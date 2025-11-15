using ClickHouse.Driver.ADO;
using ClickHouse.Driver.Utility;
using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;

using ClickHouse.EntityFrameworkCore.Storage.Internal;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;

public class ClickHouseTestStore : RelationalTestStore
{
    public ClickHouseTestStore(string name, bool shared) : base(name, shared, CreateConnection(name, shared))
    {
    }

    public override DbContextOptionsBuilder AddProviderOptions(DbContextOptionsBuilder builder)
    {
        builder.LogTo(s => Debug.WriteLine(s));
        return builder.UseClickHouse(Connection);
    }

    public int ExecuteNonQuery(string sql, params object[] parameters)
    {
        using var command = CreateCommand(sql, parameters);
        return command.ExecuteNonQuery();
    }

    public override Task CleanAsync(DbContext context)
    {
        context.Database.EnsureClean();
        return Task.CompletedTask;
    }

    public static ClickHouseTestStore GetExisting(string name)
        => new(name, true);

    public static ClickHouseTestStore Create(string name)
        => new(name, shared: false);

    private static ClickHouseDbConnection CreateConnection(string name, bool sharedCache)
    {
        var connectionString = new ClickHouseConnectionStringBuilder(TestEnvironment.DefaultConnection)
        {
            Database = name
        }.ToString();

        var connection = new ClickHouseDbConnection(connectionString);
        connection.CustomSettings.Add("allow_create_index_without_type", "1");
        //connection.CustomSettings.Add("enable_json_type", "1");
        return connection;
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