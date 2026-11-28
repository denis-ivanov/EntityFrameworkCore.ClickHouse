using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Associations.OwnedTableSplitting;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.OwnedTableSplitting;

public class OwnedTableSplittingStructuralEqualityClickHouseTest : OwnedTableSplittingStructuralEqualityRelationalTestBase<OwnedTableSplittingClickHouseFixture>
{
    public OwnedTableSplittingStructuralEqualityClickHouseTest(OwnedTableSplittingClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Associate_with_inline_null()
    {
        return base.Associate_with_inline_null();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Associate_with_parameter_null()
    {
        return base.Associate_with_parameter_null();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_associate_with_inline_null()
    {
        return base.Nested_associate_with_inline_null();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Not_equals()
    {
        return base.Not_equals();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains_with_inline()
    {
        return base.Contains_with_inline();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains_with_parameter()
    {
        return base.Contains_with_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Two_associates()
    {
        return base.Two_associates();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_associate_with_inline()
    {
        return base.Nested_associate_with_inline();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_collection_with_parameter()
    {
        return base.Nested_collection_with_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_associate_with_parameter()
    {
        return base.Nested_associate_with_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains_with_nested_and_composed_operators()
    {
        return base.Contains_with_nested_and_composed_operators();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Two_nested_collections()
    {
        return base.Two_nested_collections();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Two_nested_associates()
    {
        return base.Two_nested_associates();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains_with_operators_composed_on_the_collection()
    {
        return base.Contains_with_operators_composed_on_the_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_collection_with_inline()
    {
        return base.Nested_collection_with_inline();
    }
}