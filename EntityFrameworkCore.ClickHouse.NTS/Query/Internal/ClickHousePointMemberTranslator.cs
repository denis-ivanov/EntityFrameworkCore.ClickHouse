using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using NetTopologySuite.Geometries;
using System.Reflection;

namespace EntityFrameworkCore.ClickHouse.NTS.Query.Internal;

public class ClickHousePointMemberTranslator : IMemberTranslator
{
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public ClickHousePointMemberTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression? Translate(SqlExpression? instance, MemberInfo member, Type returnType, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (member.DeclaringType != typeof(Point))
        {
            return null;
        }

        if (member.Name == nameof(Point.X))
        {
            return _sqlExpressionFactory.Function(
                name: "tupleElement",
                arguments: [instance, _sqlExpressionFactory.Constant(1)],
                returnType: typeof(double),
                nullable: true,
                argumentsPropagateNullability: [true, true]);
        }

        return null;
    }
}
