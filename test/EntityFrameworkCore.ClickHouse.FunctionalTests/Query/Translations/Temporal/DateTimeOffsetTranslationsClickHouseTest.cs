using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Translations.Temporal;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Temporal;

public class DateTimeOffsetTranslationsClickHouseTest : DateTimeOffsetTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public DateTimeOffsetTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task UtcNow() => base.UtcNow();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Day() => base.Day();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Month() => base.Month();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task ToUnixTimeSecond() => base.ToUnixTimeSecond();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task ToUnixTimeMilliseconds() => base.ToUnixTimeMilliseconds();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task TimeOfDay() => base.TimeOfDay();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nanosecond() => base.Nanosecond();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Date() => base.Date();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Milliseconds_parameter_and_constant() => base.Milliseconds_parameter_and_constant();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Microsecond() => base.Microsecond();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Second() => base.Second();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddHours() => base.AddHours();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task DayOfYear() => base.DayOfYear();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Now() => base.Now();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Year() => base.Year();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Millisecond() => base.Millisecond();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Hour() => base.Hour();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddMinutes() => base.AddMinutes();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddMonths() => base.AddMonths();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddDays() => base.AddDays();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddYears() => base.AddYears();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddMilliseconds() => base.AddMilliseconds();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Minute() => base.Minute();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddSeconds() => base.AddSeconds();
}