using Microsoft.EntityFrameworkCore.Query.Translations.Operators;
using Microsoft.EntityFrameworkCore.TestUtilities;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Xunit;
using Xunit.Abstractions;
using System.Threading.Tasks;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Operators;

public class ComparisonOperatorTranslationsClickHouseTest : ComparisonOperatorTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public ComparisonOperatorTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Equal() => base.Equal();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task NotEqual() => base.NotEqual();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task GreaterThan() => base.GreaterThan();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task GreaterThanOrEqual() => base.GreaterThanOrEqual();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task LessThan() => base.LessThan();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task LessThanOrEqual() => base.LessThanOrEqual();
}