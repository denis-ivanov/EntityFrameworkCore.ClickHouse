using Microsoft.EntityFrameworkCore.Query.Associations.OwnedNavigations;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.OwnedNavigations;

public class OwnedNavigationsPrimitiveCollectionClickHouseTest : OwnedNavigationsPrimitiveCollectionRelationalTestBase<OwnedNavigationsClickHouseFixture>
{
    public OwnedNavigationsPrimitiveCollectionClickHouseTest(OwnedNavigationsClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Any_predicate() => base.Any_predicate();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Index() => base.Index();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Count() => base.Count();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Select_Sum() => base.Select_Sum();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains() => base.Contains();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_Count() => base.Nested_Count();
}