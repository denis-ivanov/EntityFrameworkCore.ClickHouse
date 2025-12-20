using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.ClickHouse.Tests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseUInt16DbFunctionsExtensionsTest
{
    [Fact]
    public void ToUInt16_Int32_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt16(12));
    }

    [Fact]
    public void ToUInt16_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt16("123"));
    }

    [Fact]
    public void ToUInt16OrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt16OrZero("123"));
    }

    [Fact]
    public void ToUInt16OrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt16OrNull("123"));
    }

    [Fact]
    public void ToUInt16OrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt16OrDefault("123"));
    }

    [Fact]
    public void ToUInt16OrDefault_StringWithDefault_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt16OrDefault("123", (ushort)42));
    }
}
