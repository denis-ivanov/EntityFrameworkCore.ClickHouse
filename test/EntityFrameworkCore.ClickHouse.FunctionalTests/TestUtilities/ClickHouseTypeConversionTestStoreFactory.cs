using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;

public class ClickHouseTypeConversionTestStoreFactory : ClickHouseTestStoreFactory
{
    public static new ClickHouseTypeConversionTestStoreFactory Instance { get; } = new();

    protected ClickHouseTypeConversionTestStoreFactory()
    {
    }

    public override TestStore GetOrCreate(string storeName)
        => ClickHouseTestStore.GetExisting("TypeConversion");
}
