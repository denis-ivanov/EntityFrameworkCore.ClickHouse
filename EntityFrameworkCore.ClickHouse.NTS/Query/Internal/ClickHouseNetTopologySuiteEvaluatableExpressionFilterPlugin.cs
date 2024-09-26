using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EntityFrameworkCore.ClickHouse.NTS.Query.Internal;

public class ClickHouseNetTopologySuiteEvaluatableExpressionFilterPlugin : IEvaluatableExpressionFilterPlugin
{
    public bool IsEvaluatableExpression(Expression expression)
    {
        return false;
    }
}
