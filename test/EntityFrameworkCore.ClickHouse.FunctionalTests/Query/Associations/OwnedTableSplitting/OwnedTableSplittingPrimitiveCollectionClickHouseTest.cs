using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Associations.OwnedTableSplitting;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.OwnedTableSplitting;

public class OwnedTableSplittingPrimitiveCollectionClickHouseTest : OwnedTableSplittingPrimitiveCollectionRelationalTestBase<OwnedTableSplittingClickHouseFixture>
{
    public OwnedTableSplittingPrimitiveCollectionClickHouseTest(OwnedTableSplittingClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Any_predicate()
    {
        return base.Any_predicate();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains()
    {
        return base.Contains();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Count()
    {
        return base.Count();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index()
    {
        return base.Index();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_Count()
    {
        return base.Nested_Count();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_Sum()
    {
        return base.Select_Sum();
    }
}