using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query.Internal
{
    public class ClickHouseSqlTranslatingExpressionVisitorFactory :
        IRelationalSqlTranslatingExpressionVisitorFactory
    {
        private readonly RelationalSqlTranslatingExpressionVisitorDependencies _dependencies;

        public ClickHouseSqlTranslatingExpressionVisitorFactory(
            [NotNull]RelationalSqlTranslatingExpressionVisitorDependencies dependencies)
        {
            _dependencies = dependencies;
        }

        public RelationalSqlTranslatingExpressionVisitor Create(QueryCompilationContext queryCompilationContext,
            QueryableMethodTranslatingExpressionVisitor queryableMethodTranslatingExpressionVisitor)
        {
            return new ClickHouseSqlTranslatingExpressionVisitor(
                _dependencies,
                queryCompilationContext,
                queryableMethodTranslatingExpressionVisitor);
        }
    }
}