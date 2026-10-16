using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query.Associations.ComplexTableSplitting;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexTableSplitting;

public class ComplexTableSplittingClickHouseFixture : ComplexTableSplittingRelationalFixtureBase
{
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;
}
