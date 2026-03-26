using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class AdHocJsonQueryClickHouseTest : AdHocJsonQueryRelationalTestBase
{
    public AdHocJsonQueryClickHouseTest(NonSharedFixture fixture) : base(fixture)
    {
    }
    
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;

    protected override Task Seed30028(DbContext ctx)
    {
        return Task.CompletedTask;
    }

    protected override Task Seed33046(DbContext ctx)
    {
        return Task.CompletedTask;
    }

    protected override Task SeedJunkInJson(DbContext ctx)
    {
        return Task.CompletedTask;
    }

    protected override Task SeedTrickyBuffering(DbContext ctx)
    {
        return Task.CompletedTask;
    }

    protected override Task SeedShadowProperties(DbContext ctx)
    {
        return Task.CompletedTask;
    }

    protected override Task SeedNotICollection(DbContext ctx)
    {
        return Task.CompletedTask;
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_json_array_of_primitives_on_reference()
    {
        await base.Project_json_array_of_primitives_on_reference();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Not_ICollection_basic_projection()
    {
        await base.Not_ICollection_basic_projection();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Entity_splitting_with_owned_json()
    {
        await base.Entity_splitting_with_owned_json();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_missing_required_navigation(bool async)
    {
        await base.Project_missing_required_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_missing_required_scalar(bool async)
    {
        await base.Project_missing_required_scalar(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_top_level_json_entity_with_missing_scalars(bool async)
    {
        await base.Project_top_level_json_entity_with_missing_scalars(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_top_level_entity_with_null_value_required_scalars(bool async)
    {
        await base.Project_top_level_entity_with_null_value_required_scalars(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bad_json_properties_null_navigations(bool noTracking)
    {
        await base.Bad_json_properties_null_navigations(noTracking);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task HasJsonPropertyName()
    {
        await base.HasJsonPropertyName();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_shadow_properties_from_json_entity()
    {
        await base.Project_shadow_properties_from_json_entity();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Shadow_properties_basic_tracking()
    {
        await base.Shadow_properties_basic_tracking();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_null_required_navigation(bool async)
    {
        await base.Project_null_required_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    [InlineData(false)]
    [InlineData(true)]
    public override async Task Project_root_with_missing_scalars(bool async)
    {
        await base.Project_root_with_missing_scalars(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tricky_buffering_basic()
    {
        await base.Tricky_buffering_basic();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Predicate_based_on_element_of_json_array_of_primitives3()
    {
        await base.Predicate_based_on_element_of_json_array_of_primitives3();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Try_project_collection_but_JSON_is_entity()
    {
        await base.Try_project_collection_but_JSON_is_entity();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bad_json_properties_empty_navigations(bool noTracking)
    {
        await base.Bad_json_properties_empty_navigations(noTracking);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_null_required_scalar(bool async)
    {
        await base.Project_null_required_scalar(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_with_nested_json_collection_mapped_to_private_field_via_IReadOnlyList()
    {
        await base.Query_with_nested_json_collection_mapped_to_private_field_via_IReadOnlyList();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_root_entity_with_missing_required_navigation(bool async)
    {
        await base.Project_root_entity_with_missing_required_navigation(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Junk_in_json_basic_no_tracking()
    {
        await base.Junk_in_json_basic_no_tracking();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Predicate_based_on_element_of_json_array_of_primitives2()
    {
        await base.Predicate_based_on_element_of_json_array_of_primitives2();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_entity_with_json_null_values()
    {
        await base.Project_entity_with_json_null_values();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Predicate_based_on_element_of_json_array_of_primitives1()
    {
        await base.Predicate_based_on_element_of_json_array_of_primitives1();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_root_entity_with_null_required_navigation(bool async)
    {
        await base.Project_root_entity_with_null_required_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bad_json_properties_duplicated_navigations(bool noTracking)
    {
        await base.Bad_json_properties_duplicated_navigations(noTracking);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bad_json_properties_duplicated_scalars(bool noTracking)
    {
        await base.Bad_json_properties_duplicated_scalars(noTracking);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_nested_json_entity_with_missing_scalars(bool async)
    {
        await base.Project_nested_json_entity_with_missing_scalars(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_element_of_json_array_of_primitives()
    {
        await base.Project_element_of_json_array_of_primitives();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bad_json_properties_empty_scalars(bool noTracking)
    {
        await base.Bad_json_properties_empty_scalars(noTracking);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_entity_with_optional_json_entity_owned_by_required_json()
    {
        await base.Project_entity_with_optional_json_entity_owned_by_required_json();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Shadow_properties_basic_no_tracking()
    {
        await base.Shadow_properties_basic_no_tracking();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bad_json_properties_null_scalars(bool noTracking)
    {
        await base.Bad_json_properties_null_scalars(noTracking);
    }

    protected override Task SeedBadJsonProperties(ContextBadJsonProperties ctx)
    {
        throw new System.NotImplementedException();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_project_nullable_json_property_when_the_element_in_json_is_not_present()
    {
        await base.Can_project_nullable_json_property_when_the_element_in_json_is_not_present();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Try_project_reference_but_JSON_is_collection()
    {
        await base.Try_project_reference_but_JSON_is_collection();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_json_with_no_properties()
    {
        await base.Project_json_with_no_properties();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Missing_navigation_works_with_deduplication(bool async)
    {
        await base.Missing_navigation_works_with_deduplication(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_required_json_entity()
    {
        await base.Project_required_json_entity();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_proxies_entity_with_json()
    {
        await base.Project_proxies_entity_with_json();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Accessing_missing_navigation_works()
    {
        await base.Accessing_missing_navigation_works();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_optional_json_entity_owned_by_required_json_entity()
    {
        await base.Project_optional_json_entity_owned_by_required_json_entity();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_on_nested_collection_with_init_only_navigation()
    {
        await base.Contains_on_nested_collection_with_init_only_navigation();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Junk_in_json_basic_tracking()
    {
        await base.Junk_in_json_basic_tracking();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_json_properties_materialized_as_null_when_the_element_in_json_is_not_present()
    {
        await base.Optional_json_properties_materialized_as_null_when_the_element_in_json_is_not_present();
    }
}