using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public sealed class ClickHouseMemberTranslatorProvider : RelationalMemberTranslatorProvider
{
    public ClickHouseMemberTranslatorProvider(RelationalMemberTranslatorProviderDependencies dependencies)
        : base(dependencies)
    {
        AddTranslators([
            new ClickHouseStringTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseArrayTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseMathTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseConvertTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseDateTimeMemberTranslator(dependencies.SqlExpressionFactory)
        ]);
    }
}
