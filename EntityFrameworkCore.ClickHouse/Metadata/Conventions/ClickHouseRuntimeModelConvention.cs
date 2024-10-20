using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System.Collections.Generic;

namespace ClickHouse.EntityFrameworkCore.Metadata.Conventions;

public class ClickHouseRuntimeModelConvention : RelationalRuntimeModelConvention
{
    public ClickHouseRuntimeModelConvention(
        ProviderConventionSetBuilderDependencies dependencies, 
        RelationalConventionSetBuilderDependencies relationalDependencies) : base(dependencies, relationalDependencies)
    {
    }

    protected override void ProcessEntityTypeAnnotations(Dictionary<string, object> annotations, IEntityType entityType, RuntimeEntityType runtimeEntityType,
        bool runtime)
    {
        base.ProcessEntityTypeAnnotations(annotations, entityType, runtimeEntityType, runtime);

        if (!runtime)
        {
            annotations.Remove(ClickHouseAnnotationNames.MergeTreeEngine);
            annotations.Remove(ClickHouseAnnotationNames.OrderBy);
            annotations.Remove(ClickHouseAnnotationNames.PartitionBy);
            annotations.Remove(ClickHouseAnnotationNames.PrimaryKey);
            annotations.Remove(ClickHouseAnnotationNames.SampleBy);
        }
    }
}
