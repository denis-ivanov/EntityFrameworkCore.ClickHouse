using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.ClickHouse.Tests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseUInt8DbFunctionsExtensionsTest
{
    [Fact]
    public void ToUInt8_Int32_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt8(123));
    }

    [Fact]
    public void ToUInt8_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt8("123"));
    }

    [Fact]
    public void ToUInt8OrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt8OrZero("123"));
    }

    [Fact]
    public void ToUInt8OrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt8OrNull("123"));
    }

    [Fact]
    public void ToUInt8OrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt8OrDefault("123"));
    }

    [Fact]
    public void ToUInt8OrDefault_StringWithDefault_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt8OrDefault("123", (byte)42));
    }
}
