using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities
{
    public class ClickHouseTestStoreFactory : RelationalTestStoreFactory
    {
        public static ClickHouseTestStoreFactory Instance = new ();

        public override TestStore Create(string storeName)
        {
            return new ClickHouseTestStore(storeName, false);
        }

        public override TestStore GetOrCreate(string storeName)
        {
            return new ClickHouseTestStore(storeName, false);
        }

        public override IServiceCollection AddProviderServices(IServiceCollection serviceCollection)
        {
            return serviceCollection.AddEntityFrameworkClickHouse();
        }
    }
}
