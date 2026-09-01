using Microsoft.EntityFrameworkCore.Query.Associations.OwnedJson;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.OwnedJson;

public class OwnedJsonBulkUpdateClickHouseTest : OwnedJsonBulkUpdateRelationalTestBase<OwnedJsonClickHouseFixture>
{
    public OwnedJsonBulkUpdateClickHouseTest(OwnedJsonClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_association() => base.Update_association();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_property_inside_association() => base.Update_property_inside_association();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Delete_association() => base.Delete_association();
}