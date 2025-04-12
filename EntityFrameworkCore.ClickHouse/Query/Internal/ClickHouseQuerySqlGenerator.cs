using ClickHouse.EntityFrameworkCore.Query.Expressions;
using ClickHouse.EntityFrameworkCore.Query.Expressions.Internal;
using ClickHouse.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseQuerySqlGenerator : QuerySqlGenerator
{
    public ClickHouseQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies)
        : base(dependencies)
    {
    }

    protected override Expression VisitExtension(Expression extensionExpression)
        => extensionExpression switch
        {
            ClickHouseTrimExpression e => VisitTrim(e),

            _ => base.VisitExtension(extensionExpression)
        };

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

    protected override Expression VisitUnary(UnaryExpression node)
    {
        if (node.NodeType == ExpressionType.ArrayLength)
        {
            return node;
        }

        return base.VisitUnary(node);
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

    private Expression VisitTrim(ClickHouseTrimExpression trimExpression)
    {
        Sql.Append("trim(")
            .Append(trimExpression.TrimMode switch
            {
                ClickHouseStringTrimMode.Both => "BOTH ",
                ClickHouseStringTrimMode.Leading => "LEADING ",
                ClickHouseStringTrimMode.Trailing => "TRAILING ",
                _ => throw new InvalidEnumArgumentException("Invalid trim mode", (int)trimExpression.TrimMode, typeof(ClickHouseStringTrimMode))
            });

        Visit(trimExpression.TrimCharacters);

        Sql.Append(" FROM ");
        Visit(trimExpression.InputString);
        Sql.Append(")");

        return trimExpression;
    }
}