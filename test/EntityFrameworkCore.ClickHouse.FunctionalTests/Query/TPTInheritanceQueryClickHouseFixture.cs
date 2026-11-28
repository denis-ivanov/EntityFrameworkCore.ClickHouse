using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
#if NET11_0_OR_GREATER
using Microsoft.EntityFrameworkCore.Query.Inheritance;
#endif
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPTInheritanceQueryClickHouseFixture : TPTInheritanceQueryFixture
{
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance; 
#if NET11_0_OR_GREATER

    public override bool UseGeneratedKeys
        => false;
#endif
}
