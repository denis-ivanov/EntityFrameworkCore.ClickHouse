using ClickHouse.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Collections.Generic;
using System.Reflection;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;

public class ClickHousePrecompiledQueryTestHelpers : PrecompiledQueryTestHelpers
{
    public static readonly ClickHousePrecompiledQueryTestHelpers Instance = new();

    protected override IEnumerable<MetadataReference> BuildProviderMetadataReferences()
    {
        yield return MetadataReference.CreateFromFile(typeof(ClickHouseOptionsExtension).Assembly.Location);
        yield return MetadataReference.CreateFromFile(Assembly.GetExecutingAssembly().Location);
    }
}
