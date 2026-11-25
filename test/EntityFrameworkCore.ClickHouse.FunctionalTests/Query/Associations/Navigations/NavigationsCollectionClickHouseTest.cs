using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.Navigations;

public class NavigationsCollectionClickHouseTest : NavigationsCollectionRelationalTestBase<NavigationsClickHouseFixture>
{
    public NavigationsCollectionClickHouseTest(NavigationsClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task OrderBy_ElementAt() => base.OrderBy_ElementAt();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index_constant() => base.Index_constant();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Distinct() => base.Distinct();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index_out_of_bounds() => base.Index_out_of_bounds();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index_on_nested_collection() => base.Index_on_nested_collection();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index_parameter() => base.Index_parameter();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Distinct_over_projected_nested_collection() => base.Distinct_over_projected_nested_collection();

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Distinct_projected(Microsoft.EntityFrameworkCore.QueryTrackingBehavior queryTrackingBehavior) => base.Distinct_projected(queryTrackingBehavior);

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Distinct_over_projected_filtered_nested_collection() => base.Distinct_over_projected_filtered_nested_collection();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where() => base.Where();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Count() => base.Count();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task GroupBy() => base.GroupBy();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index_column() => base.Index_column();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_within_Select_within_Select_with_aggregates() => base.Select_within_Select_within_Select_with_aggregates();
}