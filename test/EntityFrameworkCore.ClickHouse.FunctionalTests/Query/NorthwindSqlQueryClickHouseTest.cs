using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Data.Common;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindSqlQueryClickHouseTest : NorthwindSqlQueryTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindSqlQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }

    protected override DbParameter CreateDbParameter(string name, object value)
    {
        throw new System.NotImplementedException();
    }
}
