using ClickHouse.Driver.ADO.Parameters;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Data.Common;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class FromSqlQueryClickHouseTest : FromSqlQueryTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public FromSqlQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }

    protected override DbParameter CreateDbParameter(string name, object value)
    {
        return new ClickHouseDbParameter { ParameterName = name, Value = value };
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bad_data_error_handling_invalid_cast(bool async)
    {
        await base.Bad_data_error_handling_invalid_cast(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bad_data_error_handling_invalid_cast_key(bool async)
    {
        await base.Bad_data_error_handling_invalid_cast_key(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bad_data_error_handling_invalid_cast_no_tracking(bool async)
    {
        await base.Bad_data_error_handling_invalid_cast_no_tracking(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bad_data_error_handling_invalid_cast_projection(bool async)
    {
        await base.Bad_data_error_handling_invalid_cast_projection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bad_data_error_handling_null(bool async)
    {
        await base.Bad_data_error_handling_null(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bad_data_error_handling_null_no_tracking(bool async)
    {
        await base.Bad_data_error_handling_null_no_tracking(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bad_data_error_handling_null_projection(bool async)
    {
        await base.Bad_data_error_handling_null_projection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Entity_equality_through_fromsql(bool async)
    {
        await base.Entity_equality_through_fromsql(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_Count_used_twice_with_parameters(bool async)
    {
        await base.FromSql_Count_used_twice_with_parameters(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_Count_used_twice_without_parameters(bool async)
    {
        await base.FromSql_Count_used_twice_without_parameters(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_GroupBy_non_reducing_Select(bool async)
    {
        await base.FromSql_GroupBy_non_reducing_Select(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_queryable_multiple_composed_with_parameters_and_closure_parameters_interpolated(bool async)
    {
        await base.FromSql_queryable_multiple_composed_with_parameters_and_closure_parameters_interpolated(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_queryable_with_parameters_inline_interpolated(bool async)
    {
        await base.FromSql_queryable_with_parameters_inline_interpolated(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_queryable_with_parameters_interpolated(bool async)
    {
        await base.FromSql_queryable_with_parameters_interpolated(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_used_twice_with_parameters(bool async)
    {
        await base.FromSql_used_twice_with_parameters(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_used_twice_without_parameters(bool async)
    {
        await base.FromSql_used_twice_without_parameters(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_with_db_parameter_in_split_query(bool async)
    {
        await base.FromSql_with_db_parameter_in_split_query(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_with_inlined_db_parameter(bool async)
    {
        await base.FromSql_with_inlined_db_parameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_with_inlined_db_parameter_without_name_prefix(bool async)
    {
        await base.FromSql_with_inlined_db_parameter_without_name_prefix(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlInterpolated_parameterization_issue_12213(bool async)
    {
        await base.FromSqlInterpolated_parameterization_issue_12213(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlInterpolated_queryable_multiple_composed_with_parameters_and_closure_parameters_interpolated(bool async)
    {
        await base.FromSqlInterpolated_queryable_multiple_composed_with_parameters_and_closure_parameters_interpolated(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlInterpolated_queryable_with_parameters_inline_interpolated(bool async)
    {
        await base.FromSqlInterpolated_queryable_with_parameters_inline_interpolated(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlInterpolated_queryable_with_parameters_interpolated(bool async)
    {
        await base.FromSqlInterpolated_queryable_with_parameters_interpolated(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlInterpolated_with_inlined_db_parameter(bool async)
    {
        await base.FromSqlInterpolated_with_inlined_db_parameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlInterpolated_with_inlined_db_parameter_without_name_prefix(bool async)
    {
        await base.FromSqlInterpolated_with_inlined_db_parameter_without_name_prefix(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_annotations_do_not_affect_successive_calls(bool async)
    {
        await base.FromSqlRaw_annotations_do_not_affect_successive_calls(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_composed_contains(bool async)
    {
        await base.FromSqlRaw_composed_contains(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_composed_contains2(bool async)
    {
        await base.FromSqlRaw_composed_contains2(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_composed_with_common_table_expression(bool async)
    {
        await base.FromSqlRaw_composed_with_common_table_expression(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_composed_with_nullable_predicate(bool async)
    {
        await base.FromSqlRaw_composed_with_nullable_predicate(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_does_not_parameterize_interpolated_string(bool async)
    {
        await base.FromSqlRaw_does_not_parameterize_interpolated_string(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_in_subquery_with_dbParameter(bool async)
    {
        await base.FromSqlRaw_in_subquery_with_dbParameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_in_subquery_with_positional_dbParameter_with_name(bool async)
    {
        await base.FromSqlRaw_in_subquery_with_positional_dbParameter_with_name(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_in_subquery_with_positional_dbParameter_without_name(bool async)
    {
        await base.FromSqlRaw_in_subquery_with_positional_dbParameter_without_name(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_composed(bool async)
    {
        await base.FromSqlRaw_queryable_composed(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_composed_after_removing_whitespaces(bool async)
    {
        await base.FromSqlRaw_queryable_composed_after_removing_whitespaces(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_composed_compiled(bool async)
    {
        await base.FromSqlRaw_queryable_composed_compiled(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_composed_compiled_with_DbParameter(bool async)
    {
        await base.FromSqlRaw_queryable_composed_compiled_with_DbParameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_composed_compiled_with_nameless_DbParameter(bool async)
    {
        await base.FromSqlRaw_queryable_composed_compiled_with_nameless_DbParameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_composed_compiled_with_parameter(bool async)
    {
        await base.FromSqlRaw_queryable_composed_compiled_with_parameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_composed_multiple_line_query(bool async)
    {
        await base.FromSqlRaw_queryable_composed_multiple_line_query(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_multiple_composed(bool async)
    {
        await base.FromSqlRaw_queryable_multiple_composed(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_multiple_composed_with_closure_parameters(bool async)
    {
        await base.FromSqlRaw_queryable_multiple_composed_with_closure_parameters(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_multiple_composed_with_parameters_and_closure_parameters(bool async)
    {
        await base.FromSqlRaw_queryable_multiple_composed_with_parameters_and_closure_parameters(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_multiple_line_query(bool async)
    {
        await base.FromSqlRaw_queryable_multiple_line_query(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_simple(bool async)
    {
        await base.FromSqlRaw_queryable_simple(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_simple_as_no_tracking_not_composed(bool async)
    {
        await base.FromSqlRaw_queryable_simple_as_no_tracking_not_composed(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_simple_cache_key_includes_query_string(bool async)
    {
        await base.FromSqlRaw_queryable_simple_cache_key_includes_query_string(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_simple_columns_out_of_order(bool async)
    {
        await base.FromSqlRaw_queryable_simple_columns_out_of_order(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_simple_columns_out_of_order_and_extra_columns(bool async)
    {
        await base.FromSqlRaw_queryable_simple_columns_out_of_order_and_extra_columns(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_simple_columns_out_of_order_and_not_enough_columns_throws(bool async)
    {
        await base.FromSqlRaw_queryable_simple_columns_out_of_order_and_not_enough_columns_throws(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_simple_composed_include(bool async)
    {
        await base.FromSqlRaw_queryable_simple_composed_include(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_simple_different_cased_columns_and_not_enough_columns_throws(bool async)
    {
        await base.FromSqlRaw_queryable_simple_different_cased_columns_and_not_enough_columns_throws(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_simple_include(bool async)
    {
        await base.FromSqlRaw_queryable_simple_include(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_simple_projection_composed(bool async)
    {
        await base.FromSqlRaw_queryable_simple_projection_composed(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_simple_projection_not_composed(bool async)
    {
        await base.FromSqlRaw_queryable_simple_projection_not_composed(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_with_null_parameter(bool async)
    {
        await base.FromSqlRaw_queryable_with_null_parameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_with_parameters(bool async)
    {
        await base.FromSqlRaw_queryable_with_parameters(async);
    }

#if NET10_0
    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
#else
#pragma warning disable xUnit1028 // The EF Core specification method returns a value used by other tests.
    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
#endif
    public override async Task<string?> FromSqlRaw_queryable_with_parameters_and_closure(bool async)
    {
        return await base.FromSqlRaw_queryable_with_parameters_and_closure(async);
    }
#if NET11_0_OR_GREATER
#pragma warning restore xUnit1028
#endif

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_with_parameters_cache_key_includes_parameters(bool async)
    {
        await base.FromSqlRaw_queryable_with_parameters_cache_key_includes_parameters(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_queryable_with_parameters_inline(bool async)
    {
        await base.FromSqlRaw_queryable_with_parameters_inline(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_with_db_parameters_called_multiple_times(bool async)
    {
        await base.FromSqlRaw_with_db_parameters_called_multiple_times(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_with_dbParameter(bool async)
    {
        await base.FromSqlRaw_with_dbParameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_with_dbParameter_and_regular_parameter_with_same_name(bool async)
    {
        await base.FromSqlRaw_with_dbParameter_and_regular_parameter_with_same_name(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_with_dbParameter_mixed(bool async)
    {
        await base.FromSqlRaw_with_dbParameter_mixed(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_with_dbParameter_mixed_in_subquery(bool async)
    {
        await base.FromSqlRaw_with_dbParameter_mixed_in_subquery(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_with_dbParameter_without_name_prefix(bool async)
    {
        await base.FromSqlRaw_with_dbParameter_without_name_prefix(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_with_join_and_include(bool async)
    {
        await base.FromSqlRaw_with_join_and_include(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_with_SelectMany_and_include(bool async)
    {
        await base.FromSqlRaw_with_SelectMany_and_include(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw_with_set_operation(bool async)
    {
        await base.FromSqlRaw_with_set_operation(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_closed_connection_opened_by_it_when_buffering(bool async)
    {
        await base.Include_closed_connection_opened_by_it_when_buffering(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_does_not_close_user_opened_connection_for_empty_result(bool async)
    {
        await base.Include_does_not_close_user_opened_connection_for_empty_result(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Keyless_entity_with_all_nulls(bool async)
    {
        await base.Keyless_entity_with_all_nulls(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Line_endings_after_Select(bool async)
    {
        await base.Line_endings_after_Select(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_occurrences_of_FromSql_with_db_parameter_adds_two_parameters(bool async)
    {
        await base.Multiple_occurrences_of_FromSql_with_db_parameter_adds_two_parameters(async);
    }
}
