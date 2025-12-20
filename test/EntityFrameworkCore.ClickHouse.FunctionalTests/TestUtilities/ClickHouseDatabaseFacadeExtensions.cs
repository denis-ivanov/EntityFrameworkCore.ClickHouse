using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;

public static class ClickHouseDatabaseFacadeExtensions
{
    public static void EnsureClean(this DatabaseFacade databaseFacade)
        => databaseFacade.CreateExecutionStrategy()
            .Execute(() => new ClickHouseDatabaseCleaner().Clean(databaseFacade));
}
