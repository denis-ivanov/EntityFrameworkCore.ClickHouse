using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindMiscellaneousQueryClickHouseTest : NorthwindMiscellaneousQueryRelationalTestBase<
    NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindMiscellaneousQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }
}
