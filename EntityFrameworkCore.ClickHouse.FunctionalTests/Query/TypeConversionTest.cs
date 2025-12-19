using EntityFrameworkCore.ClickHouse.FunctionalTests.TestModels.TypeConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public sealed class TypeConversionTest : IClassFixture<TypeConversionQueryFixtureBase<NoopModelCustomizer>>
{
    public TypeConversionTest(
        TypeConversionQueryFixtureBase<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [Fact]
    public async Task ToBool_Number_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToBool = EF.Functions.ToBool(e.Int8AsFloat)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toBool("t"."Int8AsFloat") AS "ToBool"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToBool_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToBool = EF.Functions.ToBool(e.Int8AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toBool("t"."Int8AsStringValid") AS "ToBool"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt8_Float_ShouldConvert()
    {
        var context = CreateContext();
        
        await context.TypeConversions
            .Select(e => new
            {
                ToInt8 = EF.Functions.ToInt8(e.Int8AsFloat)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt8("t"."Int8AsFloat") AS "ToInt8"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt8_String_ShouldConvert()
    {
        var context = CreateContext();
        
        await context.TypeConversions
            .Select(e => new
            {
                ToInt8 = EF.Functions.ToInt8(e.Int8AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt8("t"."Int8AsStringValid") AS "ToInt8"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt8OrZero_String_ShouldConvert()
    {
        var context = CreateContext();
        
        await context.TypeConversions
            .Select(e => new
            {
                ToInt8OrZero = EF.Functions.ToInt8OrZero(e.Int8AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt8OrZero("t"."Int8AsStringValid") AS "ToInt8OrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt8OrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt8OrNull = EF.Functions.ToInt8OrNull(e.Int8AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt8OrNull("t"."Int8AsStringValid") AS "ToInt8OrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt8OrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt8OrDefault = EF.Functions.ToInt8OrDefault(e.Int8AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt8OrDefault("t"."Int8AsStringValid") AS "ToInt8OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt8OrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt8OrDefault = EF.Functions.ToInt8OrDefault(e.Int8AsStringValid, EF.Functions.ToInt8(e.Int8AsFloat))
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt8OrDefault("t"."Int8AsStringValid", toInt8("t"."Int8AsFloat")) AS "ToInt8OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt16_Float_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt16 = EF.Functions.ToInt16(e.Int16AsFloat)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt16("t"."Int16AsFloat") AS "ToInt16"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt16_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt16 = EF.Functions.ToInt16(e.Int16AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt16("t"."Int16AsStringValid") AS "ToInt16"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt16OrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt16OrZero = EF.Functions.ToInt16OrZero(e.Int16AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt16OrZero("t"."Int16AsStringValid") AS "ToInt16OrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt16OrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt16OrNull = EF.Functions.ToInt16OrNull(e.Int16AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt16OrNull("t"."Int16AsStringValid") AS "ToInt16OrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt16OrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt16OrDefault = EF.Functions.ToInt16OrDefault(e.Int16AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt16OrDefault("t"."Int16AsStringValid") AS "ToInt16OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt16OrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt16OrDefault = EF.Functions.ToInt16OrDefault(e.Int16AsStringValid, EF.Functions.ToInt16(e.Int16AsFloat))
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt16OrDefault("t"."Int16AsStringValid", toInt16("t"."Int16AsFloat")) AS "ToInt16OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt32_Float_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt32 = EF.Functions.ToInt32(e.Int32AsFloat)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt32("t"."Int32AsFloat") AS "ToInt32"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt32_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt32 = EF.Functions.ToInt32(e.Int32AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt32("t"."Int32AsStringValid") AS "ToInt32"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt32OrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt32OrZero = EF.Functions.ToInt32OrZero(e.Int32AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt32OrZero("t"."Int32AsStringValid") AS "ToInt32OrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt32OrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt32OrNull = EF.Functions.ToInt32OrNull(e.Int32AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt32OrNull("t"."Int32AsStringValid") AS "ToInt32OrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt32OrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt32OrDefault = EF.Functions.ToInt32OrDefault(e.Int32AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt32OrDefault("t"."Int32AsStringValid") AS "ToInt32OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt32OrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt32OrDefault = EF.Functions.ToInt32OrDefault(e.Int32AsStringValid, EF.Functions.ToInt32(e.Int32AsFloat))
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt32OrDefault("t"."Int32AsStringValid", toInt32("t"."Int32AsFloat")) AS "ToInt32OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt64_Float_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt64 = EF.Functions.ToInt64(e.Int64AsFloat)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt64("t"."Int64AsFloat") AS "ToInt64"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt64_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt64 = EF.Functions.ToInt64(e.Int64AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt64("t"."Int64AsStringValid") AS "ToInt64"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt64OrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt64OrZero = EF.Functions.ToInt64OrZero(e.Int64AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt64OrZero("t"."Int64AsStringValid") AS "ToInt64OrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt64OrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt64OrNull = EF.Functions.ToInt64OrNull(e.Int64AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt64OrNull("t"."Int64AsStringValid") AS "ToInt64OrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt64OrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt64OrDefault = EF.Functions.ToInt64OrDefault(e.Int64AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt64OrDefault("t"."Int64AsStringValid") AS "ToInt64OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt64OrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt64OrDefault = EF.Functions.ToInt64OrDefault(e.Int64AsStringValid, EF.Functions.ToInt64(e.Int64AsFloat))
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt64OrDefault("t"."Int64AsStringValid", toInt64("t"."Int64AsFloat")) AS "ToInt64OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt128_Float_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt128 = EF.Functions.ToInt128(e.Int128AsFloat)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt128("t"."Int128AsFloat") AS "ToInt128"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt128_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt128 = EF.Functions.ToInt128(e.Int128AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt128("t"."Int128AsStringValid") AS "ToInt128"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt128OrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt128OrZero = EF.Functions.ToInt128OrZero(e.Int128AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt128OrZero("t"."Int128AsStringValid") AS "ToInt128OrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt128OrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt128OrNull = EF.Functions.ToInt128OrNull(e.Int128AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt128OrNull("t"."Int128AsStringValid") AS "ToInt128OrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt128OrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt128OrDefault = EF.Functions.ToInt128OrDefault(e.Int128AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt128OrDefault("t"."Int128AsStringValid") AS "ToInt128OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToInt128OrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToInt128OrDefault = EF.Functions.ToInt128OrDefault(e.Int128AsStringValid, EF.Functions.ToInt128(e.Int128AsFloat))
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toInt128OrDefault("t"."Int128AsStringValid", toInt128("t"."Int128AsFloat")) AS "ToInt128OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt8_Float_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt8 = EF.Functions.ToUInt8(e.UInt8AsFloat)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt8("t"."UInt8AsFloat") AS "ToUInt8"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt8_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt8 = EF.Functions.ToUInt8(e.UInt8AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt8("t"."UInt8AsStringValid") AS "ToUInt8"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt8OrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt8OrZero = EF.Functions.ToUInt8OrZero(e.UInt8AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt8OrZero("t"."UInt8AsStringValid") AS "ToUInt8OrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt8OrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt8OrNull = EF.Functions.ToUInt8OrNull(e.UInt8AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt8OrNull("t"."UInt8AsStringValid") AS "ToUInt8OrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt8OrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt8OrDefault = EF.Functions.ToUInt8OrDefault(e.UInt8AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt8OrDefault("t"."UInt8AsStringValid") AS "ToUInt8OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt8OrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt8OrDefault = EF.Functions.ToUInt8OrDefault(e.UInt8AsStringValid, EF.Functions.ToUInt8(e.UInt8AsFloat))
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt8OrDefault("t"."UInt8AsStringValid", toUInt8("t"."UInt8AsFloat")) AS "ToUInt8OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt16_Float_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt16 = EF.Functions.ToUInt16(e.UInt16AsFloat)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt16("t"."UInt16AsFloat") AS "ToUInt16"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt16_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt16 = EF.Functions.ToUInt16(e.UInt16AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt16("t"."UInt16AsStringValid") AS "ToUInt16"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt16OrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt16OrZero = EF.Functions.ToUInt16OrZero(e.UInt16AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt16OrZero("t"."UInt16AsStringValid") AS "ToUInt16OrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt16OrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt16OrNull = EF.Functions.ToUInt16OrNull(e.UInt16AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt16OrNull("t"."UInt16AsStringValid") AS "ToUInt16OrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt16OrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt16OrDefault = EF.Functions.ToUInt16OrDefault(e.UInt16AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt16OrDefault("t"."UInt16AsStringValid") AS "ToUInt16OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt16OrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt16OrDefault = EF.Functions.ToUInt16OrDefault(e.UInt16AsStringValid, EF.Functions.ToUInt16(e.UInt16AsFloat))
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt16OrDefault("t"."UInt16AsStringValid", toUInt16("t"."UInt16AsFloat")) AS "ToUInt16OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt32_Float_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt32 = EF.Functions.ToUInt32(e.UInt32AsFloat)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt32("t"."UInt32AsFloat") AS "ToUInt32"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt32_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt32 = EF.Functions.ToUInt32(e.UInt32AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt32("t"."UInt32AsStringValid") AS "ToUInt32"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt32OrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt32OrZero = EF.Functions.ToUInt32OrZero(e.UInt32AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt32OrZero("t"."UInt32AsStringValid") AS "ToUInt32OrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt32OrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt32OrNull = EF.Functions.ToUInt32OrNull(e.UInt32AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt32OrNull("t"."UInt32AsStringValid") AS "ToUInt32OrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt32OrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt32OrDefault = EF.Functions.ToUInt32OrDefault(e.UInt32AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt32OrDefault("t"."UInt32AsStringValid") AS "ToUInt32OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt32OrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt32OrDefault = EF.Functions.ToUInt32OrDefault(e.UInt32AsStringValid, EF.Functions.ToUInt32(e.UInt32AsFloat))
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt32OrDefault("t"."UInt32AsStringValid", toUInt32("t"."UInt32AsFloat")) AS "ToUInt32OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt64_Float_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt64 = EF.Functions.ToUInt64(e.UInt64AsFloat)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt64("t"."UInt64AsFloat") AS "ToUInt64"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt64_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt64 = EF.Functions.ToUInt64(e.UInt64AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt64("t"."UInt64AsStringValid") AS "ToUInt64"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt64OrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt64OrZero = EF.Functions.ToUInt64OrZero(e.UInt64AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt64OrZero("t"."UInt64AsStringValid") AS "ToUInt64OrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt64OrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt64OrNull = EF.Functions.ToUInt64OrNull(e.UInt64AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt64OrNull("t"."UInt64AsStringValid") AS "ToUInt64OrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt64OrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt64OrDefault = EF.Functions.ToUInt64OrDefault(e.UInt64AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt64OrDefault("t"."UInt64AsStringValid") AS "ToUInt64OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt64OrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt64OrDefault = EF.Functions.ToUInt64OrDefault(e.UInt64AsStringValid, EF.Functions.ToUInt64(e.UInt64AsFloat))
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt64OrDefault("t"."UInt64AsStringValid", toUInt64("t"."UInt64AsFloat")) AS "ToUInt64OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }
    
    [Fact]
    public async Task ToUInt128_Float_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt128 = EF.Functions.ToUInt128(e.UInt128AsFloat)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt128("t"."UInt128AsFloat") AS "ToUInt128"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt128_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt128 = EF.Functions.ToUInt128(e.UInt128AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt128("t"."UInt128AsStringValid") AS "ToUInt128"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt128OrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt128OrZero = EF.Functions.ToUInt128OrZero(e.UInt128AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt128OrZero("t"."UInt128AsStringValid") AS "ToUInt128OrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt128OrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt128OrNull = EF.Functions.ToUInt128OrNull(e.UInt128AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt128OrNull("t"."UInt128AsStringValid") AS "ToUInt128OrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt128OrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt128OrDefault = EF.Functions.ToUInt128OrDefault(e.UInt128AsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt128OrDefault("t"."UInt128AsStringValid") AS "ToUInt128OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToUInt128OrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUInt128OrDefault = EF.Functions.ToUInt128OrDefault(e.UInt128AsStringValid, EF.Functions.ToUInt128(e.UInt128AsFloat))
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUInt128OrDefault("t"."UInt128AsStringValid", toUInt128("t"."UInt128AsFloat")) AS "ToUInt128OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToGuid_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUuid = EF.Functions.ToUuid(e.GuidAsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUUID("t"."GuidAsStringValid") AS "ToUuid"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToGuidOrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUuidOrZero = EF.Functions.ToUuidOrZero(e.GuidAsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUUIDOrZero("t"."GuidAsStringValid") AS "ToUuidOrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToGuidOrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUuidOrNull = EF.Functions.ToUuidOrNull(e.GuidAsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUUIDOrNull("t"."GuidAsStringValid") AS "ToUuidOrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToGuidOrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUuidOrDefault = EF.Functions.ToUuidOrDefault(e.GuidAsStringValid)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUUIDOrDefault("t"."GuidAsStringValid") AS "ToUuidOrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToGuidOrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToUuidOrDefault = EF.Functions.ToUuidOrDefault(e.GuidAsStringValid, Guid.Empty)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toUUIDOrDefault("t"."GuidAsStringValid", toUUID('00000000-0000-0000-0000-000000000000')) AS "ToUuidOrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal32_Number_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal32Num = EF.Functions.ToDecimal32(e.Int8AsFloat, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal32("t"."Int8AsFloat", 2) AS "ToDecimal32Num"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal32OrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal32OrZero = EF.Functions.ToDecimal32OrZero(e.Int8AsStringValid, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal32OrZero("t"."Int8AsStringValid", 2) AS "ToDecimal32OrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal32OrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal32OrNull = EF.Functions.ToDecimal32OrNull(e.Int8AsStringValid, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal32OrNull("t"."Int8AsStringValid", 2) AS "ToDecimal32OrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal32OrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal32OrDefault = EF.Functions.ToDecimal32OrDefault(e.Int8AsStringValid, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal32OrDefault("t"."Int8AsStringValid", 2) AS "ToDecimal32OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal32OrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal32OrDefault = EF.Functions.ToDecimal32OrDefault(e.Int8AsStringValid, 2, 42)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal32OrDefault("t"."Int8AsStringValid", 2, toDecimal32(42, 2)) AS "ToDecimal32OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal64_Number_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal64Num = EF.Functions.ToDecimal64(e.Int16AsFloat, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal64("t"."Int16AsFloat", 2) AS "ToDecimal64Num"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal64OrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal64OrZero = EF.Functions.ToDecimal64OrZero(e.Int16AsStringValid, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal64OrZero("t"."Int16AsStringValid", 2) AS "ToDecimal64OrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal64OrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal64OrNull = EF.Functions.ToDecimal64OrNull(e.Int16AsStringValid, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal64OrNull("t"."Int16AsStringValid", 2) AS "ToDecimal64OrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal64OrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal64OrDefault = EF.Functions.ToDecimal64OrDefault(e.Int16AsStringValid, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal64OrDefault("t"."Int16AsStringValid", 2) AS "ToDecimal64OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal64OrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal64OrDefault = EF.Functions.ToDecimal64OrDefault(e.Int16AsStringValid, 2, 42)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal64OrDefault("t"."Int16AsStringValid", 2, toDecimal64(42, 2)) AS "ToDecimal64OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal128_Number_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal128Num = EF.Functions.ToDecimal128(e.Int32AsFloat, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal128("t"."Int32AsFloat", 2) AS "ToDecimal128Num"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal128OrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal128OrZero = EF.Functions.ToDecimal128OrZero(e.Int32AsStringValid, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal128OrZero("t"."Int32AsStringValid", 2) AS "ToDecimal128OrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal128OrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal128OrNull = EF.Functions.ToDecimal128OrNull(e.Int32AsStringValid, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal128OrNull("t"."Int32AsStringValid", 2) AS "ToDecimal128OrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal128OrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal128OrDefault = EF.Functions.ToDecimal128OrDefault(e.Int32AsStringValid, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal128OrDefault("t"."Int32AsStringValid", 2) AS "ToDecimal128OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal128OrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal128OrDefault = EF.Functions.ToDecimal128OrDefault(e.Int32AsStringValid, 2, 42)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal128OrDefault("t"."Int32AsStringValid", 2, toDecimal128(42, 2)) AS "ToDecimal128OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal256_Number_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal256Num = EF.Functions.ToDecimal256(e.Int64AsFloat, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal256("t"."Int64AsFloat", 2) AS "ToDecimal256Num"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal256OrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal256OrZero = EF.Functions.ToDecimal256OrZero(e.Int64AsStringValid, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal256OrZero("t"."Int64AsStringValid", 2) AS "ToDecimal256OrZero"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal256OrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal256OrNull = EF.Functions.ToDecimal256OrNull(e.Int64AsStringValid, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal256OrNull("t"."Int64AsStringValid", 2) AS "ToDecimal256OrNull"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal256OrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal256OrDefault = EF.Functions.ToDecimal256OrDefault(e.Int64AsStringValid, 2)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal256OrDefault("t"."Int64AsStringValid", 2) AS "ToDecimal256OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDecimal256OrDefault_StringWithDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new
            {
                ToDecimal256OrDefault = EF.Functions.ToDecimal256OrDefault(e.Int64AsStringValid, 2, 42)
            })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDecimal256OrDefault("t"."Int64AsStringValid", 2, toDecimal256(42, 2)) AS "ToDecimal256OrDefault"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDate_Float_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new { ToDate = EF.Functions.ToDate(e.DateAsFloat32) })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDate("t"."DateAsFloat32") AS "ToDate"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDate_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new { ToDate = EF.Functions.ToDate(e.DateAsStringValid) })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDate("t"."DateAsStringValid") AS "ToDate"
            FROM "TypeConversions" AS "t"
            """);
    }
    
    [Fact]
    public async Task ToDate_DateTime_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new { ToDate = EF.Functions.ToDate(e.DateAsDateTime) })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDate("t"."DateAsDateTime") AS "ToDate"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDate_FloatWithTimeZone_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new { ToDate = EF.Functions.ToDate(e.DateAsFloat32, "Asia/Nicosia") })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDate("t"."DateAsFloat32", 'Asia/Nicosia') AS "ToDate"
            FROM "TypeConversions" AS "t"
            """);
    }
    
    [Fact]
    public async Task ToDate_StringWithTimeZone_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new { ToDate = EF.Functions.ToDate(e.DateAsStringValid, "Asia/Nicosia") })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDate("t"."DateAsStringValid", 'Asia/Nicosia') AS "ToDate"
            FROM "TypeConversions" AS "t"
            """);
    }
    
    [Fact]
    public async Task ToDate_DateTimeWithTimeZone_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new { ToDate = EF.Functions.ToDate(e.DateAsDateTime, "Asia/Nicosia") })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDate("t"."DateAsDateTime", 'Asia/Nicosia') AS "ToDate"
            FROM "TypeConversions" AS "t"
            """);
    }

    [Fact]
    public async Task ToDateOrZero_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new { ToDate = EF.Functions.ToDateOrZero(e.DateAsStringValid) })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDateOrZero("t"."DateAsStringValid") AS "ToDate"
            FROM "TypeConversions" AS "t"
            """);
    }
    
    [Fact]
    public async Task ToDateOrNull_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new { ToDate = EF.Functions.ToDateOrNull(e.DateAsStringValid) })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDateOrNull("t"."DateAsStringValid") AS "ToDate"
            FROM "TypeConversions" AS "t"
            """);
    }
    
    [Fact]
    public async Task ToDateOrDefault_String_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new { ToDate = EF.Functions.ToDateOrDefault(e.DateAsStringValid) })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDateOrDefault("t"."DateAsStringValid") AS "ToDate"
            FROM "TypeConversions" AS "t"
            """);
    }
    
    [Fact]
    public async Task ToDateOrDefault_StringDefault_ShouldConvert()
    {
        var context = CreateContext();

        await context.TypeConversions
            .Select(e => new { ToDate = EF.Functions.ToDateOrDefault(e.DateAsStringValid, DateOnly.FromDateTime(DateTime.Now)) })
            .ToArrayAsync();

        AssertSql(
            """
            SELECT toDateOrDefault("t"."DateAsStringValid", toDate(now())) AS "ToDate"
            FROM "TypeConversions" AS "t"
            """);

    }
    
    private TypeConversionQueryFixtureBase<NoopModelCustomizer> Fixture { get; }

    private void AssertSql(params string[] expected) => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);

    private TypeConversionDbContext CreateContext() => Fixture.CreateContext();
}
