using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.ClickHouse.Tests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseDecimal256DbFunctionsExtensionsTest
{
    [Fact]
    public void ToDecimal256_Int32_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal256(123, 3));
    }

    [Fact]
    public void ToDecimal256_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal256("123.45", 3));
    }

    [Fact]
    public void ToDecimal256OrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal256OrZero("123.45", 3));
    }

    [Fact]
    public void ToDecimal256OrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal256OrNull("123.45", 3));
    }

    [Fact]
    public void ToDecimal256OrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal256OrDefault("123.45", 3));
    }

    [Fact]
    public void ToDecimal256OrDefault_StringWithDefault_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToDecimal256OrDefault("123.45", 3, 42m));
    }
    
    [Fact]
    public void DivideDecimal_Decimal_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.DivideDecimal(10.5m, 2.0m));
    }
    
    [Fact]
    public void DivideDecimal_DecimalWithPrecision_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.DivideDecimal(10.5m, 2.0m, 3));
    }
}
