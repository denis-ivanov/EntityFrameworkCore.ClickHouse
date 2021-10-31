using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace EntityFrameworkCore.ClickHouse.IntegrationTests.Query.Internal
{
    [TestFixture]
    public class ClickHouseParameterTranslatorTests : DatabaseFixture
    {
        [Test]
        public void StartWith()
        {
            var prefix = "Lorem";
            
            Context.SimpleEntities.Any(e => e.Text.StartsWith(prefix)).Should().BeTrue();
        }
        
        [Test]
        public void EndsWith()
        {
            var suffix = "ipsum";
            Context.SimpleEntities.Any(e => e.Text.EndsWith(suffix)).Should().BeTrue();
        }
   
        [Test]
        public void LimitOffset()
        {
            (Context.SimpleEntities.OrderBy(x => x.Id).Skip(0).Take(1).ToList().Count == 1).Should().BeTrue();
        }
    }
}