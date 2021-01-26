using System;
using System.Collections.Generic;
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

        protected override Expression VisitExists(ExistsExpression existsExpression)
        {
            if (existsExpression.IsNegated)
            {
                Sql.Append("NOT ");
            }

            Sql.Append(" if (count() > 0, 1, 0) ");

            using (Sql.Indent())
            {
                if (IsNonComposedSetOperation(existsExpression.Subquery))
                {
                    // Naked set operation
                    GenerateSetOperation((SetOperationBase)existsExpression.Subquery.Tables[0]);

                    return existsExpression.Subquery;
                }

                IDisposable subQueryIndent = null;

                if (existsExpression.Subquery.Alias != null)
                {
                    Sql.AppendLine("(");
                    subQueryIndent = Sql.Indent();
                }

                if (existsExpression.Subquery.IsDistinct)
                {
                    Sql.Append("DISTINCT ");
                }

                GenerateTop(existsExpression.Subquery);

                if (existsExpression.Subquery.Tables.Any())
                {
                    Sql.AppendLine().Append("FROM ");

                    GenerateList(existsExpression.Subquery.Tables, e => Visit(e), sql => sql.AppendLine());
                }

                if (existsExpression.Subquery.Predicate != null)
                {
                    Sql.AppendLine().Append("WHERE ");

                    Visit(existsExpression.Subquery.Predicate);
                }

                if (existsExpression.Subquery.GroupBy.Count > 0)
                {
                    Sql.AppendLine().Append("GROUP BY ");

                    GenerateList(existsExpression.Subquery.GroupBy, e => Visit(e));
                }

                if (existsExpression.Subquery.Having != null)
                {
                    Sql.AppendLine().Append("HAVING ");

                    Visit(existsExpression.Subquery.Having);
                }

                GenerateOrderings(existsExpression.Subquery);
                GenerateLimitOffset(existsExpression.Subquery);

                if (existsExpression.Subquery.Alias != null)
                {
                    subQueryIndent.Dispose();

                    // TODO
                    //Sql.AppendLine()
                    //    .Append(")" + AliasSeparator + Sql.DelimitIdentifier(existsExpression.Subquery.Alias));
                }
            }

            return existsExpression;
        }

        private bool IsNonComposedSetOperation(SelectExpression selectExpression)
            =>    selectExpression.Offset == null
               && selectExpression.Limit == null
               && !selectExpression.IsDistinct
               && selectExpression.Predicate == null
               && selectExpression.Having == null
               && selectExpression.Orderings.Count == 0
               && selectExpression.GroupBy.Count == 0
               && selectExpression.Tables.Count == 1
               && selectExpression.Tables[0] is SetOperationBase setOperation
               && selectExpression.Projection.Count == setOperation.Source1.Projection.Count
               && selectExpression.Projection.Select(
                       (pe, index) => pe.Expression is ColumnExpression column
                                      && string.Equals(column.Table.Alias, setOperation.Alias, StringComparison.OrdinalIgnoreCase)
                                      && string.Equals(
                                          column.Name, setOperation.Source1.Projection[index].Alias, StringComparison.OrdinalIgnoreCase))
                   .All(e => e);

        private void GenerateList<T>(
            IReadOnlyList<T> items,
            Action<T> generationAction,
            Action<IRelationalCommandBuilder> joinAction = null)
        {
            joinAction ??= (isb => isb.Append(", "));

            for (var i = 0; i < items.Count; i++)
            {
                if (i > 0)
                {
                    joinAction(Sql);
                }

                generationAction(items[i]);
            }
        }
    }
}
