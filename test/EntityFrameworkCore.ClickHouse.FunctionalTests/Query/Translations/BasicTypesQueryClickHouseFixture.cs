using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
#if NET11_0_OR_GREATER
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
#endif
using Microsoft.EntityFrameworkCore.Query.Translations;
#if NET11_0_OR_GREATER
using Microsoft.EntityFrameworkCore.TestModels.BasicTypesModel;
#endif
using Microsoft.EntityFrameworkCore.TestUtilities;
#if NET11_0_OR_GREATER
using System;
#endif

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations;

public class BasicTypesQueryClickHouseFixture : BasicTypesQueryFixtureBase, ITestSqlLoggerFactory
{
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;

    public TestSqlLoggerFactory TestSqlLoggerFactory
        => (TestSqlLoggerFactory)ListLoggerFactory;
#if NET11_0_OR_GREATER

    protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
    {
        base.OnModelCreating(modelBuilder, context);

        // ClickHouse cannot store NULL for an Array column.
        modelBuilder.Entity<NullableBasicTypesEntity>()
            .Property(entity => entity.ByteArray)
            .HasConversion(
                static bytes => Convert.ToBase64String(bytes!),
                static text => Convert.FromBase64String(text),
                ValueComparer.CreateDefault<byte[]>(favorStructuralComparisons: true));
    }
#endif
}
