using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Translations.Temporal;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Temporal;

public class DateOnlyTranslationsClickHouseTest : DateOnlyTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public DateOnlyTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddDays() => base.AddDays();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddYears() => base.AddYears();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task DayOfWeek() => base.DayOfWeek();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Day() => base.Day();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task ToDateTime_with_complex_DateTime() => base.ToDateTime_with_complex_DateTime();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task ToDateTime_property_with_constant_TimeOnly() => base.ToDateTime_property_with_constant_TimeOnly();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Month() => base.Month();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddMonths() => base.AddMonths();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task ToDateTime_with_complex_TimeOnly() => base.ToDateTime_with_complex_TimeOnly();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Year() => base.Year();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task ToDateTime_constant_DateTime_with_property_TimeOnly() => base.ToDateTime_constant_DateTime_with_property_TimeOnly();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task DayNumber_subtraction() => base.DayNumber_subtraction();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task DayOfYear() => base.DayOfYear();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_property() => base.FromDateTime_compared_to_property();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_constant_and_parameter() => base.FromDateTime_compared_to_constant_and_parameter();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task ToDateTime_property_with_property_TimeOnly() => base.ToDateTime_property_with_property_TimeOnly();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task DayNumber() => base.DayNumber();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromDateTime() => base.FromDateTime();
}