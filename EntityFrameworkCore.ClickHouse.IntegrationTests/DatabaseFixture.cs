using ClickHouse.Client.ADO;
using ClickHouse.Client.Utility;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace EntityFrameworkCore.ClickHouse.IntegrationTests
{
    [TestFixture, ExcludeFromCodeCoverage]
    public abstract class DatabaseFixture
    {
        protected ClickHouseContext Context { get; set; }
        
        [SetUp]
        public async Task Initialize()
        {
            Context = new ClickHouseContext();
            await Context.Database.EnsureCreatedAsync();


            var connection = new ClickHouseConnection("Host=localhost;Protocol=http;Port=8123;Database=" + TestContext.CurrentContext.Test.ClassName);
            var command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO ""SimpleEntities"" (""Id"", ""Text"") VALUES ({p0:Int32}, {p1:String});";
            command.AddParameter("p0", 1);
            command.AddParameter("p1", "Loremsdasipsum");
            connection.Open();
            command.ExecuteNonQuery();

            // await Context.SimpleEntities.AddRangeAsync(
            //     new SimpleEntity { Id = 1, Text = "Lorem ipsum" }
            // );
            // await Context.SaveChangesAsync();
        }

        [TearDown]
        public async Task Destroy()
        {
            await Context.Database.EnsureDeletedAsync();
        }
    }
}
