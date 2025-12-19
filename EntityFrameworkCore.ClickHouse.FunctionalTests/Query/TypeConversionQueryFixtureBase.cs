using EntityFrameworkCore.ClickHouse.FunctionalTests.TestModels.TypeConversion;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TypeConversionQueryFixtureBase<TModelCustomizer> : SharedStoreFixtureBase<TypeConversionDbContext> where TModelCustomizer : ITestModelCustomizer, new()
{
    protected override string StoreName => "TypeConversion";

    protected override ITestStoreFactory TestStoreFactory => ClickHouseTypeConversionTestStoreFactory.Instance;

    public TestSqlLoggerFactory TestSqlLoggerFactory => (TestSqlLoggerFactory)ListLoggerFactory;

    protected override async Task SeedAsync(TypeConversionDbContext context)
    {
        var entity = new TypeConversion
        {
            Id = 1,
            Int8AsFloat = Convert.ToSingle(sbyte.MaxValue),
            Int8AsStringValid = sbyte.MinValue.ToString(CultureInfo.InvariantCulture),
            Nan = "abc",
            Int16AsFloat = Convert.ToSingle(short.MaxValue),
            Int16AsStringValid = short.MinValue.ToString(CultureInfo.InvariantCulture),
            Int32AsFloat = Convert.ToSingle(int.MaxValue),
            Int32AsStringValid = int.MinValue.ToString(CultureInfo.InvariantCulture),
            Int64AsFloat = Convert.ToSingle(long.MaxValue),
            Int64AsStringValid = long.MinValue.ToString(CultureInfo.InvariantCulture),
            Int128AsFloat = 42f,
            Int128AsStringValid = Convert.ToString(-42f, CultureInfo.InvariantCulture),
            UInt8AsFloat = Convert.ToSingle(byte.MaxValue),
            UInt8AsStringValid = byte.MinValue.ToString(CultureInfo.InvariantCulture),
            UInt16AsFloat = Convert.ToSingle(ushort.MaxValue),
            UInt16AsStringValid = ushort.MinValue.ToString(CultureInfo.InvariantCulture),
            UInt32AsFloat = Convert.ToSingle(uint.MaxValue),
            UInt32AsStringValid = uint.MinValue.ToString(CultureInfo.InvariantCulture),
            UInt64AsFloat = Convert.ToSingle(ulong.MaxValue),
            UInt64AsStringValid = ulong.MinValue.ToString(CultureInfo.InvariantCulture),
            GuidAsStringValid = Guid.NewGuid().ToString()
        };

        await context.TypeConversions.AddAsync(entity);
        await base.SeedAsync(context);
    }
}
