using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query.Associations.OwnedNavigations;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.OwnedNavigations;

public class OwnedNavigationsClickHouseFixture : OwnedNavigationsRelationalFixtureBase
{
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;
}