using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class OwnedQueryClickHouseTest : OwnedQueryRelationalTestBase<OwnedQueryClickHouseTest.OwnedQueryClickHouseFixture>
{
    public OwnedQueryClickHouseTest(OwnedQueryClickHouseFixture fixture) : base(fixture)
    {
    }

    public class OwnedQueryClickHouseFixture : RelationalOwnedQueryFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;
    }
}
