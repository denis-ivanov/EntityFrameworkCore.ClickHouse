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
        if (!designTime)
        {
            yield break;
        }

        var entityType = table.EntityTypeMappings.First().TypeBase;

        foreach (var annotation in entityType.GetAnnotations()
                     .Where(e => e.Name.StartsWith(ClickHouseAnnotationNames.Prefix)))
        {
            yield return annotation;
        }
    }

    public override IEnumerable<IAnnotation> For(IRelationalModel model, bool designTime)
    {
        if (!designTime)
        {
            yield break;
        }

        foreach (var annotation in model.GetAnnotations().Where(e => e.Name.StartsWith(ClickHouseAnnotationNames.Prefix)))
        {
            yield return annotation;
        }
    }
}
