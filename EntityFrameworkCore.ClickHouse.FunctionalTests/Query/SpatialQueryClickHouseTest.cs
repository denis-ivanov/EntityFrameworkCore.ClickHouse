using Microsoft.EntityFrameworkCore.Query;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class SpatialQueryClickHouseTest : SpatialQueryRelationalTestBase<SpatialQueryClickHouseFixture>
{
    public SpatialQueryClickHouseTest(SpatialQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
