using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: DesignTimeProviderServices("ClickHouse.EntityFrameworkCore.Design.Internal.ClickHouseDesignTimeServices")]

namespace ClickHouse.EntityFrameworkCore.Design.Internal;

public class ClickHouseDesignTimeServices : IDesignTimeServices
{
    public void ConfigureDesignTimeServices(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddEntityFrameworkClickHouse();

#pragma warning disable EF1001 // Internal EF Core API usage.
        new EntityFrameworkRelationalDesignServicesBuilder(services)
            .TryAdd<ICSharpRuntimeAnnotationCodeGenerator, ClickHouseCSharpRuntimeAnnotationCodeGenerator>()
#pragma warning restore EF1001 // Internal EF Core API usage.
            .TryAdd<IAnnotationCodeGenerator, ClickHouseAnnotationCodeGenerator>()
            .TryAdd<IDatabaseModelFactory, ClickHouseDatabaseModelFactory>()
            .TryAdd<IProviderConfigurationCodeGenerator, ClickHouseCodeGenerator>()
            .TryAddCoreServices();
    }
}
