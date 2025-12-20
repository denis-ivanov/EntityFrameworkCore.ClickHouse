using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.ClickHouse.Tests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseDecimal32DbFunctionsExtensionsTest
{
    [Fact]
    public void ToDecimal32_Int32_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal32(123, 3));
    }
    
    [Fact]
    public void ToDecimal32_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal32("123.45", 3));
    }
    
    [Fact]
    public void ToDecimal32OrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal32OrZero("123.45", 3));
    }
    
    [Fact]
    public void ToDecimal32OrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal32OrNull("123.45", 3));
    }
    
    [Fact]
    public void ToDecimal32OrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal32OrDefault("123.45", 3));
    }
    
    [Fact]
    public void ToDecimal32OrDefault_StringWithDefault_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal32OrDefault("123.45", 3, 42m));
    }
}
