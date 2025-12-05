using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests;

public class ValueConvertersEndToEndClickHouseTest
    : ValueConvertersEndToEndTestBase<ValueConvertersEndToEndClickHouseTest.ValueConvertersEndToEndClickHouseFixture>
{
    public ValueConvertersEndToEndClickHouseTest(ValueConvertersEndToEndClickHouseFixture fixture)
        : base(fixture)
    {
    }

    [ConditionalTheory(Skip = "TBD")]
    public override Task Can_insert_and_read_back_with_conversions(int[] valueOrder)
    {
        return base.Can_insert_and_read_back_with_conversions(valueOrder);
    }
    
    [ConditionalTheory]
    [InlineData(nameof(ConvertingEntity.BoolAsChar), "String", false)]
    [InlineData(nameof(ConvertingEntity.BoolAsNullableChar), "String", false)]
    [InlineData(nameof(ConvertingEntity.BoolAsString), "String", false)]
    [InlineData(nameof(ConvertingEntity.BoolAsInt), "Int32", false)]
    [InlineData(nameof(ConvertingEntity.BoolAsNullableString), "String", false)]
    [InlineData(nameof(ConvertingEntity.BoolAsNullableInt), "Int32", false)]
    [InlineData(nameof(ConvertingEntity.IntAsLong), "Int64", false)]
    [InlineData(nameof(ConvertingEntity.IntAsNullableLong), "Int64", false)]
    [InlineData(nameof(ConvertingEntity.BytesAsString), "String", false)]
    [InlineData(nameof(ConvertingEntity.BytesAsNullableString), "String", false)]
    [InlineData(nameof(ConvertingEntity.CharAsString), "String", false)]
    [InlineData(nameof(ConvertingEntity.CharAsNullableString), "String", false)]
    [InlineData(nameof(ConvertingEntity.DateTimeOffsetToBinary), "Int64", false)]
    [InlineData(nameof(ConvertingEntity.DateTimeOffsetToNullableBinary), "Int64", false)]
    [InlineData(nameof(ConvertingEntity.DateTimeOffsetToString), "String", false)]
    [InlineData(nameof(ConvertingEntity.DateTimeOffsetToNullableString), "String", false)]
    [InlineData(nameof(ConvertingEntity.DateTimeToBinary), "Int64", false)]
    [InlineData(nameof(ConvertingEntity.DateTimeToNullableBinary), "Int64", false)]
    [InlineData(nameof(ConvertingEntity.DateTimeToString), "String", false)]
    [InlineData(nameof(ConvertingEntity.DateTimeToNullableString), "String", false)]
    [InlineData(nameof(ConvertingEntity.EnumToString), "String", false)]
    [InlineData(nameof(ConvertingEntity.EnumToNullableString), "String", false)]
    [InlineData(nameof(ConvertingEntity.EnumToNumber), "Int64", false)]
    [InlineData(nameof(ConvertingEntity.EnumToNullableNumber), "Int64", false)]
    [InlineData(nameof(ConvertingEntity.GuidToString), "String", false)]
    [InlineData(nameof(ConvertingEntity.GuidToNullableString), "String", false)]
    [InlineData(nameof(ConvertingEntity.GuidToBytes), "Array(UInt8)", false)]
    [InlineData(nameof(ConvertingEntity.GuidToNullableBytes), "Array(UInt8)", false)]
    [InlineData(nameof(ConvertingEntity.IPAddressToString), "String", false)]
    [InlineData(nameof(ConvertingEntity.IPAddressToNullableString), "String", false)]
    [InlineData(nameof(ConvertingEntity.IPAddressToBytes), "Array(UInt8)", false)]
    [InlineData(nameof(ConvertingEntity.IPAddressToNullableBytes), "Array(UInt8)", false)]
    [InlineData(nameof(ConvertingEntity.PhysicalAddressToString), "String", false)]
    [InlineData(nameof(ConvertingEntity.PhysicalAddressToNullableString), "String", false)]
    [InlineData(nameof(ConvertingEntity.PhysicalAddressToBytes), "Array(UInt8)", false)]
    [InlineData(nameof(ConvertingEntity.PhysicalAddressToNullableBytes), "Array(UInt8)", false)]
    [InlineData(nameof(ConvertingEntity.NumberToString), "String", false)]
    [InlineData(nameof(ConvertingEntity.NumberToNullableString), "String", false)]
    [InlineData(nameof(ConvertingEntity.NumberToBytes), "Array(UInt8)", false)]
    [InlineData(nameof(ConvertingEntity.NumberToNullableBytes), "Array(UInt8)", false)]
    [InlineData(nameof(ConvertingEntity.StringToBool), "Bool", false)]
    [InlineData(nameof(ConvertingEntity.StringToNullableBool), "Bool", false)]
    [InlineData(nameof(ConvertingEntity.StringToBytes), "Array(UInt8)", false)]
    [InlineData(nameof(ConvertingEntity.StringToNullableBytes), "Array(UInt8)", false)]
    [InlineData(nameof(ConvertingEntity.StringToChar), "String", false)]
    [InlineData(nameof(ConvertingEntity.StringToNullableChar), "String", false)]
    [InlineData(nameof(ConvertingEntity.StringToDateTime), "DateTime", false)]
    [InlineData(nameof(ConvertingEntity.StringToNullableDateTime), "DateTime", false)]
    [InlineData(nameof(ConvertingEntity.StringToDateTimeOffset), "String", false)]
    [InlineData(nameof(ConvertingEntity.StringToNullableDateTimeOffset), "String", false)]
    [InlineData(nameof(ConvertingEntity.StringToEnum), "UInt16", false)]
    [InlineData(nameof(ConvertingEntity.StringToNullableEnum), "UInt16", false)]
    [InlineData(nameof(ConvertingEntity.StringToGuid), "UUID", false)]
    [InlineData(nameof(ConvertingEntity.StringToNullableGuid), "UUID", false)]
    [InlineData(nameof(ConvertingEntity.StringToNumber), "UInt8", false)]
    [InlineData(nameof(ConvertingEntity.StringToNullableNumber), "UInt8", false)]
    [InlineData(nameof(ConvertingEntity.StringToTimeSpan), "Time", false)]
    [InlineData(nameof(ConvertingEntity.StringToNullableTimeSpan), "Time", false)]
    [InlineData(nameof(ConvertingEntity.TimeSpanToTicks), "Int64", false)]
    [InlineData(nameof(ConvertingEntity.TimeSpanToNullableTicks), "Int64", false)]
    [InlineData(nameof(ConvertingEntity.TimeSpanToString), "String", false)]
    [InlineData(nameof(ConvertingEntity.TimeSpanToNullableString), "String", false)]
    [InlineData(nameof(ConvertingEntity.UriToString), "String", false)]
    [InlineData(nameof(ConvertingEntity.UriToNullableString), "String", false)]
    [InlineData(nameof(ConvertingEntity.NullableCharAsString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableCharAsNullableString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableBoolAsChar), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableBoolAsNullableChar), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableBoolAsString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableBoolAsNullableString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableBoolAsInt), "Int32", true)]
    [InlineData(nameof(ConvertingEntity.NullableBoolAsNullableInt), "Int32", true)]
    [InlineData(nameof(ConvertingEntity.NullableIntAsLong), "Int64", true)]
    [InlineData(nameof(ConvertingEntity.NullableIntAsNullableLong), "Int64", true)]
    [InlineData(nameof(ConvertingEntity.NullableBytesAsString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableBytesAsNullableString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableDateTimeOffsetToBinary), "Int64", true)]
    [InlineData(nameof(ConvertingEntity.NullableDateTimeOffsetToNullableBinary), "Int64", true)]
    [InlineData(nameof(ConvertingEntity.NullableDateTimeOffsetToString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableDateTimeOffsetToNullableString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableDateTimeToBinary), "Int64", true)]
    [InlineData(nameof(ConvertingEntity.NullableDateTimeToNullableBinary), "Int64", true)]
    [InlineData(nameof(ConvertingEntity.NullableDateTimeToString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableDateTimeToNullableString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableEnumToString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableEnumToNullableString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableEnumToNumber), "Int64", true)]
    [InlineData(nameof(ConvertingEntity.NullableEnumToNullableNumber), "Int64", true)]
    [InlineData(nameof(ConvertingEntity.NullableGuidToString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableGuidToNullableString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableGuidToBytes), "Array(UInt8)", true)]
    [InlineData(nameof(ConvertingEntity.NullableGuidToNullableBytes), "Array(UInt8)", true)]
    [InlineData(nameof(ConvertingEntity.NullableIPAddressToString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableIPAddressToNullableString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableIPAddressToBytes), "Array(UInt8)", true)]
    [InlineData(nameof(ConvertingEntity.NullableIPAddressToNullableBytes), "Array(UInt8)", true)]
    [InlineData(nameof(ConvertingEntity.NullablePhysicalAddressToString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullablePhysicalAddressToNullableString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullablePhysicalAddressToBytes), "Array(UInt8)", true)]
    [InlineData(nameof(ConvertingEntity.NullablePhysicalAddressToNullableBytes), "Array(UInt8)", true)]
    [InlineData(nameof(ConvertingEntity.NullableNumberToString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableNumberToNullableString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableNumberToBytes), "Array(UInt8)", true)]
    [InlineData(nameof(ConvertingEntity.NullableNumberToNullableBytes), "Array(UInt8)", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToBool), "Bool", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToNullableBool), "Bool", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToBytes), "Array(UInt8)", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToNullableBytes), "Array(UInt8)", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToChar), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToNullableChar), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToDateTime), "DateTime", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToNullableDateTime), "DateTime", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToDateTimeOffset), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToNullableDateTimeOffset), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToEnum), "UInt16", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToNullableEnum), "UInt16", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToGuid), "UUID", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToNullableGuid), "UUID", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToNumber), "UInt8", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToNullableNumber), "UInt8", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToTimeSpan), "Time", true)]
    [InlineData(nameof(ConvertingEntity.NullableStringToNullableTimeSpan), "Time", true)]
    [InlineData(nameof(ConvertingEntity.NullableTimeSpanToTicks), "Int64", true)]
    [InlineData(nameof(ConvertingEntity.NullableTimeSpanToNullableTicks), "Int64", true)]
    [InlineData(nameof(ConvertingEntity.NullableTimeSpanToString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableTimeSpanToNullableString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableUriToString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullableUriToNullableString), "String", true)]
    [InlineData(nameof(ConvertingEntity.NullStringToNonNullString), "String", false)]
    [InlineData(nameof(ConvertingEntity.NonNullStringToNullString), "String", true)]
    public virtual void Properties_with_conversions_map_to_appropriately_null_columns(
        string propertyName,
        string databaseType,
        bool isNullable)
    {
        using var context = CreateContext();

        var property = context.Model.FindEntityType(typeof(ConvertingEntity))!.FindProperty(propertyName);

        Assert.Equal(databaseType, property!.GetColumnType());
        Assert.Equal(isNullable, property!.IsNullable);
    }

    public class ValueConvertersEndToEndClickHouseFixture : ValueConvertersEndToEndFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;

        protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
        {
            base.OnModelCreating(modelBuilder, context);

            modelBuilder.Entity<ConvertingEntity>(
                b =>
                {
                    b.Property(e => e.NullableListOfInt).HasDefaultValue(new List<int>());
                    b.Property(e => e.ListOfInt).HasDefaultValue(new List<int>());
                    b.Property(e => e.NullableEnumerableOfInt).HasDefaultValue(Enumerable.Empty<int>());
                    b.Property(e => e.EnumerableOfInt).HasDefaultValue(Enumerable.Empty<int>());
                });
        }
    }
}
