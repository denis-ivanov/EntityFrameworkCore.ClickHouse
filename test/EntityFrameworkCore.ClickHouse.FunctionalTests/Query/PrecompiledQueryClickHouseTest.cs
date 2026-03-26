using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class PrecompiledQueryClickHouseTest : PrecompiledQueryRelationalTestBase, IClassFixture<PrecompiledQueryClickHouseTest.PrecompiledQueryClickHouseFixture>
{
    public PrecompiledQueryClickHouseTest(PrecompiledQueryRelationalFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    public class PrecompiledQueryClickHouseFixture : PrecompiledQueryRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;

        public override PrecompiledQueryTestHelpers PrecompiledQueryTestHelpers
            => ClickHousePrecompiledQueryTestHelpers.Instance;
    }
}
