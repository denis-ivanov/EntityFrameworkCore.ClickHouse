using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestModels.JsonQuery;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class JsonQueryClickHouseFixture : JsonQueryRelationalFixture
{
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;

    protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
    {
        base.OnModelCreating(modelBuilder, context);

        // EF Core's relational model validation rejects nested primitive collections.
        string[] nestedCollections =
        [
            nameof(JsonEntityAllTypes.TestInt64CollectionCollection),
            nameof(JsonEntityAllTypes.TestDoubleCollectionCollection),
            nameof(JsonEntityAllTypes.TestSingleCollectionCollection),
            nameof(JsonEntityAllTypes.TestBooleanCollectionCollection),
            nameof(JsonEntityAllTypes.TestCharacterCollectionCollection),
            nameof(JsonEntityAllTypes.TestDefaultStringCollectionCollection),
            nameof(JsonEntityAllTypes.TestMaxLengthStringCollectionCollection),
            nameof(JsonEntityAllTypes.TestInt16CollectionCollection),
            nameof(JsonEntityAllTypes.TestInt32CollectionCollection),
            nameof(JsonEntityAllTypes.TestNullableEnumWithIntConverterCollectionCollection),
            nameof(JsonEntityAllTypes.TestNullableInt32CollectionCollection),
            nameof(JsonEntityAllTypes.TestNullableEnumCollectionCollection)
        ];

        EntityTypeBuilder<JsonEntityAllTypes> allTypes = modelBuilder.Entity<JsonEntityAllTypes>();
        OwnedNavigationBuilder<JsonEntityAllTypes, JsonOwnedAllTypes> reference = allTypes.OwnsOne(static entity => entity.Reference);
        OwnedNavigationBuilder<JsonEntityAllTypes, JsonOwnedAllTypes> collection = allTypes.OwnsMany(static entity => entity.Collection);

        foreach (string propertyName in nestedCollections)
        {
            allTypes.Ignore(propertyName);
            reference.Ignore(propertyName);
            collection.Ignore(propertyName);
        }
    }
}
