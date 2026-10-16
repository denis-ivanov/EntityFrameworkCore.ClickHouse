using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonStructuralEqualityClickHouseTest : ComplexJsonStructuralEqualityRelationalTestBase<ComplexJsonClickHouseFixture>
{
    public ComplexJsonStructuralEqualityClickHouseTest(ComplexJsonClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Associate_with_inline_null()
    {
        await base.Associate_with_inline_null();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Associate_with_parameter_null()
    {
        await base.Associate_with_parameter_null();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_with_inline()
    {
        await base.Contains_with_inline();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains_with_nested_and_composed_operators()
    {
        return base.Contains_with_nested_and_composed_operators();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_with_operators_composed_on_the_collection()
    {
        await base.Contains_with_operators_composed_on_the_collection();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_with_parameter()
    {
        await base.Contains_with_parameter();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nested_associate_with_inline_null()
    {
        await base.Nested_associate_with_inline_null();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nested_associate_with_inline()
    {
        await base.Nested_associate_with_inline();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nested_associate_with_parameter()
    {
        await base.Nested_associate_with_parameter();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nested_collection_with_inline()
    {
        await base.Nested_collection_with_inline();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nested_collection_with_parameter()
    {
        await base.Nested_collection_with_parameter();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Not_equals()
    {
        await base.Not_equals();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nullable_value_type_with_null()
    {
        await base.Nullable_value_type_with_null();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Two_associates()
    {
        await base.Two_associates();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Two_nested_associates()
    {
        await base.Two_nested_associates();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Two_nested_collections()
    {
        await base.Two_nested_collections();
    }
}
