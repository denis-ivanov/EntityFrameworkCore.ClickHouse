using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseParameterBasedSqlProcessor : RelationalParameterBasedSqlProcessor
{
    public ClickHouseParameterBasedSqlProcessor(
        RelationalParameterBasedSqlProcessorDependencies dependencies,
        RelationalParameterBasedSqlProcessorParameters parameters)
        : base(dependencies, parameters)
    {
    }

    protected override Expression ProcessSqlNullability(
        Expression selectExpression,
        IReadOnlyDictionary<string, object> parametersValues,
        out bool canCache)
    {
        return new ClickHouseSqlNullabilityProcessor(Dependencies, Parameters).Process(
            selectExpression, parametersValues, out canCache);
    }
}