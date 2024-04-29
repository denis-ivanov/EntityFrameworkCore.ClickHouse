using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;
using System;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Scaffolding.Internal;

public class ClickHouseCodeGenerator : ProviderCodeGenerator
{
    private static readonly MethodInfo UseClickHouseMethodInfo
        = typeof(ClickHouseDbContextOptionsBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseDbContextOptionsBuilderExtensions.UseClickHouse),
            [typeof(DbContextOptionsBuilder), typeof(string), typeof(Action<ClickHouseDbContextOptionsBuilder>)])!;

    public ClickHouseCodeGenerator(ProviderCodeGeneratorDependencies dependencies)
        : base(dependencies)
    {
    }

    public override MethodCallCodeFragment GenerateUseProvider(
        string connectionString,
        MethodCallCodeFragment? providerOptions)
        => new(
            UseClickHouseMethodInfo,
            providerOptions == null
                ? new object[] { connectionString }
                : new object[] { connectionString, new NestedClosureCodeFragment("x", providerOptions) });
}
