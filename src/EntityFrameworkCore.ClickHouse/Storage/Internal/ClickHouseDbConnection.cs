using ClickHouse.Driver.ADO;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal;

public class ClickHouseDbConnection : ClickHouseConnection
{
    public ClickHouseDbConnection()
    {
        Settings = new ClickHouseClientSettings(Settings) { UseFormDataParameters = true };
    }

    public ClickHouseDbConnection(string connectionString) : base(connectionString)
    {
        Settings = new ClickHouseClientSettings(Settings) { UseFormDataParameters = true };
    }
}
