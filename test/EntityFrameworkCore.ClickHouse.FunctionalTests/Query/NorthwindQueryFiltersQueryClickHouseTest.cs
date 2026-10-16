using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindQueryFiltersQueryClickHouseTest : NorthwindQueryFiltersQueryTestBase<
    NorthwindQueryClickHouseFixture<NorthwindQueryFiltersCustomizer>>
{
    public NorthwindQueryFiltersQueryClickHouseTest(NorthwindQueryClickHouseFixture<NorthwindQueryFiltersCustomizer> fixture) : base(fixture)
    {
    }
}
