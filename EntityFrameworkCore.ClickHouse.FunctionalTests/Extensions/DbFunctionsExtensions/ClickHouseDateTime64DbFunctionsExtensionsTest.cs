using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseDateTime64DbFunctionsExtensionsTest
{
    [Fact]
    public void ToDateTime64_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64("2025-12-16", 9));
    }

    [Fact]
    public void ToDateTime64_StringWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64("2025-12-16", 9, "Asia/Istanbul"));
    }

    [Fact]
    public void ToDateTime64_UInt_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64(123456789, 9));
    }

    [Fact]
    public void ToDateTime64_UIntWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64(123456789, 9, "Asia/Istanbul"));
    }

    [Fact]
    public void DateTime64_DateOnly_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64(new DateOnly(2025, 12, 16), 9));
    }

    [Fact]
    public void DateTime64_DateOnlyWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64(new DateOnly(2025, 12, 16), 9, "Asia/Istanbul"));
    }

    [Fact]
    public void DateTime64_Float_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64(123456789.123456789f, 9));
    }

    [Fact]
    public void DateTime64_FloatWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64(123456789.123456789f, 9, "Asia/Istanbul"));
    }
}
