using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query.Internal
{
    public sealed class ClickHouseMethodCallTranslatorProvider : RelationalMethodCallTranslatorProvider
    {
        public ClickHouseMethodCallTranslatorProvider(RelationalMethodCallTranslatorProviderDependencies dependencies)
            : base(dependencies)
        {
            AddTranslators(new IMethodCallTranslator[]
            {
                new ClickHouseArrayTranslator(dependencies.SqlExpressionFactory),
                new ClickHouseStringTranslator(dependencies.SqlExpressionFactory),
                new ClickHouseMathTranslator(dependencies.SqlExpressionFactory)
            });
        }
    }
}
