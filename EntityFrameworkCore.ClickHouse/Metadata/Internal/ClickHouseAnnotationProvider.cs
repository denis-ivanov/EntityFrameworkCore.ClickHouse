using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Linq;

namespace ClickHouse.EntityFrameworkCore.Metadata.Internal;

public class ClickHouseAnnotationProvider : RelationalAnnotationProvider
{
    public ClickHouseAnnotationProvider(RelationalAnnotationProviderDependencies dependencies) : base(dependencies)
    {
    }

    public override IEnumerable<IAnnotation> For(ITable table, bool designTime)
    {
        var entityType = table.EntityTypeMappings.First().TypeBase;

        foreach (var annotation in entityType.GetAnnotations()
                     .Where(e => e.Name.StartsWith(ClickHouseAnnotationNames.Prefix)))
        {
            yield return annotation;
        }
    }
}
