using Microsoft.EntityFrameworkCore.Query.Associations.OwnedJson;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.OwnedJson;

public class OwnedJsonCollectionClickHouseTest : OwnedJsonCollectionRelationalTestBase<OwnedJsonClickHouseFixture>
{
    public OwnedJsonCollectionClickHouseTest(OwnedJsonClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index_on_nested_collection() => base.Index_on_nested_collection();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index_parameter() => base.Index_parameter();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Distinct_over_projected_filtered_nested_collection() => base.Distinct_over_projected_filtered_nested_collection();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index_column() => base.Index_column();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index_out_of_bounds() => base.Index_out_of_bounds();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where() => base.Where();

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Distinct_projected(QueryTrackingBehavior queryTrackingBehavior) => base.Distinct_projected(queryTrackingBehavior);

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task GroupBy() => base.GroupBy();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Distinct() => base.Distinct();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index_constant() => base.Index_constant();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task OrderBy_ElementAt() => base.OrderBy_ElementAt();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_within_Select_within_Select_with_aggregates() => base.Select_within_Select_within_Select_with_aggregates();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Count() => base.Count();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Distinct_over_projected_nested_collection() => base.Distinct_over_projected_nested_collection();
}