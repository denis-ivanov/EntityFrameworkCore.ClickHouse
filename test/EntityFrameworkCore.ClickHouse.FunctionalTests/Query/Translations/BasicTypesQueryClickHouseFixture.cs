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
using System.Threading.Tasks;
#endif

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Translations;

public class BasicTypesQueryClickHouseFixture : BasicTypesQueryFixtureBase, ITestSqlLoggerFactory
{
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;

    public TestSqlLoggerFactory TestSqlLoggerFactory
        => (TestSqlLoggerFactory)ListLoggerFactory;
#if NET11_0_OR_GREATER
    private static readonly DateTime s_minimumDateTime = new(1900, 1, 1);
    private static readonly DateOnly s_minimumDate = DateOnly.FromDateTime(s_minimumDateTime);
    private readonly BasicTypesData _expectedData = CreateData();

    protected override Task SeedAsync(BasicTypesContext context)
    {
        BasicTypesData data = CreateData();
        context.AddRange(data.BasicTypesEntities);
        context.AddRange(data.NullableBasicTypesEntities);

        return context.SaveChangesAsync();
    }

    public override ISetSource GetExpectedData()
        => _expectedData;

    protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
    {
        base.OnModelCreating(modelBuilder, context);

        modelBuilder.Entity<BasicTypesEntity>().Property(static entity => entity.DateTime).HasColumnType("DateTime64(7)");
        modelBuilder.Entity<NullableBasicTypesEntity>().Property(static entity => entity.DateTime).HasColumnType("DateTime64(7)");
        modelBuilder.Entity<BasicTypesEntity>().Property(static entity => entity.DateOnly).HasColumnType("Date32");
        modelBuilder.Entity<NullableBasicTypesEntity>().Property(static entity => entity.DateOnly).HasColumnType("Date32");

        // ClickHouse cannot store NULL for an Array column.
        modelBuilder.Entity<NullableBasicTypesEntity>()
            .Property(entity => entity.ByteArray)
            .HasConversion(
                static bytes => Convert.ToBase64String(bytes!),
                static text => Convert.FromBase64String(text),
                ValueComparer.CreateDefault<byte[]>(favorStructuralComparisons: true));
    }

    private static BasicTypesData CreateData()
    {
        BasicTypesData data = new();

        // Keep the time and fractional seconds when moving .NET minimum dates into ClickHouse's range.
        foreach (BasicTypesEntity entity in data.BasicTypesEntities)
        {
            if (entity.DateTime < s_minimumDateTime)
            {
                entity.DateTime = s_minimumDateTime + entity.DateTime.TimeOfDay;
            }

            if (entity.DateOnly < s_minimumDate)
            {
                entity.DateOnly = s_minimumDate;
            }
        }

        foreach (NullableBasicTypesEntity entity in data.NullableBasicTypesEntities)
        {
            if (entity.DateTime is DateTime value && value < s_minimumDateTime)
            {
                entity.DateTime = s_minimumDateTime + value.TimeOfDay;
            }

            if (entity.DateOnly < s_minimumDate)
            {
                entity.DateOnly = s_minimumDate;
            }
        }

        return data;
    }
#endif
}
