using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class UInt128DbFunctionsExtensionsClickHouseTest : IClassFixture<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public UInt128DbFunctionsExtensionsClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task ToUInt128_conversion()
    {
        var context = CreateContext();
        
        await context.Products
            .Where(e => e.ProductID == 16)
            .Select(e => new
            {
                ToUInt128 = EF.Functions.ToUInt128(e.UnitsInStock),
                ToUInt128OrZero = EF.Functions.ToUInt128OrZero(e.ProductName),
                ToUInt128OrNull = EF.Functions.ToUInt128OrNull(e.ProductName),
                ToUInt128OrDefault_NoDefault = EF.Functions.ToUInt128OrDefault(e.ProductName),
                ToUInt128OrDefault_WithDefault = EF.Functions.ToUInt128OrDefault(e.ProductName, 5)
            })
            .ToListAsync();

        AssertSql(
            """
            SELECT toUInt128("p"."UnitsInStock") AS "ToUInt128", toUInt128OrZero("p"."ProductName") AS "ToUInt128OrZero", toUInt128OrNull("p"."ProductName") AS "ToUInt128OrNull", toUInt128OrDefault("p"."ProductName") AS "ToUInt128OrDefault_NoDefault", toUInt128OrDefault("p"."ProductName", toUInt128(5)) AS "ToUInt128OrDefault_WithDefault"
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
