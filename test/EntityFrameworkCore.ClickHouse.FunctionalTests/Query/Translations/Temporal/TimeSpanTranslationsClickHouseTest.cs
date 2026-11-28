using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Translations.Temporal;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Temporal;

public class TimeSpanTranslationsClickHouseTest : TimeSpanTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public TimeSpanTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Milliseconds() => base.Milliseconds();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Minutes() => base.Minutes();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Microseconds() => base.Microseconds();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Seconds() => base.Seconds();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Hours() => base.Hours();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nanoseconds() => base.Nanoseconds();
}