using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class JsonQueryClickHouseTest : JsonQueryRelationalTestBase<JsonQueryClickHouseFixture>
{
    public JsonQueryClickHouseTest(JsonQueryClickHouseFixture fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_on_entity_with_json_basic(bool async)
    {
        await base.FromSql_on_entity_with_json_basic(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_on_entity_with_json_inheritance_on_base(bool async)
    {
        await base.FromSql_on_entity_with_json_inheritance_on_base(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_on_entity_with_json_inheritance_on_derived(bool async)
    {
        await base.FromSql_on_entity_with_json_inheritance_on_derived(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_on_entity_with_json_inheritance_project_reference_on_base(bool async)
    {
        await base.FromSql_on_entity_with_json_inheritance_project_reference_on_base(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_on_entity_with_json_inheritance_project_reference_on_derived(bool async)
    {
        await base.FromSql_on_entity_with_json_inheritance_project_reference_on_derived(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_on_entity_with_json_project_json_collection(bool async)
    {
        await base.FromSql_on_entity_with_json_project_json_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_on_entity_with_json_project_json_reference(bool async)
    {
        await base.FromSql_on_entity_with_json_project_json_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_all_types_projection_from_owned_entity_reference(bool async)
    {
        await base.Json_all_types_projection_from_owned_entity_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_json_projection_enum_inside_json_entity(bool async)
    {
        await base.Basic_json_projection_enum_inside_json_entity(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_json_projection_owned_collection_branch_NoTrackingWithIdentityResolution(bool async)
    {
        await base.Basic_json_projection_owned_collection_branch_NoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_json_projection_owned_collection_leaf(bool async)
    {
        await base.Basic_json_projection_owned_collection_leaf(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_json_projection_owned_collection_root_NoTrackingWithIdentityResolution(bool async)
    {
        await base.Basic_json_projection_owned_collection_root_NoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_json_projection_owned_reference_branch_NoTrackingWithIdentityResolution(bool async)
    {
        await base.Basic_json_projection_owned_reference_branch_NoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_nested_collection_anonymous_projection_in_projection(bool async)
    {
        await base.Json_nested_collection_anonymous_projection_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_branch_collection_distinct_and_other_collection(bool async)
    {
        await base.Json_branch_collection_distinct_and_other_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_Select_entity_collection_ElementAt(bool async)
    {
        await base.Json_collection_Select_entity_collection_ElementAt(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_all_types_entity_projection(bool async)
    {
        await base.Json_all_types_entity_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_branch_collection_distinct_and_other_collection_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_branch_collection_distinct_and_other_collection_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_SelectMany_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_collection_SelectMany_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_nested_collection_anonymous_projection_in_projection_NoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_nested_collection_anonymous_projection_in_projection_NoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_deduplication_with_collection_in_original_and_collection_indexer_in_target(bool async)
    {
        await base.Json_projection_deduplication_with_collection_in_original_and_collection_indexer_in_target(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_collection_element_and_reference_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_collection_element_and_reference_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_deduplication_with_collection_indexer_in_original(bool async)
    {
        await base.Json_projection_deduplication_with_collection_indexer_in_original(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_nested_collection_and_element_correct_order_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_nested_collection_and_element_correct_order_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_deduplication_with_collection_indexer_in_target(bool async)
    {
        await base.Json_projection_deduplication_with_collection_indexer_in_target(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_deduplication_with_collection_indexer_in_target_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_deduplication_with_collection_indexer_in_target_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_nested_collection_and_element_using_parameter_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_nested_collection_and_element_using_parameter_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_enum_with_custom_conversion(bool async)
    {
        await base.Json_projection_enum_with_custom_conversion(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_after_collection_index_in_projection_using_constant_when_owner_is_not_present(bool async)
    {
        await base.Json_collection_after_collection_index_in_projection_using_constant_when_owner_is_not_present(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_json_projection_owned_reference_duplicated2_NoTrackingWithIdentityResolution(bool async)
    {
        await base.Basic_json_projection_owned_reference_duplicated2_NoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_nested_collection_and_element_using_parameter_AsNoTrackingWithIdentityResolution2(bool async)
    {
        await base.Json_projection_nested_collection_and_element_using_parameter_AsNoTrackingWithIdentityResolution2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_nested_collection_and_element_wrong_order_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_nested_collection_and_element_wrong_order_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_nothing_interesting_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_nothing_interesting_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_nested_collection_element_using_parameter_and_the_owner_in_correct_order_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_nested_collection_element_using_parameter_and_the_owner_in_correct_order_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_second_element_projected_before_entire_collection_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_second_element_projected_before_entire_collection_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_second_element_projected_before_owner_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_second_element_projected_before_owner_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_second_element_projected_before_owner_nested_as_well_as_root_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_second_element_projected_before_owner_nested_as_well_as_root_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_second_element_projected_before_owner_as_well_as_root_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_second_element_projected_before_owner_as_well_as_root_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_second_element_projected_before_owner_nested_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_second_element_projected_before_owner_nested_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_second_element_through_collection_element_constant_different_values_projected_before_owner_nested_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_second_element_through_collection_element_constant_different_values_projected_before_owner_nested_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_second_element_through_collection_element_constant_projected_after_owner_nested_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_second_element_through_collection_element_constant_projected_after_owner_nested_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_second_element_through_collection_element_constant_projected_before_owner_nested_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_second_element_through_collection_element_constant_projected_before_owner_nested_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_second_element_through_collection_element_parameter_correctly_projected_after_owner_nested_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_second_element_through_collection_element_parameter_correctly_projected_after_owner_nested_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_second_element_through_collection_element_parameter_different_values_projected_before_owner_nested_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_second_element_through_collection_element_parameter_different_values_projected_before_owner_nested_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_second_element_through_collection_element_parameter_projected_after_owner_nested_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_second_element_through_collection_element_parameter_projected_after_owner_nested_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_second_element_through_collection_element_parameter_projected_before_owner_nested_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_second_element_through_collection_element_parameter_projected_before_owner_nested_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_only_second_element_through_collection_element_constant_projected_nested_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_only_second_element_through_collection_element_constant_projected_nested_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_second_element_through_collection_element_parameter_projected_before_owner_nested_AsNoTrackingWithIdentityResolution2(bool async)
    {
        await base.Json_projection_second_element_through_collection_element_parameter_projected_before_owner_nested_AsNoTrackingWithIdentityResolution2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_using_queryable_methods_on_top_of_JSON_collection_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_using_queryable_methods_on_top_of_JSON_collection_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_json_collection_in_tracking_query_fails(bool async)
    {
        await base.Project_json_collection_in_tracking_query_fails(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_json_entity_FirstOrDefault_subquery_with_binding_on_top(bool async)
    {
        await base.Project_json_entity_FirstOrDefault_subquery_with_binding_on_top(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_json_reference_in_tracking_query_fails(bool async)
    {
        await base.Project_json_reference_in_tracking_query_fails(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_json_entity_FirstOrDefault_subquery_with_entity_comparison_on_top(bool async)
    {
        await base.Project_json_entity_FirstOrDefault_subquery_with_entity_comparison_on_top(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_json_projection_owned_reference_duplicated_NoTrackingWithIdentityResolution(bool async)
    {
        await base.Basic_json_projection_owned_reference_duplicated_NoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_json_projection_owned_reference_leaf(bool async)
    {
        await base.Basic_json_projection_owned_reference_leaf(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_json_projection_owned_reference_root_NoTrackingWithIdentityResolution(bool async)
    {
        await base.Basic_json_projection_owned_reference_root_NoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_json_projection_owner_entity_duplicated_NoTrackingWithIdentityResolution(bool async)
    {
        await base.Basic_json_projection_owner_entity_duplicated_NoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_json_entity_in_tracking_query_fails_even_when_owner_is_present(bool async)
    {
        await base.Project_json_entity_in_tracking_query_fails_even_when_owner_is_present(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_json_projection_owner_entity_NoTrackingWithIdentityResolution(bool async)
    {
        await base.Basic_json_projection_owner_entity_NoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_basic(bool async)
    {
        await base.Json_collection_index_in_projection_basic(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_json_projection_owner_entity_twice_NoTrackingWithIdentityResolution(bool async)
    {
        await base.Basic_json_projection_owner_entity_twice_NoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_json_projection_scalar(bool async)
    {
        await base.Basic_json_projection_scalar(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_entity_with_inheritance_basic_projection(bool async)
    {
        await base.Json_entity_with_inheritance_basic_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Custom_naming_projection_everything(bool async)
    {
        await base.Custom_naming_projection_everything(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Custom_naming_projection_owned_collection(bool async)
    {
        await base.Custom_naming_projection_owned_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Custom_naming_projection_owned_reference(bool async)
    {
        await base.Custom_naming_projection_owned_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Custom_naming_projection_owned_scalar(bool async)
    {
        await base.Custom_naming_projection_owned_scalar(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Custom_naming_projection_owner_entity(bool async)
    {
        await base.Custom_naming_projection_owner_entity(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Entity_including_collection_with_json(bool async)
    {
        await base.Entity_including_collection_with_json(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_First_on_json_scalar(bool async)
    {
        await base.Group_by_First_on_json_scalar(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_FirstOrDefault_on_json_scalar(bool async)
    {
        await base.Group_by_FirstOrDefault_on_json_scalar(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_scalar_length(bool async)
    {
        await base.Json_scalar_length(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_property_in_predicate(bool async)
    {
        await base.Json_property_in_predicate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_subquery_property_pushdown_length(bool async)
    {
        await base.Json_subquery_property_pushdown_length(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_subquery_reference_pushdown_reference(bool async)
    {
        await base.Json_subquery_reference_pushdown_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_subquery_reference_pushdown_reference_anonymous_projection(bool async)
    {
        await base.Json_subquery_reference_pushdown_reference_anonymous_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_subquery_reference_pushdown_reference_pushdown_anonymous_projection(bool async)
    {
        await base.Json_subquery_reference_pushdown_reference_pushdown_anonymous_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_subquery_reference_pushdown_reference_pushdown_reference(bool async)
    {
        await base.Json_subquery_reference_pushdown_reference_pushdown_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_subquery_reference_pushdown_reference_pushdown_collection(bool async)
    {
        await base.Json_subquery_reference_pushdown_reference_pushdown_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_subquery_reference_pushdown_property(bool async)
    {
        await base.Json_subquery_reference_pushdown_property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_entity_with_single_owned(bool async)
    {
        await base.Project_entity_with_single_owned(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task LeftJoin_json_entities(bool async)
    {
        await base.LeftJoin_json_entities(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task RightJoin_json_entities(bool async)
    {
        await base.RightJoin_json_entities(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Left_join_json_entities_complex_projection(bool async)
    {
        await base.Left_join_json_entities_complex_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Left_join_json_entities_json_being_inner(bool async)
    {
        await base.Left_join_json_entities_json_being_inner(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Left_join_json_entities_complex_projection_json_being_inner(bool async)
    {
        await base.Left_join_json_entities_complex_projection_json_being_inner(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_entity_with_inheritance_project_derived(bool async)
    {
        await base.Json_entity_with_inheritance_project_derived(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_entity_with_inheritance_project_navigations(bool async)
    {
        await base.Json_entity_with_inheritance_project_navigations(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_entity_with_inheritance_project_navigations_on_derived(bool async)
    {
        await base.Json_entity_with_inheritance_project_navigations_on_derived(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_entity_backtracking(bool async)
    {
        await base.Json_entity_backtracking(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_ElementAt_in_projection(bool async)
    {
        await base.Json_collection_ElementAt_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_ElementAtOrDefault_in_projection(bool async)
    {
        await base.Json_collection_ElementAtOrDefault_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_project_collection(bool async)
    {
        await base.Json_collection_index_in_projection_project_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_ElementAt_project_collection(bool async)
    {
        await base.Json_collection_ElementAt_project_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_ElementAtOrDefault_project_collection(bool async)
    {
        await base.Json_collection_ElementAtOrDefault_project_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_using_parameter(bool async)
    {
        await base.Json_collection_index_in_projection_using_parameter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_using_column(bool async)
    {
        await base.Json_collection_index_in_projection_using_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_using_untranslatable_client_method(bool async)
    {
        await base.Json_collection_index_in_projection_using_untranslatable_client_method(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_using_untranslatable_client_method2(bool async)
    {
        await base.Json_collection_index_in_projection_using_untranslatable_client_method2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_outside_bounds(bool async)
    {
        await base.Json_collection_index_outside_bounds(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_outside_bounds2(bool async)
    {
        await base.Json_collection_index_outside_bounds2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_outside_bounds_with_property_access(bool async)
    {
        await base.Json_collection_index_outside_bounds_with_property_access(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_nested(bool async)
    {
        await base.Json_collection_index_in_projection_nested(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_nested_project_scalar(bool async)
    {
        await base.Json_collection_index_in_projection_nested_project_scalar(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_nested_project_reference(bool async)
    {
        await base.Json_collection_index_in_projection_nested_project_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_nested_project_collection(bool async)
    {
        await base.Json_collection_index_in_projection_nested_project_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_nested_project_collection_anonymous_projection(bool async)
    {
        await base.Json_collection_index_in_projection_nested_project_collection_anonymous_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_predicate_using_constant(bool async)
    {
        await base.Json_collection_index_in_predicate_using_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_predicate_using_variable(bool async)
    {
        await base.Json_collection_index_in_predicate_using_variable(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_predicate_using_column(bool async)
    {
        await base.Json_collection_index_in_predicate_using_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_predicate_using_complex_expression1(bool async)
    {
        await base.Json_collection_index_in_predicate_using_complex_expression1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_predicate_using_complex_expression2(bool async)
    {
        await base.Json_collection_index_in_predicate_using_complex_expression2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_ElementAt_in_predicate(bool async)
    {
        await base.Json_collection_ElementAt_in_predicate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_predicate_nested_mix(bool async)
    {
        await base.Json_collection_index_in_predicate_nested_mix(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_ElementAt_and_pushdown(bool async)
    {
        await base.Json_collection_ElementAt_and_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_Any_with_predicate(bool async)
    {
        await base.Json_collection_Any_with_predicate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_Where_ElementAt(bool async)
    {
        await base.Json_collection_Where_ElementAt(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_Skip(bool async)
    {
        await base.Json_collection_Skip(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_OrderByDescending_Skip_ElementAt(bool async)
    {
        await base.Json_collection_OrderByDescending_Skip_ElementAt(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_Distinct_Count_with_predicate(bool async)
    {
        await base.Json_collection_Distinct_Count_with_predicate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_within_collection_Count(bool async)
    {
        await base.Json_collection_within_collection_Count(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_in_projection_with_composition_count(bool async)
    {
        await base.Json_collection_in_projection_with_composition_count(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_in_projection_with_anonymous_projection_of_scalars(bool async)
    {
        await base.Json_collection_in_projection_with_anonymous_projection_of_scalars(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_in_projection_with_composition_where_and_anonymous_projection_of_scalars(bool async)
    {
        await base.Json_collection_in_projection_with_composition_where_and_anonymous_projection_of_scalars(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_in_projection_with_composition_where_and_anonymous_projection_of_primitive_arrays(bool async)
    {
        await base.Json_collection_in_projection_with_composition_where_and_anonymous_projection_of_primitive_arrays(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_filter_in_projection(bool async)
    {
        await base.Json_collection_filter_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_nested_collection_filter_in_projection(bool async)
    {
        await base.Json_nested_collection_filter_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_skip_take_in_projection(bool async)
    {
        await base.Json_collection_skip_take_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_skip_take_in_projection_project_into_anonymous_type(bool async)
    {
        await base.Json_collection_skip_take_in_projection_project_into_anonymous_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_skip_take_in_projection_with_json_reference_access_as_final_operation(bool async)
    {
        await base.Json_collection_skip_take_in_projection_with_json_reference_access_as_final_operation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_distinct_in_projection(bool async)
    {
        await base.Json_collection_distinct_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_anonymous_projection_distinct_in_projection(bool async)
    {
        await base.Json_collection_anonymous_projection_distinct_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_leaf_filter_in_projection(bool async)
    {
        await base.Json_collection_leaf_filter_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_multiple_collection_projections(bool async)
    {
        await base.Json_multiple_collection_projections(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_leaf_collection_distinct_and_other_collection(bool async)
    {
        await base.Json_leaf_collection_distinct_and_other_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_of_primitives_SelectMany(bool async)
    {
        await base.Json_collection_of_primitives_SelectMany(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_of_primitives_index_used_in_predicate(bool async)
    {
        await base.Json_collection_of_primitives_index_used_in_predicate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_of_primitives_index_used_in_projection(bool async)
    {
        await base.Json_collection_of_primitives_index_used_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_of_primitives_index_used_in_orderby(bool async)
    {
        await base.Json_collection_of_primitives_index_used_in_orderby(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_of_primitives_contains_in_predicate(bool async)
    {
        await base.Json_collection_of_primitives_contains_in_predicate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_with_parameter_Select_ElementAt(bool async)
    {
        await base.Json_collection_index_with_parameter_Select_ElementAt(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_with_expression_Select_ElementAt(bool async)
    {
        await base.Json_collection_index_with_expression_Select_ElementAt(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_Select_entity_ElementAt(bool async)
    {
        await base.Json_collection_Select_entity_ElementAt(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_Select_entity_in_anonymous_object_ElementAt(bool async)
    {
        await base.Json_collection_Select_entity_in_anonymous_object_ElementAt(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_Select_entity_with_initializer_ElementAt(bool async)
    {
        await base.Json_collection_Select_entity_with_initializer_ElementAt(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_using_constant_when_owner_is_present(bool async)
    {
        await base.Json_collection_index_in_projection_using_constant_when_owner_is_present(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_using_constant_when_owner_is_not_present(bool async)
    {
        await base.Json_collection_index_in_projection_using_constant_when_owner_is_not_present(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]    
    public override async Task Json_collection_index_in_projection_using_parameter_when_owner_is_present(bool async)
    {
        await base.Json_collection_index_in_projection_using_parameter_when_owner_is_present(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_using_parameter_when_owner_is_not_present(bool async)
    {
        await base.Json_collection_index_in_projection_using_parameter_when_owner_is_not_present(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]    
    public override async Task Json_collection_after_collection_index_in_projection_using_constant_when_owner_is_present(bool async)
    {
        await base.Json_collection_after_collection_index_in_projection_using_constant_when_owner_is_present(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_after_collection_index_in_projection_using_parameter_when_owner_is_present(bool async)
    {
        await base.Json_collection_after_collection_index_in_projection_using_parameter_when_owner_is_present(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_after_collection_index_in_projection_using_parameter_when_owner_is_not_present(bool async)
    {
        await base.Json_collection_after_collection_index_in_projection_using_parameter_when_owner_is_not_present(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_when_owner_is_present_misc1(bool async)
    {
        await base.Json_collection_index_in_projection_when_owner_is_present_misc1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_when_owner_is_not_present_misc1(bool async)
    {
        await base.Json_collection_index_in_projection_when_owner_is_not_present_misc1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_when_owner_is_present_misc2(bool async)
    {
        await base.Json_collection_index_in_projection_when_owner_is_present_misc2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_when_owner_is_not_present_misc2(bool async)
    {
        await base.Json_collection_index_in_projection_when_owner_is_not_present_misc2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_when_owner_is_present_multiple(bool async)
    {
        await base.Json_collection_index_in_projection_when_owner_is_present_multiple(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_collection_index_in_projection_when_owner_is_not_present_multiple(bool async)
    {
        await base.Json_collection_index_in_projection_when_owner_is_not_present_multiple(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_scalar_required_null_semantics(bool async)
    {
        await base.Json_scalar_required_null_semantics(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_scalar_optional_null_semantics(bool async)
    {
        await base.Json_scalar_optional_null_semantics(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_on_json_scalar(bool async)
    {
        await base.Group_by_on_json_scalar(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_on_json_scalar_using_collection_indexer(bool async)
    {
        await base.Group_by_on_json_scalar_using_collection_indexer(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_Skip_Take_on_json_scalar(bool async)
    {
        await base.Group_by_Skip_Take_on_json_scalar(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_json_scalar_Orderby_json_scalar_FirstOrDefault(bool async)
    {
        await base.Group_by_json_scalar_Orderby_json_scalar_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_json_scalar_Skip_First_project_json_scalar(bool async)
    {
        await base.Group_by_json_scalar_Skip_First_project_json_scalar(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_with_include_on_json_entity(bool async)
    {
        await base.Json_with_include_on_json_entity(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_with_include_on_entity_reference(bool async)
    {
        await base.Json_with_include_on_entity_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_with_include_on_entity_collection(bool async)
    {
        await base.Json_with_include_on_entity_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_with_include_on_entity_collection_and_reference(bool async)
    {
        await base.Json_with_include_on_entity_collection_and_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_with_projection_of_json_reference_leaf_and_entity_collection(bool async)
    {
        await base.Json_with_projection_of_json_reference_leaf_and_entity_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_with_projection_of_json_reference_and_entity_collection(bool async)
    {
        await base.Json_with_projection_of_json_reference_and_entity_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_with_projection_of_multiple_json_references_and_entity_collection(bool async)
    {
        await base.Json_with_projection_of_multiple_json_references_and_entity_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_with_projection_of_json_collection_leaf_and_entity_collection(bool async)
    {
        await base.Json_with_projection_of_json_collection_leaf_and_entity_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_with_projection_of_json_collection_and_entity_collection(bool async)
    {
        await base.Json_with_projection_of_json_collection_and_entity_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_with_projection_of_json_collection_element_and_entity_collection(bool async)
    {
        await base.Json_with_projection_of_json_collection_element_and_entity_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_with_projection_of_mix_of_json_collections_json_references_and_entity_collection(bool async)
    {
        await base.Json_with_projection_of_mix_of_json_collections_json_references_and_entity_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_all_types_projection_individual_properties(bool async)
    {
        await base.Json_all_types_projection_individual_properties(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_boolean_predicate(bool async)
    {
        await base.Json_boolean_predicate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_boolean_predicate_negated(bool async)
    {
        await base.Json_boolean_predicate_negated(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_boolean_projection(bool async)
    {
        await base.Json_boolean_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_boolean_projection_negated(bool async)
    {
        await base.Json_boolean_projection_negated(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_default_string(bool async)
    {
        await base.Json_predicate_on_default_string(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_max_length_string(bool async)
    {
        await base.Json_predicate_on_max_length_string(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_string_condition(bool async)
    {
        await base.Json_predicate_on_string_condition(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_byte(bool async)
    {
        await base.Json_predicate_on_byte(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_byte_array(bool async)
    {
        await base.Json_predicate_on_byte_array(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_character(bool async)
    {
        await base.Json_predicate_on_character(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_datetime(bool async)
    {
        await base.Json_predicate_on_datetime(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_datetimeoffset(bool async)
    {
        await base.Json_predicate_on_datetimeoffset(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_decimal(bool async)
    {
        await base.Json_predicate_on_decimal(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_double(bool async)
    {
        await base.Json_predicate_on_double(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_guid(bool async)
    {
        await base.Json_predicate_on_guid(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_int16(bool async)
    {
        await base.Json_predicate_on_int16(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_int32(bool async)
    {
        await base.Json_predicate_on_int32(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_int64(bool async)
    {
        await base.Json_predicate_on_int64(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_signedbyte(bool async)
    {
        await base.Json_predicate_on_signedbyte(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_single(bool async)
    {
        await base.Json_predicate_on_single(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_timespan(bool async)
    {
        await base.Json_predicate_on_timespan(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_dateonly(bool async)
    {
        await base.Json_predicate_on_dateonly(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_timeonly(bool async)
    {
        await base.Json_predicate_on_timeonly(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_unisgnedint16(bool async)
    {
        await base.Json_predicate_on_unisgnedint16(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_unsignedint32(bool async)
    {
        await base.Json_predicate_on_unsignedint32(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_unsignedint64(bool async)
    {
        await base.Json_predicate_on_unsignedint64(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_enum(bool async)
    {
        await base.Json_predicate_on_enum(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_enumwithintconverter(bool async)
    {
        await base.Json_predicate_on_enumwithintconverter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_nullableenum1(bool async)
    {
        await base.Json_predicate_on_nullableenum1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_nullableenum2(bool async)
    {
        await base.Json_predicate_on_nullableenum2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_nullableenumwithconverterthathandlesnulls1(bool async)
    {
        await base.Json_predicate_on_nullableenumwithconverterthathandlesnulls1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_nullableenumwithconverterthathandlesnulls2(bool async)
    {
        await base.Json_predicate_on_nullableenumwithconverterthathandlesnulls2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_nullableenumwithconverter1(bool async)
    {
        await base.Json_predicate_on_nullableenumwithconverter1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_nullableenumwithconverter2(bool async)
    {
        await base.Json_predicate_on_nullableenumwithconverter2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_nullableint321(bool async)
    {
        await base.Json_predicate_on_nullableint321(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_nullableint322(bool async)
    {
        await base.Json_predicate_on_nullableint322(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_bool_converted_to_int_zero_one(bool async)
    {
        await base.Json_predicate_on_bool_converted_to_int_zero_one(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_bool_converted_to_int_zero_one_with_explicit_comparison(bool async)
    {
        await base.Json_predicate_on_bool_converted_to_int_zero_one_with_explicit_comparison(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_bool_converted_to_string_True_False(bool async)
    {
        await base.Json_predicate_on_bool_converted_to_string_True_False(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_bool_converted_to_string_True_False_with_explicit_comparison(bool async)
    {
        await base.Json_predicate_on_bool_converted_to_string_True_False_with_explicit_comparison(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_bool_converted_to_string_Y_N(bool async)
    {
        await base.Json_predicate_on_bool_converted_to_string_Y_N(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_bool_converted_to_string_Y_N_with_explicit_comparison(bool async)
    {
        await base.Json_predicate_on_bool_converted_to_string_Y_N_with_explicit_comparison(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_int_zero_one_converted_to_bool(bool async)
    {
        await base.Json_predicate_on_int_zero_one_converted_to_bool(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_string_True_False_converted_to_bool(bool async)
    {
        await base.Json_predicate_on_string_True_False_converted_to_bool(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_predicate_on_string_Y_N_converted_to_bool(bool async)
    {
        await base.Json_predicate_on_string_Y_N_converted_to_bool(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_owner_entity_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_owner_entity_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_nested_collection_anonymous_projection_of_primitives_in_projection_NoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_nested_collection_anonymous_projection_of_primitives_in_projection_NoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_reference_collection_and_collection_element_nested_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_reference_collection_and_collection_element_nested_AsNoTrackingWithIdentityResolution(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Json_projection_only_second_element_through_collection_element_parameter_projected_nested_AsNoTrackingWithIdentityResolution(bool async)
    {
        await base.Json_projection_only_second_element_through_collection_element_parameter_projected_nested_AsNoTrackingWithIdentityResolution(async);
    }
}
