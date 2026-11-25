using Humanizer;
using Microsoft.EntityFrameworkCore.Query.Associations.ComplexTableSplitting;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexTableSplitting;

public class ComplexTableSplittingStructuralEqualityClickHouseTest : ComplexTableSplittingStructuralEqualityRelationalTestBase<ComplexTableSplittingClickHouseFixture>
{
    public ComplexTableSplittingStructuralEqualityClickHouseTest(ComplexTableSplittingClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Associate_with_inline_null()
    {
        await base.Associate_with_inline_null();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Associate_with_parameter_null()
    {
        await base.Associate_with_parameter_null();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nested_associate_with_inline_null()
    {
        await base.Nested_associate_with_inline_null();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nested_associate_with_inline()
    {
        await base.Nested_associate_with_inline();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nested_associate_with_parameter()
    {
        await base.Nested_associate_with_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Not_equals()
    {
        await base.Not_equals();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nullable_value_type_with_null()
    {
        await base.Nullable_value_type_with_null();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Two_associates()
    {
        await base.Two_associates();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Two_nested_associates()
    {
        await base.Two_nested_associates();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_with_inline()
    {
        await base.Contains_with_inline();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_with_nested_and_composed_operators()
    {
        await base.Contains_with_nested_and_composed_operators();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_with_operators_composed_on_the_collection()
    {
        await base.Contains_with_operators_composed_on_the_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_with_parameter()
    {
        await base.Contains_with_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nested_collection_with_inline()
    {
        await base.Nested_collection_with_inline();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nested_collection_with_parameter()
    {
        await base.Nested_collection_with_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Two_nested_collections()
    {
        await base.Two_nested_collections();
    }
}
