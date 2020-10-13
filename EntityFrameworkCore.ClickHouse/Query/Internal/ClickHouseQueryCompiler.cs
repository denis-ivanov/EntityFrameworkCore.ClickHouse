using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace ClickHouse.EntityFrameworkCore.Query.Internal
{
    public class ClickHouseQueryCompiler : QueryCompiler
    {
        public ClickHouseQueryCompiler(
            IQueryContextFactory queryContextFactory,
            ICompiledQueryCache compiledQueryCache,
            ICompiledQueryCacheKeyGenerator compiledQueryCacheKeyGenerator,
            IDatabase database,
            IDiagnosticsLogger<DbLoggerCategory.Query> logger,
            ICurrentDbContext currentContext,
            IEvaluatableExpressionFilter evaluatableExpressionFilter,
            IModel model)
            : base(
                queryContextFactory,
                compiledQueryCache,
                compiledQueryCacheKeyGenerator,
                database,
                logger,
                currentContext,
                evaluatableExpressionFilter,
                model)
        {
        }

        public override Expression ExtractParameters(Expression query, IParameterValues parameterValues, IDiagnosticsLogger<DbLoggerCategory.Query> logger,
            bool parameterize = true, bool generateContextAccessors = false)
        {
            return query;
        }
    }
}