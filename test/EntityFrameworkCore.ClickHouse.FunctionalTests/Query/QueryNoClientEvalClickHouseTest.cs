using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class QueryNoClientEvalClickHouseTest : QueryNoClientEvalTestBase<QueryNoClientEvalClickHouseFixture>
{
    public QueryNoClientEvalClickHouseTest(QueryNoClientEvalClickHouseFixture fixture) : base(fixture)
    {
    }
}
