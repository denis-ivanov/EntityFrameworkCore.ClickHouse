using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.ClickHouse.Tests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseDecimal128DbFunctionsExtensionsTest
{
    [Fact]
    public void ToDecimal128_Int32_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal128(123, 3));
    }

    [Fact]
    public void ToDecimal128_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal128("123.45", 3));
    }

    [Fact]
    public void ToDecimal128OrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal128OrZero("123.45", 3));
    }

    [Fact]
    public void ToDecimal128OrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal128OrNull("123.45", 3));
    }

    [Fact]
    public void ToDecimal128OrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal128OrDefault("123.45", 3));
    }

    [Fact]
    public void ToDecimal128OrDefault_StringWithDefault_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal128OrDefault("123.45", 3, 42m));
    }
}