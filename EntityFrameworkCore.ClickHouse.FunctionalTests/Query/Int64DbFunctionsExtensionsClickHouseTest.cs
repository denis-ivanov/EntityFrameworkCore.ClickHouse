using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class Int64DbFunctionsExtensionsClickHouseTest : IClassFixture<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public Int64DbFunctionsExtensionsClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task ToInt64_conversion()
    {
        var context = CreateContext();
        
        await context.Products
            .Where(e => e.ProductID == 16)
            .Select(e => new
            {
                ToInt64 = EF.Functions.ToInt64(e.UnitsInStock),
                ToInt64OrZero = EF.Functions.ToInt64OrZero(e.ProductName),
                ToInt64OrNull = EF.Functions.ToInt64OrNull(e.ProductName),
                ToInt64OrDefault_NoDefault = EF.Functions.ToInt64OrDefault(e.ProductName),
                ToInt64OrDefault_WithDefault = EF.Functions.ToInt64OrDefault(e.ProductName, 5)
            })
            .ToListAsync();

        AssertSql(
            """
            SELECT toInt64("p"."UnitsInStock") AS "ToInt64", toInt64OrZero("p"."ProductName") AS "ToInt64OrZero", toInt64OrNull("p"."ProductName") AS "ToInt64OrNull", toInt64OrDefault("p"."ProductName") AS "ToInt64OrDefault_NoDefault", toInt64OrDefault("p"."ProductName", toInt64(5)) AS "ToInt64OrDefault_WithDefault"
            FROM "Products" AS "p"
            WHERE "p"."ProductID" = 16
            """);
    }

    protected NorthwindQueryClickHouseFixture<NoopModelCustomizer> Fixture { get; }
    
    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);

    protected NorthwindContext CreateContext()
        => Fixture.CreateContext();
}
