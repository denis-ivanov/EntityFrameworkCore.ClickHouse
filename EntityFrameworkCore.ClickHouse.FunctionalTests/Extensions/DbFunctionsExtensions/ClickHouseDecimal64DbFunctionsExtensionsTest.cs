using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseDecimal64DbFunctionsExtensionsTest
{
    [Fact]
    public void ToDecimal64_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal64("123.45", 3));
    }
    
    [Fact]
    public void ToDecimal64_Int32_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal64(123, 3));
    }
    
    [Fact]
    public void ToDecimal64OrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal64OrZero("123.45", 3));
    }
    
    [Fact]
    public void ToDecimal64OrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal64OrNull("123.45", 3));
    }
    
    [Fact]
    public void ToDecimal64OrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal64OrDefault("123.45", 3));
    }
    
    [Fact]
    public void ToDecimal64OrDefault_StringWithDefault_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal64OrDefault("123.45", 3, 42.0m));
    }
}
