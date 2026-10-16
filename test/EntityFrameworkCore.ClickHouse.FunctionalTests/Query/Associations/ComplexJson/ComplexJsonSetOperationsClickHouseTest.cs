using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonSetOperationsClickHouseTest : ComplexJsonSetOperationsRelationalTestBase<ComplexJsonClickHouseFixture>
{
    public ComplexJsonSetOperationsClickHouseTest(ComplexJsonClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Over_assocate_collection_Select_nested_with_aggregates_projected(QueryTrackingBehavior queryTrackingBehavior)
    {
        await base.Over_assocate_collection_Select_nested_with_aggregates_projected(queryTrackingBehavior);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Over_associate_collections()
    {
        await base.Over_associate_collections();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Over_nested_associate_collection()
    {
        await base.Over_nested_associate_collection();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Over_different_collection_properties()
    {
        await base.Over_different_collection_properties();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Over_associate_collection_projected(QueryTrackingBehavior queryTrackingBehavior)
    {
        await base.Over_associate_collection_projected(queryTrackingBehavior);
    }
}