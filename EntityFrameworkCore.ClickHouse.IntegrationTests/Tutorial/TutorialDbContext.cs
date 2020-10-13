using EntityFrameworkCore.ClickHouse.IntegrationTests.Tutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.ClickHouse.IntegrationTests.Tutorial
{
    public class TutorialDbContext : DbContext
    {
        protected TutorialDbContext()
        {
        }

        public TutorialDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hit> Hits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
