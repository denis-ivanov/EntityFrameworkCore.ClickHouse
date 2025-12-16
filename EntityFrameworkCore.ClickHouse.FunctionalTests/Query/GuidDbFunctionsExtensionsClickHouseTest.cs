using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class GuidDbFunctionsExtensionsClickHouseTest : IClassFixture<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public GuidDbFunctionsExtensionsClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task ToGuid_conversion()
    {
        // TODO Tests
//         var context = CreateContext();
//         Guid g = Guid.Parse("550e8400-e29b-41d4-a716-446655440000");
//         
//         await context.Database.ExecuteSqlRawAsync(
//             $"""
//              ALTER TABLE Products 
//             UPDATE ProductName = '{g.ToString()}'
//              WHERE ProductID = 16
//             """);
//
//         var p = await context.Products
//             .Where(e => e.ProductID == 16)
//             .Select(e => new
//             {
//                 GuidParse = Guid.Parse(e.ProductName),
//                 ToUuid = EF.Functions.ToUuid(e.ProductName)
//             })
//             .ToListAsync();
//
//         Assert.Equal(g, p.Single().GuidParse);
//         Assert.Equal(g, p.Single().ToUuid);
    }
    
    protected NorthwindQueryClickHouseFixture<NoopModelCustomizer> Fixture { get; }
    
    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);

    protected NorthwindContext CreateContext()
        => Fixture.CreateContext();
}
