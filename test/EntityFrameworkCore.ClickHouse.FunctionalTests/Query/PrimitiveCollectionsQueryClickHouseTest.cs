using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class PrimitiveCollectionsQueryClickHouseTest : PrimitiveCollectionsQueryRelationalTestBase<
    PrimitiveCollectionsQueryClickHouseTest.PrimitiveCollectionsQueryClickHouseFixture>
{
    public PrimitiveCollectionsQueryClickHouseTest(PrimitiveCollectionsQueryClickHouseFixture fixture) : base(fixture)
    {
    }

    public class PrimitiveCollectionsQueryClickHouseFixture : PrimitiveCollectionsQueryFixtureBase, ITestSqlLoggerFactory
    {
        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;

        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;
    }
}
