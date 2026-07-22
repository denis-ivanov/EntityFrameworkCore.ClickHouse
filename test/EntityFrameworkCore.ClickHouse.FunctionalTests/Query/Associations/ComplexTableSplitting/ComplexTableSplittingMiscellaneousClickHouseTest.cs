using Microsoft.EntityFrameworkCore.Query.Associations.ComplexTableSplitting;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexTableSplitting;

public class ComplexTableSplittingMiscellaneousClickHouseTest : ComplexTableSplittingMiscellaneousRelationalTestBase<ComplexTableSplittingClickHouseFixture>
{
    public ComplexTableSplittingMiscellaneousClickHouseTest(ComplexTableSplittingClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromSql_on_root() => base.FromSql_on_root();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_property_on_non_nullable_value_type() => base.Where_property_on_non_nullable_value_type();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_property_on_nullable_value_type_Value() => base.Where_property_on_nullable_value_type_Value();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_HasValue_on_nullable_value_type() => base.Where_HasValue_on_nullable_value_type();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_on_associate_scalar_property() => base.Where_on_associate_scalar_property();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_on_optional_associate_scalar_property() => base.Where_on_optional_associate_scalar_property();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Where_on_nested_associate_scalar_property() => base.Where_on_nested_associate_scalar_property();
}