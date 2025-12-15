using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class UInt32DbFunctionsExtensionsClickHouseTest : IClassFixture<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public UInt32DbFunctionsExtensionsClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task ToUInt32_conversion()
    {
        var context = CreateContext();
        
        await context.Products
            .Where(e => e.ProductID == 16)
            .Select(e => new
            {
                ToUInt32 = EF.Functions.ToUInt32(e.UnitsInStock),
                ToUInt32OrZero = EF.Functions.ToUInt32OrZero(e.ProductName),
                ToUInt32OrNull = EF.Functions.ToUInt32OrNull(e.ProductName),
                ToUInt32OrDefault_NoDefault = EF.Functions.ToUInt32OrDefault(e.ProductName),
                ToUInt32OrDefault_WithDefault = EF.Functions.ToUInt32OrDefault(e.ProductName, 5)
            })
            .ToListAsync();

        AssertSql(
            """
            SELECT toUInt32("p"."UnitsInStock") AS "ToUInt32", toUInt32OrZero("p"."ProductName") AS "ToUInt32OrZero", toUInt32OrNull("p"."ProductName") AS "ToUInt32OrNull", toUInt32OrDefault("p"."ProductName") AS "ToUInt32OrDefault_NoDefault", toUInt32OrDefault("p"."ProductName", toUInt32(5)) AS "ToUInt32OrDefault_WithDefault"
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
