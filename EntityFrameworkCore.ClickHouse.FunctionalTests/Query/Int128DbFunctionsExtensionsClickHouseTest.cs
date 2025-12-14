using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class Int128DbFunctionsExtensionsClickHouseTest : IClassFixture<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public Int128DbFunctionsExtensionsClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task ToInt128_conversion()
    {
        var context = CreateContext();
        
        await context.Products
            .Where(e => e.ProductID == 16)
            .Select(e => new
            {
                ToInt128 = EF.Functions.ToInt128(e.UnitsInStock),
                ToInt128OrZero = EF.Functions.ToInt128OrZero(e.ProductName),
                ToInt128OrNull = EF.Functions.ToInt128OrNull(e.ProductName),
                ToInt128OrDefault_NoDefault = EF.Functions.ToInt128OrDefault(e.ProductName),
                ToInt128OrDefault_WithDefault = EF.Functions.ToInt128OrDefault(e.ProductName, 5)
            })
            .ToListAsync();

        AssertSql(
            """
            SELECT toInt128("p"."UnitsInStock") AS "ToInt128", toInt128OrZero("p"."ProductName") AS "ToInt128OrZero", toInt128OrNull("p"."ProductName") AS "ToInt128OrNull", toInt128OrDefault("p"."ProductName") AS "ToInt128OrDefault_NoDefault", toInt128OrDefault("p"."ProductName", toInt128(5)) AS "ToInt128OrDefault_WithDefault"
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
