using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace ClickHouse.EntityFrameworkCore.Query.Internal
{
    public class ClickHouseQuerySqlGenerator : QuerySqlGenerator
    {
        
        public ClickHouseQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies) : base(dependencies)
        {
        }

        protected override void GenerateLimitOffset(SelectExpression selectExpression)
        {
            if (selectExpression.Limit != null)
            {
                Sql.AppendLine("LIMIT ");
                Visit(selectExpression.Limit);
            }

            if (selectExpression.Offset != null)
            {
                Sql.Append(" OFFSET ");
                Visit(selectExpression.Offset);
            }
        }

        protected override Expression VisitSqlParameter(SqlParameterExpression sqlParameterExpression)
        {
            if (Sql.Parameters
                .All(p => p.InvariantName != sqlParameterExpression.Name))
            {
                Sql.AddParameter(
                    sqlParameterExpression.Name,
                    sqlParameterExpression.Name,
                    sqlParameterExpression.TypeMapping,
                    sqlParameterExpression.IsNullable);
            }

            // see https://github.com/DarkWanderer/ClickHouse.Client/wiki/SQL-Parameters
            Sql.Append("{").Append($"{sqlParameterExpression.Name}:{sqlParameterExpression.TypeMapping.StoreType}").Append("}");

            return sqlParameterExpression;
        }
    }
}
