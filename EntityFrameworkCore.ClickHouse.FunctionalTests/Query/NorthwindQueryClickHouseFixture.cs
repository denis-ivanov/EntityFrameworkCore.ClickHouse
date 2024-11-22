using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindQueryClickHouseFixture<TModelCustomizer> : NorthwindQueryRelationalFixture<TModelCustomizer>
    where TModelCustomizer : ITestModelCustomizer, new()
{
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseNorthwindTestStoreFactory.Instance;

    protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
    {
        base.OnModelCreating(modelBuilder, context);

        modelBuilder.Entity<OrderDetail>().Property(e => e.UnitPrice).HasPrecision(12, 4);
        modelBuilder.Entity<Product>().Property(e => e.UnitPrice).HasPrecision(12, 4);
    }
}
