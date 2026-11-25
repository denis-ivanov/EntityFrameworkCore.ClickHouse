using Microsoft.EntityFrameworkCore.Query.Associations.OwnedNavigations;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.OwnedNavigations;

public class OwnedNavigationsStructuralEqualityClickHouseTest : OwnedNavigationsStructuralEqualityRelationalTestBase<OwnedNavigationsClickHouseFixture>
{
    public OwnedNavigationsStructuralEqualityClickHouseTest(OwnedNavigationsClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_collection_with_inline() => base.Nested_collection_with_inline();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Two_nested_associates() => base.Two_nested_associates();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_associate_with_inline() => base.Nested_associate_with_inline();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Two_nested_collections() => base.Two_nested_collections();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_associate_with_parameter() => base.Nested_associate_with_parameter();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains_with_inline() => base.Contains_with_inline();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_collection_with_parameter() => base.Nested_collection_with_parameter();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains_with_parameter() => base.Contains_with_parameter();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Associate_with_parameter_null() => base.Associate_with_parameter_null();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Associate_with_inline_null() => base.Associate_with_inline_null();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains_with_operators_composed_on_the_collection() => base.Contains_with_operators_composed_on_the_collection();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Not_equals() => base.Not_equals();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains_with_nested_and_composed_operators() => base.Contains_with_nested_and_composed_operators();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Two_associates() => base.Two_associates();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_associate_with_inline_null() => base.Nested_associate_with_inline_null();
}