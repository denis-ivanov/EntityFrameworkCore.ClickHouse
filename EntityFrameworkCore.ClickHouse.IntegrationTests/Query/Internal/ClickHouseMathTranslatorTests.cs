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
    public class ClickHouseMathTranslatorTests
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
                new SimpleEntity { Id = 1, Text = "Item1" },
                new SimpleEntity { Id = 2, Text = "Item3" },
                new SimpleEntity { Id = 3, Text = "Item4" }
            );
            await context.SaveChangesAsync();
        }

        [Test]
        public void Exp()
        {
            // Arrange
            const double v = 1;
            var c = new ClickHouseContext();

            // Act
            var exp = c.SimpleEntities.Select(e => Math.Exp(v)).First();

            // Assert
            exp.Should().BeApproximately(Math.Exp(v), 0.0001);
        }

        [Test]
        public void Log()
        {
            // Arrange
            const double v = 2;
            var c = new ClickHouseContext();

            // Act
            var log = c.SimpleEntities.Select(e => Math.Log(v)).First();

            // Assert
            log.Should().BeApproximately(Math.Log(v), 0.0001);
        }
        
        [Test]
        public void Log10()
        {
            // Arrange
            const double v = 3;
            var c = new ClickHouseContext();

            // Act
            var log10 = c.SimpleEntities.Select(e => Math.Log10(v)).First();

            // Assert
            log10.Should().BeApproximately(Math.Log10(v), 0.0001);
        }
        
        [Test]
        public void Sqrt()
        {
            // Arrange
            const double v = 4;
            var c = new ClickHouseContext();

            // Act
            var sqrt = c.SimpleEntities.Select(e => Math.Sqrt(v)).First();

            // Assert
            sqrt.Should().BeApproximately(Math.Sqrt(v), 0.0001);
        }
        
        [Test]
        public void Cbrt()
        {
            // Arrange
            const double v = 5;
            var c = new ClickHouseContext();

            // Act
            var cqrt = c.SimpleEntities.Select(e => Math.Cbrt(v)).First();

            // Assert
            cqrt.Should().BeApproximately(Math.Cbrt(v), 0.0001);
        }
        
        [Test]
        public void Sin()
        {
            // Arrange
            const double v = 6;
            var c = new ClickHouseContext();

            // Act
            var sin = c.SimpleEntities.Select(e => Math.Sin(v)).First();

            // Assert
            sin.Should().BeApproximately(Math.Sin(v), 0.0001);
        }
        
        [Test]
        public void Cos()
        {
            // Arrange
            const double v = 7;
            var c = new ClickHouseContext();

            // Act
            var cos = c.SimpleEntities.Select(e => Math.Cos(v)).First();

            // Assert
            cos.Should().BeApproximately(Math.Cos(v), 0.0001);
        }
        
        [Test]
        public void Tan()
        {
            // Arrange
            const double v = 8;
            var c = new ClickHouseContext();

            // Act
            var tan = c.SimpleEntities.Select(e => Math.Tan(v)).First();

            // Assert
            tan.Should().BeApproximately(Math.Tan(v), 0.0001);
        }
        
        [Test]
        public void Asin()
        {
            // Arrange
            const double v = 0.6;
            var c = new ClickHouseContext();

            // Act
            var asin = c.SimpleEntities.Select(e => Math.Asin(v)).First();

            // Assert
            asin.Should().BeApproximately(Math.Asin(v), 0.0001);
        }
        
        [Test]
        public void Acos()
        {
            // Arrange
            const double v = 0.5;
            var c = new ClickHouseContext();

            // Act
            var acos = c.SimpleEntities.Select(e => Math.Acos(v)).First();

            // Assert
            acos.Should().BeApproximately(Math.Acos(v), 0.0001);
        }
        
        [Test]
        public void Atan()
        {
            // Arrange
            const double v = 11;
            var c = new ClickHouseContext();

            // Act
            var atan = c.SimpleEntities.Select(e => Math.Atan(v)).First();

            // Assert
            atan.Should().BeApproximately(Math.Atan(v), 0.0001);
        }
        
        [Test]
        public void Pow()
        {
            // Arrange
            const double v = 12;
            var c = new ClickHouseContext();

            // Act
            var pow = c.SimpleEntities.Select(e => Math.Pow(v, 3)).First();

            // Assert
            pow.Should().BeApproximately(Math.Pow(v, 3), 0.0001);
        }
        
        [OneTimeTearDown]
        public async Task Destroy()
        {
            await new ClickHouseContext().Database.EnsureDeletedAsync();
        }
    }
}
