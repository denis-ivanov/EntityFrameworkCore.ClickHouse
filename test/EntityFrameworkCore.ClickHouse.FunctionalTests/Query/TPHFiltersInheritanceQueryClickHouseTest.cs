using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPHFiltersInheritanceQueryClickHouseTest : FiltersInheritanceQueryTestBase<TPHFiltersInheritanceQueryClickHouseFixture>
{
    public TPHFiltersInheritanceQueryClickHouseTest(TPHFiltersInheritanceQueryClickHouseFixture fixture) : base(fixture)
    {
    }
}
