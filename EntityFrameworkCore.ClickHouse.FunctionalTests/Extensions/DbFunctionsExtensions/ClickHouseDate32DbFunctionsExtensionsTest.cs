namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Extensions.DbFunctionsExtensions;

using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

public sealed class ClickHouseDate32DbFunctionsExtensionsTest
{
    [Fact]
    public void ToDate32_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDate32("2025-12-16"));
    }

    [Fact]
    public void ToDate32_UInt_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDate32(123456789u));
    }

    [Fact]
    public void ToDate32OrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDate32OrZero("2025-12-16"));
    }

    [Fact]
    public void ToDate32OrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDate32OrNull("2025-12-16"));
    }

    [Fact]
    public void ToDate32OrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDate32OrDefault("2025-12-16"));
    }

    [Fact]
    public void ToDate32OrDefault_StringWithDefault_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDate32OrDefault("2025-12-16", new DateOnly(2025, 12, 16)));
    }
}
