using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestModels.TypeConversion;

public class TypeConversionDbContext : DbContext
{
    public TypeConversionDbContext(DbContextOptions<TypeConversionDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<TypeConversion> TypeConversions { get; set; }
}
