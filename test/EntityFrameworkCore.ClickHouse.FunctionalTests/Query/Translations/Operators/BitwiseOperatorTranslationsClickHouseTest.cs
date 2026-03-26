using Microsoft.EntityFrameworkCore.Query.Translations.Operators;
using Microsoft.EntityFrameworkCore.TestUtilities;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Xunit;
using Xunit.Abstractions;
using System.Threading.Tasks;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Operators;

public class BitwiseOperatorTranslationsClickHouseTest : BitwiseOperatorTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public BitwiseOperatorTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task And() => base.And();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Or() => base.Or();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Xor() => base.Xor();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Complement() => base.Complement();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Left_shift() => base.Left_shift();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Right_shift() => base.Right_shift();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Or_multiple() => base.Or_multiple();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task And_over_boolean() => base.And_over_boolean();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Or_over_boolean() => base.Or_over_boolean();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Xor_over_boolean() => base.Xor_over_boolean();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task And_or_over_boolean() => base.And_or_over_boolean();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task And_with_logical_and() => base.And_with_logical_and();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task And_with_logical_or() => base.And_with_logical_or();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Or_with_logical_and() => base.Or_with_logical_and();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Or_with_logical_or() => base.Or_with_logical_or();
}