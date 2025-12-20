using EntityFrameworkCore.ClickHouse.FunctionalTests.TestModels.Northwind;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindChangeTrackingQueryClickHouseTest : NorthwindChangeTrackingQueryTestBase<
    NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindChangeTrackingQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture)
        : base(fixture)
    {
    }

    protected override NorthwindContext CreateNoTrackingContext()
        => new NorthwindClickHouseContext(
            new DbContextOptionsBuilder(Fixture.CreateOptions())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).Options);

    [ConditionalFact(Skip = "TBD")]
    public override void Multiple_entities_can_revert()
    {
        base.Multiple_entities_can_revert();
    }
}
