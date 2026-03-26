using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPCRelationshipsQueryClickHouseTest : TPCRelationshipsQueryTestBase<TPCRelationshipsQueryClickHouseTest.TPCRelationshipsQueryClickHouseFixture>
{
    public TPCRelationshipsQueryClickHouseTest(TPCRelationshipsQueryClickHouseFixture fixture) : base(fixture)
    {
    }

    public class TPCRelationshipsQueryClickHouseFixture : TPCRelationshipsQueryRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;
    }
}
