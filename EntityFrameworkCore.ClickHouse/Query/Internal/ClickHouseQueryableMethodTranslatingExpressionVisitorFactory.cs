using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query.Internal
{
    public class ClickHouseQueryableMethodTranslatingExpressionVisitorFactory :
        IQueryableMethodTranslatingExpressionVisitorFactory
    {
        private readonly QueryableMethodTranslatingExpressionVisitorDependencies _dependencies;
        private readonly RelationalQueryableMethodTranslatingExpressionVisitorDependencies _relationalDependencies;

        public ClickHouseQueryableMethodTranslatingExpressionVisitorFactory(QueryableMethodTranslatingExpressionVisitorDependencies dependencies, RelationalQueryableMethodTranslatingExpressionVisitorDependencies relationalDependencies)
        {
            _dependencies = dependencies;
            _relationalDependencies = relationalDependencies;
        }

        public QueryableMethodTranslatingExpressionVisitor Create(IModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            
            return new ClickHouseQueryableMethodTranslatingExpressionVisitor(_dependencies, _relationalDependencies, model);
        }
    }
}