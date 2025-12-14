using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class Int32DbFunctionsExtensionsClickHouseTest : IClassFixture<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public Int32DbFunctionsExtensionsClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task ToInt32_conversion()
    {
        var context = CreateContext();
        
        await context.Products
            .Where(e => e.ProductID == 16)
            .Select(e => new
            {
                ToInt32 = EF.Functions.ToInt32(e.UnitsInStock),
                ToInt32OrZero = EF.Functions.ToInt32OrZero(e.ProductName),
                ToInt32OrNull = EF.Functions.ToInt32OrNull(e.ProductName),
                ToInt32OrDefault_NoDefault = EF.Functions.ToInt32OrDefault(e.ProductName),
                ToInt32OrDefault_WithDefault = EF.Functions.ToInt32OrDefault(e.ProductName, 5)
            })
            .ToListAsync();

        AssertSql(
            """
            SELECT toInt32("p"."UnitsInStock") AS "ToInt32", toInt32OrZero("p"."ProductName") AS "ToInt32OrZero", toInt32OrNull("p"."ProductName") AS "ToInt32OrNull", toInt32OrDefault("p"."ProductName") AS "ToInt32OrDefault_NoDefault", toInt32OrDefault("p"."ProductName", toInt32(5)) AS "ToInt32OrDefault_WithDefault"
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
