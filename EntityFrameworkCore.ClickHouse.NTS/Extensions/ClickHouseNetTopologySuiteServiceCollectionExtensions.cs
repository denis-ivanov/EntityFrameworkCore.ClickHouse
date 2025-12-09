using EntityFrameworkCore.ClickHouse.NTS.Query.Internal;
using EntityFrameworkCore.ClickHouse.NTS.Storage.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NetTopologySuite;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ClickHouseNetTopologySuiteServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkClickHouseNetTopologySuite(
        this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddSingleton(NtsGeometryServices.Instance);

        new EntityFrameworkRelationalServicesBuilder(serviceCollection)
            .TryAdd<IRelationalTypeMappingSourcePlugin, ClickHouseNetTopologySuiteTypeMappingSourcePlugin>()
            .TryAdd<IMethodCallTranslatorPlugin, ClickHouseNetTopologySuiteMethodCallTranslatorPlugin>()
            .TryAdd<IAggregateMethodCallTranslatorPlugin, ClickHouseNetTopologySuiteAggregateMethodCallTranslatorPlugin>()
            .TryAdd<IMemberTranslatorPlugin, ClickHouseNetTopologySuiteMemberTranslatorPlugin>()
            /*.TryAdd<IEvaluatableExpressionFilterPlugin, ClickHouseNetTopologySuiteEvaluatableExpressionFilterPlugin>()*/;

        return serviceCollection;
    }
}
