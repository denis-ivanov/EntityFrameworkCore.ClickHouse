using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonCollectionClickHouseTest : ComplexJsonCollectionRelationalTestBase<ComplexJsonClickHouseFixture>
{
    public ComplexJsonCollectionClickHouseTest(ComplexJsonClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Count()
    {
        await base.Count();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distinct()
    {
        await base.Distinct();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distinct_over_projected_nested_collection()
    {
        await base.Distinct_over_projected_nested_collection();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distinct_over_projected_filtered_nested_collection()
    {
        await base.Distinct_over_projected_filtered_nested_collection();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distinct_projected(QueryTrackingBehavior queryTrackingBehavior)
    {
        await base.Distinct_projected(queryTrackingBehavior);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy()
    {
        await base.GroupBy();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Index_column()
    {
        await base.Index_column();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Index_constant()
    {
        await base.Index_constant();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Index_on_nested_collection()
    {
        await base.Index_on_nested_collection();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Index_out_of_bounds()
    {
        await base.Index_out_of_bounds();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Index_parameter()
    {
        await base.Index_parameter();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OrderBy_ElementAt()
    {
        await base.OrderBy_ElementAt();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_within_Select_within_Select_with_aggregates()
    {
        await base.Select_within_Select_within_Select_with_aggregates();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where()
    {
        await base.Where();
    }
}
