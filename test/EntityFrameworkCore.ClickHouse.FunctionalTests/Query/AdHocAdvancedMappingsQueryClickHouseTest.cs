using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class AdHocAdvancedMappingsQueryClickHouseTest : AdHocAdvancedMappingsQueryRelationalTestBase
{
    public AdHocAdvancedMappingsQueryClickHouseTest(NonSharedFixture fixture) : base(fixture)
    {
    }
    
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Double_convert_interface_created_expression_tree()
    {
        await base.Double_convert_interface_created_expression_tree();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_correlated_collection_along_with_non_mapped_property()
    {
        await base.Projecting_correlated_collection_along_with_non_mapped_property();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projection_failing_with_EnumToStringConverter()
    {
        await base.Projection_failing_with_EnumToStringConverter();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_hierarchy_with_non_nullable_property_on_derived()
    {
        await base.Can_query_hierarchy_with_non_nullable_property_on_derived();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Casts_are_removed_from_expression_tree_when_redundant()
    {
        await base.Casts_are_removed_from_expression_tree_when_redundant();
    }
}
