using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseAggregateMethodVisitor : ExpressionVisitor
{
    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        if (node.Method.DeclaringType == typeof(ClickHouseEnumerable) && node.Arguments.Count > 1)
        {
            return new EnumerableExpression(Visit(node.Arguments[1]));
        }

        return base.VisitMethodCall(node);
    }
}
