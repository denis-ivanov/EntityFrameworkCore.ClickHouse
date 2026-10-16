using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class GearsOfWarQueryClickHouseTest : GearsOfWarQueryRelationalTestBase<GearsOfWarQueryClickHouseFixture>
{
    public GearsOfWarQueryClickHouseTest(GearsOfWarQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Accessing_derived_property_using_hard_and_soft_cast(bool async)
    {
        await base.Accessing_derived_property_using_hard_and_soft_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Accessing_property_of_optional_navigation_in_child_projection_works(bool async)
    {
        await base.Accessing_property_of_optional_navigation_in_child_projection_works(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Accessing_reference_navigation_collection_composition_generates_single_query(bool async)
    {
        await base.Accessing_reference_navigation_collection_composition_generates_single_query(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task All_with_optional_navigation_is_translated_to_sql(bool async)
    {
        await base.All_with_optional_navigation_is_translated_to_sql(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Anonymous_projection_take_followed_by_projecting_single_element_from_collection_navigation(bool async)
    {
        await base.Anonymous_projection_take_followed_by_projecting_single_element_from_collection_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Any_with_optional_navigation_as_subquery_predicate_is_translated_to_sql(bool async)
    {
        await base.Any_with_optional_navigation_as_subquery_predicate_is_translated_to_sql(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_query_gears(bool async)
    {
        await base.Basic_query_gears(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bitwise_operation_with_non_null_parameter_optimizes_null_checks(bool async)
    {
        await base.Bitwise_operation_with_non_null_parameter_optimizes_null_checks(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bitwise_operation_with_null_arguments(bool async)
    {
        await base.Bitwise_operation_with_null_arguments(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bool_projection_from_subquery_treated_appropriately_in_where(bool async)
    {
        await base.Bool_projection_from_subquery_treated_appropriately_in_where(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Byte_array_filter_by_length_literal_does_not_cast_on_varbinary_n(bool async)
    {
        await base.Byte_array_filter_by_length_literal_does_not_cast_on_varbinary_n(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Cast_OfType_works_correctly(bool async)
    {
        await base.Cast_OfType_works_correctly(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Cast_ordered_subquery_to_base_type_using_typed_ToArray(bool async)
    {
        await base.Cast_ordered_subquery_to_base_type_using_typed_ToArray(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Cast_result_operator_on_subquery_is_properly_lifted_to_a_convert(bool async)
    {
        await base.Cast_result_operator_on_subquery_is_properly_lifted_to_a_convert(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Cast_subquery_to_base_type_using_typed_ToList(bool async)
    {
        await base.Cast_subquery_to_base_type_using_typed_ToList(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Cast_to_derived_followed_by_include_and_FirstOrDefault(bool async)
    {
        await base.Cast_to_derived_followed_by_include_and_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Cast_to_derived_followed_by_multiple_includes(bool async)
    {
        await base.Cast_to_derived_followed_by_multiple_includes(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Cast_to_derived_type_after_OfType_works(bool async)
    {
        await base.Cast_to_derived_type_after_OfType_works(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Cast_to_derived_type_causes_client_eval(bool async)
    {
        await base.Cast_to_derived_type_causes_client_eval(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Checked_context_throws_on_client_evaluation(bool isAsync)
    {
        return base.Checked_context_throws_on_client_evaluation(isAsync);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Checked_context_with_addition_does_not_fail(bool isAsync)
    {
        return base.Checked_context_with_addition_does_not_fail(isAsync);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Checked_context_with_cast_does_not_fail(bool isAsync)
    {
        return base.Checked_context_with_cast_does_not_fail(isAsync);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_eval_followed_by_aggregate_operation(bool async)
    {
        await base.Client_eval_followed_by_aggregate_operation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_member_and_unsupported_string_Equals_in_the_same_query(bool async)
    {
        await base.Client_member_and_unsupported_string_Equals_in_the_same_query(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_method_on_collection_navigation_in_additional_from_clause(bool async)
    {
        await base.Client_method_on_collection_navigation_in_additional_from_clause(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_method_on_collection_navigation_in_order_by(bool async)
    {
        await base.Client_method_on_collection_navigation_in_order_by(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_method_on_collection_navigation_in_outer_join_key(bool async)
    {
        await base.Client_method_on_collection_navigation_in_outer_join_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_method_on_collection_navigation_in_predicate(bool async)
    {
        await base.Client_method_on_collection_navigation_in_predicate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_method_on_collection_navigation_in_predicate_accessed_by_ef_property(bool async)
    {
        await base.Client_method_on_collection_navigation_in_predicate_accessed_by_ef_property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_projection_with_nested_unmapped_property_bubbles_up_translation_failure_info(bool async)
    {
        await base.Client_projection_with_nested_unmapped_property_bubbles_up_translation_failure_info(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_side_equality_with_parameter_works_with_optional_navigations(bool async)
    {
        await base.Client_side_equality_with_parameter_works_with_optional_navigations(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Coalesce_operator_in_predicate(bool async)
    {
        await base.Coalesce_operator_in_predicate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Coalesce_operator_in_predicate_with_other_conditions(bool async)
    {
        await base.Coalesce_operator_in_predicate_with_other_conditions(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Coalesce_operator_in_projection_with_other_conditions(bool async)
    {
        await base.Coalesce_operator_in_projection_with_other_conditions(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Coalesce_used_with_non_unicode_string_column_and_constant(bool async)
    {
        await base.Coalesce_used_with_non_unicode_string_column_and_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Coalesce_with_non_root_evaluatable_Convert(bool async)
    {
        await base.Coalesce_with_non_root_evaluatable_Convert(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_navigation_access_on_derived_entity_using_cast(bool async)
    {
        await base.Collection_navigation_access_on_derived_entity_using_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_navigation_access_on_derived_entity_using_cast_in_SelectMany(bool async)
    {
        await base.Collection_navigation_access_on_derived_entity_using_cast_in_SelectMany(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_navigation_ofType_filter_works(bool async)
    {
        await base.Collection_navigation_ofType_filter_works(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_with_inheritance_and_join_include_joined(bool async)
    {
        await base.Collection_with_inheritance_and_join_include_joined(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_with_inheritance_and_join_include_source(bool async)
    {
        await base.Collection_with_inheritance_and_join_include_source(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task CompareTo_used_with_non_unicode_string_column_and_constant(bool async)
    {
        await base.CompareTo_used_with_non_unicode_string_column_and_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Comparing_entities_using_Equals_inheritance(bool async)
    {
        await base.Comparing_entities_using_Equals_inheritance(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Comparing_two_collection_navigations_composite_key(bool async)
    {
        await base.Comparing_two_collection_navigations_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Comparing_two_collection_navigations_inheritance(bool async)
    {
        await base.Comparing_two_collection_navigations_inheritance(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Comparison_with_value_converted_subclass(bool async)
    {
        await base.Comparison_with_value_converted_subclass(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_GroupBy_after_set_operator(bool async)
    {
        await base.Complex_GroupBy_after_set_operator(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_GroupBy_after_set_operator_using_result_selector(bool async)
    {
        await base.Complex_GroupBy_after_set_operator_using_result_selector(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_predicate_with_AndAlso_and_nullable_bool_property(bool async)
    {
        await base.Complex_predicate_with_AndAlso_and_nullable_bool_property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Composite_key_entity_equal(bool async)
    {
        await base.Composite_key_entity_equal(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Composite_key_entity_equal_null(bool async)
    {
        await base.Composite_key_entity_equal_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Composite_key_entity_not_equal(bool async)
    {
        await base.Composite_key_entity_not_equal(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Composite_key_entity_not_equal_null(bool async)
    {
        await base.Composite_key_entity_not_equal_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Concat_anonymous_with_count(bool async)
    {
        await base.Concat_anonymous_with_count(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Concat_scalars_with_count(bool async)
    {
        await base.Concat_scalars_with_count(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Concat_with_collection_navigations(bool async)
    {
        await base.Concat_with_collection_navigations(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Concat_with_count(bool async)
    {
        await base.Concat_with_count(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Concat_with_scalar_projection(bool async)
    {
        await base.Concat_with_scalar_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Conditional_expression_with_test_being_simplified_to_constant_complex(bool isAsync)
    {
        return base.Conditional_expression_with_test_being_simplified_to_constant_complex(isAsync);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Conditional_expression_with_test_being_simplified_to_constant_simple(bool isAsync)
    {
        return base.Conditional_expression_with_test_being_simplified_to_constant_simple(isAsync);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Conditional_Navigation_With_Member_Access_On_Related_Types(bool async)
    {
        await base.Conditional_Navigation_With_Member_Access_On_Related_Types(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Conditional_Navigation_With_Member_Access_On_Same_Type(bool async)
    {
        await base.Conditional_Navigation_With_Member_Access_On_Same_Type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Conditional_Navigation_With_Trivial_Member_Access(bool async)
    {
        await base.Conditional_Navigation_With_Trivial_Member_Access(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Conditional_with_conditions_evaluating_to_false_gets_optimized(bool async)
    {
        await base.Conditional_with_conditions_evaluating_to_false_gets_optimized(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Conditional_with_conditions_evaluating_to_true_gets_optimized(bool async)
    {
        await base.Conditional_with_conditions_evaluating_to_true_gets_optimized(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Constant_enum_with_same_underlying_value_as_previously_parameterized_int(bool async)
    {
        await base.Constant_enum_with_same_underlying_value_as_previously_parameterized_int(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_on_collection_of_byte_subquery(bool async)
    {
        await base.Contains_on_collection_of_byte_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_on_collection_of_nullable_byte_subquery(bool async)
    {
        await base.Contains_on_collection_of_nullable_byte_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_on_collection_of_nullable_byte_subquery_null_constant(bool async)
    {
        await base.Contains_on_collection_of_nullable_byte_subquery_null_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_on_collection_of_nullable_byte_subquery_null_parameter(bool async)
    {
        await base.Contains_on_collection_of_nullable_byte_subquery_null_parameter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_on_nullable_array_produces_correct_sql(bool async)
    {
        await base.Contains_on_nullable_array_produces_correct_sql(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_on_readonly_enumerable(bool async)
    {
        await base.Contains_on_readonly_enumerable(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_with_local_nullable_guid_list_closure(bool async)
    {
        await base.Contains_with_local_nullable_guid_list_closure(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_after_distinct_3_levels(bool async)
    {
        await base.Correlated_collection_after_distinct_3_levels(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_after_distinct_3_levels_without_original_identifiers(bool async)
    {
        await base.Correlated_collection_after_distinct_3_levels_without_original_identifiers(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_order_by_constant(bool async)
    {
        await base.Correlated_collection_order_by_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_order_by_constant_null_of_non_mapped_type(bool async)
    {
        await base.Correlated_collection_order_by_constant_null_of_non_mapped_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_take(bool async)
    {
        await base.Correlated_collection_take(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_via_SelectMany_with_Distinct_missing_indentifying_columns_in_projection(bool async)
    {
        await base.Correlated_collection_via_SelectMany_with_Distinct_missing_indentifying_columns_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_complex_order_by_funcletized_to_constant_bool(bool async)
    {
        await base.Correlated_collection_with_complex_order_by_funcletized_to_constant_bool(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_complex_OrderBy(bool async)
    {
        await base.Correlated_collection_with_complex_OrderBy(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_distinct_3_levels(bool async)
    {
        await base.Correlated_collection_with_distinct_3_levels(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_distinct_not_projecting_identifier_column(bool async)
    {
        await base.Correlated_collection_with_distinct_not_projecting_identifier_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_distinct_not_projecting_identifier_column_also_projecting_complex_expressions(bool async)
    {
        await base.Correlated_collection_with_distinct_not_projecting_identifier_column_also_projecting_complex_expressions(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_distinct_projecting_identifier_column(bool async)
    {
        await base.Correlated_collection_with_distinct_projecting_identifier_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_distinct_projecting_identifier_column_and_correlation_key(bool async)
    {
        await base.Correlated_collection_with_distinct_projecting_identifier_column_and_correlation_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_distinct_projecting_identifier_column_composite_key(bool async)
    {
        await base.Correlated_collection_with_distinct_projecting_identifier_column_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_groupby_not_projecting_identifier_column_but_only_grouping_key_in_final_projection(bool async)
    {
        await base.Correlated_collection_with_groupby_not_projecting_identifier_column_but_only_grouping_key_in_final_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_groupby_not_projecting_identifier_column_with_group_aggregate_in_final_projection(bool async)
    {
        await base.Correlated_collection_with_groupby_not_projecting_identifier_column_with_group_aggregate_in_final_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_groupby_not_projecting_identifier_column_with_group_aggregate_in_final_projection_multiple_grouping_keys(bool async)
    {
        await base.Correlated_collection_with_groupby_not_projecting_identifier_column_with_group_aggregate_in_final_projection_multiple_grouping_keys(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_groupby_with_complex_grouping_key_not_projecting_identifier_column_with_group_aggregate_in_final_projection(bool async)
    {
        await base.Correlated_collection_with_groupby_with_complex_grouping_key_not_projecting_identifier_column_with_group_aggregate_in_final_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_inner_collection_references_element_two_levels_up(bool async)
    {
        await base.Correlated_collection_with_inner_collection_references_element_two_levels_up(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_top_level_Count(bool async)
    {
        await base.Correlated_collection_with_top_level_Count(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_top_level_FirstOrDefault(bool async)
    {
        await base.Correlated_collection_with_top_level_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_top_level_Last_with_order_by_on_inner(bool async)
    {
        await base.Correlated_collection_with_top_level_Last_with_order_by_on_inner(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_top_level_Last_with_orderby_on_outer(bool async)
    {
        await base.Correlated_collection_with_top_level_Last_with_orderby_on_outer(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_very_complex_order_by(bool async)
    {
        await base.Correlated_collection_with_very_complex_order_by(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_basic_projecting_constant(bool async)
    {
        await base.Correlated_collections_basic_projecting_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_basic_projecting_constant_bool(bool async)
    {
        await base.Correlated_collections_basic_projecting_constant_bool(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_basic_projecting_single_property(bool async)
    {
        await base.Correlated_collections_basic_projecting_single_property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_basic_projection(bool async)
    {
        await base.Correlated_collections_basic_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_basic_projection_composite_key(bool async)
    {
        await base.Correlated_collections_basic_projection_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_basic_projection_explicit_to_array(bool async)
    {
        await base.Correlated_collections_basic_projection_explicit_to_array(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_basic_projection_explicit_to_list(bool async)
    {
        await base.Correlated_collections_basic_projection_explicit_to_list(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_basic_projection_ordered(bool async)
    {
        await base.Correlated_collections_basic_projection_ordered(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_complex_scenario1(bool async)
    {
        await base.Correlated_collections_complex_scenario1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_complex_scenario2(bool async)
    {
        await base.Correlated_collections_complex_scenario2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_deeply_nested_left_join(bool async)
    {
        await base.Correlated_collections_deeply_nested_left_join(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_different_collections_projected(bool async)
    {
        await base.Correlated_collections_different_collections_projected(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_from_left_join_with_additional_elements_projected_of_that_join(bool async)
    {
        await base.Correlated_collections_from_left_join_with_additional_elements_projected_of_that_join(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_inner_subquery_predicate_references_outer_qsre(bool async)
    {
        await base.Correlated_collections_inner_subquery_predicate_references_outer_qsre(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_inner_subquery_selector_references_outer_qsre(bool async)
    {
        await base.Correlated_collections_inner_subquery_selector_references_outer_qsre(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_left_join_with_self_reference(bool async)
    {
        await base.Correlated_collections_left_join_with_self_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_multiple_nested_complex_collections(bool async)
    {
        await base.Correlated_collections_multiple_nested_complex_collections(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_naked_navigation_with_ToArray(bool async)
    {
        await base.Correlated_collections_naked_navigation_with_ToArray(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_naked_navigation_with_ToList(bool async)
    {
        await base.Correlated_collections_naked_navigation_with_ToList(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_naked_navigation_with_ToList_followed_by_projecting_count(bool async)
    {
        await base.Correlated_collections_naked_navigation_with_ToList_followed_by_projecting_count(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_nested(bool async)
    {
        await base.Correlated_collections_nested(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_nested_inner_subquery_references_outer_qsre_one_level_up(bool async)
    {
        await base.Correlated_collections_nested_inner_subquery_references_outer_qsre_one_level_up(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_nested_inner_subquery_references_outer_qsre_two_levels_up(bool async)
    {
        await base.Correlated_collections_nested_inner_subquery_references_outer_qsre_two_levels_up(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_nested_mixed_streaming_with_buffer1(bool async)
    {
        await base.Correlated_collections_nested_mixed_streaming_with_buffer1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_nested_mixed_streaming_with_buffer2(bool async)
    {
        await base.Correlated_collections_nested_mixed_streaming_with_buffer2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_nested_with_custom_ordering(bool async)
    {
        await base.Correlated_collections_nested_with_custom_ordering(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_on_left_join_with_null_value(bool async)
    {
        await base.Correlated_collections_on_left_join_with_null_value(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_on_left_join_with_predicate(bool async)
    {
        await base.Correlated_collections_on_left_join_with_predicate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_on_RightJoin_with_predicate(bool async)
    {
        await base.Correlated_collections_on_RightJoin_with_predicate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_on_select_many(bool async)
    {
        await base.Correlated_collections_on_select_many(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_project_anonymous_collection_result(bool async)
    {
        await base.Correlated_collections_project_anonymous_collection_result(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_projection_of_collection_thru_navigation(bool async)
    {
        await base.Correlated_collections_projection_of_collection_thru_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_same_collection_projected_multiple_times(bool async)
    {
        await base.Correlated_collections_same_collection_projected_multiple_times(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_similar_collection_projected_multiple_times(bool async)
    {
        await base.Correlated_collections_similar_collection_projected_multiple_times(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_with_Distinct(bool async)
    {
        await base.Correlated_collections_with_Distinct(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_with_FirstOrDefault(bool async)
    {
        await base.Correlated_collections_with_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_with_funky_orderby_complex_scenario1(bool async)
    {
        await base.Correlated_collections_with_funky_orderby_complex_scenario1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_with_funky_orderby_complex_scenario2(bool async)
    {
        await base.Correlated_collections_with_funky_orderby_complex_scenario2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_with_Skip(bool async)
    {
        await base.Correlated_collections_with_Skip(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collections_with_Take(bool async)
    {
        await base.Correlated_collections_with_Take(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Count_with_optional_navigation_is_translated_to_sql(bool async)
    {
        await base.Count_with_optional_navigation_is_translated_to_sql(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DateTimeOffset_Contains_Less_than_Greater_than(bool async)
    {
        await base.DateTimeOffset_Contains_Less_than_Greater_than(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DateTimeOffset_Date_returns_datetime(bool async)
    {
        await base.DateTimeOffset_Date_returns_datetime(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DateTimeOffsetNow_minus_timespan(bool async)
    {
        await base.DateTimeOffsetNow_minus_timespan(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DefaultIfEmpty_top_level_over_arbitrary_expression_with_non_nullable_value_type(bool async)
    {
        await base.DefaultIfEmpty_top_level_over_arbitrary_expression_with_non_nullable_value_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DefaultIfEmpty_top_level_over_arbitrary_expression_with_nullable_value_type(bool async)
    {
        await base.DefaultIfEmpty_top_level_over_arbitrary_expression_with_nullable_value_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DefaultIfEmpty_top_level_over_column_with_nullable_value_type(bool async)
    {
        await base.DefaultIfEmpty_top_level_over_column_with_nullable_value_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Derived_reference_is_skipped_when_base_type(bool async)
    {
        await base.Derived_reference_is_skipped_when_base_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distinct_on_subquery_doesnt_get_lifted(bool async)
    {
        await base.Distinct_on_subquery_doesnt_get_lifted(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distinct_with_optional_navigation_is_translated_to_sql(bool async)
    {
        await base.Distinct_with_optional_navigation_is_translated_to_sql(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Double_order_by_binary_expression(bool async)
    {
        await base.Double_order_by_binary_expression(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Double_order_by_on_is_null(bool async)
    {
        await base.Double_order_by_on_is_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Double_order_by_on_Like(bool async)
    {
        await base.Double_order_by_on_Like(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Double_order_by_on_nullable_bool_coming_from_optional_navigation(bool async)
    {
        await base.Double_order_by_on_nullable_bool_coming_from_optional_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Double_order_by_on_string_compare(bool async)
    {
        await base.Double_order_by_on_string_compare(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task EF_Property_based_Include_navigation_on_derived_type(bool async)
    {
        await base.EF_Property_based_Include_navigation_on_derived_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ElementAt_basic_with_OrderBy(bool async)
    {
        await base.ElementAt_basic_with_OrderBy(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ElementAtOrDefault_basic_with_OrderBy(bool async)
    {
        await base.ElementAtOrDefault_basic_with_OrderBy(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ElementAtOrDefault_basic_with_OrderBy_parameter(bool async)
    {
        await base.ElementAtOrDefault_basic_with_OrderBy_parameter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Entity_equality_empty(bool async)
    {
        await base.Entity_equality_empty(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Enum_array_contains(bool async)
    {
        await base.Enum_array_contains(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Enum_closure_typed_as_underlying_type_generates_correct_parameter_type(bool async)
    {
        await base.Enum_closure_typed_as_underlying_type_generates_correct_parameter_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Enum_flags_closure_typed_as_different_type_generates_correct_parameter_type(bool async)
    {
        await base.Enum_flags_closure_typed_as_different_type_generates_correct_parameter_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Enum_flags_closure_typed_as_underlying_type_generates_correct_parameter_type(bool async)
    {
        await base.Enum_flags_closure_typed_as_underlying_type_generates_correct_parameter_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Enum_matching_take_value_gets_different_type_mapping(bool async)
    {
        await base.Enum_matching_take_value_gets_different_type_mapping(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_on_subquery_projecting_one_value_type_from_empty_collection(bool async)
    {
        await base.Filter_on_subquery_projecting_one_value_type_from_empty_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_with_complex_predicate_containing_subquery(bool async)
    {
        await base.Filter_with_complex_predicate_containing_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_collection_projection_with_order_comparison_predicate_converted_to_join(bool async)
    {
        await base.Filtered_collection_projection_with_order_comparison_predicate_converted_to_join(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_collection_projection_with_order_comparison_predicate_converted_to_join2(bool async)
    {
        await base.Filtered_collection_projection_with_order_comparison_predicate_converted_to_join2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_collection_projection_with_order_comparison_predicate_converted_to_join3(bool async)
    {
        await base.Filtered_collection_projection_with_order_comparison_predicate_converted_to_join3(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Find_underlying_property_after_GroupJoin_DefaultIfEmpty(bool async)
    {
        await base.Find_underlying_property_after_GroupJoin_DefaultIfEmpty(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FirstOrDefault_navigation_access_entity_equality_in_where_predicate_apply_peneding_selector(bool async)
    {
        await base.FirstOrDefault_navigation_access_entity_equality_in_where_predicate_apply_peneding_selector(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FirstOrDefault_on_empty_collection_of_DateTime_in_subquery(bool async)
    {
        await base.FirstOrDefault_on_empty_collection_of_DateTime_in_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FirstOrDefault_over_int_compared_to_zero(bool async)
    {
        await base.FirstOrDefault_over_int_compared_to_zero(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FirstOrDefault_with_manually_created_groupjoin_is_translated_to_sql(bool async)
    {
        await base.FirstOrDefault_with_manually_created_groupjoin_is_translated_to_sql(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetValueOrDefault_in_filter(bool async)
    {
        await base.GetValueOrDefault_in_filter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetValueOrDefault_in_filter_non_nullable_column(bool async)
    {
        await base.GetValueOrDefault_in_filter_non_nullable_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetValueOrDefault_in_order_by(bool async)
    {
        await base.GetValueOrDefault_in_order_by(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetValueOrDefault_in_projection(bool async)
    {
        await base.GetValueOrDefault_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetValueOrDefault_on_DateTimeOffset(bool async)
    {
        await base.GetValueOrDefault_on_DateTimeOffset(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetValueOrDefault_with_argument(bool async)
    {
        await base.GetValueOrDefault_with_argument(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetValueOrDefault_with_argument_complex(bool async)
    {
        await base.GetValueOrDefault_with_argument_complex(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_nullable_property_and_project_the_grouping_key_HasValue(bool async)
    {
        await base.Group_by_nullable_property_and_project_the_grouping_key_HasValue(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_nullable_property_HasValue_and_project_the_grouping_key(bool async)
    {
        await base.Group_by_nullable_property_HasValue_and_project_the_grouping_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_on_StartsWith_with_null_parameter_as_argument(bool async)
    {
        await base.Group_by_on_StartsWith_with_null_parameter_as_argument(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_over_projection_with_multiple_properties_accessed_thru_navigation(bool async)
    {
        await base.Group_by_over_projection_with_multiple_properties_accessed_thru_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_with_aggregate_max_on_entity_type(bool async)
    {
        await base.Group_by_with_aggregate_max_on_entity_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_with_having_StartsWith_with_null_parameter_as_argument(bool async)
    {
        await base.Group_by_with_having_StartsWith_with_null_parameter_as_argument(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_with_include_with_entity_in_result_selector(bool async)
    {
        await base.Group_by_with_include_with_entity_in_result_selector(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Groupby_anonymous_type_with_navigations_followed_up_by_anonymous_projection_and_orderby(bool async)
    {
        await base.Groupby_anonymous_type_with_navigations_followed_up_by_anonymous_projection_and_orderby(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_Property_Include_Aggregate_with_anonymous_selector(bool async)
    {
        await base.GroupBy_Property_Include_Aggregate_with_anonymous_selector(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_Property_Include_Select_Average(bool async)
    {
        await base.GroupBy_Property_Include_Select_Average(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_Property_Include_Select_Count(bool async)
    {
        await base.GroupBy_Property_Include_Select_Count(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_Property_Include_Select_LongCount(bool async)
    {
        await base.GroupBy_Property_Include_Select_LongCount(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_Property_Include_Select_Max(bool async)
    {
        await base.GroupBy_Property_Include_Select_Max(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_Property_Include_Select_Min(bool async)
    {
        await base.GroupBy_Property_Include_Select_Min(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_Property_Include_Select_Sum(bool async)
    {
        await base.GroupBy_Property_Include_Select_Sum(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_Select_sum(bool async)
    {
        await base.GroupBy_Select_sum(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_with_boolean_groupin_key_thru_navigation_access(bool async)
    {
        await base.GroupBy_with_boolean_groupin_key_thru_navigation_access(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_with_boolean_grouping_key(bool async)
    {
        await base.GroupBy_with_boolean_grouping_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupJoin_Composite_Key(bool async)
    {
        await base.GroupJoin_Composite_Key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupJoin_on_entity_qsre_keys_inner_key_is_nested_navigation(bool async)
    {
        await base.GroupJoin_on_entity_qsre_keys_inner_key_is_nested_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_after_select_anonymous_projection_throws(bool async)
    {
        await base.Include_after_select_anonymous_projection_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_after_Select_throws(bool async)
    {
        await base.Include_after_Select_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_after_select_with_cast_throws(bool async)
    {
        await base.Include_after_select_with_cast_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_after_select_with_entity_projection_throws(bool async)
    {
        await base.Include_after_select_with_entity_projection_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_after_SelectMany_throws(bool async)
    {
        await base.Include_after_SelectMany_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_base_navigation_on_derived_entity(bool async)
    {
        await base.Include_base_navigation_on_derived_entity(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_and_invalid_navigation_using_string_throws(bool async)
    {
        await base.Include_collection_and_invalid_navigation_using_string_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_on_derived_type_using_EF_Property(bool async)
    {
        await base.Include_collection_on_derived_type_using_EF_Property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_on_derived_type_using_lambda(bool async)
    {
        await base.Include_collection_on_derived_type_using_lambda(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_on_derived_type_using_lambda_with_soft_cast(bool async)
    {
        await base.Include_collection_on_derived_type_using_lambda_with_soft_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_on_derived_type_using_string(bool async)
    {
        await base.Include_collection_on_derived_type_using_string(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_OrderBy_aggregate(bool async)
    {
        await base.Include_collection_OrderBy_aggregate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_Cast_to_base(bool async)
    {
        await base.Include_collection_with_Cast_to_base(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_complex_OrderBy2(bool async)
    {
        await base.Include_collection_with_complex_OrderBy2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_complex_OrderBy3(bool async)
    {
        await base.Include_collection_with_complex_OrderBy3(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_multiple_circular(bool async)
    {
        await base.Include_multiple_circular(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_multiple_circular_with_filter(bool async)
    {
        await base.Include_multiple_circular_with_filter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_multiple_include_then_include(bool async)
    {
        await base.Include_multiple_include_then_include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_multiple_one_to_one_and_one_to_many(bool async)
    {
        await base.Include_multiple_one_to_one_and_one_to_many(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_multiple_one_to_one_and_one_to_many_self_reference(bool async)
    {
        await base.Include_multiple_one_to_one_and_one_to_many_self_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_multiple_one_to_one_and_one_to_one_and_one_to_many(bool async)
    {
        await base.Include_multiple_one_to_one_and_one_to_one_and_one_to_many(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_multiple_one_to_one_optional_and_one_to_one_required(bool async)
    {
        await base.Include_multiple_one_to_one_optional_and_one_to_one_required(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_navigation_on_derived_type(bool async)
    {
        await base.Include_navigation_on_derived_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_on_derived_entity_using_OfType(bool async)
    {
        await base.Include_on_derived_entity_using_OfType(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_on_derived_entity_with_cast(bool async)
    {
        await base.Include_on_derived_entity_with_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_on_derived_multi_level(bool async)
    {
        await base.Include_on_derived_multi_level(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_on_derived_type_with_order_by_and_paging(bool async)
    {
        await base.Include_on_derived_type_with_order_by_and_paging(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_on_entity_that_is_not_present_in_final_projection_but_uses_TypeIs_instead(bool async)
    {
        await base.Include_on_entity_that_is_not_present_in_final_projection_but_uses_TypeIs_instead(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_coalesce_result1()
    {
        base.Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_coalesce_result1();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_coalesce_result2()
    {
        base.Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_coalesce_result2();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_coalesce_result3(bool async)
    {
        await base.Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_coalesce_result3(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_coalesce_result4(bool async)
    {
        await base.Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_coalesce_result4(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_complex_projection_result(bool async)
    {
        await base.Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_complex_projection_result(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_conditional_result(bool async)
    {
        await base.Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_conditional_result(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_inheritance_and_coalesce_result(bool async)
    {
        await base.Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_inheritance_and_coalesce_result(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_one_to_many_on_composite_key_then_orderby_key_properties(bool async)
    {
        await base.Include_one_to_many_on_composite_key_then_orderby_key_properties(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_on_derived_type_using_EF_Property(bool async)
    {
        await base.Include_reference_on_derived_type_using_EF_Property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_on_derived_type_using_lambda(bool async)
    {
        await base.Include_reference_on_derived_type_using_lambda(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_on_derived_type_using_lambda_with_soft_cast(bool async)
    {
        await base.Include_reference_on_derived_type_using_lambda_with_soft_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_on_derived_type_using_lambda_with_tracking(bool async)
    {
        await base.Include_reference_on_derived_type_using_lambda_with_tracking(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_on_derived_type_using_string(bool async)
    {
        await base.Include_reference_on_derived_type_using_string(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_on_derived_type_using_string_nested1(bool async)
    {
        await base.Include_reference_on_derived_type_using_string_nested1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_on_derived_type_using_string_nested2(bool async)
    {
        await base.Include_reference_on_derived_type_using_string_nested2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_using_alternate_key(bool async)
    {
        await base.Include_using_alternate_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_where_list_contains_navigation(bool async)
    {
        await base.Include_where_list_contains_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_where_list_contains_navigation2(bool async)
    {
        await base.Include_where_list_contains_navigation2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_client_method_and_member_access_still_applies_includes(bool async)
    {
        await base.Include_with_client_method_and_member_access_still_applies_includes(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_complex_order_by(bool async)
    {
        await base.Include_with_complex_order_by(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_concat(bool async)
    {
        await base.Include_with_concat(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_group_by_and_FirstOrDefault_gets_properly_applied(bool async)
    {
        await base.Include_with_group_by_and_FirstOrDefault_gets_properly_applied(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_join_and_inheritance_with_orderby_before_and_after_include(bool async)
    {
        await base.Include_with_join_and_inheritance_with_orderby_before_and_after_include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_join_and_inheritance1(bool async)
    {
        await base.Include_with_join_and_inheritance1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_join_and_inheritance2(bool async)
    {
        await base.Include_with_join_and_inheritance2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_join_and_inheritance3(bool async)
    {
        await base.Include_with_join_and_inheritance3(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_join_collection1(bool async)
    {
        await base.Include_with_join_collection1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_join_collection2(bool async)
    {
        await base.Include_with_join_collection2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_join_multi_level(bool async)
    {
        await base.Include_with_join_multi_level(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_join_reference1(bool async)
    {
        await base.Include_with_join_reference1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_join_reference2(bool async)
    {
        await base.Include_with_join_reference2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_nested_navigation_in_order_by(bool async)
    {
        await base.Include_with_nested_navigation_in_order_by(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_order_by_constant(bool async)
    {
        await base.Include_with_order_by_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_projection_of_unmapped_property_still_gets_applied(bool async)
    {
        await base.Include_with_projection_of_unmapped_property_still_gets_applied(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_entity_with_itself_grouped_by_key_followed_by_include_skip_take(bool async)
    {
        await base.Join_entity_with_itself_grouped_by_key_followed_by_include_skip_take(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_include_coalesce_nested(bool async)
    {
        await base.Join_include_coalesce_nested(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_include_coalesce_simple(bool async)
    {
        await base.Join_include_coalesce_simple(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_include_conditional(bool async)
    {
        await base.Join_include_conditional(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_inner_source_custom_projection_followed_by_filter(bool async)
    {
        await base.Join_inner_source_custom_projection_followed_by_filter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_navigation_translated_to_subquery_composite_key(bool async)
    {
        await base.Join_navigation_translated_to_subquery_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_on_entity_qsre_keys(bool async)
    {
        await base.Join_on_entity_qsre_keys(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_on_entity_qsre_keys_composite_key(bool async)
    {
        await base.Join_on_entity_qsre_keys_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_on_entity_qsre_keys_inheritance(bool async)
    {
        await base.Join_on_entity_qsre_keys_inheritance(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_on_entity_qsre_keys_inner_key_is_navigation(bool async)
    {
        await base.Join_on_entity_qsre_keys_inner_key_is_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_on_entity_qsre_keys_inner_key_is_navigation_composite_key(bool async)
    {
        await base.Join_on_entity_qsre_keys_inner_key_is_navigation_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_on_entity_qsre_keys_inner_key_is_nested_navigation(bool async)
    {
        await base.Join_on_entity_qsre_keys_inner_key_is_nested_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_on_entity_qsre_keys_outer_key_is_navigation(bool async)
    {
        await base.Join_on_entity_qsre_keys_outer_key_is_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_predicate_condition_equals_condition(bool async)
    {
        await base.Join_predicate_condition_equals_condition(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_predicate_value(bool async)
    {
        await base.Join_predicate_value(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_predicate_value_equals_condition(bool async)
    {
        await base.Join_predicate_value_equals_condition(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_with_complex_key_selector(bool async)
    {
        await base.Join_with_complex_key_selector(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_with_inner_being_a_subquery_projecting_anonymous_type_with_single_property(bool async)
    {
        await base.Join_with_inner_being_a_subquery_projecting_anonymous_type_with_single_property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_with_inner_being_a_subquery_projecting_single_property(bool async)
    {
        await base.Join_with_inner_being_a_subquery_projecting_single_property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_with_order_by_on_inner_sequence_navigation_translated_to_subquery_composite_key(bool async)
    {
        await base.Join_with_order_by_on_inner_sequence_navigation_translated_to_subquery_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_with_order_by_without_skip_or_take(bool async)
    {
        await base.Join_with_order_by_without_skip_or_take(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_with_order_by_without_skip_or_take_nested(bool async)
    {
        await base.Join_with_order_by_without_skip_or_take_nested(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Left_join_predicate_condition_equals_condition(bool async)
    {
        await base.Left_join_predicate_condition_equals_condition(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Left_join_predicate_value(bool async)
    {
        await base.Left_join_predicate_value(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Left_join_predicate_value_equals_condition(bool async)
    {
        await base.Left_join_predicate_value_equals_condition(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Left_join_projection_using_coalesce_tracking(bool async)
    {
        await base.Left_join_projection_using_coalesce_tracking(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Left_join_projection_using_conditional_tracking(bool async)
    {
        await base.Left_join_projection_using_conditional_tracking(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Left_join_with_GroupBy_with_composite_group_key(bool async)
    {
        await base.Left_join_with_GroupBy_with_composite_group_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Logical_operation_with_non_null_parameter_optimizes_null_checks(bool async)
    {
        await base.Logical_operation_with_non_null_parameter_optimizes_null_checks(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Member_access_on_derived_entity_using_cast(bool async)
    {
        await base.Member_access_on_derived_entity_using_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Member_access_on_derived_entity_using_cast_and_let(bool async)
    {
        await base.Member_access_on_derived_entity_using_cast_and_let(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Member_access_on_derived_materialized_entity_using_cast(bool async)
    {
        await base.Member_access_on_derived_materialized_entity_using_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_derived_included_on_one_method(bool async)
    {
        await base.Multiple_derived_included_on_one_method(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Multiple_includes_with_client_method_around_entity_and_also_projecting_included_collection()
    {
        return base.Multiple_includes_with_client_method_around_entity_and_also_projecting_included_collection();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_order_bys_are_properly_lifted_from_subquery_created_by_include(bool async)
    {
        await base.Multiple_order_bys_are_properly_lifted_from_subquery_created_by_include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_orderby_with_navigation_expansion_on_one_of_the_order_bys(bool async)
    {
        await base.Multiple_orderby_with_navigation_expansion_on_one_of_the_order_bys(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_orderby_with_navigation_expansion_on_one_of_the_order_bys_inside_subquery(bool async)
    {
        await base.Multiple_orderby_with_navigation_expansion_on_one_of_the_order_bys_inside_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_orderby_with_navigation_expansion_on_one_of_the_order_bys_inside_subquery_complex_orderings(bool async)
    {
        await base.Multiple_orderby_with_navigation_expansion_on_one_of_the_order_bys_inside_subquery_complex_orderings(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_orderby_with_navigation_expansion_on_one_of_the_order_bys_inside_subquery_duplicated_orderings(bool async)
    {
        await base.Multiple_orderby_with_navigation_expansion_on_one_of_the_order_bys_inside_subquery_duplicated_orderings(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nav_expansion_inside_Contains_argument(bool async)
    {
        await base.Nav_expansion_inside_Contains_argument(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nav_expansion_with_member_pushdown_inside_Contains_argument(bool async)
    {
        await base.Nav_expansion_with_member_pushdown_inside_Contains_argument(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nav_rewrite_Distinct_with_convert()
    {
        await base.Nav_rewrite_Distinct_with_convert();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nav_rewrite_Distinct_with_convert_anonymous()
    {
        await base.Nav_rewrite_Distinct_with_convert_anonymous();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nav_rewrite_with_convert1(bool async)
    {
        await base.Nav_rewrite_with_convert1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nav_rewrite_with_convert2(bool async)
    {
        await base.Nav_rewrite_with_convert2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nav_rewrite_with_convert3(bool async)
    {
        await base.Nav_rewrite_with_convert3(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_access_fk_on_derived_entity_using_cast(bool async)
    {
        await base.Navigation_access_fk_on_derived_entity_using_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_access_on_derived_entity_using_cast(bool async)
    {
        await base.Navigation_access_on_derived_entity_using_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_access_on_derived_materialized_entity_using_cast(bool async)
    {
        await base.Navigation_access_on_derived_materialized_entity_using_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_access_via_EFProperty_on_derived_entity_using_cast(bool async)
    {
        await base.Navigation_access_via_EFProperty_on_derived_entity_using_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_accessed_twice_outside_and_inside_subquery(bool async)
    {
        await base.Navigation_accessed_twice_outside_and_inside_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_based_on_complex_expression1(bool async)
    {
        await base.Navigation_based_on_complex_expression1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_based_on_complex_expression2(bool async)
    {
        await base.Navigation_based_on_complex_expression2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_based_on_complex_expression3(bool async)
    {
        await base.Navigation_based_on_complex_expression3(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_based_on_complex_expression4(bool async)
    {
        await base.Navigation_based_on_complex_expression4(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_based_on_complex_expression5(bool async)
    {
        await base.Navigation_based_on_complex_expression5(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_based_on_complex_expression6(bool async)
    {
        await base.Navigation_based_on_complex_expression6(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_inside_interpolated_string_expanded(bool async)
    {
        await base.Navigation_inside_interpolated_string_expanded(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Negated_bool_ternary_inside_anonymous_type_in_projection(bool async)
    {
        await base.Negated_bool_ternary_inside_anonymous_type_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nested_contains_with_enum(bool async)
    {
        await base.Nested_contains_with_enum(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Non_string_concat_uses_appropriate_type_mapping(bool async)
    {
        await base.Non_string_concat_uses_appropriate_type_mapping(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Non_unicode_parameter_is_used_for_non_unicode_column(bool async)
    {
        await base.Non_unicode_parameter_is_used_for_non_unicode_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Non_unicode_string_literal_is_used_for_non_unicode_column(bool async)
    {
        await base.Non_unicode_string_literal_is_used_for_non_unicode_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Non_unicode_string_literal_is_used_for_non_unicode_column_right(bool async)
    {
        await base.Non_unicode_string_literal_is_used_for_non_unicode_column_right(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Non_unicode_string_literals_in_contains_is_used_for_non_unicode_column(bool async)
    {
        await base.Non_unicode_string_literals_in_contains_is_used_for_non_unicode_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Non_unicode_string_literals_is_used_for_non_unicode_column_in_subquery(bool async)
    {
        await base.Non_unicode_string_literals_is_used_for_non_unicode_column_in_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Non_unicode_string_literals_is_used_for_non_unicode_column_with_contains(bool async)
    {
        await base.Non_unicode_string_literals_is_used_for_non_unicode_column_with_contains(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Non_unicode_string_literals_is_used_for_non_unicode_column_with_subquery(bool async)
    {
        await base.Non_unicode_string_literals_is_used_for_non_unicode_column_with_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Null_checks_in_correlated_predicate_are_correctly_translated(bool async)
    {
        await base.Null_checks_in_correlated_predicate_are_correctly_translated(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Null_propagation_optimization1(bool async)
    {
        await base.Null_propagation_optimization1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Null_propagation_optimization2(bool async)
    {
        await base.Null_propagation_optimization2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Null_propagation_optimization3(bool async)
    {
        await base.Null_propagation_optimization3(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Null_propagation_optimization4(bool async)
    {
        await base.Null_propagation_optimization4(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Null_propagation_optimization5(bool async)
    {
        await base.Null_propagation_optimization5(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Null_propagation_optimization6(bool async)
    {
        await base.Null_propagation_optimization6(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Null_semantics_is_correctly_applied_for_function_comparisons_that_take_arguments_from_optional_navigation(bool async)
    {
        await base.Null_semantics_is_correctly_applied_for_function_comparisons_that_take_arguments_from_optional_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Null_semantics_is_correctly_applied_for_function_comparisons_that_take_arguments_from_optional_navigation_complex(bool async)
    {
        await base.Null_semantics_is_correctly_applied_for_function_comparisons_that_take_arguments_from_optional_navigation_complex(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Null_semantics_on_nullable_bool_from_inner_join_subquery_is_fully_applied(bool async)
    {
        await base.Null_semantics_on_nullable_bool_from_inner_join_subquery_is_fully_applied(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Null_semantics_on_nullable_bool_from_left_join_subquery_is_fully_applied(bool async)
    {
        await base.Null_semantics_on_nullable_bool_from_left_join_subquery_is_fully_applied(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nullable_bool_comparison_is_translated_to_server(bool async)
    {
        await base.Nullable_bool_comparison_is_translated_to_server(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OfType_in_subquery_works(bool async)
    {
        await base.OfType_in_subquery_works(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OfTypeNav1(bool async)
    {
        await base.OfTypeNav1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OfTypeNav2(bool async)
    {
        await base.OfTypeNav2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OfTypeNav3(bool async)
    {
        await base.OfTypeNav3(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_Navigation_Null_Coalesce_To_Clr_Type(bool async)
    {
        await base.Optional_Navigation_Null_Coalesce_To_Clr_Type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_all(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_all(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_array_initializers(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_array_initializers(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_binary_and_expression(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_binary_and_expression(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_binary_expression(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_binary_expression(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_conditional_expression(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_conditional_expression(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_contains(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_contains(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_DTOs(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_DTOs(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_list_initializers(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_list_initializers(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_negated_predicate(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_negated_predicate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_orderby(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_orderby(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_predicate(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_predicate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_predicate_negated(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_predicate_negated(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_predicate_negated_complex1(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_predicate_negated_complex1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_predicate_negated_complex2(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_predicate_negated_complex2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_predicate2(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_predicate2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_projection(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_projection_into_anonymous_type(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_projection_into_anonymous_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_skip(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_skip(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_type_compensation_works_with_take(bool async)
    {
        await base.Optional_navigation_type_compensation_works_with_take(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_with_collection_composite_key(bool async)
    {
        await base.Optional_navigation_with_collection_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Order_by_entity_qsre(bool async)
    {
        await base.Order_by_entity_qsre(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Order_by_entity_qsre_composite_key(bool async)
    {
        await base.Order_by_entity_qsre_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Order_by_entity_qsre_with_inheritance(bool async)
    {
        await base.Order_by_entity_qsre_with_inheritance(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Order_by_entity_qsre_with_other_orderbys(bool async)
    {
        await base.Order_by_entity_qsre_with_other_orderbys(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Order_by_is_properly_lifted_from_subquery_with_same_order_by_in_the_outer_query(bool async)
    {
        await base.Order_by_is_properly_lifted_from_subquery_with_same_order_by_in_the_outer_query(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Orderby_added_for_client_side_GroupJoin_composite_dependent_to_principal_LOJ_when_incomplete_key_is_used(bool async)
    {
        await base.Orderby_added_for_client_side_GroupJoin_composite_dependent_to_principal_LOJ_when_incomplete_key_is_used(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OrderBy_bool_coming_from_optional_navigation(bool async)
    {
        await base.OrderBy_bool_coming_from_optional_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OrderBy_Contains_empty_list(bool async)
    {
        await base.OrderBy_Contains_empty_list(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OrderBy_same_expression_containing_IsNull_correctly_deduplicates_the_ordering(bool async)
    {
        await base.OrderBy_same_expression_containing_IsNull_correctly_deduplicates_the_ordering(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OrderBy_StartsWith_with_null_parameter_as_argument(bool async)
    {
        await base.OrderBy_StartsWith_with_null_parameter_as_argument(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Outer_parameter_in_group_join_with_DefaultIfEmpty(bool async)
    {
        await base.Outer_parameter_in_group_join_with_DefaultIfEmpty(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Outer_parameter_in_join_key(bool async)
    {
        await base.Outer_parameter_in_join_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Outer_parameter_in_join_key_inner_and_outer(bool async)
    {
        await base.Outer_parameter_in_join_key_inner_and_outer(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_used_multiple_times_take_appropriate_inferred_type_mapping(bool async)
    {
        await base.Parameter_used_multiple_times_take_appropriate_inferred_type_mapping(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_navigation_nested_composite_key(bool async)
    {
        await base.Project_collection_navigation_nested_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_navigation_nested_with_take_composite_key(bool async)
    {
        await base.Project_collection_navigation_nested_with_take_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_navigation_with_inheritance1(bool async)
    {
        await base.Project_collection_navigation_with_inheritance1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_navigation_with_inheritance2(bool async)
    {
        await base.Project_collection_navigation_with_inheritance2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_navigation_with_inheritance3(bool async)
    {
        await base.Project_collection_navigation_with_inheritance3(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_derivied_entity_with_convert_to_parent(bool async)
    {
        await base.Project_derivied_entity_with_convert_to_parent(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_discriminator_columns(bool async)
    {
        await base.Project_discriminator_columns(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_entity_and_collection_element(bool async)
    {
        await base.Project_entity_and_collection_element(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_equality_with_value_converted_property(bool async)
    {
        await base.Project_equality_with_value_converted_property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_navigation_defined_on_base_from_entity_with_inheritance_using_soft_cast(bool async)
    {
        await base.Project_navigation_defined_on_base_from_entity_with_inheritance_using_soft_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_navigation_defined_on_derived_from_entity_with_inheritance_using_soft_cast(bool async)
    {
        await base.Project_navigation_defined_on_derived_from_entity_with_inheritance_using_soft_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_one_value_type_converted_to_nullable_from_empty_collection(bool async)
    {
        await base.Project_one_value_type_converted_to_nullable_from_empty_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_one_value_type_from_empty_collection(bool async)
    {
        await base.Project_one_value_type_from_empty_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_one_value_type_with_client_projection_from_empty_collection(bool async)
    {
        await base.Project_one_value_type_with_client_projection_from_empty_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_shadow_properties(bool async)
    {
        await base.Project_shadow_properties(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_correlated_collection_followed_by_Distinct(bool async)
    {
        await base.Projecting_correlated_collection_followed_by_Distinct(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_entity_as_well_as_complex_correlated_collection_followed_by_Distinct(bool async)
    {
        await base.Projecting_entity_as_well_as_complex_correlated_collection_followed_by_Distinct(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_entity_as_well_as_correlated_collection_followed_by_Distinct(bool async)
    {
        await base.Projecting_entity_as_well_as_correlated_collection_followed_by_Distinct(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_entity_as_well_as_correlated_collection_of_scalars_followed_by_Distinct(bool async)
    {
        await base.Projecting_entity_as_well_as_correlated_collection_of_scalars_followed_by_Distinct(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_nullable_bool_in_conditional_works(bool async)
    {
        await base.Projecting_nullable_bool_in_conditional_works(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_property_converted_to_nullable_and_use_it_in_order_by(bool async)
    {
        await base.Projecting_property_converted_to_nullable_and_use_it_in_order_by(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_property_converted_to_nullable_into_element_init(bool async)
    {
        await base.Projecting_property_converted_to_nullable_into_element_init(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_property_converted_to_nullable_into_member_access(bool async)
    {
        await base.Projecting_property_converted_to_nullable_into_member_access(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_property_converted_to_nullable_into_member_assignment(bool async)
    {
        await base.Projecting_property_converted_to_nullable_into_member_assignment(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_property_converted_to_nullable_into_new_array(bool async)
    {
        await base.Projecting_property_converted_to_nullable_into_new_array(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_property_converted_to_nullable_into_unary(bool async)
    {
        await base.Projecting_property_converted_to_nullable_into_unary(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_property_converted_to_nullable_with_addition(bool async)
    {
        await base.Projecting_property_converted_to_nullable_with_addition(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_property_converted_to_nullable_with_addition_and_final_projection(bool async)
    {
        await base.Projecting_property_converted_to_nullable_with_addition_and_final_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_property_converted_to_nullable_with_comparison(bool async)
    {
        await base.Projecting_property_converted_to_nullable_with_comparison(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_property_converted_to_nullable_with_conditional(bool async)
    {
        await base.Projecting_property_converted_to_nullable_with_conditional(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_property_converted_to_nullable_with_function_call(bool async)
    {
        await base.Projecting_property_converted_to_nullable_with_function_call(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_property_converted_to_nullable_with_function_call2(bool async)
    {
        await base.Projecting_property_converted_to_nullable_with_function_call2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_required_string_column_compared_to_null_parameter(bool async)
    {
        await base.Projecting_required_string_column_compared_to_null_parameter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_some_properties_as_well_as_correlated_collection_followed_by_Distinct(bool async)
    {
        await base.Projecting_some_properties_as_well_as_correlated_collection_followed_by_Distinct(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Property_access_on_derived_entity_using_cast(bool async)
    {
        await base.Property_access_on_derived_entity_using_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_reusing_parameter_doesnt_declare_duplicate_parameter(bool async)
    {
        await base.Query_reusing_parameter_doesnt_declare_duplicate_parameter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_reusing_parameter_doesnt_declare_duplicate_parameter_complex(bool async)
    {
        await base.Query_reusing_parameter_doesnt_declare_duplicate_parameter_complex(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_reusing_parameter_with_inner_query_doesnt_declare_duplicate_parameter(bool async)
    {
        await base.Query_reusing_parameter_with_inner_query_doesnt_declare_duplicate_parameter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_reusing_parameter_with_inner_query_expression_doesnt_declare_duplicate_parameter(bool async)
    {
        await base.Query_reusing_parameter_with_inner_query_expression_doesnt_declare_duplicate_parameter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_with_complex_let_containing_ordering_and_filter_projecting_firstOrDefault_element_of_let(bool async)
    {
        await base.Query_with_complex_let_containing_ordering_and_filter_projecting_firstOrDefault_element_of_let(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Reference_include_chain_loads_correctly_when_middle_is_null(bool async)
    {
        await base.Reference_include_chain_loads_correctly_when_middle_is_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_as_operator(bool async)
    {
        await base.Select_as_operator(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_coalesce_with_anonymous_types(bool async)
    {
        await base.Select_coalesce_with_anonymous_types(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_comparison_with_null(bool async)
    {
        await base.Select_comparison_with_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_conditional_with_anonymous_type_and_null_constant(bool async)
    {
        await base.Select_conditional_with_anonymous_type_and_null_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_conditional_with_anonymous_types(bool async)
    {
        await base.Select_conditional_with_anonymous_types(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_correlated_filtered_collection(bool async)
    {
        await base.Select_correlated_filtered_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_correlated_filtered_collection_returning_queryable_throws(bool async)
    {
        await base.Select_correlated_filtered_collection_returning_queryable_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_correlated_filtered_collection_with_composite_key(bool async)
    {
        await base.Select_correlated_filtered_collection_with_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_correlated_filtered_collection_works_with_caching(bool async)
    {
        await base.Select_correlated_filtered_collection_works_with_caching(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_datetimeoffset_comparison_in_projection(bool async)
    {
        await base.Select_datetimeoffset_comparison_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_inverted_boolean(bool async)
    {
        await base.Select_inverted_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_inverted_nullable_boolean(bool async)
    {
        await base.Select_inverted_nullable_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_length_of_string_property(bool async)
    {
        await base.Select_length_of_string_property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_multiple_conditions(bool async)
    {
        await base.Select_multiple_conditions(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_navigation_with_concat_and_count(bool async)
    {
        await base.Select_navigation_with_concat_and_count(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_nested_ternary_operations(bool async)
    {
        await base.Select_nested_ternary_operations(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_conditional_with_inheritance(bool async)
    {
        await base.Select_null_conditional_with_inheritance(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_conditional_with_inheritance_negative(bool async)
    {
        await base.Select_null_conditional_with_inheritance_negative(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_parameter(bool async)
    {
        await base.Select_null_parameter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_parameter_is_not_null(bool async)
    {
        await base.Select_null_parameter_is_not_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_propagation_negative1(bool async)
    {
        await base.Select_null_propagation_negative1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_propagation_negative2(bool async)
    {
        await base.Select_null_propagation_negative2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_propagation_negative3(bool async)
    {
        await base.Select_null_propagation_negative3(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_propagation_negative4(bool async)
    {
        await base.Select_null_propagation_negative4(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_propagation_negative5(bool async)
    {
        await base.Select_null_propagation_negative5(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_propagation_negative6(bool async)
    {
        await base.Select_null_propagation_negative6(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_propagation_negative7(bool async)
    {
        await base.Select_null_propagation_negative7(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_propagation_negative8(bool async)
    {
        await base.Select_null_propagation_negative8(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_propagation_negative9(bool async)
    {
        await base.Select_null_propagation_negative9(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_propagation_optimization7(bool async)
    {
        await base.Select_null_propagation_optimization7(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_propagation_optimization8(bool async)
    {
        await base.Select_null_propagation_optimization8(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_propagation_optimization9(bool async)
    {
        await base.Select_null_propagation_optimization9(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_propagation_works_for_multiple_navigations_with_composite_keys(bool async)
    {
        await base.Select_null_propagation_works_for_multiple_navigations_with_composite_keys(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_null_propagation_works_for_navigations_with_composite_keys(bool async)
    {
        await base.Select_null_propagation_works_for_navigations_with_composite_keys(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_required_navigation_on_derived_type(bool async)
    {
        await base.Select_required_navigation_on_derived_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_required_navigation_on_the_same_type_with_cast(bool async)
    {
        await base.Select_required_navigation_on_the_same_type_with_cast(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Singleton_Navigation_With_Member_Access(bool async)
    {
        await base.Select_Singleton_Navigation_With_Member_Access(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_StartsWith_with_null_parameter_as_argument(bool async)
    {
        await base.Select_StartsWith_with_null_parameter_as_argument(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_boolean(bool async)
    {
        await base.Select_subquery_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_boolean_empty(bool async)
    {
        await base.Select_subquery_boolean_empty(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_boolean_empty_with_pushdown(bool async)
    {
        await base.Select_subquery_boolean_empty_with_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_boolean_with_pushdown(bool async)
    {
        await base.Select_subquery_boolean_with_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_distinct_firstordefault(bool async)
    {
        await base.Select_subquery_distinct_firstordefault(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_distinct_singleordefault_boolean_empty_with_pushdown(bool async)
    {
        await base.Select_subquery_distinct_singleordefault_boolean_empty_with_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_distinct_singleordefault_boolean_empty1(bool async)
    {
        await base.Select_subquery_distinct_singleordefault_boolean_empty1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_distinct_singleordefault_boolean_empty2(bool async)
    {
        await base.Select_subquery_distinct_singleordefault_boolean_empty2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_distinct_singleordefault_boolean_with_pushdown(bool async)
    {
        await base.Select_subquery_distinct_singleordefault_boolean_with_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_distinct_singleordefault_boolean1(bool async)
    {
        await base.Select_subquery_distinct_singleordefault_boolean1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_distinct_singleordefault_boolean2(bool async)
    {
        await base.Select_subquery_distinct_singleordefault_boolean2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_int_with_inside_cast_and_coalesce(bool async)
    {
        await base.Select_subquery_int_with_inside_cast_and_coalesce(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_int_with_outside_cast_and_coalesce(bool async)
    {
        await base.Select_subquery_int_with_outside_cast_and_coalesce(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_int_with_pushdown_and_coalesce(bool async)
    {
        await base.Select_subquery_int_with_pushdown_and_coalesce(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_int_with_pushdown_and_coalesce2(bool async)
    {
        await base.Select_subquery_int_with_pushdown_and_coalesce2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_projecting_multiple_constants_inside_anonymous(bool async)
    {
        await base.Select_subquery_projecting_multiple_constants_inside_anonymous(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_projecting_single_constant_bool(bool async)
    {
        await base.Select_subquery_projecting_single_constant_bool(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_projecting_single_constant_inside_anonymous(bool async)
    {
        await base.Select_subquery_projecting_single_constant_inside_anonymous(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_projecting_single_constant_int(bool async)
    {
        await base.Select_subquery_projecting_single_constant_int(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_projecting_single_constant_null_of_non_mapped_type(bool async)
    {
        await base.Select_subquery_projecting_single_constant_null_of_non_mapped_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_projecting_single_constant_of_non_mapped_type(bool async)
    {
        await base.Select_subquery_projecting_single_constant_of_non_mapped_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_projecting_single_constant_string(bool async)
    {
        await base.Select_subquery_projecting_single_constant_string(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_ternary_operation_multiple_conditions(bool async)
    {
        await base.Select_ternary_operation_multiple_conditions(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_ternary_operation_multiple_conditions_2(bool async)
    {
        await base.Select_ternary_operation_multiple_conditions_2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_ternary_operation_with_boolean(bool async)
    {
        await base.Select_ternary_operation_with_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_ternary_operation_with_has_value_not_null(bool async)
    {
        await base.Select_ternary_operation_with_has_value_not_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_ternary_operation_with_inverted_boolean(bool async)
    {
        await base.Select_ternary_operation_with_inverted_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Where_Navigation(bool async)
    {
        await base.Select_Where_Navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Where_Navigation_Client(bool async)
    {
        await base.Select_Where_Navigation_Client(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Where_Navigation_Equals_Navigation(bool async)
    {
        await base.Select_Where_Navigation_Equals_Navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Where_Navigation_Included(bool async)
    {
        await base.Select_Where_Navigation_Included(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Where_Navigation_Null(bool async)
    {
        await base.Select_Where_Navigation_Null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Where_Navigation_Null_Reverse(bool async)
    {
        await base.Select_Where_Navigation_Null_Reverse(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Where_Navigation_Scalar_Equals_Navigation_Scalar(bool async)
    {
        await base.Select_Where_Navigation_Scalar_Equals_Navigation_Scalar(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Where_Navigation_Scalar_Equals_Navigation_Scalar_Projected(bool async)
    {
        await base.Select_Where_Navigation_Scalar_Equals_Navigation_Scalar_Projected(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_predicate_after_navigation_with_non_equality_comparison_DefaultIfEmpty_converted_to_left_join(bool async)
    {
        await base.SelectMany_predicate_after_navigation_with_non_equality_comparison_DefaultIfEmpty_converted_to_left_join(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_predicate_with_non_equality_comparison_converted_to_inner_join(bool async)
    {
        await base.SelectMany_predicate_with_non_equality_comparison_converted_to_inner_join(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_predicate_with_non_equality_comparison_DefaultIfEmpty_converted_to_left_join(bool async)
    {
        await base.SelectMany_predicate_with_non_equality_comparison_DefaultIfEmpty_converted_to_left_join(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_predicate_with_non_equality_comparison_with_Take_doesnt_convert_to_join(bool async)
    {
        await base.SelectMany_predicate_with_non_equality_comparison_with_Take_doesnt_convert_to_join(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_Where_DefaultIfEmpty_with_navigation_in_the_collection_selector(bool async)
    {
        await base.SelectMany_Where_DefaultIfEmpty_with_navigation_in_the_collection_selector(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_Where_DefaultIfEmpty_with_navigation_in_the_collection_selector_not_equal(bool async)
    {
        await base.SelectMany_Where_DefaultIfEmpty_with_navigation_in_the_collection_selector_not_equal(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_Where_DefaultIfEmpty_with_navigation_in_the_collection_selector_order_comparison(bool async)
    {
        await base.SelectMany_Where_DefaultIfEmpty_with_navigation_in_the_collection_selector_order_comparison(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_without_result_selector_and_non_equality_comparison_converted_to_join(bool async)
    {
        await base.SelectMany_without_result_selector_and_non_equality_comparison_converted_to_join(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Set_operator_with_navigation_in_projection_groupby_aggregate(bool async)
    {
        await base.Set_operator_with_navigation_in_projection_groupby_aggregate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Singleton_Navigation_With_Member_Access(bool async)
    {
        await base.Singleton_Navigation_With_Member_Access(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_with_orderby_followed_by_orderBy_is_pushed_down(bool async)
    {
        await base.Skip_with_orderby_followed_by_orderBy_is_pushed_down(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Streaming_correlated_collection_issue_11403(bool async)
    {
        await base.Streaming_correlated_collection_issue_11403(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Streaming_correlated_collection_issue_11403_returning_ordered_enumerable_throws(bool async)
    {
        await base.Streaming_correlated_collection_issue_11403_returning_ordered_enumerable_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_based_Include_navigation_on_derived_type(bool async)
    {
        await base.String_based_Include_navigation_on_derived_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_compare_with_null_conditional_argument(bool async)
    {
        await base.String_compare_with_null_conditional_argument(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_compare_with_null_conditional_argument2(bool async)
    {
        await base.String_compare_with_null_conditional_argument2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_concat_nullable_expressions_are_coalesced(bool async)
    {
        await base.String_concat_nullable_expressions_are_coalesced(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_concat_on_various_types(bool async)
    {
        await base.String_concat_on_various_types(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_concat_with_null_conditional_argument(bool async)
    {
        await base.String_concat_with_null_conditional_argument(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_concat_with_null_conditional_argument2(bool async)
    {
        await base.String_concat_with_null_conditional_argument2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_containing_join_gets_lifted_clashing_names(bool async)
    {
        await base.Subquery_containing_join_gets_lifted_clashing_names(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_containing_join_projecting_main_from_clause_gets_lifted(bool async)
    {
        await base.Subquery_containing_join_projecting_main_from_clause_gets_lifted(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_containing_left_join_projecting_main_from_clause_gets_lifted(bool async)
    {
        await base.Subquery_containing_left_join_projecting_main_from_clause_gets_lifted(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_containing_SelectMany_projecting_main_from_clause_gets_lifted(bool async)
    {
        await base.Subquery_containing_SelectMany_projecting_main_from_clause_gets_lifted(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_created_by_include_gets_lifted_nested(bool async)
    {
        await base.Subquery_created_by_include_gets_lifted_nested(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_inside_Take_argument(bool async)
    {
        await base.Subquery_inside_Take_argument(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_is_lifted_from_additional_from_clause(bool async)
    {
        await base.Subquery_is_lifted_from_additional_from_clause(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_is_lifted_from_main_from_clause_of_SelectMany(bool async)
    {
        await base.Subquery_is_lifted_from_main_from_clause_of_SelectMany(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_projecting_non_nullable_scalar_contains_non_nullable_value_doesnt_need_null_expansion(bool async)
    {
        await base.Subquery_projecting_non_nullable_scalar_contains_non_nullable_value_doesnt_need_null_expansion(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_projecting_non_nullable_scalar_contains_non_nullable_value_doesnt_need_null_expansion_negated(bool async)
    {
        await base.Subquery_projecting_non_nullable_scalar_contains_non_nullable_value_doesnt_need_null_expansion_negated(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_projecting_nullable_scalar_contains_nullable_value_needs_null_expansion(bool async)
    {
        await base.Subquery_projecting_nullable_scalar_contains_nullable_value_needs_null_expansion(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_projecting_nullable_scalar_contains_nullable_value_needs_null_expansion_negated(bool async)
    {
        await base.Subquery_projecting_nullable_scalar_contains_nullable_value_needs_null_expansion_negated(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_with_result_operator_is_not_lifted(bool async)
    {
        await base.Subquery_with_result_operator_is_not_lifted(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Sum_with_no_data_nullable_double(bool async)
    {
        await base.Sum_with_no_data_nullable_double(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Sum_with_optional_navigation_is_translated_to_sql(bool async)
    {
        await base.Sum_with_optional_navigation_is_translated_to_sql(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Take_without_orderby_followed_by_orderBy_is_pushed_down1(bool async)
    {
        await base.Take_without_orderby_followed_by_orderBy_is_pushed_down1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Take_without_orderby_followed_by_orderBy_is_pushed_down2(bool async)
    {
        await base.Take_without_orderby_followed_by_orderBy_is_pushed_down2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Take_without_orderby_followed_by_orderBy_is_pushed_down3(bool async)
    {
        await base.Take_without_orderby_followed_by_orderBy_is_pushed_down3(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ThenInclude_collection_on_derived_after_base_reference(bool async)
    {
        await base.ThenInclude_collection_on_derived_after_base_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ThenInclude_collection_on_derived_after_derived_collection(bool async)
    {
        await base.ThenInclude_collection_on_derived_after_derived_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ThenInclude_collection_on_derived_after_derived_reference(bool async)
    {
        await base.ThenInclude_collection_on_derived_after_derived_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ThenInclude_reference_on_derived_after_derived_collection(bool async)
    {
        await base.ThenInclude_reference_on_derived_after_derived_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToString_boolean_computed_nullable(bool async)
    {
        await base.ToString_boolean_computed_nullable(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToString_boolean_property_non_nullable(bool async)
    {
        await base.ToString_boolean_property_non_nullable(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToString_boolean_property_nullable(bool async)
    {
        await base.ToString_boolean_property_nullable(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToString_enum_contains(bool async)
    {
        await base.ToString_enum_contains(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToString_enum_property_projection(bool async)
    {
        await base.ToString_enum_property_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToString_nullable_enum_contains(bool async)
    {
        await base.ToString_nullable_enum_contains(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToString_nullable_enum_property_projection(bool async)
    {
        await base.ToString_nullable_enum_property_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToString_string_property_projection(bool async)
    {
        await base.ToString_string_property_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Trying_to_access_unmapped_property_in_projection(bool async)
    {
        await base.Trying_to_access_unmapped_property_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Trying_to_access_unmapped_property_inside_aggregate(bool async)
    {
        await base.Trying_to_access_unmapped_property_inside_aggregate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Trying_to_access_unmapped_property_inside_join_key_selector(bool async)
    {
        await base.Trying_to_access_unmapped_property_inside_join_key_selector(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Trying_to_access_unmapped_property_inside_subquery(bool async)
    {
        await base.Trying_to_access_unmapped_property_inside_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Trying_to_access_unmapped_property_throws_informative_error(bool async)
    {
        await base.Trying_to_access_unmapped_property_throws_informative_error(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Unicode_string_literals_is_used_for_non_unicode_column_with_concat(bool async)
    {
        await base.Unicode_string_literals_is_used_for_non_unicode_column_with_concat(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_with_collection_navigations(bool async)
    {
        await base.Union_with_collection_navigations(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Unnecessary_include_doesnt_get_added_complex_when_projecting_EF_Property(bool async)
    {
        await base.Unnecessary_include_doesnt_get_added_complex_when_projecting_EF_Property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Using_indexer_on_byte_array_and_string_in_projection(bool async)
    {
        await base.Using_indexer_on_byte_array_and_string_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_any_subquery_without_collision(bool async)
    {
        await base.Where_any_subquery_without_collision(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_bool_column_and_Contains(bool async)
    {
        await base.Where_bool_column_and_Contains(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_bool_column_or_Contains(bool async)
    {
        await base.Where_bool_column_or_Contains(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_coalesce_with_anonymous_types(bool async)
    {
        await base.Where_coalesce_with_anonymous_types(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_compare_anonymous_types(bool async)
    {
        await base.Where_compare_anonymous_types(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_compare_anonymous_types_with_uncorrelated_members(bool async)
    {
        await base.Where_compare_anonymous_types_with_uncorrelated_members(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_conditional_equality_1(bool async)
    {
        await base.Where_conditional_equality_1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_conditional_equality_2(bool async)
    {
        await base.Where_conditional_equality_2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_conditional_equality_3(bool async)
    {
        await base.Where_conditional_equality_3(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_contains_on_navigation_with_composite_keys(bool async)
    {
        await base.Where_contains_on_navigation_with_composite_keys(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_count_subquery_without_collision(bool async)
    {
        await base.Where_count_subquery_without_collision(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_equals_method_on_nullable_with_object_overload(bool async)
    {
        await base.Where_equals_method_on_nullable_with_object_overload(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_is_properly_lifted_from_subquery_created_by_include(bool async)
    {
        await base.Where_is_properly_lifted_from_subquery_created_by_include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_member_access_on_anonymous_type(bool async)
    {
        await base.Where_member_access_on_anonymous_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_null_parameter_is_not_null(bool async)
    {
        await base.Where_null_parameter_is_not_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_required_navigation_on_derived_type(bool async)
    {
        await base.Where_required_navigation_on_derived_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_boolean(bool async)
    {
        await base.Where_subquery_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_boolean_with_pushdown(bool async)
    {
        await base.Where_subquery_boolean_with_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_concat_firstordefault_boolean(bool async)
    {
        await base.Where_subquery_concat_firstordefault_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_distinct_first_boolean(bool async)
    {
        await base.Where_subquery_distinct_first_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_distinct_firstordefault_boolean(bool async)
    {
        await base.Where_subquery_distinct_firstordefault_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_distinct_firstordefault_boolean_with_pushdown(bool async)
    {
        await base.Where_subquery_distinct_firstordefault_boolean_with_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_distinct_last_boolean(bool async)
    {
        await base.Where_subquery_distinct_last_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_distinct_lastordefault_boolean(bool async)
    {
        await base.Where_subquery_distinct_lastordefault_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_distinct_orderby_firstordefault_boolean(bool async)
    {
        await base.Where_subquery_distinct_orderby_firstordefault_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_distinct_orderby_firstordefault_boolean_with_pushdown(bool async)
    {
        await base.Where_subquery_distinct_orderby_firstordefault_boolean_with_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_distinct_singleordefault_boolean_with_pushdown(bool async)
    {
        await base.Where_subquery_distinct_singleordefault_boolean_with_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_distinct_singleordefault_boolean1(bool async)
    {
        await base.Where_subquery_distinct_singleordefault_boolean1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_distinct_singleordefault_boolean2(bool async)
    {
        await base.Where_subquery_distinct_singleordefault_boolean2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_equality_to_null_with_composite_key(bool async)
    {
        await base.Where_subquery_equality_to_null_with_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_equality_to_null_with_composite_key_should_match_nulls(bool async)
    {
        await base.Where_subquery_equality_to_null_with_composite_key_should_match_nulls(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_equality_to_null_without_composite_key(bool async)
    {
        await base.Where_subquery_equality_to_null_without_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_equality_to_null_without_composite_key_should_match_null(bool async)
    {
        await base.Where_subquery_equality_to_null_without_composite_key_should_match_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_join_firstordefault_boolean(bool async)
    {
        await base.Where_subquery_join_firstordefault_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_left_join_firstordefault_boolean(bool async)
    {
        await base.Where_subquery_left_join_firstordefault_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_union_firstordefault_boolean(bool async)
    {
        await base.Where_subquery_union_firstordefault_boolean(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_with_ElementAt_using_column_as_index(bool async)
    {
        await base.Where_subquery_with_ElementAt_using_column_as_index(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_with_ElementAtOrDefault_equality_to_null_with_composite_key(bool async)
    {
        await base.Where_subquery_with_ElementAtOrDefault_equality_to_null_with_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_with_enum_flags_parameter(bool async)
    {
        await base.Where_with_enum_flags_parameter(async);
    }
}
