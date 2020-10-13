using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query.Internal
{
    public class ClickHouseQuerySqlGeneratorFactory : IQuerySqlGeneratorFactory
    {
        private readonly QuerySqlGeneratorDependencies _dependencies;

        public ClickHouseQuerySqlGeneratorFactory([NotNull]QuerySqlGeneratorDependencies dependencies)
        {
            _dependencies = dependencies;
        }

        public QuerySqlGenerator Create()
        {
           return new ClickHouseQuerySqlGenerator(_dependencies);
        }
    }
}
