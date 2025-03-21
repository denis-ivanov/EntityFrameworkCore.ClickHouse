﻿using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public sealed class ClickHouseMethodCallTranslatorProvider : RelationalMethodCallTranslatorProvider
{
    public ClickHouseMethodCallTranslatorProvider(RelationalMethodCallTranslatorProviderDependencies dependencies)
        : base(dependencies)
    {
        AddTranslators([
            new ClickHouseArrayTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseGuidTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseStringTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseMathTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseConvertTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseDateTimeMethodTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseTupleMemberTranslator(dependencies.SqlExpressionFactory, dependencies.RelationalTypeMappingSource),
            new ClickHouseObjectToStringTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseDateOnlyMethodTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseRegexMethodTranslator(dependencies.SqlExpressionFactory)
        ]);
    }
}
