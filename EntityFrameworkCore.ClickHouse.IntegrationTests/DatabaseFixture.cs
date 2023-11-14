using ClickHouse.Client.ADO;
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
            await using var connection = new ClickHouseConnection(ClickHouseContext.ConnectionStringWithoutDatabase);
            await using var command = connection.CreateCommand();
            command.CommandText = "CREATE DATABASE UnitTests";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            
            Context = new ClickHouseContext();
            await Context.Database.EnsureCreatedAsync();

            await Context.SimpleEntities.AddRangeAsync(
                new SimpleEntity { Id = 1, Text = "Lorem ipsum" }
            );
            await Context.SaveChangesAsync();
        }

        [TearDown]
        public async Task Destroy()
        {
            await Context.Database.EnsureDeletedAsync();
        }
    }
}
