using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseQueryTranslationPreprocessor : RelationalQueryTranslationPreprocessor
{
    public ClickHouseQueryTranslationPreprocessor(
        QueryTranslationPreprocessorDependencies dependencies,
        RelationalQueryTranslationPreprocessorDependencies relationalDependencies, QueryCompilationContext queryCompilationContext)
        : base(dependencies, relationalDependencies, queryCompilationContext)
    {
    }

    public override Expression Process(Expression query)
    {
        query = new ClickHouseAggregateMethodVisitor().Visit(query);

        return base.Process(query);
    }
}