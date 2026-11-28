using ClickHouse.Driver.ADO.Parameters;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Data.Common;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class SqlQueryClickHouseTest : SqlQueryTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public SqlQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
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
    public override async Task SqlQueryRaw_queryable_simple_different_cased_columns_and_not_enough_columns_throws(bool async)
    {
        await base.SqlQueryRaw_queryable_simple_different_cased_columns_and_not_enough_columns_throws(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_queryable_composed_compiled_with_nameless_DbParameter(bool async)
    {
        await base.SqlQueryRaw_queryable_composed_compiled_with_nameless_DbParameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_queryable_multiple_composed(bool async)
    {
        await base.SqlQueryRaw_queryable_multiple_composed(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_queryable_multiple_composed_with_closure_parameters(bool async)
    {
        await base.SqlQueryRaw_queryable_multiple_composed_with_closure_parameters(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_queryable_multiple_composed_with_parameters_and_closure_parameters(bool async)
    {
        await base.SqlQueryRaw_queryable_multiple_composed_with_parameters_and_closure_parameters(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_queryable_with_parameters(bool async)
    {
        await base.SqlQueryRaw_queryable_with_parameters(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_queryable_with_parameters_inline(bool async)
    {
        await base.SqlQueryRaw_queryable_with_parameters_inline(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQuery_queryable_with_parameters_interpolated(bool async)
    {
        await base.SqlQuery_queryable_with_parameters_interpolated(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQuery_queryable_with_parameters_inline_interpolated(bool async)
    {
        await base.SqlQuery_queryable_with_parameters_inline_interpolated(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQuery_queryable_multiple_composed_with_parameters_and_closure_parameters_interpolated(bool async)
    {
        await base.SqlQuery_queryable_multiple_composed_with_parameters_and_closure_parameters_interpolated(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_queryable_with_null_parameter(bool async)
    {
        await base.SqlQueryRaw_queryable_with_null_parameter(async);
    }

#if NET10_0
    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
#else
#pragma warning disable xUnit1028 // The EF Core specification method returns a value used by other tests.
    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
#endif
    public override async Task<string> SqlQueryRaw_queryable_with_parameters_and_closure(bool async)
    {
        return await base.SqlQueryRaw_queryable_with_parameters_and_closure(async);
    }
#if NET11_0_OR_GREATER
#pragma warning restore xUnit1028
#endif

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_queryable_with_parameters_cache_key_includes_parameters(bool async)
    {
        await base.SqlQueryRaw_queryable_with_parameters_cache_key_includes_parameters(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_queryable_simple_projection_composed(bool async)
    {
        await base.SqlQueryRaw_queryable_simple_projection_composed(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_with_dbParameter(bool async)
    {
        await base.SqlQueryRaw_with_dbParameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_with_dbParameter_mixed(bool async)
    {
        await base.SqlQueryRaw_with_dbParameter_mixed(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_with_db_parameters_called_multiple_times(bool async)
    {
        await base.SqlQueryRaw_with_db_parameters_called_multiple_times(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQuery_with_inlined_db_parameter(bool async)
    {
        await base.SqlQuery_with_inlined_db_parameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQuery_with_inlined_db_parameter_without_name_prefix(bool async)
    {
        await base.SqlQuery_with_inlined_db_parameter_without_name_prefix(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQuery_parameterization_issue_12213(bool async)
    {
        await base.SqlQuery_parameterization_issue_12213(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_does_not_parameterize_interpolated_string(bool async)
    {
        await base.SqlQueryRaw_does_not_parameterize_interpolated_string(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_in_subquery_with_dbParameter(bool async)
    {
        await base.SqlQueryRaw_in_subquery_with_dbParameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_in_subquery_with_positional_dbParameter_without_name(bool async)
    {
        await base.SqlQueryRaw_in_subquery_with_positional_dbParameter_without_name(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_in_subquery_with_positional_dbParameter_with_name(bool async)
    {
        await base.SqlQueryRaw_in_subquery_with_positional_dbParameter_with_name(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SqlQueryRaw_with_dbParameter_mixed_in_subquery(bool async)
    {
        await base.SqlQueryRaw_with_dbParameter_mixed_in_subquery(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_occurrences_of_SqlQuery_with_db_parameter_adds_two_parameters(bool async)
    {
        await base.Multiple_occurrences_of_SqlQuery_with_db_parameter_adds_two_parameters(async);
    }

    protected override DbParameter CreateDbParameter(string name, object value)
    {
        return new ClickHouseDbParameter { ParameterName = name, Value = value };
    }
}
