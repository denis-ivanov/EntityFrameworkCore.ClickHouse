using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseDateDbFunctionsExtensionsTest
{
    [Fact]
    public void ToDate_Int32_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDate(123));
    } 
    
    [Fact]
    public void ToDate_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDate("2025-12-16"));
    }
    
    [Fact]
    public void ToDate_DateTime_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDate(DateTime.Now));
    }

    [Fact]
    public void ToDate_Int32WithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDate(123, "Asia/Istanbul"));
    }

    [Fact]
    public void ToDate_StringWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDate("2025-12-16", "Asia/Istanbul"));
    }

    [Fact]
    public void ToDate_DateTimeWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDate(DateTime.Now, "Asia/Istanbul"));
    }

    [Fact]
    public void ToDateOrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateOrZero("2025-12-16"));
    }

    [Fact]
    public void ToDateOrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateOrNull("2025-12-16"));
    }

    [Fact]
    public void ToDateOrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateOrDefault("2025-12-16"));
    }

    [Fact]
    public void ToDateOrDefault_StringWithDefault_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateOrDefault("2025-12-16", new DateOnly(2025, 12, 16)));
    }
}
