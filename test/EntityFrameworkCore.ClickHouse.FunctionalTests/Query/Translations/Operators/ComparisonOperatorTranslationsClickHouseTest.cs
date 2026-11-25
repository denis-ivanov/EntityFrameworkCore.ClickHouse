using Microsoft.EntityFrameworkCore.Query.Translations.Operators;
using Microsoft.EntityFrameworkCore.TestUtilities;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Xunit;
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

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Equal() => base.Equal();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task NotEqual() => base.NotEqual();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task GreaterThan() => base.GreaterThan();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task GreaterThanOrEqual() => base.GreaterThanOrEqual();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task LessThan() => base.LessThan();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task LessThanOrEqual() => base.LessThanOrEqual();
}