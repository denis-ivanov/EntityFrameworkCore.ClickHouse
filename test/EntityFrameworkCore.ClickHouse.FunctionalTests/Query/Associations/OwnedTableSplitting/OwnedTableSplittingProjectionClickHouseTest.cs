using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Associations.OwnedTableSplitting;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.OwnedTableSplitting;

public class OwnedTableSplittingProjectionClickHouseTest : OwnedTableSplittingProjectionRelationalTestBase<OwnedTableSplittingClickHouseFixture>
{
    public OwnedTableSplittingProjectionClickHouseTest(OwnedTableSplittingClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_associate(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_associate_collection(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_associate_collection(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_nested_collection_on_optional_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_nested_collection_on_optional_associate(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_nested_collection_on_required_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_nested_collection_on_required_associate(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_nullable_value_type_property_on_null_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_nullable_value_type_property_on_null_associate(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_optional_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_optional_associate(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_optional_nested_on_optional_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_optional_nested_on_optional_associate(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_optional_nested_on_required_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_optional_nested_on_required_associate(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_property_on_optional_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_property_on_optional_associate(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_required_associate_via_optional_navigation(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_required_associate_via_optional_navigation(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_required_nested_on_optional_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_required_nested_on_optional_associate(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_required_nested_on_required_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_required_nested_on_required_associate(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_root(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_root(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_root_duplicated(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_root_duplicated(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_scalar_property_on_required_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_scalar_property_on_required_associate(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_subquery_optional_related_FirstOrDefault(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_subquery_optional_related_FirstOrDefault(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_subquery_required_related_FirstOrDefault(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_subquery_required_related_FirstOrDefault(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_unmapped_associate_scalar_property(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_unmapped_associate_scalar_property(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_untranslatable_method_on_associate_scalar_property(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_untranslatable_method_on_associate_scalar_property(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_value_type_property_on_null_associate_throws(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.Select_value_type_property_on_null_associate_throws(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task SelectMany_associate_collection(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.SelectMany_associate_collection(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task SelectMany_nested_collection_on_optional_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.SelectMany_nested_collection_on_optional_associate(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task SelectMany_nested_collection_on_required_associate(QueryTrackingBehavior queryTrackingBehavior)
    {
        return base.SelectMany_nested_collection_on_required_associate(queryTrackingBehavior);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_FirstOrDefault_complex_collection(QueryTrackingBehavior queryTrackingBehavior)
    {
        await base.Select_subquery_FirstOrDefault_complex_collection(queryTrackingBehavior);
    }
}
