using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class WarningsClickHouseTest : WarningsTestBase<QueryNoClientEvalClickHouseFixture>
{
    public WarningsClickHouseTest(QueryNoClientEvalClickHouseFixture fixture) : base(fixture)
    {
    }
}
