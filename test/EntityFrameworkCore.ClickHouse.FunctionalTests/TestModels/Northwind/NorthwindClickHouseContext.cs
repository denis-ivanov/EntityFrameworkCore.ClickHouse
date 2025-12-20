using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestModels.Northwind;

public class NorthwindClickHouseContext : NorthwindRelationalContext
{
    public NorthwindClickHouseContext(DbContextOptions options)
        : base(options)
    {
    }
}
