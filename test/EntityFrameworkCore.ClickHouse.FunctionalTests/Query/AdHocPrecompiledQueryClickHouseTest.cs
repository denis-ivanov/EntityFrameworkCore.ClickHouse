using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class AdHocPrecompiledQueryClickHouseTest : AdHocPrecompiledQueryRelationalTestBase
{
    public AdHocPrecompiledQueryClickHouseTest(NonSharedFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
    
    protected override bool AlwaysPrintGeneratedSources
        => false;

#if NET10_0
    protected override ITestStoreFactory TestStoreFactory
#else
    protected override ITestStoreFactory NonSharedTestStoreFactory
#endif
        => ClickHouseTestStoreFactory.Instance;

    protected override PrecompiledQueryTestHelpers PrecompiledQueryTestHelpers
        => ClickHousePrecompiledQueryTestHelpers.Instance;

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Index_no_evaluatability()
    {
        await base.Index_no_evaluatability();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task JsonScalar()
    {
        await base.JsonScalar();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_entity_with_property_requiring_converter_with_closure_works()
    {
        await base.Projecting_entity_with_property_requiring_converter_with_closure_works();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Index_with_captured_variable()
    {
        await base.Index_with_captured_variable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Materialize_non_public()
    {
        await base.Materialize_non_public();
    }
}