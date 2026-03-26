using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NullKeysClickHouseTest : NullKeysTestBase<NullKeysClickHouseTest.NullKeysClickHouseFixture>
{
    public NullKeysClickHouseTest(NullKeysClickHouseFixture fixture) : base(fixture)
    {
    }

    public class NullKeysClickHouseFixture : NullKeysFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;
    }
}
