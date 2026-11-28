using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
#if NET11_0_OR_GREATER
using Microsoft.EntityFrameworkCore.Query.Inheritance;
#endif
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPCInheritanceQueryClickHouseFixture : TPCInheritanceQueryFixture
{
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;

    public override bool UseGeneratedKeys
        => false;
}
