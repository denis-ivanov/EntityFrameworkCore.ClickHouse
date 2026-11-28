using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Associations.OwnedTableSplitting;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.OwnedTableSplitting;

public class OwnedTableSplittingPrimitiveCollectionClickHouseTest : OwnedTableSplittingPrimitiveCollectionRelationalTestBase<OwnedTableSplittingClickHouseFixture>
{
    public OwnedTableSplittingPrimitiveCollectionClickHouseTest(OwnedTableSplittingClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Any_predicate()
    {
        return base.Any_predicate();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains()
    {
        return base.Contains();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Count()
    {
        return base.Count();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index()
    {
        return base.Index();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_Count()
    {
        return base.Nested_Count();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_Sum()
    {
        return base.Select_Sum();
    }
}