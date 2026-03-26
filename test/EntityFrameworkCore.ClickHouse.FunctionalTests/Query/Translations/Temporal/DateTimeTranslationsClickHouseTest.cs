using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Translations.Temporal;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Temporal;

public class DateTimeTranslationsClickHouseTest : DateTimeTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public DateTimeTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Hour() => base.Hour();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task New_with_parameters() => base.New_with_parameters();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task UtcNow() => base.UtcNow();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task subtract_and_TotalDays() => base.subtract_and_TotalDays();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task DayOfYear() => base.DayOfYear();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Month() => base.Month();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Today() => base.Today();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Parse_with_parameter() => base.Parse_with_parameter();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Minute() => base.Minute();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Date() => base.Date();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Year() => base.Year();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddYear() => base.AddYear();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task TimeOfDay() => base.TimeOfDay();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Millisecond() => base.Millisecond();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task New_with_constant() => base.New_with_constant();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Day() => base.Day();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Second() => base.Second();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Parse_with_constant() => base.Parse_with_constant();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Now() => base.Now();
}