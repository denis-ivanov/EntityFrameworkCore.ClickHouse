using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindMiscellaneousQueryClickHouseTest : NorthwindMiscellaneousQueryRelationalTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindMiscellaneousQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task All_on_distinct(bool async)
    {
        await base.All_on_distinct(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task All_top_level_subquery(bool async)
    {
        await base.All_top_level_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task All_top_level_subquery_ef_property(bool async)
    {
        await base.All_top_level_subquery_ef_property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Anonymous_projection_skip_empty_collection_FirstOrDefault(bool async)
    {
        await base.Anonymous_projection_skip_empty_collection_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Anonymous_projection_skip_take_empty_collection_FirstOrDefault(bool async)
    {
        await base.Anonymous_projection_skip_take_empty_collection_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Anonymous_projection_take_empty_collection_FirstOrDefault(bool async)
    {
        await base.Anonymous_projection_take_empty_collection_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Anonymous_subquery_orderby(bool async)
    {
        await base.Anonymous_subquery_orderby(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task AsQueryable_in_query_server_evals(bool async)
    {
        await base.AsQueryable_in_query_server_evals(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_code_unknown_method(bool async)
    {
        await base.Client_code_unknown_method(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_code_using_instance_in_anonymous_type(bool async)
    {
        await base.Client_code_using_instance_in_anonymous_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_code_using_instance_in_static_method(bool async)
    {
        await base.Client_code_using_instance_in_static_method(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_code_using_instance_method_throws(bool async)
    {
        await base.Client_code_using_instance_method_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Coalesce_Correct_Multiple_Same_TypeMapping(bool async)
    {
        await base.Coalesce_Correct_Multiple_Same_TypeMapping(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_nested_query_doesnt_try_binding_to_grandparent_when_parent_returns_complex_result(bool async)
    {
        await base.Complex_nested_query_doesnt_try_binding_to_grandparent_when_parent_returns_complex_result(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_nested_query_properly_binds_to_grandparent_when_parent_returns_scalar_result(bool async)
    {
        await base.Complex_nested_query_properly_binds_to_grandparent_when_parent_returns_scalar_result(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_on_distinct(bool async)
    {
        await base.Contains_on_distinct(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Convert_to_nullable_on_nullable_value_is_ignored(bool async)
    {
        await base.Convert_to_nullable_on_nullable_value_is_ignored(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_distinct_without_default_identifiers_projecting_columns(bool async)
    {
        await base.Correlated_collection_with_distinct_without_default_identifiers_projecting_columns(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_distinct_without_default_identifiers_projecting_columns_with_navigation(bool async)
    {
        await base.Correlated_collection_with_distinct_without_default_identifiers_projecting_columns_with_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DefaultIfEmpty_in_subquery(bool async)
    {
        await base.DefaultIfEmpty_in_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DefaultIfEmpty_in_subquery_nested_filter_order_comparison(bool async)
    {
        await base.DefaultIfEmpty_in_subquery_nested_filter_order_comparison(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DefaultIfEmpty_in_subquery_not_correlated(bool async)
    {
        await base.DefaultIfEmpty_in_subquery_not_correlated(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DefaultIfEmpty_Sum_over_collection_navigation(bool async)
    {
        await base.DefaultIfEmpty_Sum_over_collection_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DefaultIfEmpty_top_level_preceded_by_constant_Select(bool async)
    {
        await base.DefaultIfEmpty_top_level_preceded_by_constant_Select(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DefaultIfEmpty_top_level(bool async)
    {
        await base.DefaultIfEmpty_top_level(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DTO_subquery_orderby(bool async)
    {
        await base.DTO_subquery_orderby(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Entity_equality_orderby_descending_subquery_composite_key(bool async)
    {
        await base.Entity_equality_orderby_descending_subquery_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Entity_equality_orderby_subquery(bool async)
    {
        await base.Entity_equality_orderby_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Entity_equality_through_subquery_composite_key(bool async)
    {
        await base.Entity_equality_through_subquery_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task First_on_collection_in_projection(bool async)
    {
        await base.First_on_collection_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FirstOrDefault_with_predicate_nested(bool async)
    {
        await base.FirstOrDefault_with_predicate_nested(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_with_DefaultIfEmpty_on_both_sources(bool async)
    {
        await base.Join_with_DefaultIfEmpty_on_both_sources(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Max_on_empty_sequence_throws(bool async)
    {
        await base.Max_on_empty_sequence_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OrderBy_any(bool async)
    {
        await base.OrderBy_any(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OrderBy_correlated_subquery1(bool async)
    {
        await base.OrderBy_correlated_subquery1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OrderBy_correlated_subquery2(bool async)
    {
        await base.OrderBy_correlated_subquery2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Contains_with_projection_and_ordering(bool async)
    {
        await base.Parameter_collection_Contains_with_projection_and_ordering(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Pending_selector_in_cardinality_reducing_method_is_applied_before_expanding_collection_navigation_member(bool async)
    {
        await base.Pending_selector_in_cardinality_reducing_method_is_applied_before_expanding_collection_navigation_member(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_expression_with_to_string_and_contains(bool async)
    {
        await base.Query_expression_with_to_string_and_contains(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_correlated_subquery_ordered(bool async)
    {
        await base.Select_correlated_subquery_ordered(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_DTO_constructor_distinct_with_collection_projection_translated_to_server_with_binding_after_client_eval(bool async)
    {
        await base.Select_DTO_constructor_distinct_with_collection_projection_translated_to_server_with_binding_after_client_eval(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_expression_date_add_milliseconds_above_the_range(bool async)
    {
        await base.Select_expression_date_add_milliseconds_above_the_range(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_expression_date_add_milliseconds_below_the_range(bool async)
    {
        await base.Select_expression_date_add_milliseconds_below_the_range(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_expression_date_add_milliseconds_large_number_divided(bool async)
    {
        await base.Select_expression_date_add_milliseconds_large_number_divided(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_expression_date_add_year(bool async)
    {
        await base.Select_expression_date_add_year(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_expression_datetime_add_hour(bool async)
    {
        await base.Select_expression_datetime_add_hour(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_expression_datetime_add_minute(bool async)
    {
        await base.Select_expression_datetime_add_minute(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_expression_datetime_add_month(bool async)
    {
        await base.Select_expression_datetime_add_month(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_expression_datetime_add_second(bool async)
    {
        await base.Select_expression_datetime_add_second(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_expression_datetime_add_ticks(bool async)
    {
        await base.Select_expression_datetime_add_ticks(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_expression_int_to_string(bool async)
    {
        await base.Select_expression_int_to_string(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_expression_long_to_string(bool async)
    {
        await base.Select_expression_long_to_string(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_expression_other_to_string(bool async)
    {
        await base.Select_expression_other_to_string(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_expression_references_are_updated_correctly_with_subquery(bool async)
    {
        await base.Select_expression_references_are_updated_correctly_with_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_subquery_recursive_trivial(bool async)
    {
        await base.Select_subquery_recursive_trivial(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Where_Subquery_Deep_First(bool async)
    {
        await base.Select_Where_Subquery_Deep_First(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Where_Subquery_Deep_Single(bool async)
    {
        await base.Select_Where_Subquery_Deep_Single(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Where_Subquery_Equality(bool async)
    {
        await base.Select_Where_Subquery_Equality(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_correlated_subquery_hard(bool async)
    {
        await base.SelectMany_correlated_subquery_hard(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_correlated_with_DefaultIfEmpty_and_Select_value_type_in_selector_throws(bool async)
    {
        await base.SelectMany_correlated_with_DefaultIfEmpty_and_Select_value_type_in_selector_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_correlated_with_Select_value_type_and_DefaultIfEmpty_in_selector(bool async)
    {
        await base.SelectMany_correlated_with_Select_value_type_and_DefaultIfEmpty_in_selector(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_Joined_DefaultIfEmpty(bool async)
    {
        await base.SelectMany_Joined_DefaultIfEmpty(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_Joined_DefaultIfEmpty2(bool async)
    {
        await base.SelectMany_Joined_DefaultIfEmpty2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_Joined_DefaultIfEmpty3(bool async)
    {
        await base.SelectMany_Joined_DefaultIfEmpty3(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Single_non_scalar_projection_after_skip_uses_join(bool async)
    {
        await base.Single_non_scalar_projection_after_skip_uses_join(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_member_pushdown_does_not_change_original_subquery_model(bool async)
    {
        await base.Subquery_member_pushdown_does_not_change_original_subquery_model(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_member_pushdown_does_not_change_original_subquery_model2(bool async)
    {
        await base.Subquery_member_pushdown_does_not_change_original_subquery_model2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_with_navigation_inside_inline_collection(bool async)
    {
        await base.Subquery_with_navigation_inside_inline_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Throws_on_concurrent_query_first(bool async)
    {
        await base.Throws_on_concurrent_query_first(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Throws_on_concurrent_query_list(bool async)
    {
        await base.Throws_on_concurrent_query_list(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToListAsync_with_canceled_token()
    {
        await base.ToListAsync_with_canceled_token();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToString_with_formatter_is_evaluated_on_the_client(bool async)
    {
        await base.ToString_with_formatter_is_evaluated_on_the_client(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_nanosecond_and_microsecond_component(bool async)
    {
        await base.Where_nanosecond_and_microsecond_component(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_query_composition_entity_equality_multiple_elements_SingleOrDefault(bool async)
    {
        await base.Where_query_composition_entity_equality_multiple_elements_SingleOrDefault(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_subquery_on_collection(bool async)
    {
        await base.Where_subquery_on_collection(async);
    }
}
