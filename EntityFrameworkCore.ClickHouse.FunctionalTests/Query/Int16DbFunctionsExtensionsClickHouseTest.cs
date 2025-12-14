using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class Int16DbFunctionsExtensionsClickHouseTest : IClassFixture<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public Int16DbFunctionsExtensionsClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task ToInt16_conversion()
    {
        var context = CreateContext();
        
        await context.Products
            .Where(e => e.ProductID == 16)
            .Select(e => new
            {
                ToInt16 = EF.Functions.ToInt16(e.UnitsInStock),
                ToInt16OrZero = EF.Functions.ToInt16OrZero(e.ProductName),
                ToInt16OrNull = EF.Functions.ToInt16OrNull(e.ProductName),
                ToInt16OrDefault_NoDefault = EF.Functions.ToInt16OrDefault(e.ProductName),
                ToInt16OrDefault_WithDefault = EF.Functions.ToInt16OrDefault(e.ProductName, 5)
            })
            .ToListAsync();

        AssertSql(
            """
            SELECT toInt16("p"."UnitsInStock") AS "ToInt16", toInt16OrZero("p"."ProductName") AS "ToInt16OrZero", toInt16OrNull("p"."ProductName") AS "ToInt16OrNull", toInt16OrDefault("p"."ProductName") AS "ToInt16OrDefault_NoDefault", toInt16OrDefault("p"."ProductName", toInt16(5)) AS "ToInt16OrDefault_WithDefault"
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
