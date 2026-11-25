using ClickHouse.Driver.ADO;
using ClickHouse.EntityFrameworkCore.Extensions;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Compatibility;

public class OwnedJsonMappingClickHouseTest
{
    [Fact]
    public async Task Owned_json_value_can_be_saved_and_read()
    {
#if NET10_0
        CancellationToken cancellationToken = CancellationToken.None;
#else
        CancellationToken cancellationToken = TestContext.Current.CancellationToken;
#endif
        var connection = new ClickHouseConnectionStringBuilder(TestEnvironment.DefaultConnection)
        {
            Database = $"OwnedJsonMapping_{Guid.NewGuid():N}"
        };
        var options = new DbContextOptionsBuilder<JsonContext>()
            .UseClickHouse(connection.ToString())
            .Options;
        await using var context = new JsonContext(options);

        try
        {
            await context.Database.EnsureCreatedAsync(cancellationToken);
            context.Add(new Document
            {
                Id = 1,
                Details = new Details { Name = "ClickHouse" },
                RelatedDetails = [new Details { Name = "First" }, new Details { Name = "Second" }]
            });

            await context.SaveChangesAsync(cancellationToken);

            context.ChangeTracker.Clear();

            var document = await context.Set<Document>().SingleAsync(cancellationToken);

            Assert.Equal("ClickHouse", document.Details.Name);
            Assert.Null(document.OptionalDetails);
            Assert.Collection(
                document.RelatedDetails,
                static details => Assert.Equal("First", details.Name),
                static details => Assert.Equal("Second", details.Name));

            string projectedName = await context.Set<Document>()
                .Select(static item => item.Details.Name)
                .SingleAsync(cancellationToken);
            Assert.Equal("ClickHouse", projectedName);
        }
        finally
        {
            await context.Database.EnsureDeletedAsync();
        }
    }

    private sealed class JsonContext(DbContextOptions<JsonContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>(builder =>
            {
                builder.Property(document => document.Id).ValueGeneratedNever();
                builder.OwnsOne(document => document.Details, details => details.ToJson());
                builder.OwnsOne(document => document.OptionalDetails, details => details.ToJson());
                builder.OwnsMany(document => document.RelatedDetails, details => details.ToJson());
            });
        }
    }

    private sealed class Document
    {
        public int Id { get; set; }
        public Details Details { get; set; } = new();
        public Details? OptionalDetails { get; set; }
        public List<Details> RelatedDetails { get; set; } = [];
    }

    private sealed class Details
    {
        public string Name { get; set; } = "";
    }
}
