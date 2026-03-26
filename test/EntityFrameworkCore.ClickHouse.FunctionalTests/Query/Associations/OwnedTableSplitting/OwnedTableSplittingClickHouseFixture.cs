using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query.Associations.OwnedTableSplitting;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.OwnedTableSplitting;

public class OwnedTableSplittingClickHouseFixture : OwnedTableSplittingRelationalFixtureBase
{
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;
}
