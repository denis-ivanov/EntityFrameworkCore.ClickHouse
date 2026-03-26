using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPCManyToManyNoTrackingQueryClickHouseTest : TPCManyToManyNoTrackingQueryRelationalTestBase<TPCManyToManyQueryClickHouseFixture>
{
    public TPCManyToManyNoTrackingQueryClickHouseTest(TPCManyToManyQueryClickHouseFixture fixture) : base(fixture)
    {
    }
}
