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
    public void ToDateTime64_DateOnly_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64(new DateOnly(2025, 12, 16), 9));
    }

    [Fact]
    public void ToDateTime64_DateOnlyWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64(new DateOnly(2025, 12, 16), 9, "Asia/Istanbul"));
    }

    [Fact]
    public void ToDateTime64_Float_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64(123456789.123456789f, 9));
    }

    [Fact]
    public void ToDateTime64_FloatWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64(123456789.123456789f, 9, "Asia/Istanbul"));
    }

    [Fact]
    public void ToDateTime64OrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrZero("2025-12-16", 9));
    }

    [Fact]
    public void ToDateTime64OrZero_StringWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrZero("2025-12-16", 9, "Asia/Istanbul"));
    }
    
    [Fact]
    public void ToDateTime64OrZero_UInt_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrZero(123456789, 9));
    }

    [Fact]
    public void ToDateTime64OrZero_UIntWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrZero(123456789, 9, "Asia/Istanbul"));
    }

    [Fact]
    public void ToDateTime64OrZero_DateTime_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrZero(DateTime.Now, 9));
    }

    [Fact]
    public void ToDateTime64OrZero_DateTimeWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrZero(DateTime.Now, 9, "Asia/Istanbul"));
    }

    [Fact]
    public void ToDateTime64OrZero_Float_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrZero(123456789.123456789f, 9));
    }

    [Fact]
    public void ToDateTime64OrZero_FloatWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrZero(123456789.123456789f, 9, "Asia/Istanbul"));
    }

    [Fact]
    public void ToDateTime64OrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrNull("2025-12-16", 9));
    }

    [Fact]
    public void ToDateTime64OrNull_StringWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrNull("2025-12-16", 9, "Asia/Istanbul"));
    }

    [Fact]
    public void ToDateTime64OrNull_UInt_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrNull(123456789, 9));
    }

    [Fact]
    public void ToDateTime64OrNull_UIntWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrNull(123456789, 9, "Asia/Istanbul"));
    }

    [Fact]
    public void ToDateTime64OrNull_DateTime_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrNull(DateTime.Now, 9));
    }

    [Fact]
    public void ToDateTime64OrNull_DateTimeWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrNull(DateTime.Now, 9, "Asia/Istanbul"));
    }
    
    [Fact]
    public void ToDateTime64OrNull_Float_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrNull(123456789.123456789f, 9));
    }
    
    [Fact]
    public void ToDateTime64OrNull_FloatWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime64OrNull(123456789.123456789f, 9, "Asia/Istanbul"));
    }
}
