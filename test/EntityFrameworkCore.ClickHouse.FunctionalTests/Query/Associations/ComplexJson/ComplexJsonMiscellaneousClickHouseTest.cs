using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonMiscellaneousClickHouseTest : ComplexJsonMiscellaneousRelationalTestBase<ComplexJsonClickHouseFixture>
{
    public ComplexJsonMiscellaneousClickHouseTest(ComplexJsonClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_on_associate_scalar_property()
    {
        await base.Where_on_associate_scalar_property();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_on_nested_associate_scalar_property()
    {
        await base.Where_on_nested_associate_scalar_property();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_on_optional_associate_scalar_property()
    {
        await base.Where_on_optional_associate_scalar_property();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_on_root()
    {
        await base.FromSql_on_root();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_HasValue_on_nullable_value_type()
    {
        await base.Where_HasValue_on_nullable_value_type();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_property_on_non_nullable_value_type()
    {
        await base.Where_property_on_non_nullable_value_type();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_property_on_nullable_value_type_Value()
    {
        await base.Where_property_on_nullable_value_type_Value();
    }
}