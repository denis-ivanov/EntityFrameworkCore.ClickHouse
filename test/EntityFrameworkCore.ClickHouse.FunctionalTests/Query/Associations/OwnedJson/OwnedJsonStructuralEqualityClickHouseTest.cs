using Microsoft.EntityFrameworkCore.Query.Associations.OwnedJson;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.OwnedJson;

public class OwnedJsonStructuralEqualityClickHouseTest : OwnedJsonStructuralEqualityRelationalTestBase<OwnedJsonClickHouseFixture>
{
    public OwnedJsonStructuralEqualityClickHouseTest(OwnedJsonClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Two_associates() => base.Two_associates();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_associate_with_parameter() => base.Nested_associate_with_parameter();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains_with_parameter() => base.Contains_with_parameter();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains_with_operators_composed_on_the_collection() => base.Contains_with_operators_composed_on_the_collection();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_collection_with_parameter() => base.Nested_collection_with_parameter();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Associate_with_parameter_null() => base.Associate_with_parameter_null();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Not_equals() => base.Not_equals();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_associate_with_inline() => base.Nested_associate_with_inline();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Associate_with_inline_null() => base.Associate_with_inline_null();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Two_nested_associates() => base.Two_nested_associates();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_associate_with_inline_null() => base.Nested_associate_with_inline_null();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nested_collection_with_inline() => base.Nested_collection_with_inline();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains_with_nested_and_composed_operators() => base.Contains_with_nested_and_composed_operators();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Two_nested_collections() => base.Two_nested_collections();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Contains_with_inline() => base.Contains_with_inline();
}