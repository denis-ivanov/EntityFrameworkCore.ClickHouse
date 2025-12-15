using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class UInt16DbFunctionsExtensionsClickHouseTest : IClassFixture<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public UInt16DbFunctionsExtensionsClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task ToUInt16_conversion()
    {
        var context = CreateContext();
        
        await context.Products
            .Where(e => e.ProductID == 16)
            .Select(e => new
            {
                ToUInt16 = EF.Functions.ToUInt16(e.UnitsInStock),
                ToUInt16OrZero = EF.Functions.ToUInt16OrZero(e.ProductName),
                ToUInt16OrNull = EF.Functions.ToUInt16OrNull(e.ProductName),
                ToUInt16OrDefault_NoDefault = EF.Functions.ToUInt16OrDefault(e.ProductName),
                ToUInt16OrDefault_WithDefault = EF.Functions.ToUInt16OrDefault(e.ProductName, 5)
            })
            .ToListAsync();

        AssertSql(
            """
            SELECT toUInt16("p"."UnitsInStock") AS "ToUInt16", toUInt16OrZero("p"."ProductName") AS "ToUInt16OrZero", toUInt16OrNull("p"."ProductName") AS "ToUInt16OrNull", toUInt16OrDefault("p"."ProductName") AS "ToUInt16OrDefault_NoDefault", toUInt16OrDefault("p"."ProductName", toUInt16(5)) AS "ToUInt16OrDefault_WithDefault"
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
