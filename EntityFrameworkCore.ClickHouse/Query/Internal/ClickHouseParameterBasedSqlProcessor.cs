using Microsoft.EntityFrameworkCore.Query;
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

    protected override Expression ProcessSqlNullability(Expression queryExpression, ParametersCacheDecorator Decorator)
    {
        return new ClickHouseSqlNullabilityProcessor(Dependencies, Parameters).Process(queryExpression, Decorator);
    }
}
