using Microsoft.EntityFrameworkCore.Query.Translations.Operators;
using Microsoft.EntityFrameworkCore.TestUtilities;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Xunit;
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

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task And() => base.And();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Or() => base.Or();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Xor() => base.Xor();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Complement() => base.Complement();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Left_shift() => base.Left_shift();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Right_shift() => base.Right_shift();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Or_multiple() => base.Or_multiple();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task And_over_boolean() => base.And_over_boolean();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Or_over_boolean() => base.Or_over_boolean();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Xor_over_boolean() => base.Xor_over_boolean();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task And_or_over_boolean() => base.And_or_over_boolean();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task And_with_logical_and() => base.And_with_logical_and();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task And_with_logical_or() => base.And_with_logical_or();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Or_with_logical_and() => base.Or_with_logical_and();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Or_with_logical_or() => base.Or_with_logical_or();
}