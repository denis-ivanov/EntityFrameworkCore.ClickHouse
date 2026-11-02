using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindSetOperationsQueryClickHouseTest : NorthwindSetOperationsQueryRelationalTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindSetOperationsQueryClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper) : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_eval_Union_FirstOrDefault(bool async)
    {
        await base.Client_eval_Union_FirstOrDefault(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_projection_after_set_operation(bool async)
    {
        await base.Collection_projection_after_set_operation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Concat_with_one_side_being_GroupBy_aggregate(bool async)
    {
        await base.Concat_with_one_side_being_GroupBy_aggregate(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_Select_Union(bool async)
    {
        await base.GroupBy_Select_Union(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_Union(bool async)
    {
        await base.Include_Union(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OrderBy_Take_Union(bool async)
    {
        await base.OrderBy_Take_Union(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Except_reference_projection(bool async)
    {
        await base.Select_Except_reference_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Union(bool async)
    {
        await base.Select_Union(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Union_different_fields_in_anonymous_with_subquery(bool async)
    {
        await base.Select_Union_different_fields_in_anonymous_with_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_Union_unrelated(bool async)
    {
        await base.Select_Union_unrelated(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SubSelect_Union(bool async)
    {
        await base.SubSelect_Union(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union(bool async)
    {
        await base.Union(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_Include(bool async)
    {
        await base.Union_Include(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_inside_Concat(bool async)
    {
        await base.Union_inside_Concat(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_Intersect(bool async)
    {
        await base.Union_Intersect(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_nested(bool async)
    {
        await base.Union_nested(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_non_entity(bool async)
    {
        await base.Union_non_entity(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_on_distinct(bool async)
    {
        await base.Union_on_distinct(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_on_entity_plus_other_column_with_correlated_collection(bool async)
    {
        await base.Union_on_entity_plus_other_column_with_correlated_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_on_entity_with_correlated_collection(bool async)
    {
        await base.Union_on_entity_with_correlated_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_OrderBy_Skip_Take(bool async)
    {
        await base.Union_OrderBy_Skip_Take(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_binary_binary(bool async)
    {
        await base.Union_over_binary_binary(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_binary_constant(bool async)
    {
        await base.Union_over_binary_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_binary_column(bool async)
    {
        await base.Union_over_binary_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_binary_function(bool async)
    {
        await base.Union_over_binary_function(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_binary_scalarsubquery(bool async)
    {
        await base.Union_over_binary_scalarsubquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_binary_unary(bool async)
    {
        await base.Union_over_binary_unary(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_column_binary(bool async)
    {
        await base.Union_over_column_binary(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_column_column(bool async)
    {
        await base.Union_over_column_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_column_constant(bool async)
    {
        await base.Union_over_column_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_column_function(bool async)
    {
        await base.Union_over_column_function(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_column_scalarsubquery(bool async)
    {
        await base.Union_over_column_scalarsubquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_column_unary(bool async)
    {
        await base.Union_over_column_unary(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_constant_column(bool async)
    {
        await base.Union_over_constant_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_constant_constant(bool async)
    {
        await base.Union_over_constant_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_constant_function(bool async)
    {
        await base.Union_over_constant_function(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_constant_unary(bool async)
    {
        await base.Union_over_constant_unary(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_function_binary(bool async)
    {
        await base.Union_over_function_binary(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_function_column(bool async)
    {
        await base.Union_over_function_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_function_constant(bool async)
    {
        await base.Union_over_function_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_function_function(bool async)
    {
        await base.Union_over_function_function(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_constant_binary(bool async)
    {
        await base.Union_over_constant_binary(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_constant_scalarsubquery(bool async)
    {
        await base.Union_over_constant_scalarsubquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_function_scalarsubquery(bool async)
    {
        await base.Union_over_function_scalarsubquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_function_unary(bool async)
    {
        await base.Union_over_function_unary(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_Where(bool async)
    {
        await base.Union_Where(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_Skip_Take_OrderBy_ThenBy_Where(bool async)
    {
        await base.Union_Skip_Take_OrderBy_ThenBy_Where(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_Union(bool async)
    {
        await base.Union_Union(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_Take_Union_Take(bool async)
    {
        await base.Union_Take_Union_Take(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_Select(bool async)
    {
        await base.Union_Select(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_Select_scalar(bool async)
    {
        await base.Union_Select_scalar(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_with_anonymous_type_projection(bool async)
    {
        await base.Union_with_anonymous_type_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_unary_column(bool async)
    {
        await base.Union_over_unary_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_unary_function(bool async)
    {
        await base.Union_over_unary_function(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_unary_constant(bool async)
    {
        await base.Union_over_unary_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_unary_unary(bool async)
    {
        await base.Union_over_unary_unary(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_unary_binary(bool async)
    {
        await base.Union_over_unary_binary(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_unary_scalarsubquery(bool async)
    {
        await base.Union_over_unary_scalarsubquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_scalarsubquery_column(bool async)
    {
        await base.Union_over_scalarsubquery_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_scalarsubquery_function(bool async)
    {
        await base.Union_over_scalarsubquery_function(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_scalarsubquery_constant(bool async)
    {
        await base.Union_over_scalarsubquery_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_scalarsubquery_unary(bool async)
    {
        await base.Union_over_scalarsubquery_unary(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_scalarsubquery_binary(bool async)
    {
        await base.Union_over_scalarsubquery_binary(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_scalarsubquery_scalarsubquery(bool async)
    {
        await base.Union_over_scalarsubquery_scalarsubquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_OrderBy_Take1(bool async)
    {
        await base.Union_over_OrderBy_Take1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_OrderBy_without_Skip_Take1(bool async)
    {
        await base.Union_over_OrderBy_without_Skip_Take1(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_OrderBy_Take2(bool async)
    {
        await base.Union_over_OrderBy_Take2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_OrderBy_without_Skip_Take2(bool async)
    {
        await base.Union_over_OrderBy_without_Skip_Take2(async);
    }
}
