using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Translations.Temporal;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Temporal;

public class TimeSpanTranslationsClickHouseTest : TimeSpanTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public TimeSpanTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Milliseconds() => base.Milliseconds();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Minutes() => base.Minutes();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Microseconds() => base.Microseconds();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Seconds() => base.Seconds();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Hours() => base.Hours();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nanoseconds() => base.Nanoseconds();
}