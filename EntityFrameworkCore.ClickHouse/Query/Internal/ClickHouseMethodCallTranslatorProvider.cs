using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query.Internal
{
    public class ClickHouseMethodCallTranslatorProvider : RelationalMethodCallTranslatorProvider
    {
        public ClickHouseMethodCallTranslatorProvider(RelationalMethodCallTranslatorProviderDependencies dependencies)
            : base(dependencies)
        {
        }
    }
}
