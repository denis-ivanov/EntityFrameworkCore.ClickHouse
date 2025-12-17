using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Extensions.DbFunctionsExtensions;

public sealed class ClickHouseUuidDbFunctionsExtensionsTest
{
    [Fact]
    public void ToUuid_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUuid("123"));
    }

    [Fact]
    public void ToUuidOrZero_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUuidOrZero("123"));
    }

    [Fact]
    public void ToUuidOrNull_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUuidOrNull("123"));
    }

    [Fact]
    public void ToUuidOrDefault_String_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUuidOrDefault("123"));
    }

    [Fact]
    public void ToUuidOrDefault_StringWithDefault_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => EF.Functions.ToUuidOrDefault("123", Guid.Empty));
    }
}
