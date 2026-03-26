using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class SpatialQueryClickHouseTest : SpatialQueryRelationalTestBase<SpatialQueryClickHouseFixture>
{
    public SpatialQueryClickHouseTest(SpatialQueryClickHouseFixture fixture) : base(fixture)
    {
    }
}
