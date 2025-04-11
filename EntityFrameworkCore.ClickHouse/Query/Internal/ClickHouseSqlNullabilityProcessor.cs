using ClickHouse.EntityFrameworkCore.Query.Expressions.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseSqlNullabilityProcessor : SqlNullabilityProcessor
{
    public ClickHouseSqlNullabilityProcessor(
        RelationalParameterBasedSqlProcessorDependencies dependencies,
        RelationalParameterBasedSqlProcessorParameters parameters)
        : base(dependencies, parameters)
    {
    }

    protected override SqlExpression VisitCustomSqlExpression(
        SqlExpression sqlExpression,
        bool allowOptimizedExpansion,
        out bool nullable)
        => sqlExpression switch
        {
            ClickHouseTrimExpression e => VisitTrim(e, allowOptimizedExpansion, out nullable),

            _ => base.VisitCustomSqlExpression(sqlExpression, allowOptimizedExpansion, out nullable)
        };

    protected virtual SqlExpression VisitTrim(
        ClickHouseTrimExpression trimExpression,
        bool allowOptimizedExpansion,
        out bool nullable)
    {
        var inputString = Visit(trimExpression.InputString, out var inputStringNullable);
        var trimCharacters = Visit(trimExpression.TrimCharacters, out var trimCharactersNullable);
        nullable = inputStringNullable || trimCharactersNullable;

        SqlExpression updated = trimExpression.Update(inputString, trimCharacters);

        return updated;
    }
}