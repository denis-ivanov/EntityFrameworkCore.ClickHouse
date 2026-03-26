using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPCFiltersInheritanceQueryClickHouseTest : TPCFiltersInheritanceQueryTestBase<TPCFiltersInheritanceQueryClickHouseFixture>
{
    public TPCFiltersInheritanceQueryClickHouseTest(TPCFiltersInheritanceQueryClickHouseFixture fixture) : base(fixture)
    {
    }
}
