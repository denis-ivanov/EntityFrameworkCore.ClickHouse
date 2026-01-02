using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class AggregateDbFunctionsExtensionsClickHouseTest : IClassFixture<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public AggregateDbFunctionsExtensionsClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task Any()
    {
        var context = CreateContext();
        
        await context.Customers
            .GroupBy(c => c.Country)
            .Select(g => new { Key = g.Key, AnyCity = EF.Functions.Any(g.Select(c => c.City)) })
            .ToListAsync();

        AssertSql(
            """
            SELECT "c"."Country" AS "Key", any("c"."City") AS "AnyCity"
            FROM "Customers" AS "c"
            GROUP BY "c"."Country"
            """);
    }

    [Fact]
    public async Task AnyRespectNulls()
    {
        var context = CreateContext();
        
        await context.Customers
            .GroupBy(c => c.Country)
            .Select(g => new { Key = g.Key, AnyRegion = EF.Functions.AnyRespectNulls(g.Select(c => c.Region)) })
            .ToListAsync();

        AssertSql(
            """
            SELECT "c"."Country" AS "Key", anyRespectNulls("c"."Region") AS "AnyRegion"
            FROM "Customers" AS "c"
            GROUP BY "c"."Country"
            """);
    }

    protected NorthwindQueryClickHouseFixture<NoopModelCustomizer> Fixture { get; }
    
    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);

    protected NorthwindContext CreateContext()
        => Fixture.CreateContext();
}
