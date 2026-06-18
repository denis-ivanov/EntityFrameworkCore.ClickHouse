using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseQueryTranslationPreprocessorFactory : RelationalQueryTranslationPreprocessorFactory
{
    public ClickHouseQueryTranslationPreprocessorFactory(
        QueryTranslationPreprocessorDependencies dependencies,
        RelationalQueryTranslationPreprocessorDependencies relationalDependencies)
        : base(dependencies, relationalDependencies)
    {
    }

    public override QueryTranslationPreprocessor Create(QueryCompilationContext queryCompilationContext)
    {
        return new ClickHouseQueryTranslationPreprocessor(Dependencies, RelationalDependencies, queryCompilationContext);
    }
}