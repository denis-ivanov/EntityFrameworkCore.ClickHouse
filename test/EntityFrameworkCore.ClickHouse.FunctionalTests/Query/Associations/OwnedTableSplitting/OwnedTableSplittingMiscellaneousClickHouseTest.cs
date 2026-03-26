using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Associations.OwnedTableSplitting;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.OwnedTableSplitting;

public class OwnedTableSplittingMiscellaneousClickHouseTest : OwnedTableSplittingMiscellaneousRelationalTestBase<OwnedTableSplittingClickHouseFixture>
{
    public OwnedTableSplittingMiscellaneousClickHouseTest(OwnedTableSplittingClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromSql_on_root()
    {
        return base.FromSql_on_root();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_on_associate_scalar_property()
    {
        return base.Where_on_associate_scalar_property();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_on_nested_associate_scalar_property()
    {
        return base.Where_on_nested_associate_scalar_property();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_on_optional_associate_scalar_property()
    {
        return base.Where_on_optional_associate_scalar_property();
    }
}