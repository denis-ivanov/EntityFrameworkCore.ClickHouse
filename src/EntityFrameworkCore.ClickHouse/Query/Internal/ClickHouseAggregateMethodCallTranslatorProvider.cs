using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseAggregateMethodCallTranslatorProvider : RelationalAggregateMethodCallTranslatorProvider
{
    public ClickHouseAggregateMethodCallTranslatorProvider(RelationalAggregateMethodCallTranslatorProviderDependencies dependencies) : base(dependencies)
    {
        AddTranslators([
            new ClickHouseAggregateMethodTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseQueryableAggregateMethodTranslator(dependencies.SqlExpressionFactory)
        ]);
    }
}
