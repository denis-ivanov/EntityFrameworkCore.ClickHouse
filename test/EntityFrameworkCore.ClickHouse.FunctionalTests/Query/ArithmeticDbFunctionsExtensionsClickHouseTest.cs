using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class ArithmeticDbFunctionsExtensionsClickHouseTest : IClassFixture<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public ArithmeticDbFunctionsExtensionsClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task Divide()
    {
        var context = CreateContext();
        
        await context.OrderDetails
            .Where(e => e.OrderID == 10285)
            .Select(e => new { Double = EF.Functions.Divide(e.UnitPrice, e.Discount) })
            .ToListAsync();

        AssertSql(
            """
            SELECT divide("o"."UnitPrice", "o"."Discount") AS "Double"
            FROM "OrderDetails" AS "o"
            WHERE "o"."OrderID" = 10285
            """);
    }

    [Fact]
    public async Task DivideDecimal()
    {
        var context = CreateContext();

        await context.OrderDetails
            .Where(e => e.OrderID == 10285)
            .Select(e => new
            {
                DecimalDivide = decimal.Divide(e.UnitPrice, 10m),
                DivideDecimal = EF.Functions.DivideDecimal(e.UnitPrice, 10m),
                DivideDecimalWithPrecision = EF.Functions.DivideDecimal(e.UnitPrice, 10m, 10)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT divideDecimal("o"."UnitPrice", 10::Decimal(38,19)) AS "DecimalDivide", divideDecimal("o"."UnitPrice", 10::Decimal(38,19), 10) AS "DivideDecimalWithPrecision"
            FROM "OrderDetails" AS "o"
            WHERE "o"."OrderID" = 10285
            """);
    }

    protected NorthwindQueryClickHouseFixture<NoopModelCustomizer> Fixture { get; }
    
    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);

    protected NorthwindContext CreateContext()
        => Fixture.CreateContext();
}
