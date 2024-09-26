using ClickHouse.EntityFrameworkCore.Infrastructure;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using EntityFrameworkCore.ClickHouse.NTS.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestModels.SpatialModel;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class SpatialQueryClickHouseFixture : SpatialQueryRelationalFixture
{
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;

    protected override IServiceCollection AddServices(IServiceCollection serviceCollection)
        => base.AddServices(serviceCollection)
            .AddEntityFrameworkClickHouseNetTopologySuite();

    public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
    {
        var optionsBuilder = base.AddOptions(builder);
        new ClickHouseDbContextOptionsBuilder(optionsBuilder).UseNetTopologySuite();

        return optionsBuilder;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
    {
        base.OnModelCreating(modelBuilder, context);

        modelBuilder.Entity<LineStringEntity>().Property(e => e.LineString).HasColumnType("Geometry");
        modelBuilder.Entity<MultiLineStringEntity>().Property(e => e.MultiLineString).HasColumnType("Geometry");
        modelBuilder.Entity<PointEntity>(
            x =>
            {
                x.Ignore(e => e.Geometry);
                x.Property(e => e.Point).HasColumnType("Point").IsRequired();
                x.Property(e => e.PointZ).HasColumnType("Point").IsRequired();
                x.Property(e => e.PointM).HasColumnType("Point").IsRequired();
                x.Property(e => e.PointZM).HasColumnType("Point").IsRequired();
            });
        modelBuilder.Entity<PolygonEntity>().Property(e => e.Polygon).HasColumnType("Geometry");
        modelBuilder.Entity<GeoPointEntity>().Property(e => e.Location).HasColumnType("Point");
    }
}
