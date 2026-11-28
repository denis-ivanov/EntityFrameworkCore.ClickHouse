using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Translations.Temporal;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Temporal;

public class TimeOnlyTranslationsClickHouseTest : TimeOnlyTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public TimeOnlyTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nanosecond() => base.Nanosecond();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_property() => base.FromDateTime_compared_to_property();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Add_TimeSpan() => base.Add_TimeSpan();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Microsecond() => base.Microsecond();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Hour() => base.Hour();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Subtract() => base.Subtract();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromTimeSpan_compared_to_property() => base.FromTimeSpan_compared_to_property();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Minute() => base.Minute();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Order_by_FromTimeSpan() => base.Order_by_FromTimeSpan();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_parameter() => base.FromDateTime_compared_to_parameter();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Millisecond() => base.Millisecond();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromTimeSpan_compared_to_parameter() => base.FromTimeSpan_compared_to_parameter();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task IsBetween() => base.IsBetween();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Second() => base.Second();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_constant() => base.FromDateTime_compared_to_constant();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddMinutes() => base.AddMinutes();

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddHours() => base.AddHours();
}