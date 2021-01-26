using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query.Internal
{
    public sealed class ClickHouseMemberTranslatorProvider : RelationalMemberTranslatorProvider
    {
        public ClickHouseMemberTranslatorProvider(RelationalMemberTranslatorProviderDependencies dependencies)
            : base(dependencies)
        {
            AddTranslators(new IMemberTranslator[]
            {
                new ClickHouseStringTranslator(dependencies.SqlExpressionFactory),
                new ClickHouseArrayTranslator(dependencies.SqlExpressionFactory)
            });
        }
    }
}
