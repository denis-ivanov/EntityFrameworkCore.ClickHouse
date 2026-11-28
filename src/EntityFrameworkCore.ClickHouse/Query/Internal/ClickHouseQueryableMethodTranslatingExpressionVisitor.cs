using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
#if NET11_0_OR_GREATER
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
#endif
using System;
using System.Linq.Expressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseQueryableMethodTranslatingExpressionVisitor
    : RelationalQueryableMethodTranslatingExpressionVisitor
{
#if NET11_0_OR_GREATER
    internal const string JsonArrayRows = "__ClickHouseJsonArrayRows";
    internal const string JsonArrayOrdinal = "_ordinal";
    internal const string JsonArrayValue = "_json";
#endif
    private readonly RelationalSqlTranslatingExpressionVisitor _sqlTranslator;

    public ClickHouseQueryableMethodTranslatingExpressionVisitor(
        QueryableMethodTranslatingExpressionVisitorDependencies dependencies,
        RelationalQueryableMethodTranslatingExpressionVisitorDependencies relationalDependencies,
        RelationalQueryCompilationContext queryCompilationContext)
        : base(dependencies, relationalDependencies, queryCompilationContext)
    {
        _sqlTranslator =
            relationalDependencies.RelationalSqlTranslatingExpressionVisitorFactory.Create(queryCompilationContext,
                this);
    }

    private ClickHouseQueryableMethodTranslatingExpressionVisitor(ClickHouseQueryableMethodTranslatingExpressionVisitor parent)
        : base(parent)
    {
        _sqlTranslator = RelationalDependencies.RelationalSqlTranslatingExpressionVisitorFactory.Create(QueryCompilationContext, this);
    }

    protected override QueryableMethodTranslatingExpressionVisitor CreateSubqueryVisitor()
        => new ClickHouseQueryableMethodTranslatingExpressionVisitor(this);

#if NET11_0_OR_GREATER
    protected override ShapedQueryExpression? TransformJsonQueryToTable(JsonQueryExpression jsonQueryExpression)
    {
        if (jsonQueryExpression.StructuralType is not IComplexType complex || complex.GetComplexProperties().Any())
        {
            return base.TransformJsonQueryToTable(jsonQueryExpression);
        }

        var sql = RelationalDependencies.SqlExpressionFactory;
        var mappings = RelationalDependencies.TypeMappingSource;
        var stringMapping = mappings.FindMapping(typeof(string))!;
        var intMapping = mappings.FindMapping(typeof(int))!;

        var jsonColumn = jsonQueryExpression.JsonColumn;
        var json = string.Equals(jsonColumn.TypeMapping?.StoreType, "Json", StringComparison.OrdinalIgnoreCase)
            ? (SqlExpression)sql.Function("toJSONString", [jsonColumn], nullable: true, [true], typeof(string), stringMapping)
            : jsonColumn;

        var path = new List<SqlExpression> { json };
        foreach (var segment in jsonQueryExpression.Path)
        {
            path.Add(segment.PropertyName is string name
                ? sql.Constant(name.Replace(@"\", @"\\", StringComparison.Ordinal), stringMapping)
                : sql.Add(segment.ArrayIndex!, sql.Constant(1, intMapping)));
        }

        var array = sql.Function(
            "JSONExtractArrayRaw", path, nullable: true, Enumerable.Repeat(true, path.Count), typeof(string[]),
            mappings.FindMapping(typeof(string[])));
        var alias = ((RelationalQueryCompilationContext)QueryCompilationContext).SqlAliasManager.GenerateTableAlias("json");
        var rows = new TableValuedFunctionExpression(alias, JsonArrayRows, [array]);
        var element = CreateSelect(jsonQueryExpression, rows, JsonArrayOrdinal, typeof(int), intMapping);
        var value = element.CreateColumnExpression(rows, JsonArrayValue, typeof(string), stringMapping);
        var properties = new Dictionary<ProjectionMember, Expression>();
        foreach (var property in complex.GetProperties())
        {
            if (jsonQueryExpression.FindJsonElement(property) is { PropertyName: string jsonName, StoreTypeMapping: { } mapping })
            {
                properties[new ProjectionMember().Append(new JsonProjectionMember(jsonName))] = new JsonScalarExpression(
                    value, [new PathSegment(jsonName)], Nullable.GetUnderlyingType(property.ClrType) ?? property.ClrType, mapping, property.IsNullable);
            }
        }

        // Preserve the array index as part of the derived table for ordered collection queries.
        properties[new ProjectionMember().Append(new JsonProjectionMember(JsonArrayOrdinal))]
            = element.CreateColumnExpression(rows, JsonArrayOrdinal, typeof(int), intMapping, columnNullable: false);
        element.ReplaceProjection(properties);
        element.PushdownIntoSubquery();
        var projectedRows = element.Tables[0];
        var select = CreateSelect(jsonQueryExpression, projectedRows, JsonArrayOrdinal, typeof(int), intMapping);
        select.AppendOrdering(new OrderingExpression(
            select.CreateColumnExpression(projectedRows, JsonArrayOrdinal, typeof(int), intMapping, columnNullable: false),
            ascending: true));

        return new ShapedQueryExpression(
            select,
            new RelationalStructuralTypeShaperExpression(
                complex, new ProjectionBindingExpression(select, new ProjectionMember(), typeof(ValueBuffer)), nullable: false));
    }

    private sealed class JsonProjectionMember : MemberInfo
    {
        public JsonProjectionMember(string name)
        {
            Name = name;
        }

        public override string Name { get; }
        public override Type? DeclaringType => null;
        public override Type? ReflectedType => null;
        public override MemberTypes MemberType => MemberTypes.Property;
        public override object[] GetCustomAttributes(bool inherit) => [];
        public override object[] GetCustomAttributes(Type attributeType, bool inherit) => [];
        public override bool IsDefined(Type attributeType, bool inherit) => false;
    }
#endif

    protected override ShapedQueryExpression? TranslateTake(ShapedQueryExpression source, Expression count)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(count);

        var selectExpression = (SelectExpression)source.QueryExpression;
        var translation = _sqlTranslator.Translate(count);

        if (translation != null)
        {
            selectExpression.ApplyLimit(translation);

            return source;
        }

        return null;
    }

    protected override ShapedQueryExpression? TranslateOrderBy(ShapedQueryExpression source, LambdaExpression keySelector, bool ascending)
        => ProjectSubqueryOrdering(base.TranslateOrderBy(source, keySelector, ascending));

    protected override ShapedQueryExpression? TranslateThenBy(ShapedQueryExpression source, LambdaExpression keySelector, bool ascending)
        => ProjectSubqueryOrdering(base.TranslateThenBy(source, keySelector, ascending));

    private static ShapedQueryExpression? ProjectSubqueryOrdering(ShapedQueryExpression? query)
    {
        if (query?.QueryExpression is SelectExpression { Orderings.Count: > 0 } select
            && ScalarSubqueryFinder.ContainsSubquery(select.Orderings[^1].Expression))
        {
            // ClickHouse can evaluate a correlated scalar in a projection and order by its result.
            select.PushdownIntoSubquery();
        }

        return query;
    }

    private sealed class ScalarSubqueryFinder : ExpressionVisitor
    {
        private bool _found;

        public static bool ContainsSubquery(SqlExpression expression)
        {
            ScalarSubqueryFinder finder = new();
            finder.Visit(expression);

            return finder._found;
        }

        protected override Expression VisitExtension(Expression node)
        {
            if (node is ScalarSubqueryExpression)
            {
                _found = true;
                return node;
            }

            return base.VisitExtension(node);
        }
    }
}
