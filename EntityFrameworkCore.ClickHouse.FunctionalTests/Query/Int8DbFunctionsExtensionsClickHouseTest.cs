using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class Int8DbFunctionsExtensionsClickHouseTest : IClassFixture<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public Int8DbFunctionsExtensionsClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task ToInt8_conversion()
    {
        var context = CreateContext();
        
        await context.Products
            .Where(e => e.ProductID == 16)
            .Select(e => new
            {
                ToInt8 = EF.Functions.ToInt8(e.UnitsInStock),
                ToInt8OrZero = EF.Functions.ToInt8OrZero(e.ProductName),
                ToInt8OrNull = EF.Functions.ToInt8OrNull(e.ProductName),
                ToInt8OrDefault_NoDefault = EF.Functions.ToInt8OrDefault(e.ProductName),
                ToInt8OrDefault_WithDefault = EF.Functions.ToInt8OrDefault(e.ProductName, 5)
            })
            .ToListAsync();

        AssertSql(
            """
            SELECT toInt8("p"."UnitsInStock") AS "ToInt8", toInt8OrZero("p"."ProductName") AS "ToInt8OrZero", toInt8OrNull("p"."ProductName") AS "ToInt8OrNull", toInt8OrDefault("p"."ProductName") AS "ToInt8OrDefault_NoDefault", toInt8OrDefault("p"."ProductName", toInt8(5)) AS "ToInt8OrDefault_WithDefault"
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
