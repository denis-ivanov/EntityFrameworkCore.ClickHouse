using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.Navigations;

public class NavigationsMiscellaneousClickHouseTest : NavigationsMiscellaneousRelationalTestBase<NavigationsClickHouseFixture>
{
    public NavigationsMiscellaneousClickHouseTest(NavigationsClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromSql_on_root() => base.FromSql_on_root();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_on_optional_associate_scalar_property() => base.Where_on_optional_associate_scalar_property();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_on_associate_scalar_property() => base.Where_on_associate_scalar_property();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_on_nested_associate_scalar_property() => base.Where_on_nested_associate_scalar_property();
}