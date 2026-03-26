using Microsoft.EntityFrameworkCore.Query.Translations.Operators;
using Microsoft.EntityFrameworkCore.TestUtilities;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Xunit;
using Xunit.Abstractions;
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

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Add() => base.Add();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Subtract() => base.Subtract();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Multiply() => base.Multiply();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Minus() => base.Minus();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Modulo() => base.Modulo();
}