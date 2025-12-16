using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseUInt32DbFunctionsExtensionsTest
{
    [Fact]
    public void ToUInt32_Int32_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt32(123));
    }

    [Fact]
    public void ToUInt32_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt32("123"));
    }

    [Fact]
    public void ToUInt32OrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt32OrZero("123"));
    }

    [Fact]
    public void ToUInt32OrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt32OrNull("123"));
    }

    [Fact]
    public void ToUInt32OrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt32OrDefault("123"));
    }

    [Fact]
    public void ToUInt32OrDefault_StringWithDefault_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUInt32OrDefault("123", 42u));
    }
}
