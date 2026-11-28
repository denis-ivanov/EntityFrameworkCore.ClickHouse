using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindNavigationsQueryClickHouseTest : NorthwindNavigationsQueryRelationalTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindNavigationsQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_orderby_nav_prop_count(bool async)
    {
        await base.Collection_orderby_nav_prop_count(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_select_nav_prop_count(bool async)
    {
        await base.Collection_select_nav_prop_count(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_select_nav_prop_first_or_default(bool async)
    {
        await base.Collection_select_nav_prop_first_or_default(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_select_nav_prop_first_or_default_then_nav_prop(bool async)
    {
        await base.Collection_select_nav_prop_first_or_default_then_nav_prop(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_select_nav_prop_long_count(bool async)
    {
        await base.Collection_select_nav_prop_long_count(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_select_nav_prop_sum(bool async)
    {
        await base.Collection_select_nav_prop_sum(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_select_nav_prop_sum_plus_one(bool async)
    {
        await base.Collection_select_nav_prop_sum_plus_one(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_in_subquery_referencing_outer_query_with_client_side_result_operator_and_count(bool async)
    {
        await base.Navigation_in_subquery_referencing_outer_query_with_client_side_result_operator_and_count(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_collection_FirstOrDefault_project_anonymous_type(bool async)
    {
        await base.Select_collection_FirstOrDefault_project_anonymous_type(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_collection_FirstOrDefault_project_anonymous_type_client_eval(bool async)
    {
        await base.Select_collection_FirstOrDefault_project_anonymous_type_client_eval(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Where_Navigation_Null(bool async)
    {
        await base.Select_Where_Navigation_Null(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Where_Navigation_Null_Deep(bool async)
    {
        await base.Select_Where_Navigation_Null_Deep(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Where_Navigation_Null_Reverse(bool async)
    {
        await base.Select_Where_Navigation_Null_Reverse(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_Select_Navigation(bool async)
    {
        await base.Skip_Select_Navigation(async);
    }
}
