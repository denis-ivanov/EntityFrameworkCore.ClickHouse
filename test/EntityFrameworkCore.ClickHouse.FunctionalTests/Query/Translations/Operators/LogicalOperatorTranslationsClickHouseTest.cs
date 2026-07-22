using Microsoft.EntityFrameworkCore.Query.Translations.Operators;
using Microsoft.EntityFrameworkCore.TestUtilities;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Xunit;
using Xunit.Abstractions;
using System.Threading.Tasks;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Operators;

public class LogicalOperatorTranslationsClickHouseTest : LogicalOperatorTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public LogicalOperatorTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task And() => base.And();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Or() => base.Or();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Not() => base.Not();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task And_with_bool_property() => base.And_with_bool_property();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Or_with_bool_property() => base.Or_with_bool_property();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Not_with_bool_property() => base.Not_with_bool_property();
}