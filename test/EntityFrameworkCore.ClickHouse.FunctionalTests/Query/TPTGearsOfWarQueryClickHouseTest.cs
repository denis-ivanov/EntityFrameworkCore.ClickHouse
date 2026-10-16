using Microsoft.EntityFrameworkCore.Query;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPTGearsOfWarQueryClickHouseTest : TPTGearsOfWarQueryRelationalTestBase<TPTGearsOfWarQueryClickHouseFixture>
{
    public TPTGearsOfWarQueryClickHouseTest(TPTGearsOfWarQueryClickHouseFixture fixture,
        ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
