using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseFloat32DbFunctionsExtensionsTest
{
    [Fact]
    public void ToFloat32_Int32_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToFloat32(123));
    }

    [Fact]
    public void ToFloat32_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToFloat32("123.45"));
    }

    [Fact]
    public void ToFloat32OrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToFloat32OrZero("123.45"));
    }

    [Fact]
    public void ToFloat32OrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToFloat32OrNull("123.45"));
    }

    [Fact]
    public void ToFloat32OrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToFloat32OrDefault("123.45"));
    }

    [Fact]
    public void ToFloat32OrDefault_StringWithDefault_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToFloat32OrDefault("123.45", 42.0f));
    }
}
