using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public sealed class ClickHouseMemberTranslatorProvider : RelationalMemberTranslatorProvider
{
    public ClickHouseMemberTranslatorProvider(RelationalMemberTranslatorProviderDependencies dependencies, IRelationalTypeMappingSource typeMappingSource)
        : base(dependencies)
    {
        AddTranslators([
            new ClickHouseStringTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseArrayTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseMathTranslator(dependencies.SqlExpressionFactory, typeMappingSource),
            new ClickHouseConvertTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseDateTimeMemberTranslator(dependencies.SqlExpressionFactory)
        ]);
    }
}
