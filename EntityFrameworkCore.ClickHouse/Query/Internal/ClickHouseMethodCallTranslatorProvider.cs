using Microsoft.EntityFrameworkCore.Query;

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
            new ClickHouseRegexMethodTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseBinaryPrimitivesMethodTranslator(dependencies.SqlExpressionFactory, dependencies.RelationalTypeMappingSource),
            new ClickHouseArithmeticMethodTranslator(dependencies.SqlExpressionFactory, dependencies.RelationalTypeMappingSource),
            new ClickHouseDecimalMethodTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseBoolMethodTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseInt8MethodTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseInt16MethodTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseInt32MethodTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseInt64MethodTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseInt128MethodTranslator(dependencies.SqlExpressionFactory),
            new ClickHouseUInt8MethodTranslator(dependencies.SqlExpressionFactory)
        ]);
    }
}
