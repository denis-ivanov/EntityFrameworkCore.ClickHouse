using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickHouse.EntityFrameworkCore.Migrations.Internal;

public class ClickHouseMigrationDatabaseLock : IMigrationsDatabaseLock
{
    public ClickHouseMigrationDatabaseLock(IHistoryRepository historyRepository)
    {
        HistoryRepository = historyRepository;
    }

    public void Dispose()
    {
    }

    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }

    public IHistoryRepository HistoryRepository { get; }
}