using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPTFiltersInheritanceQueryClickHouseTest : TPTFiltersInheritanceQueryTestBase<TPTFiltersInheritanceQueryClickHouseFixture>
{
    public TPTFiltersInheritanceQueryClickHouseTest(TPTFiltersInheritanceQueryClickHouseFixture fixture) : base(fixture)
    {
    }
}
