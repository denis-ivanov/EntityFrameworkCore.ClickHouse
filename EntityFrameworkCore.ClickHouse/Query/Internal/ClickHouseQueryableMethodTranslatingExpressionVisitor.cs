using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal
{
    public class ClickHouseQueryableMethodTranslatingExpressionVisitor
        : RelationalQueryableMethodTranslatingExpressionVisitor
    {
        private readonly RelationalSqlTranslatingExpressionVisitor _sqlTranslator;
        
        public ClickHouseQueryableMethodTranslatingExpressionVisitor(
            QueryableMethodTranslatingExpressionVisitorDependencies dependencies,
            RelationalQueryableMethodTranslatingExpressionVisitorDependencies relationalDependencies,
            IModel model)
            : base(dependencies, relationalDependencies, model)
        {
            _sqlTranslator = relationalDependencies.RelationalSqlTranslatingExpressionVisitorFactory.Create(model, this);
        }

        protected ClickHouseQueryableMethodTranslatingExpressionVisitor(RelationalQueryableMethodTranslatingExpressionVisitor parentVisitor)
            : base(parentVisitor)
        {
        }

        protected override ShapedQueryExpression TranslateFirstOrDefault(ShapedQueryExpression source, LambdaExpression predicate, Type returnType,
            bool returnDefault)
        {
            return base.TranslateFirstOrDefault(source, predicate, returnType, returnDefault);
        }

        protected override Expression VisitConstant(ConstantExpression constantExpression)
        {
            return base.VisitConstant(constantExpression);
        }

        public override Expression Visit(Expression node)
        {
            return base.Visit(node);
        }

        protected override ShapedQueryExpression TranslateTake(ShapedQueryExpression source, Expression count)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (count == null)
            {
                throw new ArgumentNullException(nameof(count));
            }

            var selectExpression = (SelectExpression)source.QueryExpression;
            var translation = _sqlTranslator.Translate(count);

            if (translation != null)
            {
                selectExpression.ApplyLimit(translation);

                return source;
            }

            return null;
        }

        protected override ShapedQueryExpression TranslateAny(ShapedQueryExpression source, LambdaExpression predicate)
        {
            return base.TranslateAny(source, predicate);
        }
    }
}