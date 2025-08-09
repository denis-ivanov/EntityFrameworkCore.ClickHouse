using ClickHouse.Driver.ADO;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal;

public class ClickHouseDbConnection : ClickHouseConnection
{
    public ClickHouseDbConnection()
    {
        SetFormDataParameters(true);
    }

    public ClickHouseDbConnection(string connectionString) : base(connectionString)
    {
        SetFormDataParameters(true);
    }
}
