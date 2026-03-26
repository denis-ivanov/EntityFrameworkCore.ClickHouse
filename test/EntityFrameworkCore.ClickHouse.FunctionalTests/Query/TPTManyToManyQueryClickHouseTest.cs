using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPTManyToManyQueryClickHouseTest : TPTManyToManyQueryRelationalTestBase<TPTManyToManyQueryClickHouseFixture>
{
    public TPTManyToManyQueryClickHouseTest(TPTManyToManyQueryClickHouseFixture fixture) : base(fixture)
    {
    }
}
