using EntityFrameworkCore.ClickHouse.NTS.Scaffolding.Internal;
using EntityFrameworkCore.ClickHouse.NTS.Storage.Internal;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NetTopologySuite;

namespace EntityFrameworkCore.ClickHouse.NTS.Design.Internal;

public class ClickHouseNetTopologySuiteDesignTimeServices : IDesignTimeServices
{
    public virtual void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        => serviceCollection
            .AddSingleton<IRelationalTypeMappingSourcePlugin, ClickHouseNetTopologySuiteTypeMappingSourcePlugin>()
            .AddSingleton<IProviderCodeGeneratorPlugin, ClickHouseNetTopologySuiteCodeGeneratorPlugin>()
            .TryAddSingleton(NtsGeometryServices.Instance);
}
