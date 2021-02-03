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
    public class ClickHouseConvertTranslatorTests
    {
        public class SimpleEntity
        {
            public int Id { get; set; }
            
            public string Text { get; set; }
            
            public string DateTime { get; set; }
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

        private const int Value = 1;
        
        [OneTimeSetUp]
        public async Task Initialize()
        {
            var context = new ClickHouseContext();
            await context.Database.EnsureCreatedAsync();

            await context.SimpleEntities.AddRangeAsync(
                new SimpleEntity { Id = 1, Text = 1.ToString(), DateTime = DateTime.Now.ToString("yyyy-MM-dd") }
            );
            await context.SaveChangesAsync();
        }

        #region Convert.ToXX()
        
        [Test]
        public void ToInt8()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => Convert.ToSByte(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToInt16()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => Convert.ToInt16(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToInt32()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => Convert.ToInt32(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToInt64()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => Convert.ToInt64(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToUInt8()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => Convert.ToByte(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToUInt16()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => Convert.ToUInt16(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToUInt32()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => Convert.ToUInt32(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToUInt64()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => Convert.ToUInt64(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToFloat32()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => Convert.ToSingle(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }

        [Test]
        public void ToFloat64()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => Convert.ToDouble(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }

        [Test]
        public void ToDateTime()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => Convert.ToDateTime(e.DateTime)).Single();

            // Assert
            v.Should().Be(DateTime.Today);
        }

        #endregion

        #region Type.Parse()

        [Test]
        public void Int8Parse()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => sbyte.Parse(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void Int16Parse()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => short.Parse(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void Int32Parse()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => int.Parse(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void Int64Parse()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => long.Parse(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void UInt8Parse()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => byte.Parse(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void UInt16Parse()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => ushort.Parse(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void UInt32Parse()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => uint.Parse(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void UInt64Parse()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => ulong.Parse(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void FloatParse()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => float.Parse(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }

        [Test]
        public void DoubleParse()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => double.Parse(e.Text)).Single();

            // Assert
            v.Should().Be(Value);
        }

        [Test]
        public void DateTimeParse()
        {
            // Arrange
            var c = new ClickHouseContext();
            
            // Act
            var v = c.SimpleEntities.Select(e => DateTime.Parse(e.DateTime)).Single();

            // Assert
            v.Should().Be(DateTime.Today);
        }
        
        #endregion
        
        [OneTimeTearDown]
        public async Task Destroy()
        {
            await new ClickHouseContext().Database.EnsureDeletedAsync();
        }
    }
}
