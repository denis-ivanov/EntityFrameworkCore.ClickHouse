using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;

public class ClickHouseNorthwindTestStoreFactory : ClickHouseTestStoreFactory
{
    public static new ClickHouseNorthwindTestStoreFactory Instance { get; } = new();

    protected ClickHouseNorthwindTestStoreFactory()
    {
    }

    public override TestStore GetOrCreate(string storeName)
        => ClickHouseTestStore.GetExisting("northwind");
}