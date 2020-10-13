using System.Linq;
using ClickHouse.EntityFrameworkCore.Extensions;
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
    }
}
