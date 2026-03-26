using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class ComplexNavigationsCollectionsSharedTypeQueryClickHouseTest : ComplexNavigationsCollectionsSharedTypeQueryRelationalTestBase<ComplexNavigationsSharedTypeQueryClickHouseFixture>
{
    public ComplexNavigationsCollectionsSharedTypeQueryClickHouseTest(ComplexNavigationsSharedTypeQueryClickHouseFixture fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_projection_over_GroupBy_over_parameter(bool async)
    {
        await base.Collection_projection_over_GroupBy_over_parameter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_multi_include_with_order_by_and_paging(bool async)
    {
        await base.Complex_multi_include_with_order_by_and_paging(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_multi_include_with_order_by_and_paging_joins_on_correct_key(bool async)
    {
        await base.Complex_multi_include_with_order_by_and_paging_joins_on_correct_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_multi_include_with_order_by_and_paging_joins_on_correct_key2(bool async)
    {
        await base.Complex_multi_include_with_order_by_and_paging_joins_on_correct_key2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_query_issue_21665(bool async)
    {
        await base.Complex_query_issue_21665(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_query_with_let_collection_projection_FirstOrDefault(bool async)
    {
        await base.Complex_query_with_let_collection_projection_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_query_with_let_collection_projection_FirstOrDefault_with_ToList_on_inner_and_outer(bool async)
    {
        await base.Complex_query_with_let_collection_projection_FirstOrDefault_with_ToList_on_inner_and_outer(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_SelectMany_with_nested_navigations_and_explicit_DefaultIfEmpty_with_other_query_operators_composed_on_top(bool async)
    {
        await base.Complex_SelectMany_with_nested_navigations_and_explicit_DefaultIfEmpty_with_other_query_operators_composed_on_top(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_after_different_filtered_include_different_level(bool async)
    {
        await base.Filtered_include_after_different_filtered_include_different_level(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_after_different_filtered_include_same_level(bool async)
    {
        await base.Filtered_include_after_different_filtered_include_same_level(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_after_reference_navigation(bool async)
    {
        await base.Filtered_include_after_reference_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_and_non_filtered_include_followed_by_then_include_on_same_navigation(bool async)
    {
        await base.Filtered_include_and_non_filtered_include_followed_by_then_include_on_same_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_and_non_filtered_include_on_same_navigation1(bool async)
    {
        await base.Filtered_include_and_non_filtered_include_on_same_navigation1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_and_non_filtered_include_on_same_navigation2(bool async)
    {
        await base.Filtered_include_and_non_filtered_include_on_same_navigation2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_basic_OrderBy_Skip(bool async)
    {
        await base.Filtered_include_basic_OrderBy_Skip(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_basic_OrderBy_Skip_Take(bool async)
    {
        await base.Filtered_include_basic_OrderBy_Skip_Take(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_basic_OrderBy_Skip_Take_EF_Property(bool async)
    {
        await base.Filtered_include_basic_OrderBy_Skip_Take_EF_Property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_basic_OrderBy_Take(bool async)
    {
        await base.Filtered_include_basic_OrderBy_Take(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_basic_Where(bool async)
    {
        await base.Filtered_include_basic_Where(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_basic_Where_EF_Property(bool async)
    {
        await base.Filtered_include_basic_Where_EF_Property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_calling_methods_directly_on_parameter_throws(bool async)
    {
        await base.Filtered_include_calling_methods_directly_on_parameter_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_complex_three_level_with_middle_having_filter1(bool async)
    {
        await base.Filtered_include_complex_three_level_with_middle_having_filter1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_complex_three_level_with_middle_having_filter2(bool async)
    {
        await base.Filtered_include_complex_three_level_with_middle_having_filter2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_context_accessed_inside_filter(bool async)
    {
        await base.Filtered_include_context_accessed_inside_filter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_context_accessed_inside_filter_correlated(bool async)
    {
        await base.Filtered_include_context_accessed_inside_filter_correlated(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_different_filter_set_on_same_navigation_twice(bool async)
    {
        await base.Filtered_include_different_filter_set_on_same_navigation_twice(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_different_filter_set_on_same_navigation_twice_multi_level(bool async)
    {
        await base.Filtered_include_different_filter_set_on_same_navigation_twice_multi_level(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_include_parameter_used_inside_filter_throws(bool async)
    {
        await base.Filtered_include_include_parameter_used_inside_filter_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_is_considered_loaded(bool async)
    {
        await base.Filtered_include_is_considered_loaded(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_multiple_multi_level_includes_with_first_level_using_filter_include_on_one_of_the_chains_only(bool async)
    {
        await base.Filtered_include_multiple_multi_level_includes_with_first_level_using_filter_include_on_one_of_the_chains_only(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_on_ThenInclude(bool async)
    {
        await base.Filtered_include_on_ThenInclude(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_on_ThenInclude_EF_Property(bool async)
    {
        await base.Filtered_include_on_ThenInclude_EF_Property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_OrderBy(bool async)
    {
        await base.Filtered_include_OrderBy(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_OrderBy_EF_Property(bool async)
    {
        await base.Filtered_include_OrderBy_EF_Property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_outer_parameter_used_inside_filter(bool async)
    {
        await base.Filtered_include_outer_parameter_used_inside_filter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_same_filter_set_on_same_navigation_twice(bool async)
    {
        await base.Filtered_include_same_filter_set_on_same_navigation_twice(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_same_filter_set_on_same_navigation_twice_followed_by_ThenIncludes(bool async)
    {
        await base.Filtered_include_same_filter_set_on_same_navigation_twice_followed_by_ThenIncludes(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_Skip_Take_with_another_Skip_Take_on_top_level(bool async)
    {
        await base.Filtered_include_Skip_Take_with_another_Skip_Take_on_top_level(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_Skip_without_OrderBy(bool async)
    {
        await base.Filtered_include_Skip_without_OrderBy(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_Take_with_another_Take_on_top_level(bool async)
    {
        await base.Filtered_include_Take_with_another_Take_on_top_level(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_Take_without_OrderBy(bool async)
    {
        await base.Filtered_include_Take_without_OrderBy(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_ThenInclude_OrderBy(bool async)
    {
        await base.Filtered_include_ThenInclude_OrderBy(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_variable_used_inside_filter(bool async)
    {
        await base.Filtered_include_variable_used_inside_filter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_with_Distinct_throws(bool async)
    {
        await base.Filtered_include_with_Distinct_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_with_Take_without_order_by_followed_by_ThenInclude_and_FirstOrDefault_on_top_level(bool async)
    {
        await base.Filtered_include_with_Take_without_order_by_followed_by_ThenInclude_and_FirstOrDefault_on_top_level(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_with_Take_without_order_by_followed_by_ThenInclude_and_unordered_Take_on_top_level(bool async)
    {
        await base.Filtered_include_with_Take_without_order_by_followed_by_ThenInclude_and_unordered_Take_on_top_level(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_ThenInclude_OrderBy(bool async)
    {
        await base.Filtered_ThenInclude_OrderBy(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Final_GroupBy_property_entity_Include_collection(bool async)
    {
        await base.Final_GroupBy_property_entity_Include_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Final_GroupBy_property_entity_Include_collection_multiple(bool async)
    {
        await base.Final_GroupBy_property_entity_Include_collection_multiple(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Final_GroupBy_property_entity_Include_collection_nested(bool async)
    {
        await base.Final_GroupBy_property_entity_Include_collection_nested(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Final_GroupBy_property_entity_Include_collection_reference(bool async)
    {
        await base.Final_GroupBy_property_entity_Include_collection_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Final_GroupBy_property_entity_Include_collection_reference_same_level(bool async)
    {
        await base.Final_GroupBy_property_entity_Include_collection_reference_same_level(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Final_GroupBy_property_entity_Include_reference(bool async)
    {
        await base.Final_GroupBy_property_entity_Include_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Final_GroupBy_property_entity_Include_reference_multiple(bool async)
    {
        await base.Final_GroupBy_property_entity_Include_reference_multiple(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FirstOrDefault_with_predicate_on_correlated_collection_in_projection(bool async)
    {
        await base.FirstOrDefault_with_predicate_on_correlated_collection_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_after_multiple_SelectMany_and_reference_navigation(bool async)
    {
        await base.Include_after_multiple_SelectMany_and_reference_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_after_Select(bool async)
    {
        await base.Include_after_Select(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_after_SelectMany(bool async)
    {
        await base.Include_after_SelectMany(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_after_SelectMany_and_multiple_reference_navigations(bool async)
    {
        await base.Include_after_SelectMany_and_multiple_reference_navigations(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_after_SelectMany_and_reference_navigation(bool async)
    {
        await base.Include_after_SelectMany_and_reference_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_and_ThenInclude_collections_followed_by_projecting_the_first_collection(bool async)
    {
        await base.Include_and_ThenInclude_collections_followed_by_projecting_the_first_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection(bool async)
    {
        await base.Include_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_and_another_navigation_chain_followed_by_projecting_the_first_collection(bool async)
    {
        await base.Include_collection_and_another_navigation_chain_followed_by_projecting_the_first_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_followed_by_complex_includes_and_projecting_the_included_collection(bool async)
    {
        await base.Include_collection_followed_by_complex_includes_and_projecting_the_included_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_followed_by_include_reference(bool async)
    {
        await base.Include_collection_followed_by_include_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_followed_by_projecting_the_included_collection(bool async)
    {
        await base.Include_collection_followed_by_projecting_the_included_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_multiple(bool async)
    {
        await base.Include_collection_multiple(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_multiple_with_filter(bool async)
    {
        await base.Include_collection_multiple_with_filter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_multiple_with_filter_EF_Property(bool async)
    {
        await base.Include_collection_multiple_with_filter_EF_Property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_then_reference(bool async)
    {
        await base.Include_collection_then_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_ThenInclude_reference_followed_by_projection_into_anonmous_type(bool async)
    {
        await base.Include_collection_ThenInclude_reference_followed_by_projection_into_anonmous_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_ThenInclude_two_references(bool async)
    {
        await base.Include_collection_ThenInclude_two_references(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_conditional_order_by(bool async)
    {
        await base.Include_collection_with_conditional_order_by(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_groupby_in_subquery(bool async)
    {
        await base.Include_collection_with_groupby_in_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_groupby_in_subquery_and_filter_after_groupby(bool async)
    {
        await base.Include_collection_with_groupby_in_subquery_and_filter_after_groupby(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_groupby_in_subquery_and_filter_before_groupby(bool async)
    {
        await base.Include_collection_with_groupby_in_subquery_and_filter_before_groupby(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_multiple_orderbys_complex(bool async)
    {
        await base.Include_collection_with_multiple_orderbys_complex(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_multiple_orderbys_complex_repeated(bool async)
    {
        await base.Include_collection_with_multiple_orderbys_complex_repeated(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_multiple_orderbys_complex_repeated_checked(bool async)
    {
        await base.Include_collection_with_multiple_orderbys_complex_repeated_checked(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_multiple_orderbys_member(bool async)
    {
        await base.Include_collection_with_multiple_orderbys_member(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_multiple_orderbys_methodcall(bool async)
    {
        await base.Include_collection_with_multiple_orderbys_methodcall(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_multiple_orderbys_property(bool async)
    {
        await base.Include_collection_with_multiple_orderbys_property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_inside_subquery(bool async)
    {
        await base.Include_inside_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_nested_with_optional_navigation(bool async)
    {
        await base.Include_nested_with_optional_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_partially_added_before_Where_and_then_build_upon(bool async)
    {
        await base.Include_partially_added_before_Where_and_then_build_upon(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_partially_added_before_Where_and_then_build_upon_with_filtered_include(bool async)
    {
        await base.Include_partially_added_before_Where_and_then_build_upon_with_filtered_include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_and_collection_order_by(bool async)
    {
        await base.Include_reference_and_collection_order_by(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_collection_order_by_reference_navigation(bool async)
    {
        await base.Include_reference_collection_order_by_reference_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_followed_by_include_collection(bool async)
    {
        await base.Include_reference_followed_by_include_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_ThenInclude_collection_order_by(bool async)
    {
        await base.Include_reference_ThenInclude_collection_order_by(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_ThenInclude_ThenInclude_followed_by_two_nested_selects(bool async)
    {
        await base.Include_ThenInclude_ThenInclude_followed_by_two_nested_selects(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Including_reference_navigation_and_projecting_collection_navigation(bool async)
    {
        await base.Including_reference_navigation_and_projecting_collection_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task LeftJoin_with_Any_on_outer_source_and_projecting_collection_from_inner(bool async)
    {
        await base.LeftJoin_with_Any_on_outer_source_and_projecting_collection_from_inner(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Lift_projection_mapping_when_pushing_down_subquery(bool async)
    {
        await base.Lift_projection_mapping_when_pushing_down_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multi_level_include_correct_PK_is_chosen_as_the_join_predicate_for_queries_that_join_same_table_multiple_times(bool async)
    {
        await base.Multi_level_include_correct_PK_is_chosen_as_the_join_predicate_for_queries_that_join_same_table_multiple_times(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multi_level_include_one_to_many_optional_and_one_to_many_optional_produces_valid_sql(bool async)
    {
        await base.Multi_level_include_one_to_many_optional_and_one_to_many_optional_produces_valid_sql(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_complex_include_select(bool async)
    {
        await base.Multiple_complex_include_select(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_complex_includes(bool async)
    {
        await base.Multiple_complex_includes(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_complex_includes_EF_Property(bool async)
    {
        await base.Multiple_complex_includes_EF_Property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_complex_includes_self_ref(bool async)
    {
        await base.Multiple_complex_includes_self_ref(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_complex_includes_self_ref_EF_Property(bool async)
    {
        await base.Multiple_complex_includes_self_ref_EF_Property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_include_with_multiple_optional_navigations(bool async)
    {
        await base.Multiple_include_with_multiple_optional_navigations(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_optional_navigation_with_Include(bool async)
    {
        await base.Multiple_optional_navigation_with_Include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_optional_navigation_with_string_based_Include(bool async)
    {
        await base.Multiple_optional_navigation_with_string_based_Include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_SelectMany_navigation_property_followed_by_select_collection_navigation(bool async)
    {
        await base.Multiple_SelectMany_navigation_property_followed_by_select_collection_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_SelectMany_with_Include(bool async)
    {
        await base.Multiple_SelectMany_with_Include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Null_check_in_anonymous_type_projection_should_not_be_removed(bool async)
    {
        await base.Null_check_in_anonymous_type_projection_should_not_be_removed(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Null_check_in_Dto_projection_should_not_be_removed(bool async)
    {
        await base.Null_check_in_Dto_projection_should_not_be_removed(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_with_Include_and_order(bool async)
    {
        await base.Optional_navigation_with_Include_and_order(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_with_Include_ThenInclude(bool async)
    {
        await base.Optional_navigation_with_Include_ThenInclude(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Optional_navigation_with_order_by_and_Include(bool async)
    {
        await base.Optional_navigation_with_order_by_and_Include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Orderby_SelectMany_with_Include1(bool async)
    {
        await base.Orderby_SelectMany_with_Include1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_and_include(bool async)
    {
        await base.Project_collection_and_include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_and_nested_conditional(bool async)
    {
        await base.Project_collection_and_nested_conditional(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_and_root_entity(bool async)
    {
        await base.Project_collection_and_root_entity(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_navigation(bool async)
    {
        await base.Project_collection_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_navigation_composed(bool async)
    {
        await base.Project_collection_navigation_composed(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_navigation_nested(bool async)
    {
        await base.Project_collection_navigation_nested(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_navigation_nested_anonymous(bool async)
    {
        await base.Project_collection_navigation_nested_anonymous(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_navigation_nested_with_take(bool async)
    {
        await base.Project_collection_navigation_nested_with_take(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_navigation_using_ef_property(bool async)
    {
        await base.Project_collection_navigation_using_ef_property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_navigation_and_collection(bool async)
    {
        await base.Project_navigation_and_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_collection_after_optional_reference_correlated_with_parent(bool async)
    {
        await base.Projecting_collection_after_optional_reference_correlated_with_parent(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_collection_with_FirstOrDefault(bool async)
    {
        await base.Projecting_collection_with_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_collection_with_group_by_after_optional_reference_correlated_with_parent(bool async)
    {
        await base.Projecting_collection_with_group_by_after_optional_reference_correlated_with_parent(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Queryable_in_subquery_works_when_final_projection_is_List(bool async)
    {
        await base.Queryable_in_subquery_works_when_final_projection_is_List(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Required_navigation_with_Include(bool async)
    {
        await base.Required_navigation_with_Include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Required_navigation_with_Include_ThenInclude(bool async)
    {
        await base.Required_navigation_with_Include_ThenInclude(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_nav_prop_collection_one_to_many_required(bool async)
    {
        await base.Select_nav_prop_collection_one_to_many_required(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_single_nested_subquery(bool async)
    {
        await base.Select_subquery_single_nested_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_single_nested_subquery2(bool async)
    {
        await base.Select_subquery_single_nested_subquery2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_DefaultIfEmpty_multiple_times_with_joins_projecting_a_collection(bool async)
    {
        await base.SelectMany_DefaultIfEmpty_multiple_times_with_joins_projecting_a_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_navigation_property_followed_by_select_collection_navigation(bool async)
    {
        await base.SelectMany_navigation_property_followed_by_select_collection_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_navigation_property_with_include_and_followed_by_select_collection_navigation(bool async)
    {
        await base.SelectMany_navigation_property_with_include_and_followed_by_select_collection_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_over_conditional_empty_source(bool async)
    {
        await base.SelectMany_over_conditional_empty_source(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_over_conditional_null_source(bool async)
    {
        await base.SelectMany_over_conditional_null_source(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_Include_and_order_by(bool async)
    {
        await base.SelectMany_with_Include_and_order_by(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_Include_ThenInclude(bool async)
    {
        await base.SelectMany_with_Include_ThenInclude(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_Include1(bool async)
    {
        await base.SelectMany_with_Include1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_Include2(bool async)
    {
        await base.SelectMany_with_Include2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_navigation_and_Distinct(bool async)
    {
        await base.SelectMany_with_navigation_and_Distinct(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_navigation_and_Distinct_projecting_columns_including_join_key(bool async)
    {
        await base.SelectMany_with_navigation_and_Distinct_projecting_columns_including_join_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_order_by_and_Include(bool async)
    {
        await base.SelectMany_with_order_by_and_Include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_predicate_and_DefaultIfEmpty_projecting_root_collection_element_and_another_collection(bool async)
    {
        await base.SelectMany_with_predicate_and_DefaultIfEmpty_projecting_root_collection_element_and_another_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_on_grouping_element(bool async)
    {
        await base.Skip_on_grouping_element(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_Take_Distinct_on_grouping_element(bool async)
    {
        await base.Skip_Take_Distinct_on_grouping_element(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_Take_on_grouping_element(bool async)
    {
        await base.Skip_Take_on_grouping_element(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_Take_on_grouping_element_inside_collection_projection(bool async)
    {
        await base.Skip_Take_on_grouping_element_inside_collection_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_Take_on_grouping_element_into_non_entity(bool async)
    {
        await base.Skip_Take_on_grouping_element_into_non_entity(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_Take_on_grouping_element_with_collection_include(bool async)
    {
        await base.Skip_Take_on_grouping_element_with_collection_include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_Take_on_grouping_element_with_reference_include(bool async)
    {
        await base.Skip_Take_on_grouping_element_with_reference_include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_Take_Select_collection_Skip_Take(bool async)
    {
        await base.Skip_Take_Select_collection_Skip_Take(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_Take_ToList_on_grouping_element(bool async)
    {
        await base.Skip_Take_ToList_on_grouping_element(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Take_on_correlated_collection_in_projection(bool async)
    {
        await base.Take_on_correlated_collection_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Take_on_grouping_element(bool async)
    {
        await base.Take_on_grouping_element(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Take_Select_collection_Take(bool async)
    {
        await base.Take_Select_collection_Take(async);
    }
}
