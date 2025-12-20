using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.ClickHouse.Tests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseUInt64DbFunctionsExtensionsTest
{
    [Fact]
    public void ToUInt64_Int32_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt64(123));
    }

    [Fact]
    public void ToUInt64_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt64("123"));
    }

    [Fact]
    public void ToUInt64OrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt64OrZero("123"));
    }

    [Fact]
    public void ToUInt64OrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt64OrNull("123"));
    }

    [Fact]
    public void ToUInt64OrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt64OrDefault("123"));
    }

    [Fact]
    public void ToUInt64OrDefault_StringWithDefault_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt64OrDefault("123", 42ul));
    }
}
