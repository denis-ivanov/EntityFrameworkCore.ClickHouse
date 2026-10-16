using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class AdHocPrecompiledQueryClickHouseTest : AdHocPrecompiledQueryRelationalTestBase
{
    public AdHocPrecompiledQueryClickHouseTest(NonSharedFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }
    
    protected override bool AlwaysPrintGeneratedSources
        => false;

    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;

    protected override PrecompiledQueryTestHelpers PrecompiledQueryTestHelpers
        => ClickHousePrecompiledQueryTestHelpers.Instance;

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Index_no_evaluatability()
    {
        await base.Index_no_evaluatability();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task JsonScalar()
    {
        await base.JsonScalar();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_entity_with_property_requiring_converter_with_closure_works()
    {
        await base.Projecting_entity_with_property_requiring_converter_with_closure_works();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Index_with_captured_variable()
    {
        await base.Index_with_captured_variable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Materialize_non_public()
    {
        await base.Materialize_non_public();
    }
}