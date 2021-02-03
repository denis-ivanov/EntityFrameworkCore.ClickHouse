using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ClickHouse.EntityFrameworkCore.Extensions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EntityFrameworkCore.ClickHouse.IntegrationTests.Query.Internal
{
    [TestFixture]
    public class ClickHouseStringTranslatorTests
    {
        public class SimpleEntity
        {
            public int Id { get; set; }
            
            public string Text { get; set; }
        }
        
        public class ClickHouseContext : DbContext
        {
            public DbSet<SimpleEntity> SimpleEntities { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<SimpleEntity>().HasKey(e => e.Id);

                modelBuilder.Entity<SimpleEntity>()
                    .HasMergeTreeEngine(new Expression<Func<SimpleEntity, object>>[]
                    {
                        e => e.Id
                    });
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.LogTo(TestContext.WriteLine);
                optionsBuilder.UseClickHouse("Host=localhost;Protocol=http;Port=8123;Database=" + TestContext.CurrentContext.Test.ClassName);
            }
        }

        [OneTimeSetUp]
        public async Task Initialize()
        {
            var context = new ClickHouseContext();
            await context.Database.EnsureCreatedAsync();

            await context.SimpleEntities.AddRangeAsync(
                new SimpleEntity { Id = 1, Text = "Lorem ipsum" }
            );
            await context.SaveChangesAsync();
        }

        [Test]
        public void StartsWith()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act

            // Assert
            c.SimpleEntities.Any(e => e.Text.StartsWith("Lorem")).Should().BeTrue();
        }
        
        [Test]
        public void EndsWith()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act

            // Assert
            c.SimpleEntities.Any(e => e.Text.EndsWith("ipsum")).Should().BeTrue();
        }
        
        [OneTimeTearDown]
        public async Task Destroy()
        {
            await new ClickHouseContext().Database.EnsureDeletedAsync();
        }
    }
}