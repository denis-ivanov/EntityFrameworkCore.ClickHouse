using Microsoft.EntityFrameworkCore.Query.Translations;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations;

public class MathTranslationsClickHouseTest : MathTranslationsTestBase<BasicTypesQueryClickHouseFixture>
{
    public MathTranslationsClickHouseTest(BasicTypesQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }
}
