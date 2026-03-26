using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPTManyToManyNoTrackingQueryClickHouseTest : TPTManyToManyNoTrackingQueryRelationalTestBase<TPTManyToManyQueryClickHouseFixture>
{
    public TPTManyToManyNoTrackingQueryClickHouseTest(TPTManyToManyQueryClickHouseFixture fixture) : base(fixture)
    {
    }
}
