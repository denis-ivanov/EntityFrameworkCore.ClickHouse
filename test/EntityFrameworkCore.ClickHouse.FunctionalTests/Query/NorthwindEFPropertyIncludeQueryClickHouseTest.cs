using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindEFPropertyIncludeQueryClickHouseTest : NorthwindEFPropertyIncludeQueryTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindEFPropertyIncludeQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_with_multiple_ordering(bool async)
    {
        await base.Filtered_include_with_multiple_ordering(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_order_by_collection_column(bool async)
    {
        await base.Include_collection_order_by_collection_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_order_by_subquery(bool async)
    {
        await base.Include_collection_order_by_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_skip_no_order_by(bool async)
    {
        await base.Include_collection_skip_no_order_by(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_then_include_collection(bool async)
    {
        await base.Include_collection_then_include_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_then_include_collection_predicate(bool async)
    {
        await base.Include_collection_then_include_collection_predicate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_then_include_collection_then_include_reference(bool async)
    {
        await base.Include_collection_then_include_collection_then_include_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_cross_apply_with_filter(bool async)
    {
        await base.Include_collection_with_cross_apply_with_filter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_last_no_orderby(bool async)
    {
        await base.Include_collection_with_last_no_orderby(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_multiple_conditional_order_by(bool async)
    {
        await base.Include_collection_with_multiple_conditional_order_by(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_outer_apply_with_filter(bool async)
    {
        await base.Include_collection_with_outer_apply_with_filter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_outer_apply_with_filter_non_equality(bool async)
    {
        await base.Include_collection_with_outer_apply_with_filter_non_equality(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_duplicate_collection(bool async)
    {
        await base.Include_duplicate_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_empty_reference_sets_IsLoaded(bool async)
    {
        await base.Include_empty_reference_sets_IsLoaded(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_duplicate_collection_result_operator(bool async)
    {
        await base.Include_duplicate_collection_result_operator(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_duplicate_collection_result_operator2(bool async)
    {
        await base.Include_duplicate_collection_result_operator2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_in_let_followed_by_FirstOrDefault(bool async)
    {
        await base.Include_in_let_followed_by_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_is_not_ignored_when_projection_contains_client_method_and_complex_expression(bool async)
    {
        await base.Include_is_not_ignored_when_projection_contains_client_method_and_complex_expression(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_Join_GroupBy_Select(bool async)
    {
        await base.Include_reference_Join_GroupBy_Select(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_SelectMany_GroupBy_Select(bool async)
    {
        await base.Include_reference_SelectMany_GroupBy_Select(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_Include_collection_GroupBy_Select(bool async)
    {
        await base.Join_Include_collection_GroupBy_Select(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Join_Include_reference_GroupBy_Select(bool async)
    {
        await base.Join_Include_reference_GroupBy_Select(async);
    }
}
