using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPCManyToManyQueryClickHouseTest : TPCManyToManyQueryRelationalTestBase<TPCManyToManyQueryClickHouseFixture>
{
    public TPCManyToManyQueryClickHouseTest(TPCManyToManyQueryClickHouseFixture fixture) : base(fixture)
    {
    }
}
