using Microsoft.EntityFrameworkCore.Query.Associations.ComplexTableSplitting;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexTableSplitting;

public class ComplexTableSplittingPrimitiveCollectionClickHouseTest : ComplexTableSplittingPrimitiveCollectionRelationalTestBase<ComplexTableSplittingClickHouseFixture>
{
    public ComplexTableSplittingPrimitiveCollectionClickHouseTest(ComplexTableSplittingClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Count() => base.Count();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index() => base.Index();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains() => base.Contains();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Any_predicate() => base.Any_predicate();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_Count() => base.Nested_Count();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_Sum() => base.Select_Sum();
}