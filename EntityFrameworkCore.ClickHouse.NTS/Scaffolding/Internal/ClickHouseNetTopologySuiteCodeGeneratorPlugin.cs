using ClickHouse.EntityFrameworkCore.Infrastructure;
using EntityFrameworkCore.ClickHouse.NTS.Extensions;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;
using System.Reflection;

namespace EntityFrameworkCore.ClickHouse.NTS.Scaffolding.Internal;

public class ClickHouseNetTopologySuiteCodeGeneratorPlugin : ProviderCodeGeneratorPlugin
{
    private static readonly MethodInfo UseNetTopologySuiteMethodInfo
        = typeof(ClickHouseNetTopologySuiteDbContextOptionsBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseNetTopologySuiteDbContextOptionsBuilderExtensions.UseNetTopologySuite),
            new[] { typeof(ClickHouseDbContextOptionsBuilder) })!;

    public override MethodCallCodeFragment GenerateProviderOptions()
        => new(UseNetTopologySuiteMethodInfo);
}
