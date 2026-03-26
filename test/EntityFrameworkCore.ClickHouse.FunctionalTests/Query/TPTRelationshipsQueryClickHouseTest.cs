using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPTRelationshipsQueryClickHouseTest : TPTRelationshipsQueryTestBase<TPTRelationshipsQueryClickHouseTest.TPTRelationshipsQueryClickHouseFixture>
{
    public TPTRelationshipsQueryClickHouseTest(TPTRelationshipsQueryClickHouseFixture fixture) : base(fixture)
    {
    }

    public class TPTRelationshipsQueryClickHouseFixture : TPTRelationshipsQueryRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;
    }
}
