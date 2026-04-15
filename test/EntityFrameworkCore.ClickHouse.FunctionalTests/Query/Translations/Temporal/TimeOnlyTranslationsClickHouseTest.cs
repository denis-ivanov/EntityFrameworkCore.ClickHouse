using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Translations.Temporal;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Temporal;

public class TimeOnlyTranslationsClickHouseTest : TimeOnlyTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public TimeOnlyTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Nanosecond() => base.Nanosecond();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_property() => base.FromDateTime_compared_to_property();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Add_TimeSpan() => base.Add_TimeSpan();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Microsecond() => base.Microsecond();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Hour() => base.Hour();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Subtract() => base.Subtract();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromTimeSpan_compared_to_property() => base.FromTimeSpan_compared_to_property();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Minute() => base.Minute();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Order_by_FromTimeSpan() => base.Order_by_FromTimeSpan();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_parameter() => base.FromDateTime_compared_to_parameter();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Millisecond() => base.Millisecond();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromTimeSpan_compared_to_parameter() => base.FromTimeSpan_compared_to_parameter();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task IsBetween() => base.IsBetween();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Second() => base.Second();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task FromDateTime_compared_to_constant() => base.FromDateTime_compared_to_constant();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddMinutes() => base.AddMinutes();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task AddHours() => base.AddHours();
}