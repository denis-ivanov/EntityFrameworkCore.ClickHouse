using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class QueryNoClientEvalClickHouseFixture : NorthwindQueryClickHouseFixture<NoopModelCustomizer>
{
}
