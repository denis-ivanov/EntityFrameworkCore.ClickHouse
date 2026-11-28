using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;

public static class ClickHouseDatabaseFacadeExtensions
{
#if NET10_0
    public static void EnsureClean(this DatabaseFacade databaseFacade)
#else
    public static void EnsureClean(this DatabaseFacade databaseFacade, bool createTables = true)
#endif
        => databaseFacade.CreateExecutionStrategy()
#if NET10_0
            .Execute(() => new ClickHouseDatabaseCleaner().Clean(databaseFacade));
#else
            .Execute(() => new ClickHouseDatabaseCleaner().Clean(databaseFacade, createTables));
#endif
}
