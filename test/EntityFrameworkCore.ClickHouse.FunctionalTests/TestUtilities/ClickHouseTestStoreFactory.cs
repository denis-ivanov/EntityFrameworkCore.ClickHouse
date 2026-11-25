using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.TestUtilities;
#if NET11_0_OR_GREATER
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.ValueGeneration;
#endif
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;

public class ClickHouseTestStoreFactory : RelationalTestStoreFactory
{
    public static readonly ClickHouseTestStoreFactory Instance = new ();

#if NET11_0_OR_GREATER
    public static readonly ClickHouseTestStoreFactory WithClientKeys = new QueryTestStoreFactory();
    public static readonly ClickHouseTestStoreFactory WithClientKeysAndMutations = new MutationTestStoreFactory();
    public static readonly ClickHouseTestStoreFactory WithSynchronousMutations = new SynchronousMutationTestStoreFactory();

    private sealed class SynchronousMutationTestStoreFactory : ClickHouseTestStoreFactory
    {
        public override TestStore Create(string storeName)
            => new ClickHouseTestStore(storeName, shared: false, synchronousMutations: true);

        public override TestStore GetOrCreate(string storeName)
            => new ClickHouseTestStore(storeName, shared: true, synchronousMutations: true);
    }

    private class QueryTestStoreFactory : ClickHouseTestStoreFactory
    {
        public override IServiceCollection AddProviderServices(IServiceCollection serviceCollection)
            => base.AddProviderServices(serviceCollection)
                .AddScoped<IValueGeneratorSelector, ClickHouseQueryTestValueGeneratorSelector>();
    }

    private sealed class MutationTestStoreFactory : QueryTestStoreFactory
    {
        public override TestStore Create(string storeName)
            => new ClickHouseTestStore(storeName, shared: false, synchronousMutations: true);

        public override IServiceCollection AddProviderServices(IServiceCollection serviceCollection)
            => base.AddProviderServices(serviceCollection)
                .AddScoped<IConventionSetPlugin, ClickHouseMutationFixtureConvention>();
    }
#endif

    public override TestStore Create(string storeName)
    {
        return new ClickHouseTestStore(storeName, false);
    }

    public override TestStore GetOrCreate(string storeName)
    {
        return ClickHouseTestStore.GetExisting(storeName);
    }

    public override IServiceCollection AddProviderServices(IServiceCollection serviceCollection)
    {
        return serviceCollection.AddEntityFrameworkClickHouse();
    }
}
