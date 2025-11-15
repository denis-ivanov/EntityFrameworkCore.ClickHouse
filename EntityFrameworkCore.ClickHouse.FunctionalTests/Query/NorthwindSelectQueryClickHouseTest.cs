using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindSelectQueryClickHouseTest : NorthwindSelectQueryRelationalTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindSelectQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public override async Task Select_datetime_year_component(bool async)
    {
        await base.Select_datetime_year_component(async);

        AssertSql(
            """
            SELECT CAST(toYear("o"."OrderDate") AS Int32)
            FROM "Orders" AS "o"
            """);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Client_method_in_projection_requiring_materialization_1(bool async)
    {
        return base.Client_method_in_projection_requiring_materialization_1(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Client_method_in_projection_requiring_materialization_2(bool async)
    {
        return base.Client_method_in_projection_requiring_materialization_2(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task New_date_time_in_anonymous_type_works(bool async)
    {
        return base.New_date_time_in_anonymous_type_works(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projection_of_entity_type_into_object_array(bool async)
    {
        return base.Projection_of_entity_type_into_object_array(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Set_operation_in_pending_collection(bool async)
    {
        return base.Set_operation_in_pending_collection(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Using_enumerable_parameter_in_projection(bool async)
    {
        return base.Using_enumerable_parameter_in_projection(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task VisitLambda_should_not_be_visited_trivially(bool async)
    {
        return base.VisitLambda_should_not_be_visited_trivially(async);
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public virtual async Task Select_datetime_year_component_composed(bool async)
    {
        await AssertQueryScalar(
            async,
            ss => ss.Set<Order>().Select(o => o.OrderDate.Value.AddYears(1).Year));

        AssertSql(
            """
            SELECT CAST(toYear(addYears("o"."OrderDate", 1)) AS Int32)
            FROM "Orders" AS "o"
            """);
    }

    public override async Task Select_datetime_month_component(bool async)
    {
        await base.Select_datetime_month_component(async);

        AssertSql(
            """
            SELECT CAST(toMonth("o"."OrderDate") AS Int32)
            FROM "Orders" AS "o"
            """);
    }

    public override async Task Select_datetime_day_of_year_component(bool async)
    {
        await base.Select_datetime_day_of_year_component(async);

        AssertSql(
            """
            SELECT CAST(toDayOfYear("o"."OrderDate") AS Int32)
            FROM "Orders" AS "o"
            """);
    }

    public override async Task Select_datetime_day_component(bool async)
    {
        await base.Select_datetime_day_component(async);

        AssertSql(
            """
            SELECT CAST(toDayOfMonth("o"."OrderDate") AS Int32)
            FROM "Orders" AS "o"
            """);
    }

    public override async Task Select_datetime_hour_component(bool async)
    {
        await base.Select_datetime_hour_component(async);

        AssertSql(
            """
            SELECT CAST(toHour("o"."OrderDate") AS Int32)
            FROM "Orders" AS "o"
            """);
    }

    public override async Task Select_datetime_minute_component(bool async)
    {
        await base.Select_datetime_minute_component(async);

        AssertSql(
            """
            SELECT CAST(toMinute("o"."OrderDate") AS Int32)
            FROM "Orders" AS "o"
            """);
    }

    public override async Task Select_datetime_second_component(bool async)
    {
        await base.Select_datetime_second_component(async);

        AssertSql(
            """
            SELECT CAST(toSecond("o"."OrderDate") AS Int32)
            FROM "Orders" AS "o"
            """);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override async Task Select_datetime_millisecond_component(bool async)
    {
        await base.Select_datetime_millisecond_component(async);

        AssertSql(
            """
            SELECT (CAST(toMillisecond("o"."OrderDate") AS Int32))
            FROM "Orders" AS "o"
            """);
    }

    public override async Task Select_datetime_DayOfWeek_component(bool async)
    {
        await base.Select_datetime_DayOfWeek_component(async);

        AssertSql(
            """
            SELECT CAST(toDayOfWeek("o"."OrderDate") AS Int32)
            FROM "Orders" AS "o"
            """);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override async Task Select_datetime_TimeOfDay_component(bool async)
    {
        await base.Select_datetime_TimeOfDay_component(async);

        AssertSql(
            """
            SELECT rtrim(rtrim(strftime('%H:%M:%f', "o"."OrderDate"), '0'), '.')
            FROM "Orders" AS "o"
            """);
    }

    public override async Task SelectMany_with_collection_being_correlated_subquery_which_references_non_mapped_properties_from_inner_and_outer_entity(bool async)
    {
        await AssertUnableToTranslateEFProperty(
            () => base
                .SelectMany_with_collection_being_correlated_subquery_which_references_non_mapped_properties_from_inner_and_outer_entity(
                    async));

        AssertSql();
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task SelectMany_correlated_with_outer_1(bool async)
    {
        return base.SelectMany_correlated_with_outer_1(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task SelectMany_correlated_with_outer_2(bool async)
    {
        return base.SelectMany_correlated_with_outer_2(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task SelectMany_correlated_with_outer_3(bool async)
    {
        return base.SelectMany_correlated_with_outer_3(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task SelectMany_correlated_with_outer_4(bool async)
    {
        return base.SelectMany_correlated_with_outer_4(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task SelectMany_correlated_with_outer_5(bool async)
    {
        return base.SelectMany_correlated_with_outer_5(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task SelectMany_correlated_with_outer_6(bool async)
    {
        return base.SelectMany_correlated_with_outer_6(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task SelectMany_correlated_with_outer_7(bool async)
    {
        return base.SelectMany_correlated_with_outer_7(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task SelectMany_whose_selector_references_outer_source(bool async)
    {
        return base.SelectMany_whose_selector_references_outer_source(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projecting_after_navigation_and_distinct(bool async)
    {
        return base.Projecting_after_navigation_and_distinct(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Select_nested_collection_deep(bool async)
    {
        return base.Select_nested_collection_deep(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Correlated_collection_after_groupby_with_complex_projection_containing_original_identifier(bool async)
    {
        return base.Correlated_collection_after_groupby_with_complex_projection_containing_original_identifier(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Correlated_collection_after_distinct_not_containing_original_identifier(bool async)
    {
        return base.Correlated_collection_after_distinct_not_containing_original_identifier(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Correlated_collection_after_distinct_with_complex_projection_not_containing_original_identifier(bool async)
    {
        return base.Correlated_collection_after_distinct_with_complex_projection_not_containing_original_identifier(
            async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Correlated_collection_after_distinct_with_complex_projection_containing_original_identifier(bool async)
    {
        return base.Correlated_collection_after_distinct_with_complex_projection_containing_original_identifier(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Select_nested_collection_deep_distinct_no_identifiers(bool async)
    {
        return base.Select_nested_collection_deep_distinct_no_identifiers(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Reverse_in_projection_subquery(bool async)
    {
        return base.Reverse_in_projection_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Reverse_in_projection_subquery_single_result(bool async)
    {
        return base.Reverse_in_projection_subquery_single_result(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Reverse_in_SelectMany_with_Take(bool async)
    {
        return base.Reverse_in_SelectMany_with_Take(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Project_single_element_from_collection_with_OrderBy_over_navigation_Take_and_FirstOrDefault_2(bool async)
    {
        return base
            .Project_single_element_from_collection_with_OrderBy_over_navigation_Take_and_FirstOrDefault_2(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Member_binding_after_ctor_arguments_fails_with_client_eval(bool async)
    {
        return base.Member_binding_after_ctor_arguments_fails_with_client_eval(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task SelectMany_with_collection_being_correlated_subquery_which_references_inner_and_outer_entity(bool async)
    {
        return base.SelectMany_with_collection_being_correlated_subquery_which_references_inner_and_outer_entity(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Collection_projection_selecting_outer_element_followed_by_take(bool async)
    {
        return base.Collection_projection_selecting_outer_element_followed_by_take(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Take_on_top_level_and_on_collection_projection_with_outer_apply(bool async)
    {
        return base.Take_on_top_level_and_on_collection_projection_with_outer_apply(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Take_on_correlated_collection_in_first(bool async)
    {
        return base.Take_on_correlated_collection_in_first(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Correlated_collection_after_groupby_with_complex_projection_not_containing_original_identifier(bool async)
    {
        return base.Correlated_collection_after_groupby_with_complex_projection_not_containing_original_identifier(
            async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Client_projection_via_ctor_arguments(bool async)
    {
        return base.Client_projection_via_ctor_arguments(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Client_projection_with_string_initialization_with_scalar_subquery(bool async)
    {
        return base.Client_projection_with_string_initialization_with_scalar_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Collection_FirstOrDefault_with_entity_equality_check_in_projection(bool async)
    {
        return base.Collection_FirstOrDefault_with_entity_equality_check_in_projection(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Collection_FirstOrDefault_with_nullable_unsigned_int_column(bool async)
    {
        return base.Collection_FirstOrDefault_with_nullable_unsigned_int_column(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Collection_include_over_result_of_single_non_scalar(bool async)
    {
        return base.Collection_include_over_result_of_single_non_scalar(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Collection_projection_AsNoTracking_OrderBy(bool async)
    {
        return base.Collection_projection_AsNoTracking_OrderBy(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Do_not_erase_projection_mapping_when_adding_single_projection(bool async)
    {
        return base.Do_not_erase_projection_mapping_when_adding_single_projection(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Explicit_cast_in_arithmetic_operation_is_preserved(bool async)
    {
        return base.Explicit_cast_in_arithmetic_operation_is_preserved(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Filtered_collection_projection_is_tracked(bool async)
    {
        return base.Filtered_collection_projection_is_tracked(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task FirstOrDefault_over_empty_collection_of_value_type_returns_correct_results(bool async)
    {
        return base.FirstOrDefault_over_empty_collection_of_value_type_returns_correct_results(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Filtered_collection_projection_with_to_list_is_tracked(bool async)
    {
        return base.Filtered_collection_projection_with_to_list_is_tracked(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task LastOrDefault_member_access_in_projection_translates_to_server(bool async)
    {
        return base.LastOrDefault_member_access_in_projection_translates_to_server(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task List_from_result_of_single_result_3(bool async)
    {
        return base.List_from_result_of_single_result_3(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task List_of_list_of_anonymous_type(bool async)
    {
        return base.List_of_list_of_anonymous_type(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task MemberInit_in_projection_without_arguments(bool async)
    {
        return base.MemberInit_in_projection_without_arguments(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Project_keyless_entity_FirstOrDefault_without_orderby(bool async)
    {
        return base.Project_keyless_entity_FirstOrDefault_without_orderby(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Project_single_element_from_collection_with_multiple_OrderBys_Take_and_FirstOrDefault(bool async)
    {
        return base.Project_single_element_from_collection_with_multiple_OrderBys_Take_and_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Project_single_element_from_collection_with_multiple_OrderBys_Take_and_FirstOrDefault_2(bool async)
    {
        return base.Project_single_element_from_collection_with_multiple_OrderBys_Take_and_FirstOrDefault_2(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Project_single_element_from_collection_with_multiple_OrderBys_Take_and_FirstOrDefault_followed_by_projection_of_length_property(bool async)
    {
        return base.Project_single_element_from_collection_with_multiple_OrderBys_Take_and_FirstOrDefault_followed_by_projection_of_length_property(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Project_single_element_from_collection_with_OrderBy_Distinct_and_FirstOrDefault(bool async)
    {
        return base.Project_single_element_from_collection_with_OrderBy_Distinct_and_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Project_single_element_from_collection_with_OrderBy_Distinct_and_FirstOrDefault_followed_by_projecting_length(bool async)
    {
        return base.Project_single_element_from_collection_with_OrderBy_Distinct_and_FirstOrDefault_followed_by_projecting_length(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Project_single_element_from_collection_with_OrderBy_over_navigation_Take_and_FirstOrDefault(bool async)
    {
        return base.Project_single_element_from_collection_with_OrderBy_over_navigation_Take_and_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Project_single_element_from_collection_with_OrderBy_Skip_and_FirstOrDefault(bool async)
    {
        return base.Project_single_element_from_collection_with_OrderBy_Skip_and_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Project_single_element_from_collection_with_OrderBy_Take_and_FirstOrDefault(bool async)
    {
        return base.Project_single_element_from_collection_with_OrderBy_Take_and_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Project_single_element_from_collection_with_OrderBy_Take_and_FirstOrDefault_with_parameter(bool async)
    {
        return base.Project_single_element_from_collection_with_OrderBy_Take_and_FirstOrDefault_with_parameter(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Project_single_element_from_collection_with_OrderBy_Take_and_SingleOrDefault(bool async)
    {
        return base.Project_single_element_from_collection_with_OrderBy_Take_and_SingleOrDefault(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Project_uint_through_collection_FirstOrDefault(bool async)
    {
        return base.Project_uint_through_collection_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projecting_count_of_navigation_which_is_generic_collection(bool async)
    {
        return base.Projecting_count_of_navigation_which_is_generic_collection(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projecting_count_of_navigation_which_is_generic_collection_using_convert(bool async)
    {
        return base.Projecting_count_of_navigation_which_is_generic_collection_using_convert(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projecting_count_of_navigation_which_is_generic_list(bool async)
    {
        return base.Projecting_count_of_navigation_which_is_generic_list(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projecting_Length_of_a_string_property_after_FirstOrDefault_on_correlated_collection(bool async)
    {
        return base.Projecting_Length_of_a_string_property_after_FirstOrDefault_on_correlated_collection(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projecting_multiple_collection_with_same_constant_works(bool async)
    {
        return base.Projecting_multiple_collection_with_same_constant_works(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projecting_nullable_struct(bool async)
    {
        return base.Projecting_nullable_struct(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projection_AsEnumerable_projection(bool async)
    {
        return base.Projection_AsEnumerable_projection(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projection_containing_DateTime_subtraction(bool async)
    {
        return base.Projection_containing_DateTime_subtraction(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projection_in_a_subquery_should_be_liftable(bool async)
    {
        return base.Projection_in_a_subquery_should_be_liftable(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projection_skip_projection_doesnt_project_intermittent_column(bool async)
    {
        return base.Projection_skip_projection_doesnt_project_intermittent_column(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projection_take_predicate_projection(bool async)
    {
        return base.Projection_take_predicate_projection(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projection_take_projection_doesnt_project_intermittent_column(bool async)
    {
        return base.Projection_take_projection_doesnt_project_intermittent_column(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projection_when_arithmetic_expression_precedence(bool async)
    {
        return base.Projection_when_arithmetic_expression_precedence(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projection_when_arithmetic_expressions(bool async)
    {
        return base.Projection_when_arithmetic_expressions(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projection_when_arithmetic_mixed(bool async)
    {
        return base.Projection_when_arithmetic_mixed(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Projection_when_arithmetic_mixed_subqueries(bool async)
    {
        return base.Projection_when_arithmetic_mixed_subqueries(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Reverse_in_join_inner(bool async)
    {
        return base.Reverse_in_join_inner(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Reverse_in_join_inner_with_skip(bool async)
    {
        return base.Reverse_in_join_inner_with_skip(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Select_anonymous_constant_in_expression(bool async)
    {
        return base.Select_anonymous_constant_in_expression(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Select_anonymous_literal(bool async)
    {
        return base.Select_anonymous_literal(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Select_nested_collection_count_using_anonymous_type(bool async)
    {
        return base.Select_nested_collection_count_using_anonymous_type(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Select_nested_collection_multi_level(bool async)
    {
        return base.Select_nested_collection_multi_level(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Select_nested_collection_multi_level2(bool async)
    {
        return base.Select_nested_collection_multi_level2(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Select_nested_collection_multi_level3(bool async)
    {
        return base.Select_nested_collection_multi_level3(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Select_nested_collection_multi_level4(bool async)
    {
        return base.Select_nested_collection_multi_level4(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Select_nested_collection_multi_level5(bool async)
    {
        return base.Select_nested_collection_multi_level5(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Select_nested_collection_multi_level6(bool async)
    {
        return base.Select_nested_collection_multi_level6(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Select_with_complex_expression_that_can_be_funcletized(bool async)
    {
        return base.Select_with_complex_expression_that_can_be_funcletized(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Ternary_in_client_eval_assigns_correct_types(bool async)
    {
        return base.Ternary_in_client_eval_assigns_correct_types(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task ToList_Count_in_projection_works(bool async)
    {
        return base.ToList_Count_in_projection_works(async);
    }

    [ConditionalTheory(Skip = "TBD"), MemberData(nameof(IsAsyncData))]
    public override Task Project_single_element_from_collection_with_OrderBy_Take_OrderBy_and_FirstOrDefault(bool async)
    {
        return base.Project_single_element_from_collection_with_OrderBy_Take_OrderBy_and_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = "TBD"), MemberData(nameof(IsAsyncData))]
    public override Task SelectMany_with_multiple_Take(bool async)
    {
        return base.SelectMany_with_multiple_Take(async);
    }

    [ConditionalTheory(Skip = "TBD"), MemberData(nameof(IsAsyncData))]
    public override Task SelectMany_with_nested_DefaultIfEmpty(bool async)
    {
        return base.SelectMany_with_nested_DefaultIfEmpty(async);
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
