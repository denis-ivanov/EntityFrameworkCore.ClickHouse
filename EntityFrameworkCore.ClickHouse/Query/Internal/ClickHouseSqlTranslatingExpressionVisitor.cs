using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal
{
    public class ClickHouseSqlTranslatingExpressionVisitor : RelationalSqlTranslatingExpressionVisitor
    {
        public ClickHouseSqlTranslatingExpressionVisitor(RelationalSqlTranslatingExpressionVisitorDependencies dependencies, QueryCompilationContext queryCompilationContext, QueryableMethodTranslatingExpressionVisitor queryableMethodTranslatingExpressionVisitor) : base(dependencies, queryCompilationContext, queryableMethodTranslatingExpressionVisitor)
        {
        }

        public override SqlExpression TranslateCount(SqlExpression sqlExpression)
        {
            return Dependencies.SqlExpressionFactory.Convert(
                Dependencies.SqlExpressionFactory.ApplyDefaultTypeMapping(
                    Dependencies.SqlExpressionFactory.Function(
                        "COUNT",
                        new [] { sqlExpression },
                        false,
                        new[] { false },
                        typeof(long)
                    )
                ),
                typeof(int),
                Dependencies.TypeMappingSource.FindMapping(typeof(int))
            );
        }

        public override SqlExpression TranslateLongCount(SqlExpression sqlExpression)
        {
            return Dependencies.SqlExpressionFactory.Convert(
                Dependencies.SqlExpressionFactory.ApplyDefaultTypeMapping(
                    Dependencies.SqlExpressionFactory.Function(
                        "COUNT",
                        new [] { sqlExpression },
                        false,
                        new[] { false },
                        typeof(ulong)
                    )
                ),
                typeof(int),
                Dependencies.TypeMappingSource.FindMapping(typeof(int))
            );
        }

        public override SqlExpression TranslateSum(SqlExpression sqlExpression)
        {
            return Dependencies.SqlExpressionFactory.Convert(
                Dependencies.SqlExpressionFactory.ApplyDefaultTypeMapping(
                    Dependencies.SqlExpressionFactory.Function(
                        "SUM",
                        new [] { sqlExpression },
                        false,
                        new[] { false },
                        sqlExpression.Type
                    )
                ),
                sqlExpression.Type,
                Dependencies.TypeMappingSource.FindMapping(sqlExpression.Type)
            );
        }
    }
}
