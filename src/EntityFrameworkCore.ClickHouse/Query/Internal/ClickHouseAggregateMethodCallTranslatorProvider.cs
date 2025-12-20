using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseAggregateMethodCallTranslatorProvider : RelationalAggregateMethodCallTranslatorProvider
{
    public ClickHouseAggregateMethodCallTranslatorProvider(RelationalAggregateMethodCallTranslatorProviderDependencies dependencies) : base(dependencies)
    {
        AddTranslators([new ClickHouseQueryableAggregateMethodTranslator(dependencies.SqlExpressionFactory)]);
    }
}
