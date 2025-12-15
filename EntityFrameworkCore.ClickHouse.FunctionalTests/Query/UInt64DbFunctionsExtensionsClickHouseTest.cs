using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class UInt64DbFunctionsExtensionsClickHouseTest : IClassFixture<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public UInt64DbFunctionsExtensionsClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task ToUInt64_conversion()
    {
        var context = CreateContext();
        
        await context.Products
            .Where(e => e.ProductID == 16)
            .Select(e => new
            {
                ToUInt64 = EF.Functions.ToUInt64(e.UnitsInStock),
                ToUInt64OrZero = EF.Functions.ToUInt64OrZero(e.ProductName),
                ToUInt64OrNull = EF.Functions.ToUInt64OrNull(e.ProductName),
                ToUInt64OrDefault_NoDefault = EF.Functions.ToUInt64OrDefault(e.ProductName),
                ToUInt64OrDefault_WithDefault = EF.Functions.ToUInt64OrDefault(e.ProductName, 5)
            })
            .ToListAsync();

        AssertSql(
            """
            SELECT toUInt64("p"."UnitsInStock") AS "ToUInt64", toUInt64OrZero("p"."ProductName") AS "ToUInt64OrZero", toUInt64OrNull("p"."ProductName") AS "ToUInt64OrNull", toUInt64OrDefault("p"."ProductName") AS "ToUInt64OrDefault_NoDefault", toUInt64OrDefault("p"."ProductName", toUInt64(5)) AS "ToUInt64OrDefault_WithDefault"
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
