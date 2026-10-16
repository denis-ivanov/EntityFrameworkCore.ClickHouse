using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Translations.Temporal;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Temporal;

public class DateOnlyTranslationsClickHouseTest : DateOnlyTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public DateOnlyTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddDays() => base.AddDays();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddYears() => base.AddYears();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task DayOfWeek() => base.DayOfWeek();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Day() => base.Day();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task ToDateTime_with_complex_DateTime() => base.ToDateTime_with_complex_DateTime();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task ToDateTime_property_with_constant_TimeOnly() => base.ToDateTime_property_with_constant_TimeOnly();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Month() => base.Month();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddMonths() => base.AddMonths();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task ToDateTime_with_complex_TimeOnly() => base.ToDateTime_with_complex_TimeOnly();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Year() => base.Year();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task ToDateTime_constant_DateTime_with_property_TimeOnly() => base.ToDateTime_constant_DateTime_with_property_TimeOnly();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task DayNumber_subtraction() => base.DayNumber_subtraction();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task DayOfYear() => base.DayOfYear();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_property() => base.FromDateTime_compared_to_property();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_constant_and_parameter() => base.FromDateTime_compared_to_constant_and_parameter();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task ToDateTime_property_with_property_TimeOnly() => base.ToDateTime_property_with_property_TimeOnly();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task DayNumber() => base.DayNumber();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromDateTime() => base.FromDateTime();
}