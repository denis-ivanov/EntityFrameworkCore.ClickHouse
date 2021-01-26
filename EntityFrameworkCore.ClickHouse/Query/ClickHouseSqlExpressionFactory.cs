using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query
{
    public class ClickHouseSqlExpressionFactory : SqlExpressionFactory
    {
        public ClickHouseSqlExpressionFactory(SqlExpressionFactoryDependencies dependencies) : base(dependencies)
        {
        }
    }
}