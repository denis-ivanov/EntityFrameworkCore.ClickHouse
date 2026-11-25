using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonPrimitiveCollectionClickHouseTest : ComplexJsonPrimitiveCollectionRelationalTestBase<ComplexJsonClickHouseFixture>
{
    public ComplexJsonPrimitiveCollectionClickHouseTest(ComplexJsonClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Any_predicate()
    {
        await base.Any_predicate();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains()
    {
        await base.Contains();
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
