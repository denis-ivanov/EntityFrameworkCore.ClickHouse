using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindGroupByQueryClickHouseTest : NorthwindGroupByQueryRelationalTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindGroupByQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task AsEnumerable_in_subquery_for_GroupBy(bool async)
    {
        await base.AsEnumerable_in_subquery_for_GroupBy(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_query_with_groupBy_in_subquery1(bool async)
    {
        await base.Complex_query_with_groupBy_in_subquery1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_query_with_groupBy_in_subquery2(bool async)
    {
        await base.Complex_query_with_groupBy_in_subquery2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_query_with_groupBy_in_subquery3(bool async)
    {
        await base.Complex_query_with_groupBy_in_subquery3(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_query_with_groupBy_in_subquery4(bool async)
    {
        await base.Complex_query_with_groupBy_in_subquery4(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_query_with_group_by_in_subquery5(bool async)
    {
        await base.Complex_query_with_group_by_in_subquery5(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_aggregate_Contains(bool async)
    {
        await base.GroupBy_aggregate_Contains(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_aggregate_from_multiple_query_in_same_projection(bool async)
    {
        await base.GroupBy_aggregate_from_multiple_query_in_same_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_aggregate_projecting_conditional_expression(bool async)
    {
        await base.GroupBy_aggregate_projecting_conditional_expression(async);
    }
}
