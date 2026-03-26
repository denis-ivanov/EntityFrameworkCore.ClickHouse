using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class QueryFilterFuncletizationClickHouseTest : QueryFilterFuncletizationTestBase<
    QueryFilterFuncletizationClickHouseTest.QueryFilterFuncletizationClickHouseFixture>
{
    public QueryFilterFuncletizationClickHouseTest(QueryFilterFuncletizationClickHouseFixture fixture) : base(fixture)
    {
    }

    public class QueryFilterFuncletizationClickHouseFixture : QueryFilterFuncletizationRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;
    }
}
