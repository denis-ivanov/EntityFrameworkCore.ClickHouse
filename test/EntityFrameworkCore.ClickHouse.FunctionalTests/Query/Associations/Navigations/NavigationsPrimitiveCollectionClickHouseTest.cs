using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.Navigations;

public class NavigationsPrimitiveCollectionClickHouseTest : NavigationsPrimitiveCollectionRelationalTestBase<NavigationsClickHouseFixture>
{
    public NavigationsPrimitiveCollectionClickHouseTest(NavigationsClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains() => base.Contains();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_Sum() => base.Select_Sum();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Count() => base.Count();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_Count() => base.Nested_Count();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Any_predicate() => base.Any_predicate();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index() => base.Index();
}