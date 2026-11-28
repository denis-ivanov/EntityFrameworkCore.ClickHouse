using Microsoft.EntityFrameworkCore.Query.Translations.Operators;
using Microsoft.EntityFrameworkCore.TestUtilities;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Xunit;
using System.Threading.Tasks;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Operators;

public class ArithmeticOperatorTranslationsClickHouseTest : ArithmeticOperatorTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public ArithmeticOperatorTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Add() => base.Add();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Subtract() => base.Subtract();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Multiply() => base.Multiply();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Minus() => base.Minus();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Modulo() => base.Modulo();
}