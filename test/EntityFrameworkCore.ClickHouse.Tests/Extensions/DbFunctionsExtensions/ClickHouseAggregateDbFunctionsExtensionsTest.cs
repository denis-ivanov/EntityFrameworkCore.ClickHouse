using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.ClickHouse.Tests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseAggregateDbFunctionsExtensionsTest
{
    [Fact]
    public void Any_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.Any("test"));
    }

    [Fact]
    public void AnyRespectNulls_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.AnyRespectNulls("test"));
    }
}
