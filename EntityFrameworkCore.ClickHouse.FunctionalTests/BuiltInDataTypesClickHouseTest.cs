using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests
{
    public class BuiltInDataTypesClickHouseTest : BuiltInDataTypesTestBase<BuiltInDataTypesClickHouseTest.BuiltInDataTypesClickHouseFixture>
    {
        public BuiltInDataTypesClickHouseTest(BuiltInDataTypesClickHouseFixture fixture) : base(fixture)
        {
        }

        [ConditionalFact]
        public override void Can_insert_and_read_back_all_non_nullable_data_types()
        {
            using (var context = CreateContext())
            {
                context.Set<BuiltInDataTypes>().Add(
                    new BuiltInDataTypes
                    {
                        Id = 1,
                        PartitionId = 1,
                        TestInt16 = -1234,
                        TestInt32 = -123456789,
                        TestInt64 = -1234567890123456789L,
                        TestDouble = -1.23456789,
                        TestDecimal = -1234567890.01M,
                        TestDateTime = DateTime.Parse("01/01/2000 12:34:56"),
                        TestDateTimeOffset = new DateTimeOffset(DateTime.Parse("01/01/2000 12:34:56"), TimeSpan.FromHours(-8.0)),
                        TestTimeSpan = new TimeSpan(0, 10, 9, 8, 7),
                        TestSingle = -1.234F,
                        TestBoolean = true,
                        TestByte = 255,
                        TestUnsignedInt16 = 1234,
                        TestUnsignedInt32 = 1234565789U,
                        TestUnsignedInt64 = 1234567890123456789UL,
                        TestCharacter = 'a',
                        TestSignedByte = -128,
                        Enum64 = Enum64.SomeValue,
                        Enum32 = Enum32.SomeValue,
                        Enum16 = Enum16.SomeValue,
                        Enum8 = Enum8.SomeValue,
                        EnumU64 = EnumU64.SomeValue,
                        EnumU32 = EnumU32.SomeValue,
                        EnumU16 = EnumU16.SomeValue,
                        EnumS8 = EnumS8.SomeValue
                    });

                Assert.Equal(1, context.SaveChanges());
            }

            using (var context = CreateContext())
            {
                var dt = context.Set<BuiltInDataTypes>().Where(e => e.Id == 1).ToList().Single();

                Assert.Equal((short)-1234, dt.TestInt16);
                Assert.Equal(-123456789, dt.TestInt32);
                Assert.Equal(-1234567890123456789L, dt.TestInt64);
                // https://clickhouse.com/docs/en/sql-reference/data-types/float/
                Assert.Equal(-1.23456789, dt.TestDouble, 8);
                Assert.Equal(-1234567890.01M, dt.TestDecimal);
                Assert.Equal(DateTime.Parse("01/01/2000 12:34:56"), dt.TestDateTime);
                Assert.Equal(new DateTimeOffset(DateTime.Parse("01/01/2000 12:34:56"), TimeSpan.FromHours(-8.0)), dt.TestDateTimeOffset);
                Assert.Equal(new TimeSpan(0, 10, 9, 8, 7), dt.TestTimeSpan);
                Assert.Equal(-1.234F, dt.TestSingle);
                Assert.Equal(true, dt.TestBoolean);
                Assert.Equal((byte)255, dt.TestByte);
                Assert.Equal(Enum64.SomeValue, dt.Enum64);
                Assert.Equal(Enum32.SomeValue, dt.Enum32);
                Assert.Equal(Enum16.SomeValue, dt.Enum16);
                Assert.Equal(Enum8.SomeValue, dt.Enum8);
                Assert.Equal((ushort)1234, dt.TestUnsignedInt16);
                Assert.Equal(1234565789U, dt.TestUnsignedInt32);
                Assert.Equal(1234567890123456789UL, dt.TestUnsignedInt64);
                Assert.Equal('a', dt.TestCharacter);
                Assert.Equal((sbyte)-128, dt.TestSignedByte);
                Assert.Equal(EnumU64.SomeValue, dt.EnumU64);
                Assert.Equal(EnumU32.SomeValue, dt.EnumU32);
                Assert.Equal(EnumU16.SomeValue, dt.EnumU16);
                Assert.Equal(EnumS8.SomeValue, dt.EnumS8);
            }
        }
        
        [ConditionalFact]
        public override void Can_insert_and_read_back_all_nullable_data_types_with_values_set_to_non_null()
        {
            using (var context = CreateContext())
            {
                context.Set<BuiltInNullableDataTypes>().Add(
                    new BuiltInNullableDataTypes
                    {
                        Id = 101,
                        PartitionId = 101,
                        TestString = "TestString",
                        TestByteArray = new byte[] { 10, 9, 8, 7, 6 },
                        TestNullableInt16 = -1234,
                        TestNullableInt32 = -123456789,
                        TestNullableInt64 = -1234567890123456789L,
                        TestNullableDouble = -1.23456789,
                        TestNullableDecimal = -1234567890.01M,
                        TestNullableDateTime = DateTime.Parse("01/01/2000 12:34:56"),
                        TestNullableDateTimeOffset =
                            new DateTimeOffset(DateTime.Parse("01/01/2000 12:34:56"), TimeSpan.FromHours(-8.0)),
                        TestNullableTimeSpan = new TimeSpan(0, 10, 9, 8, 7),
                        TestNullableSingle = -1.234F,
                        TestNullableBoolean = false,
                        TestNullableByte = 255,
                        TestNullableUnsignedInt16 = 1234,
                        TestNullableUnsignedInt32 = 1234565789U,
                        TestNullableUnsignedInt64 = 1234567890123456789UL,
                        TestNullableCharacter = 'a',
                        TestNullableSignedByte = -128,
                        Enum64 = Enum64.SomeValue,
                        Enum32 = Enum32.SomeValue,
                        Enum16 = Enum16.SomeValue,
                        Enum8 = Enum8.SomeValue,
                        EnumU64 = EnumU64.SomeValue,
                        EnumU32 = EnumU32.SomeValue,
                        EnumU16 = EnumU16.SomeValue,
                        EnumS8 = EnumS8.SomeValue
                    });

                Assert.Equal(1, context.SaveChanges());
            }

            using (var context = CreateContext())
            {
                var dt = context.Set<BuiltInNullableDataTypes>().Where(ndt => ndt.Id == 101).ToList().Single();

                Assert.Equal("TestString", dt.TestString);
                Assert.Equal(new byte[] { 10, 9, 8, 7, 6 }, dt.TestByteArray);
                Assert.Equal((short)-1234, dt.TestNullableInt16);
                Assert.Equal(-123456789, dt.TestNullableInt32);
                Assert.Equal(-1234567890123456789L, dt.TestNullableInt64);
                // https://clickhouse.com/docs/en/sql-reference/data-types/float/
                Assert.Equal(-1.23456789, dt.TestNullableDouble!.Value, 8);
                Assert.Equal(-1234567890.01M, dt.TestNullableDecimal);
                Assert.Equal(DateTime.Parse("01/01/2000 12:34:56"), dt.TestNullableDateTime);
                Assert.Equal(new DateTimeOffset(DateTime.Parse("01/01/2000 12:34:56"), TimeSpan.FromHours(-8.0)), dt.TestNullableDateTimeOffset);
                Assert.Equal(new TimeSpan(0, 10, 9, 8, 7), dt.TestNullableTimeSpan);
                Assert.Equal(-1.234F, dt.TestNullableSingle);
                Assert.Equal(false, dt.TestNullableBoolean);
                Assert.Equal((byte)255, dt.TestNullableByte);
                Assert.Equal(Enum64.SomeValue, dt.Enum64);
                Assert.Equal(Enum32.SomeValue, dt.Enum32);
                Assert.Equal(Enum16.SomeValue, dt.Enum16);
                Assert.Equal(Enum8.SomeValue, dt.Enum8);
                Assert.Equal((ushort)1234, dt.TestNullableUnsignedInt16);
                Assert.Equal(1234565789U, dt.TestNullableUnsignedInt32);
                Assert.Equal(1234567890123456789UL, dt.TestNullableUnsignedInt64);
                Assert.Equal('a', dt.TestNullableCharacter);
                Assert.Equal((sbyte)-128, dt.TestNullableSignedByte);
                Assert.Equal(EnumU64.SomeValue, dt.EnumU64);
                Assert.Equal(EnumU32.SomeValue, dt.EnumU32);
                Assert.Equal(EnumU16.SomeValue, dt.EnumU16);
                Assert.Equal(EnumS8.SomeValue, dt.EnumS8);
            }
        }

        [ConditionalFact]
        public override void Can_insert_and_read_back_all_nullable_data_types_with_values_set_to_null()
        {
            try
            {
                base.Can_insert_and_read_back_all_nullable_data_types_with_values_set_to_null();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public class BuiltInDataTypesClickHouseFixture : BuiltInDataTypesFixtureBase
        {
            protected override ITestStoreFactory TestStoreFactory => ClickHouseTestStoreFactory.Instance;

            public override bool StrictEquality => false;

            public override bool SupportsAnsi => true;

            public override bool SupportsUnicodeToAnsiConversion => true;

            public override bool SupportsLargeStringComparisons => false;

            public override bool SupportsBinaryKeys => false;

            public override bool SupportsDecimalComparisons => true;

            public override DateTime DefaultDateTime => new ();

            public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
            {
                return base.AddOptions(builder).LogTo(s => Trace.WriteLine(s));
            }
        }
    }
}
