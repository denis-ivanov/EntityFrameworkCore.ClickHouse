using ClickHouse.EntityFrameworkCore.Query.Expressions;
using ClickHouse.EntityFrameworkCore.Query.Expressions.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ClickHouse.EntityFrameworkCore.Query;

public class ClickHouseSqlExpressionFactory : SqlExpressionFactory
{
    public ClickHouseSqlExpressionFactory(SqlExpressionFactoryDependencies dependencies) : base(dependencies)
    {
    }

    [return: NotNullIfNotNull("sqlExpression")]
    public override SqlExpression ApplyTypeMapping(SqlExpression sqlExpression, RelationalTypeMapping typeMapping)
    {
        if (sqlExpression is { TypeMapping: null })
        {
            sqlExpression = sqlExpression switch
            {
                SqlBinaryExpression e => ApplyTypeMappingOnSqlBinary(e, typeMapping),
                ClickHouseRowValueExpression e => ApplyTypeMappingOnRowValue(e, typeMapping),

                _ => base.ApplyTypeMapping(sqlExpression, typeMapping)
            };
        }
        
        return base.ApplyTypeMapping(sqlExpression, typeMapping);
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

    public virtual ClickHouseTrimExpression Trim(
        SqlExpression stringExpression,
        SqlExpression chars,
        ClickHouseStringTrimMode mode)
    {
        return new ClickHouseTrimExpression(stringExpression, chars, mode);
    }
    
    private SqlExpression ApplyTypeMappingOnRowValue(
        ClickHouseRowValueExpression rowValueExpression,
        RelationalTypeMapping typeMapping)
    {
        var updatedValues = new SqlExpression[rowValueExpression.Values.Count];

        for (var i = 0; i < updatedValues.Length; i++)
        {
            updatedValues[i] = ApplyDefaultTypeMapping(rowValueExpression.Values[i]);
        }

        return new ClickHouseRowValueExpression(updatedValues, rowValueExpression.Type, typeMapping);
    }
    
    private SqlBinaryExpression ApplyTypeMappingOnSqlBinary(SqlBinaryExpression binary, RelationalTypeMapping typeMapping)
    {
        if (IsComparison(binary.OperatorType)
            && TryGetRowValueValues(binary.Left, out var leftValues)
            && TryGetRowValueValues(binary.Right, out var rightValues))
        {
            if (leftValues.Count != rightValues.Count)
            {
                throw new ArgumentException("RowValueComparisonRequiresTuplesOfSameLength");
            }

            var count = leftValues.Count;
            var updatedLeftValues = new SqlExpression[count];
            var updatedRightValues = new SqlExpression[count];

            for (var i = 0; i < count; i++)
            {
                var updatedElementBinaryExpression = MakeBinary(binary.OperatorType, leftValues[i], rightValues[i], typeMapping: null)!;

                if (updatedElementBinaryExpression is not SqlBinaryExpression
                    {
                        Left: var updatedLeft,
                        Right: var updatedRight,
                        OperatorType: var updatedOperatorType
                    }
                    || updatedOperatorType != binary.OperatorType)
                {
                    throw new UnreachableException("MakeBinary modified binary expression type/operator when doing row value comparison");
                }

                updatedLeftValues[i] = updatedLeft;
                updatedRightValues[i] = updatedRight;
            }

            binary = new SqlBinaryExpression(
                binary.OperatorType,
                new ClickHouseRowValueExpression(updatedLeftValues, binary.Left.Type),
                new ClickHouseRowValueExpression(updatedRightValues, binary.Right.Type),
                binary.Type,
                binary.TypeMapping);
        }

        return (SqlBinaryExpression)base.ApplyTypeMapping(binary, typeMapping);

        static bool IsComparison(ExpressionType expressionType)
        {
            switch (expressionType)
            {
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.LessThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThanOrEqual:
                    return true;
                default:
                    return false;
            }
        }

        bool TryGetRowValueValues(SqlExpression e, [NotNullWhen(true)] out IReadOnlyList<SqlExpression> values)
        {
            switch (e)
            {
                case ClickHouseRowValueExpression rowValueExpression:
                    values = rowValueExpression.Values;
                    return true;

                case SqlConstantExpression { Value : ITuple constantTuple }:
                    var v = new SqlExpression[constantTuple.Length];

                    for (var i = 0; i < v.Length; i++)
                    {
                        v[i] = Constant(constantTuple[i], typeof(object));
                    }

                    values = v;
                    return true;

                default:
                    values = null;
                    return false;
            }
        }
    }
}
