using ClickHouse.EntityFrameworkCore.Infrastructure;
using EntityFrameworkCore.ClickHouse.NTS.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EntityFrameworkCore.ClickHouse.NTS.Extensions;

public static class ClickHouseNetTopologySuiteDbContextOptionsBuilderExtensions
{
    public static ClickHouseDbContextOptionsBuilder UseNetTopologySuite(
        this ClickHouseDbContextOptionsBuilder optionsBuilder)
    {
        var coreOptionsBuilder = ((IRelationalDbContextOptionsBuilderInfrastructure)optionsBuilder).OptionsBuilder;

        var extension = coreOptionsBuilder.Options.FindExtension<ClickHouseNetTopologySuiteOptionsExtension>()
                        ?? new ClickHouseNetTopologySuiteOptionsExtension();

        ((IDbContextOptionsBuilderInfrastructure)coreOptionsBuilder).AddOrUpdateExtension(extension);

        return optionsBuilder;
    }
}
