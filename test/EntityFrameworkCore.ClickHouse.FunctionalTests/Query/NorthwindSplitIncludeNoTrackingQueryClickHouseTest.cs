using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindSplitIncludeNoTrackingQueryClickHouseTest : NorthwindSplitIncludeNoTrackingQueryTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindSplitIncludeNoTrackingQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }
}
