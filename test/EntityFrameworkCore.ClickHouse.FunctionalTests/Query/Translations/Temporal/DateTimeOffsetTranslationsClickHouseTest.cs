using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Translations.Temporal;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Temporal;

public class DateTimeOffsetTranslationsClickHouseTest : DateTimeOffsetTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public DateTimeOffsetTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task UtcNow() => base.UtcNow();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Day() => base.Day();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Month() => base.Month();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task ToUnixTimeSecond() => base.ToUnixTimeSecond();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task ToUnixTimeMilliseconds() => base.ToUnixTimeMilliseconds();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task TimeOfDay() => base.TimeOfDay();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nanosecond() => base.Nanosecond();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Date() => base.Date();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Milliseconds_parameter_and_constant() => base.Milliseconds_parameter_and_constant();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Microsecond() => base.Microsecond();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Second() => base.Second();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddHours() => base.AddHours();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task DayOfYear() => base.DayOfYear();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Now() => base.Now();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Year() => base.Year();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Millisecond() => base.Millisecond();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Hour() => base.Hour();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddMinutes() => base.AddMinutes();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddMonths() => base.AddMonths();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddDays() => base.AddDays();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddYears() => base.AddYears();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddMilliseconds() => base.AddMilliseconds();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Minute() => base.Minute();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddSeconds() => base.AddSeconds();
}