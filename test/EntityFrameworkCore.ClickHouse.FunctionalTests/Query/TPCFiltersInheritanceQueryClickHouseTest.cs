using Microsoft.EntityFrameworkCore.Query;
#if NET11_0_OR_GREATER
using Microsoft.EntityFrameworkCore.Query.Inheritance;
#endif

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPCFiltersInheritanceQueryClickHouseTest : TPCFiltersInheritanceQueryTestBase<TPCFiltersInheritanceQueryClickHouseFixture>
{
    public TPCFiltersInheritanceQueryClickHouseTest(TPCFiltersInheritanceQueryClickHouseFixture fixture) : base(fixture)
    {
    }
}
