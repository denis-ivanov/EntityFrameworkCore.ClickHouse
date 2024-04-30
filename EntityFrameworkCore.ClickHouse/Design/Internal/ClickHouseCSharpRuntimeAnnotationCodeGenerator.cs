using ClickHouse.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClickHouse.EntityFrameworkCore.Design.Internal;

#pragma warning disable EF1001 // Internal EF Core API usage.
public class ClickHouseCSharpRuntimeAnnotationCodeGenerator : RelationalCSharpRuntimeAnnotationCodeGenerator
{
    public ClickHouseCSharpRuntimeAnnotationCodeGenerator(
        CSharpRuntimeAnnotationCodeGeneratorDependencies dependencies,
        RelationalCSharpRuntimeAnnotationCodeGeneratorDependencies relationalDependencies)
        : base(dependencies, relationalDependencies)
    {
    }

    public override void Generate(IRelationalModel model, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
    {
        if (!parameters.IsRuntime)
        {
            parameters.Annotations.Remove(ClickHouseAnnotationNames.TableEngine);
        }

        base.Generate(model, parameters);
    }

    public override void Generate(ITable table, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
    {
        if (!parameters.IsRuntime)
        {
            parameters.Annotations.Remove(ClickHouseAnnotationNames.TableEngine);
        }

        base.Generate(table, parameters);
    }
}
