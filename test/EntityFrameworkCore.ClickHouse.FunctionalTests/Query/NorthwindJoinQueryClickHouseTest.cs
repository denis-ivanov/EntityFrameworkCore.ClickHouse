using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindJoinQueryClickHouseTest : NorthwindJoinQueryRelationalTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindJoinQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Condition_on_entity_with_include(bool async)
    {
        await base.Condition_on_entity_with_include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupJoin_aggregate_anonymous_key_selectors(bool async)
    {
        await base.GroupJoin_aggregate_anonymous_key_selectors(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupJoin_aggregate_anonymous_key_selectors2(bool async)
    {
        await base.GroupJoin_aggregate_anonymous_key_selectors2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupJoin_aggregate_anonymous_key_selectors_one_argument(bool async)
    {
        await base.GroupJoin_aggregate_anonymous_key_selectors_one_argument(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupJoin_as_final_operator(bool async)
    {
        await base.GroupJoin_as_final_operator(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupJoin_DefaultIfEmpty(bool async)
    {
        await base.GroupJoin_DefaultIfEmpty(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupJoin_DefaultIfEmpty_multiple(bool async)
    {
        await base.GroupJoin_DefaultIfEmpty_multiple(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupJoin_DefaultIfEmpty_Project(bool async)
    {
        await base.GroupJoin_DefaultIfEmpty_Project(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupJoin_SelectMany_subquery_with_filter_and_DefaultIfEmpty(bool async)
    {
        await base.GroupJoin_SelectMany_subquery_with_filter_and_DefaultIfEmpty(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupJoin_SelectMany_subquery_with_filter_orderby_and_DefaultIfEmpty(bool async)
    {
        await base.GroupJoin_SelectMany_subquery_with_filter_orderby_and_DefaultIfEmpty(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_local_collection_int_closure_is_cached_correctly(bool async)
    {
        await base.Join_local_collection_int_closure_is_cached_correctly(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task LeftJoin(bool async)
    {
        await base.LeftJoin(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_client_eval(bool async)
    {
        await base.SelectMany_with_client_eval(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_client_eval_with_collection_shaper(bool async)
    {
        await base.SelectMany_with_client_eval_with_collection_shaper(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_client_eval_with_collection_shaper_ignored(bool async)
    {
        await base.SelectMany_with_client_eval_with_collection_shaper_ignored(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_client_eval_with_constructor(bool async)
    {
        await base.SelectMany_with_client_eval_with_constructor(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_selecting_outer_element(bool async)
    {
        await base.SelectMany_with_selecting_outer_element(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_selecting_outer_entity(bool async)
    {
        await base.SelectMany_with_selecting_outer_entity(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_selecting_outer_entity_column_and_inner_column(bool async)
    {
        await base.SelectMany_with_selecting_outer_entity_column_and_inner_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Take_in_collection_projection_with_FirstOrDefault_on_top_level(bool async)
    {
        await base.Take_in_collection_projection_with_FirstOrDefault_on_top_level(async);
    }
}
