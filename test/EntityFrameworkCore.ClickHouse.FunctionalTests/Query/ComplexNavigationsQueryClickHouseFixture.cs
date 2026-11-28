#if NET11_0_OR_GREATER
using ClickHouse.EntityFrameworkCore.Extensions;
#endif
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
#if NET11_0_OR_GREATER
using Microsoft.EntityFrameworkCore;
#endif
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class ComplexNavigationsQueryClickHouseFixture : ComplexNavigationsQueryRelationalFixtureBase
{
#if NET11_0_OR_GREATER
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.WithSynchronousMutations;

    protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
    {
        base.OnModelCreating(modelBuilder, context);

        // EF Core seeds the navigation data in multiple steps, including updates.
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            entityType.SetMergeTreeTableEngine().SetOrderBy(["tuple()"]);
        }
    }
#else
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;
#endif
}
