using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.Navigations;

public class NavigationsClickHouseFixture : NavigationsRelationalFixtureBase
{
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;
}
