using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Translations.Temporal;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Temporal;

public class DateTimeTranslationsClickHouseTest : DateTimeTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public DateTimeTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Hour() => base.Hour();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task New_with_parameters() => base.New_with_parameters();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task UtcNow() => base.UtcNow();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task subtract_and_TotalDays() => base.subtract_and_TotalDays();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task DayOfYear() => base.DayOfYear();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Month() => base.Month();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Today() => base.Today();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Parse_with_parameter() => base.Parse_with_parameter();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Minute() => base.Minute();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Date() => base.Date();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Year() => base.Year();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddYear() => base.AddYear();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task TimeOfDay() => base.TimeOfDay();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Millisecond() => base.Millisecond();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task New_with_constant() => base.New_with_constant();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Day() => base.Day();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Second() => base.Second();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Parse_with_constant() => base.Parse_with_constant();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Now() => base.Now();
}