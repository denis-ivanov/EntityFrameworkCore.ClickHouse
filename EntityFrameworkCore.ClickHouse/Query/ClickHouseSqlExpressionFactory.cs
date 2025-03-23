using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace ClickHouse.EntityFrameworkCore.Query;

public class ClickHouseSqlExpressionFactory : SqlExpressionFactory
{
    public ClickHouseSqlExpressionFactory(SqlExpressionFactoryDependencies dependencies) : base(dependencies)
    {
    }

    public override SqlExpression MakeBinary(
        ExpressionType operatorType,
        SqlExpression left,
        SqlExpression right,
        RelationalTypeMapping typeMapping,
        SqlExpression existingExpression = null)
    {
        switch (operatorType)
        {
            case ExpressionType.And:
                return Function("bitAnd", [left, right], true, [true, true], typeMapping.ClrType, typeMapping);

            case ExpressionType.Or:
                return Function("bitOr", [left, right], true, [true, true], typeMapping.ClrType, typeMapping);

            case ExpressionType.ExclusiveOr:
                return Function("bitXor", [left, right], true, [true, true], typeMapping.ClrType, typeMapping);

            case ExpressionType.LeftShift:
                return Function("bitShiftLeft", [left, right], true, [true, true], typeMapping.ClrType, typeMapping);

            case ExpressionType.RightShift:
                return Function("bitShiftRight", [left, right], true, [true, true], typeMapping.ClrType, typeMapping);
        }

        return base.MakeBinary(operatorType, left, right, typeMapping, existingExpression);
    }
}