using Microsoft.EntityFrameworkCore.Query.Associations.OwnedJson;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.OwnedJson;

public class OwnedJsonMiscellaneousClickHouseTest : OwnedJsonMiscellaneousRelationalTestBase<OwnedJsonClickHouseFixture>
{
    public OwnedJsonMiscellaneousClickHouseTest(OwnedJsonClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_on_associate_scalar_property() => base.Where_on_associate_scalar_property();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromSql_on_root() => base.FromSql_on_root();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_on_optional_associate_scalar_property() => base.Where_on_optional_associate_scalar_property();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_on_nested_associate_scalar_property() => base.Where_on_nested_associate_scalar_property();
}