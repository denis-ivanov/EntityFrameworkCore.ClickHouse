using ClickHouse.Driver.ADO.Parameters;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Data.Common;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class SqlQueryClickHouseTest : SqlQueryTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public SqlQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    protected override DbParameter CreateDbParameter(string name, object value)
    {
        return new ClickHouseDbParameter { ParameterName = name, Value = value };
    }
}
