using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query.Internal
{
    public class ClickHouseSqlTranslatingExpressionVisitor : RelationalSqlTranslatingExpressionVisitor
    {
        public ClickHouseSqlTranslatingExpressionVisitor(
            RelationalSqlTranslatingExpressionVisitorDependencies dependencies,
            IModel model, QueryableMethodTranslatingExpressionVisitor queryableMethodTranslatingExpressionVisitor)
            : base(dependencies, model, queryableMethodTranslatingExpressionVisitor)
        {
        }
    }
}