using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class MappingQueryClickHouseTest : MappingQueryTestBase<MappingQueryClickHouseTest.MappingQueryClickHouseFixture>
{
    public MappingQueryClickHouseTest(MappingQueryFixtureBase fixture) : base(fixture)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void All_customers()
    {
        base.All_customers();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void All_employees()
    {
        base.All_employees();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void All_orders()
    {
        base.All_orders();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Project_nullable_enum()
    {
        base.Project_nullable_enum();
    }

    public class MappingQueryClickHouseFixture : MappingQueryFixtureBase
    {
        // This fixture maps a different set of columns from the shared Northwind model.
        protected override string StoreName => "NorthwindMapping";

        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;

        protected override string DatabaseSchema { get; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
        {
            base.OnModelCreating(modelBuilder, context);

            modelBuilder.Entity<MappedCustomer>(e =>
            {
                e.Property(c => c.CompanyName2).Metadata.SetColumnName("CompanyName");
                e.Metadata.SetTableName("Customers");
            });
        }
    }
}
