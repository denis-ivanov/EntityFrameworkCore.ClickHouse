using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace EntityFrameworkCore.ClickHouse.IntegrationTests.Query.Internal
{
    [TestFixture]
    public class ClickHouseStringTranslatorTests : DatabaseFixture
    {
        [Test]
        public void StartsWith()
        {
            // Arrange

            // Act

            // Assert
            Context.SimpleEntities.Any(e => e.Text.StartsWith("Lorem")).Should().BeTrue();
        }

        [Test]
        public void EndsWith()
        {
            // Arrange

            // Act

            // Assert
            Context.SimpleEntities.Any(e => e.Text.EndsWith("ipsum")).Should().BeTrue();
        }
    }
}
