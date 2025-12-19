using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseFloat64DbFunctionsExtensionsTest
{
    [Fact]
    public void ToFloat64_Int32_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToFloat64(123));
    }

    [Fact]
    public void ToFloat64_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToFloat64("123.45"));
    }

    [Fact]
    public void ToFloat64OrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToFloat64OrZero("123.45"));
    }

    [Fact]
    public void ToFloat64OrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToFloat64OrNull("123.45"));
    }

    [Fact]
    public void ToFloat64OrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToFloat64OrDefault("123.45"));
    }

    [Fact]
    public void ToFloat64OrDefault_StringWithDefault_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToFloat64OrDefault("123.45", 42.0));
    }
}
