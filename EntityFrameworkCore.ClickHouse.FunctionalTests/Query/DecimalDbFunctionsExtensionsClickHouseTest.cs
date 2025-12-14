using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class DecimalDbFunctionsExtensionsClickHouseTest : IClassFixture<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public DecimalDbFunctionsExtensionsClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task Decimal_conversions()
    {
        var context = CreateContext();
        
        await context.Products
            .Where(e => e.ProductID == 16)
            .Select(e => new
            {
                ToDecimal32Num = EF.Functions.ToDecimal32(e.UnitsInStock, 2),
                // TODO ToDecimal32Str = EF.Functions.ToDecimal32("1.5", 2)
                ToDecimal32OrZero = EF.Functions.ToDecimal32OrZero(e.ProductName, 2),
                ToDecimal32OrNull = EF.Functions.ToDecimal32OrNull(e.ProductName, 2),
                ToDecimal32OrDefault = EF.Functions.ToDecimal32OrDefault(e.ProductName, 2),
                ToDecimal32OrDefaultWithDefault = EF.Functions.ToDecimal32OrDefault(e.ProductName, 2, 42),
                
                ToDecimal64Num = EF.Functions.ToDecimal64(e.UnitsInStock, 2),
                // TODO ToDecimal64Str = EF.Functions.ToDecimal64("1.5", 2)
                ToDecimal64OrZero = EF.Functions.ToDecimal64OrZero(e.ProductName, 2),
                ToDecimal64OrNull = EF.Functions.ToDecimal64OrNull(e.ProductName, 2),
                ToDecimal64OrDefault = EF.Functions.ToDecimal64OrDefault(e.ProductName, 2),
                ToDecimal64OrDefaultWithDefault = EF.Functions.ToDecimal64OrDefault(e.ProductName, 2, 42),
                
                ToDecimal128Num = EF.Functions.ToDecimal128(e.UnitsInStock, 2),
                // TODO ToDecimal128Str = EF.Functions.ToDecimal128("1.5", 2)
                ToDecimal128OrZero = EF.Functions.ToDecimal128OrZero(e.ProductName, 2),
                ToDecimal128OrNull = EF.Functions.ToDecimal128OrNull(e.ProductName, 2),
                ToDecimal128OrDefault = EF.Functions.ToDecimal128OrDefault(e.ProductName, 2),
                ToDecimal128OrDefaultWithDefault = EF.Functions.ToDecimal128OrDefault(e.ProductName, 2, 42),
                
                ToDecimal256Num = EF.Functions.ToDecimal256(e.UnitsInStock, 2),
                // TODO ToDecimal256Str = EF.Functions.ToDecimal256("1.5", 2)
                ToDecimal256OrZero = EF.Functions.ToDecimal256OrZero(e.ProductName, 2),
                ToDecimal256OrNull = EF.Functions.ToDecimal256OrNull(e.ProductName, 2),
                ToDecimal256OrDefault = EF.Functions.ToDecimal256OrDefault(e.ProductName, 2),
                ToDecimal256OrDefaultWithDefault = EF.Functions.ToDecimal256OrDefault(e.ProductName, 2, 42),
            })
            .ToListAsync();

        AssertSql(
            """
            SELECT toDecimal32("p"."UnitsInStock", 2) AS "ToDecimal32Num", toDecimal32OrZero("p"."ProductName", 2) AS "ToDecimal32OrZero", toDecimal32OrNull("p"."ProductName", 2) AS "ToDecimal32OrNull", toDecimal32OrDefault("p"."ProductName", 2) AS "ToDecimal32OrDefault", toDecimal32OrDefault("p"."ProductName", 2, toDecimal32(42, 2)) AS "ToDecimal32OrDefaultWithDefault", toDecimal64("p"."UnitsInStock", 2) AS "ToDecimal64Num", toDecimal64OrZero("p"."ProductName", 2) AS "ToDecimal64OrZero", toDecimal64OrNull("p"."ProductName", 2) AS "ToDecimal64OrNull", toDecimal64OrDefault("p"."ProductName", 2) AS "ToDecimal64OrDefault", toDecimal64OrDefault("p"."ProductName", 2, toDecimal64(42, 2)) AS "ToDecimal64OrDefaultWithDefault", toDecimal128("p"."UnitsInStock", 2) AS "ToDecimal128Num", toDecimal128OrZero("p"."ProductName", 2) AS "ToDecimal128OrZero", toDecimal128OrNull("p"."ProductName", 2) AS "ToDecimal128OrNull", toDecimal128OrDefault("p"."ProductName", 2) AS "ToDecimal128OrDefault", toDecimal128OrDefault("p"."ProductName", 2, toDecimal128(42, 2)) AS "ToDecimal128OrDefaultWithDefault", toDecimal256("p"."UnitsInStock", 2) AS "ToDecimal256Num", toDecimal256OrZero("p"."ProductName", 2) AS "ToDecimal256OrZero", toDecimal256OrNull("p"."ProductName", 2) AS "ToDecimal256OrNull", toDecimal256OrDefault("p"."ProductName", 2) AS "ToDecimal256OrDefault", toDecimal256OrDefault("p"."ProductName", 2, toDecimal256(42, 2)) AS "ToDecimal256OrDefaultWithDefault"
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
