using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace EntityFrameworkCore.ClickHouse.IntegrationTests.Update.Internal
{
    [TestFixture, ExcludeFromCodeCoverage]
    public class ClickHouseUpdateSqlGeneratorTests : DatabaseFixture
    {
        [Test]
        public void AppendDeleteCommandHeader_DeleteEntity_ShouldOverrideDefaultBehavior()
        {
            // Arrange
            var c = new ClickHouseContext();

            // Act
            var s = c.SimpleEntities.First();

            // Assert
            c.SimpleEntities.Remove(s);
            c.SaveChanges();
        }

        [Test]
        public void AppendUpdateCommandHeader_UpdateEntity_ShouldOverrideDefaultBehavior()
        {
            // Arrange
            
            // Act
            var e = Context.SimpleEntities.First();
            e.Text = "Lorem ipsum dolor sit amet";

            // Assert
            Context.SaveChanges();
        }
    }
}
