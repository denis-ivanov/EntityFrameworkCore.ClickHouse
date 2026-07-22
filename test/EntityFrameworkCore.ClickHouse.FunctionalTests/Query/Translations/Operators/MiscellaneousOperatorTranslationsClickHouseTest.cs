using Microsoft.EntityFrameworkCore.Query.Translations.Operators;
using Microsoft.EntityFrameworkCore.TestUtilities;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Xunit;
using Xunit.Abstractions;
using System.Threading.Tasks;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations.Operators;

public class MiscellaneousOperatorTranslationsClickHouseTest : MiscellaneousOperatorTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public MiscellaneousOperatorTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Conditional() => base.Conditional();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Coalesce() => base.Coalesce();
}
