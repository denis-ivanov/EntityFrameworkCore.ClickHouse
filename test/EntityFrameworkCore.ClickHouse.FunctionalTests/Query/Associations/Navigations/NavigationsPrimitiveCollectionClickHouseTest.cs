using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.Navigations;

public class NavigationsPrimitiveCollectionClickHouseTest : NavigationsPrimitiveCollectionRelationalTestBase<NavigationsClickHouseFixture>
{
    public NavigationsPrimitiveCollectionClickHouseTest(NavigationsClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains() => base.Contains();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_Sum() => base.Select_Sum();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Count() => base.Count();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_Count() => base.Nested_Count();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Any_predicate() => base.Any_predicate();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index() => base.Index();
}