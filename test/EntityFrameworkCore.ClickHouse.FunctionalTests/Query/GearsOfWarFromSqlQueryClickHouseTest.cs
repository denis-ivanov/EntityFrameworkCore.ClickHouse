using Microsoft.EntityFrameworkCore.Query;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class GearsOfWarFromSqlQueryClickHouseTest : GearsOfWarFromSqlQueryTestBase<GearsOfWarQueryClickHouseFixture>
{
    public GearsOfWarFromSqlQueryClickHouseTest(GearsOfWarQueryClickHouseFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void From_sql_queryable_simple_columns_out_of_order()
    {
        base.From_sql_queryable_simple_columns_out_of_order();
    }
}
