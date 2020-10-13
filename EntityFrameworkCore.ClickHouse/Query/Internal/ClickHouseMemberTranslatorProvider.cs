using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query.Internal
{
    public class ClickHouseMemberTranslatorProvider : RelationalMemberTranslatorProvider
    {
        public ClickHouseMemberTranslatorProvider(RelationalMemberTranslatorProviderDependencies dependencies)
            : base(dependencies)
        {
        }
    }
}