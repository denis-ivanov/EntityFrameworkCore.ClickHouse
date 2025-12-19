using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseDateTimeDbFunctionsExtensionsTest
{
    [Fact]
    public void ToDateTime_Int32_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime(123));
    }
    
    [Fact]
    public void ToDateTime_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime("2025-12-16"));
    }

    [Fact]
    public void ToDateTime_DateOnly_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime(new DateOnly(2025, 12, 16)));
    }

    [Fact]
    public void ToDateTime_Int32WithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime(123, "Asia/Istanbul"));
    }

    [Fact]
    public void ToDateTime_StringWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime("2025-12-16", "Asia/Istanbul"));
    }

    [Fact]
    public void ToDateTime_DateOnlyWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTime(new DateOnly(2025, 12, 16), "Asia/Istanbul"));
    }

    [Fact]
    public void ToDateTimeOrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTimeOrZero("2025-12-16"));
    }

    [Fact]
    public void ToDateTimeOrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTimeOrNull("2025-12-16"));
    }

    [Fact]
    public void ToDateTimeOrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTimeOrDefault("2025-12-16"));
    }

    [Fact]
    public void ToDateTimeOrDefault_StringWithTimeZone_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTimeOrDefault("2025-12-16", "Asia/Nicosia"));
    }
    
    [Fact]
    public void ToDateTimeOrDefault_StringWithDefaultValue_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDateTimeOrDefault("2025-12-16", "Asia/Nicosia", DateTime.Now));
    }
}
