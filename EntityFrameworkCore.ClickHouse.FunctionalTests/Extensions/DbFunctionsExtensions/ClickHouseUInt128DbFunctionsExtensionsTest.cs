using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseUInt128DbFunctionsExtensionsTest
{
    [Fact]
    public void ToUInt128_Number_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt128(123));
    }

    [Fact]
    public void ToUInt128_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt128("123"));
    }

    [Fact]
    public void ToUInt128OrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt128OrZero("123"));
    }

    [Fact]
    public void ToUInt128OrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt128OrNull("123"));
    }

    [Fact]
    public void ToUInt128OrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt128OrDefault("123"));
    }

    [Fact]
    public void ToUInt128OrDefault_StringWithDefault_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt128OrDefault("123", UInt128.One));
    }
}
