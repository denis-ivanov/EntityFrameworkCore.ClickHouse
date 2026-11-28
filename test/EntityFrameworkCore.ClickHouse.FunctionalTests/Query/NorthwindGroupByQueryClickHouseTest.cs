using Microsoft.EntityFrameworkCore.Query;
#if NET11_0_OR_GREATER
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
#endif
using Microsoft.EntityFrameworkCore.TestUtilities;
#if NET11_0_OR_GREATER
using System.Linq;
#endif
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindGroupByQueryClickHouseTest : NorthwindGroupByQueryRelationalTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindGroupByQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

#if NET11_0_OR_GREATER
    [Theory]
    [MemberData(nameof(IsAsyncData))]
    public override Task GroupBy_Select_Entire_Entity_Where(bool async)
        => AssertQuery(
            async,
            static source => source.Set<Order>().GroupBy(static order => order.CustomerID)
                .Select(static orders => orders.OrderBy(static order => order.OrderID).First())
                .Where(static order => order.EmployeeID == 6u));

    [Theory]
    [MemberData(nameof(IsAsyncData))]
    public override Task GroupBy_Select_Entire_Entity_Order(bool async)
        => AssertQuery(
            async,
            static source => source.Set<Order>().GroupBy(static order => order.CustomerID)
                .Select(static orders => orders.OrderBy(static order => order.OrderID).First())
                .OrderBy(static order => order.EmployeeID)
                .ThenBy(static order => order.OrderID),
            assertOrder: true);

    [Theory]
    [MemberData(nameof(IsAsyncData))]
    public override Task GroupBy_Select_Entire_Entity_composite_key_Select(bool async)
        => AssertQuery(
            async,
            static source => source.Set<Order>().GroupBy(static order => new { order.CustomerID, order.EmployeeID })
                .Select(static orders => orders.OrderBy(static order => order.OrderID).First())
                .Select(static order => order.OrderID));

    [Theory]
    [MemberData(nameof(IsAsyncData))]
    public override Task GroupBy_ResultSelector_Entire_Entity_Where(bool async)
        => AssertQuery(
            async,
            static source => source.Set<Order>()
                .GroupBy(
                    static order => order.CustomerID,
                    static (_, orders) => orders.OrderByDescending(static order => order.OrderDate)
                        .ThenBy(static order => order.OrderID)
                        .First())
                .Where(static order => order.EmployeeID == 6u));
#endif

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task AsEnumerable_in_subquery_for_GroupBy(bool async)
    {
        await base.AsEnumerable_in_subquery_for_GroupBy(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_query_with_groupBy_in_subquery1(bool async)
    {
        await base.Complex_query_with_groupBy_in_subquery1(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_query_with_groupBy_in_subquery2(bool async)
    {
        await base.Complex_query_with_groupBy_in_subquery2(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_query_with_groupBy_in_subquery3(bool async)
    {
        await base.Complex_query_with_groupBy_in_subquery3(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_query_with_groupBy_in_subquery4(bool async)
    {
        await base.Complex_query_with_groupBy_in_subquery4(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_query_with_group_by_in_subquery5(bool async)
    {
        await base.Complex_query_with_group_by_in_subquery5(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_aggregate_Contains(bool async)
    {
        await base.GroupBy_aggregate_Contains(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_aggregate_from_multiple_query_in_same_projection(bool async)
    {
        await base.GroupBy_aggregate_from_multiple_query_in_same_projection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_aggregate_projecting_conditional_expression(bool async)
    {
        await base.GroupBy_aggregate_projecting_conditional_expression(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_aggregate_from_multiple_query_in_same_projection_2(bool async)
    {
        await base.GroupBy_aggregate_from_multiple_query_in_same_projection_2(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_aggregate_projecting_conditional_expression_based_on_group_key(bool async)
    {
        await base.GroupBy_aggregate_projecting_conditional_expression_based_on_group_key(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_scalar_aggregate_in_set_operation(bool async)
    {
        await base.GroupBy_scalar_aggregate_in_set_operation(async);
    }
    
    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_scalar_subquery(bool async)
    {
        await base.GroupBy_scalar_subquery(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_select_grouping_composed_list(bool async)
    {
        await base.GroupBy_select_grouping_composed_list(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_Shadow(bool async)
    {
        await base.GroupBy_Shadow(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_Shadow3(bool async)
    {
        await base.GroupBy_Shadow3(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_with_aggregate_containing_complex_where(bool async)
    {
        await base.GroupBy_with_aggregate_containing_complex_where(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupJoin_GroupBy_Aggregate(bool async)
    {
        await base.GroupJoin_GroupBy_Aggregate(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_GroupBy_Aggregate_with_left_join(bool async)
    {
        await base.Join_GroupBy_Aggregate_with_left_join(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Odata_groupby_empty_key(bool async)
    {
        await base.Odata_groupby_empty_key(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_correlated_collection_after_GroupBy_aggregate_when_identifier_changes_to_complex(bool async)
    {
        await base.Select_correlated_collection_after_GroupBy_aggregate_when_identifier_changes_to_complex(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_correlated_collection_after_GroupBy_aggregate_when_identifier_does_not_change(bool async)
    {
        await base.Select_correlated_collection_after_GroupBy_aggregate_when_identifier_does_not_change(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_nested_collection_with_groupby(bool async)
    {
        await base.Select_nested_collection_with_groupby(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_uncorrelated_collection_with_groupby_multiple_collections_work(bool async)
    {
        await base.Select_uncorrelated_collection_with_groupby_multiple_collections_work(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_uncorrelated_collection_with_groupby_when_outer_is_distinct(bool async)
    {
        await base.Select_uncorrelated_collection_with_groupby_when_outer_is_distinct(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_uncorrelated_collection_with_groupby_works(bool async)
    {
        await base.Select_uncorrelated_collection_with_groupby_works(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_simple_groupby(bool async)
    {
        await base.Union_simple_groupby(async);
    }
}
