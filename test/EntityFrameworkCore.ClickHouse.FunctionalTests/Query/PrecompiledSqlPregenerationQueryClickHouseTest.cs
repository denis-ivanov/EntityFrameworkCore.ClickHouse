using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class PrecompiledSqlPregenerationQueryClickHouseTest : PrecompiledSqlPregenerationQueryRelationalTestBase,
    IClassFixture<PrecompiledSqlPregenerationQueryClickHouseTest.PrecompiledSqlPregenerationQueryClickHouseFixture>
{
    public PrecompiledSqlPregenerationQueryClickHouseTest(PrecompiledSqlPregenerationQueryRelationalFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    protected override bool AlwaysPrintGeneratedSources
        => false;
    
    public class PrecompiledSqlPregenerationQueryClickHouseFixture : PrecompiledSqlPregenerationQueryRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;

        public override PrecompiledQueryTestHelpers PrecompiledQueryTestHelpers
            => ClickHousePrecompiledQueryTestHelpers.Instance;
    }
}
