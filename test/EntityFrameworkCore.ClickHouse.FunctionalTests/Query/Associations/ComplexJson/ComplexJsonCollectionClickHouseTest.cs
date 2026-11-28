using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonCollectionClickHouseTest : ComplexJsonCollectionRelationalTestBase<ComplexJsonClickHouseFixture>
{
    public ComplexJsonCollectionClickHouseTest(ComplexJsonClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Count()
    {
        await base.Count();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distinct()
    {
        await base.Distinct();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distinct_over_projected_nested_collection()
    {
        await base.Distinct_over_projected_nested_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distinct_over_projected_filtered_nested_collection()
    {
        await base.Distinct_over_projected_filtered_nested_collection();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distinct_projected(QueryTrackingBehavior queryTrackingBehavior)
    {
        await base.Distinct_projected(queryTrackingBehavior);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy()
    {
        await base.GroupBy();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Index_column()
    {
        await base.Index_column();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Index_constant()
    {
        await base.Index_constant();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Index_on_nested_collection()
    {
        await base.Index_on_nested_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Index_out_of_bounds()
    {
        await base.Index_out_of_bounds();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Index_parameter()
    {
        await base.Index_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OrderBy_ElementAt()
    {
        await base.OrderBy_ElementAt();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_within_Select_within_Select_with_aggregates()
    {
        await base.Select_within_Select_within_Select_with_aggregates();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where()
    {
        await base.Where();
    }
}
