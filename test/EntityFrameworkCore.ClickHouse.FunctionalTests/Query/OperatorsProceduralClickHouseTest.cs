using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class OperatorsProceduralClickHouseTest : OperatorsProceduralQueryTestBase
{
    public OperatorsProceduralClickHouseTest(NonSharedFixture fixture) : base(fixture)
    {
    }

#if NET10_0
    protected override ITestStoreFactory TestStoreFactory
#else
    protected override ITestStoreFactory NonSharedTestStoreFactory
#endif
        => ClickHouseTestStoreFactory.Instance;
}
