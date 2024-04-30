using ClickHouse.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Design.Internal;

public class ClickHouseAnnotationCodeGenerator : AnnotationCodeGenerator
{
    private static readonly MethodInfo HasMergeTreeEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.HasMergeTreeEngine), [typeof(EntityTypeBuilder)])!;

    public ClickHouseAnnotationCodeGenerator(AnnotationCodeGeneratorDependencies dependencies) : base(dependencies)
    {
    }

    protected override MethodCallCodeFragment GenerateFluentApi(IEntityType entityType, IAnnotation annotation)
    {
        if (annotation.Name == ClickHouseAnnotationNames.TableEngine)
        {
            if ((string)annotation.Value == ClickHouseAnnotationNames.MergeTreeEngine)
            {
               // return new MethodCallCodeFragment(HasMergeTreeEngineMethodInfo);
            }
        }

        return base.GenerateFluentApi(entityType, annotation);
    }
}
