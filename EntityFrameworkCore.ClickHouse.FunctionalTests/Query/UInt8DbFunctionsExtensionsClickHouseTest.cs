using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class UInt8DbFunctionsExtensionsClickHouseTest : IClassFixture<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public UInt8DbFunctionsExtensionsClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task ToUInt8_conversion()
    {
        var context = CreateContext();
        
        await context.Products
            .Where(e => e.ProductID == 16)
            .Select(e => new
            {
                ToUInt8 = EF.Functions.ToUInt8(e.UnitsInStock),
                ToUInt8OrZero = EF.Functions.ToUInt8OrZero(e.ProductName),
                ToUInt8OrNull = EF.Functions.ToUInt8OrNull(e.ProductName),
                ToUInt8OrDefault_NoDefault = EF.Functions.ToUInt8OrDefault(e.ProductName),
                ToUInt8OrDefault_WithDefault = EF.Functions.ToUInt8OrDefault(e.ProductName, 5)
            })
            .ToListAsync();
        
        AssertSql(
            """
            SELECT toUInt8("p"."UnitsInStock") AS "ToUInt8", toUInt8OrZero("p"."ProductName") AS "ToUInt8OrZero", toUInt8OrNull("p"."ProductName") AS "ToUInt8OrNull", toUInt8OrDefault("p"."ProductName") AS "ToUInt8OrDefault_NoDefault", toUInt8OrDefault("p"."ProductName", toUInt8(5)) AS "ToUInt8OrDefault_WithDefault"
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
