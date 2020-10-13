using ClickHouse.EntityFrameworkCore.Extensions;
using EntityFrameworkCore.ClickHouse.IntegrationTests.Tutorial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.ClickHouse.IntegrationTests.Tutorial.Configurations
{
    public class HitConfiguration : IEntityTypeConfiguration<Hit>
    {
        public void Configure(EntityTypeBuilder<Hit> builder)
        {
            builder.HasNoKey();
            builder.HasMergeTreeEngine();
            builder.ToTable("hits_v1");
            builder.Property(e => e.ClientIP6).FixedString(16);
            builder.Property(e => e.UserAgentMinor).FixedString(2);
        }
    }
}
