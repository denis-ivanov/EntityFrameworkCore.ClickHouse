using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.Navigations;

public class NavigationsSetOperationsClickHouseTest : NavigationsSetOperationsRelationalTestBase<NavigationsClickHouseFixture>
{
    public NavigationsSetOperationsClickHouseTest(NavigationsClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Over_associate_collection_projected(QueryTrackingBehavior queryTrackingBehavior) => base.Over_associate_collection_projected(queryTrackingBehavior);

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Over_associate_collections() => base.Over_associate_collections();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Over_different_collection_properties() => base.Over_different_collection_properties();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Over_nested_associate_collection() => base.Over_nested_associate_collection();

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Over_assocate_collection_Select_nested_with_aggregates_projected(QueryTrackingBehavior queryTrackingBehavior) => base.Over_assocate_collection_Select_nested_with_aggregates_projected(queryTrackingBehavior);
}