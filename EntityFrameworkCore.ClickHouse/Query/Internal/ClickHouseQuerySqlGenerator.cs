using ClickHouse.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System.Linq.Expressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseQuerySqlGenerator : QuerySqlGenerator
{
    public ClickHouseQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies) : base(dependencies)
    {
    }

    protected override void GenerateLimitOffset(SelectExpression selectExpression)
    {
        if (selectExpression.Limit != null || selectExpression.Offset != null)
        {
            Sql.AppendLine().Append("LIMIT ");

            if (selectExpression.Offset != null && selectExpression.Limit != null)
            {
                Visit(selectExpression.Offset);
                Sql.Append(", ");
                Visit(selectExpression.Limit);
            }
            else if (selectExpression.Offset != null)
            {
                Visit(selectExpression.Offset);
            }
            else if (selectExpression.Limit != null)
            {
                Visit(selectExpression.Limit);
            }
        }
    }

    protected override Expression VisitSqlParameter(SqlParameterExpression sqlParameterExpression)
    {
        var parameterNameInCommand = Dependencies.SqlGenerationHelper.GenerateParameterName(sqlParameterExpression.Name);

        if (Sql.Parameters
            .All(p => p.InvariantName != sqlParameterExpression.Name))
        {
            Sql.AddParameter(
                sqlParameterExpression.Name,
                parameterNameInCommand,
                sqlParameterExpression.TypeMapping!,
                sqlParameterExpression.IsNullable);
        }

        Sql.Append(Dependencies.SqlGenerationHelper.GenerateParameterName(sqlParameterExpression.Name, sqlParameterExpression.TypeMapping.StoreType));
        return sqlParameterExpression;
    }
}
