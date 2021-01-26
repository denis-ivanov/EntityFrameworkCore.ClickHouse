using System;
using System.Linq;
using ClickHouse.EntityFrameworkCore.Extensions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EntityFrameworkCore.ClickHouse.IntegrationTests.Tutorial
{
    [TestFixture]
    public class TutorialDbContextTests
    {
        private TutorialDbContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TutorialDbContext>();
            optionsBuilder.UseClickHouse("Host=localhost;Protocol=http;Port=8123;Database=tutorial");
            optionsBuilder.LogTo(TestContext.WriteLine);
            return new TutorialDbContext(optionsBuilder.Options);
        }

        [Test]
        public void Any()
        {
            // Arrange
            var context = CreateContext();

            // Act

            // Assert
            Assert.DoesNotThrow(() => context.Hits.Any());
        }

        [Test]
        public void AnyWithPredicate()
        {
            // Arrange
            var context = CreateContext();

            // Act

            // Assert
            Assert.DoesNotThrow(() => context.Hits.Any(e => e.WatchID > 1UL));
        }

        [Test]
        public void All()
        {
            // Arrange
            var context = CreateContext();

            // Act

            // Assert
            Assert.DoesNotThrow(() => context.Hits.All(e => e.WatchID > 0UL));
        }

        [Test]
        public void Count()
        {
            // Arrange
            var context = CreateContext();

            // Act

            // Assert
            Assert.AreNotEqual(0, context.Hits.Count());
        }

        [Test]
        public void LongCount()
        {
            // Arrange
            var context = CreateContext();

            // Act

            // Assert
            Assert.AreNotEqual(0, context.Hits.LongCount());
        }

        [Test]
        public void Min()
        {
            // Arrange
            var context = CreateContext();

            // Act

            // Assert
            Assert.AreEqual(0, context.Hits.Min(e => e.FlashMajor));
        }

        [Test]
        public void Max()
        {
            // Arrange
            var context = CreateContext();

            // Act

            // Assert
            Assert.AreEqual(23, context.Hits.Max(e => e.FlashMajor));
        }

        [Test]
        public void Sum()
        {
            // Arrange
            var context = CreateContext();

            // Act

            // Assert
            context.Hits.Sum(e => e.FlashMajor);
        }

        [Test]
        public void Average()
        {
            // Arrange
            var context = CreateContext();

            // Act

            // Assert
            context.Hits.Average(e => e.FlashMajor);
        }

        [Test]
        public void SkipTake()
        {
            // Arrange
            var context = CreateContext();
            const int takeCount = 2;

            // Act

            // Assert
            var hits = context.Hits.Skip(3).Take(takeCount).ToArray();
            Assert.AreEqual(takeCount, hits.Length);
        }

        [Test]
        public void CreateDatabase()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TutorialDbContext>();
            optionsBuilder.UseClickHouse("Host=localhost;Protocol=http;Port=8123;Database=tutorial_created");
            var context = new TutorialDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();
        }

        [Test]
        public void ToLowerToUpper()
        {
            // Arrange
            var context = CreateContext();

            // Act
            var result = context.Hits
                .Take(10)
                .Select(e => new
                {
                    Upper = e.Title.ToUpper(),
                    Lower = e.Title.ToLower()
                })
                .ToArray();

            // Assert
            foreach (var item in result)
            {
                Assert.IsTrue(IsLower(item.Lower));
                Assert.IsTrue(IsUpper(item.Upper));
            }
        }

        [Test]
        public void IsNullOrEmpty()
        {
            // Arrange
            var context = CreateContext();

            // Act
            var item = context.Hits.First(e => string.IsNullOrEmpty(e.Title));

            // Assert
            item.Title.Should().BeEmpty();
        }

        [Test]
        public void StringLength()
        {
            // Arrange
            var context = CreateContext();

            // Act
            var item = context.Hits.First(e => e.Title.Length > 0);

            // Assert
            item.Title.Should().NotBeEmpty();
        }

        [Test]
        public void EmptyArrays()
        {
            // Arrange
            var context = CreateContext();

            // Act
            var item = context.Hits
                .Select(e => new
                {
                    UInt8Array = Array.Empty<byte>(),
                    UInt16Array = Array.Empty<ushort>(),
                    UInt32Array = Array.Empty<uint>(),
                    UInt64Array = Array.Empty<ulong>(),
                    Int8Array = Array.Empty<sbyte>(),
                    Int16Array = Array.Empty<short>(),
                    Int32Array = Array.Empty<int>(),
                    Int64Array = Array.Empty<long>(),
                    Float32Array = Array.Empty<float>(),
                    Float64Array = Array.Empty<double>(),
                    DateTimeArray = Array.Empty<DateTime>(),
                    StringArray = Array.Empty<string>()
                })
                .First();

            // Assert
            item.UInt8Array.Should().BeEmpty();
            item.UInt16Array.Should().BeEmpty();
            item.UInt32Array.Should().BeEmpty();
            item.UInt64Array.Should().BeEmpty();
            item.Int8Array.Should().BeEmpty();
            item.Int16Array.Should().BeEmpty();
            item.Int32Array.Should().BeEmpty();
            item.Int64Array.Should().BeEmpty();
            item.Float32Array.Should().BeEmpty();
            item.Float64Array.Should().BeEmpty();
            item.DateTimeArray.Should().BeEmpty();
            item.StringArray.Should().BeEmpty();
        }

        [Test]
        public void Trim()
        {
            // Arrange
            const string s = "     Hello, world!     ";
            var context = CreateContext();

            // Act
            var item = context.Hits
                .Select(e => new
                {
                    TrimStart = s.TrimStart(),
                    TrimEnd = s.TrimEnd(),
                    Trim = s.Trim()
                })
                .First();

            // Assert
            item.TrimStart.Should().Be(s.TrimStart());
            item.TrimEnd.Should().Be(s.TrimEnd());
            item.Trim.Should().Be(s.Trim());
        }
        
        private bool IsLower(string s)
        {
            return s == null || s.All(c => !char.IsLetter(c) || char.IsLower(c));
        }
        
        private bool IsUpper(string s)
        {
            return s == null || s.All(c => !char.IsLetter(c) || char.IsUpper(c));
        }
    }
}
