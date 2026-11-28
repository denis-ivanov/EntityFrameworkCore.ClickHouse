using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonSetOperationsClickHouseTest : ComplexJsonSetOperationsRelationalTestBase<ComplexJsonClickHouseFixture>
{
    public ComplexJsonSetOperationsClickHouseTest(ComplexJsonClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Over_assocate_collection_Select_nested_with_aggregates_projected(QueryTrackingBehavior queryTrackingBehavior)
    {
        await base.Over_assocate_collection_Select_nested_with_aggregates_projected(queryTrackingBehavior);
    }

#if NET10_0
    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
#else
    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
#endif
    public override async Task Over_associate_collections()
    {
        await base.Over_associate_collections();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Over_nested_associate_collection()
    {
        await base.Over_nested_associate_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Over_different_collection_properties()
    {
        await base.Over_different_collection_properties();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Over_associate_collection_projected(QueryTrackingBehavior queryTrackingBehavior)
    {
        await base.Over_associate_collection_projected(queryTrackingBehavior);
    }
}