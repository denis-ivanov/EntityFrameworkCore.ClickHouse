using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonPrimitiveCollectionClickHouseTest : ComplexJsonPrimitiveCollectionRelationalTestBase<ComplexJsonClickHouseFixture>
{
    public ComplexJsonPrimitiveCollectionClickHouseTest(ComplexJsonClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Any_predicate()
    {
        await base.Any_predicate();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains()
    {
        await base.Contains();
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
