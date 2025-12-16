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
    private const byte DecimalPrecision32 = 9;
    private const byte DecimalMaxScale32 = 9;

    private const byte DecimalPrecision64 = 18;
    private const byte DecimalMaxScale64 = 18;

    private const byte DecimalPrecision128 = 38;
    private const byte DecimalMaxScale128 = 38;

    private const byte DecimalPrecision256 = 76;
    private const byte DecimalMaxScale256 = 76;

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

    #region Decimal

    public SqlExpression ToDecimal32(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal32",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision32, DecimalMaxScale32, scale));
    }

    public SqlExpression ToDecimal32OrZero(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal32OrZero",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision32, DecimalMaxScale32, scale));
    }

    public SqlExpression ToDecimal32OrNull(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal32OrNull",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision32, DecimalMaxScale32, scale));
    }

    public SqlExpression ToDecimal32OrDefault(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal32OrDefault",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision32, DecimalMaxScale32, scale));
    }

    public SqlExpression ToDecimal32OrDefault(SqlExpression number, SqlExpression scale, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: decimal })
        {
            defaultValue = ToDecimal32(defaultValue, scale);
        }

        return Function(
            name: "toDecimal32OrDefault",
            arguments: [number, scale, defaultValue],
            nullable: true,
            argumentsPropagateNullability: [true, true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision32, DecimalMaxScale32, scale));
    }

    public SqlExpression ToDecimal64(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal64",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision64, DecimalMaxScale64, scale));
    }

    public SqlExpression ToDecimal64OrZero(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal64OrZero",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision64, DecimalMaxScale64, scale));
    }

    public SqlExpression ToDecimal64OrNull(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal64OrNull",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision64, DecimalMaxScale64, scale));
    }

    public SqlExpression ToDecimal64OrDefault(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal64OrDefault",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision64, DecimalMaxScale64, scale));
    }

    public SqlExpression ToDecimal64OrDefault(SqlExpression number, SqlExpression scale, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: decimal })
        {
            defaultValue = ToDecimal64(defaultValue, scale);
        }

        return Function(
            name: "toDecimal64OrDefault",
            arguments: [number, scale, defaultValue],
            nullable: true,
            argumentsPropagateNullability: [true, true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision64, DecimalMaxScale64, scale));
    }
    
    public SqlExpression ToDecimal128(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal128",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision128, DecimalMaxScale128, scale));
    }

    public SqlExpression ToDecimal128OrZero(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal128OrZero",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision128, DecimalMaxScale128, scale));
    }

    public SqlExpression ToDecimal128OrNull(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal128OrNull",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision128, DecimalMaxScale128, scale));
    }

    public SqlExpression ToDecimal128OrDefault(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal128OrDefault",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision128, DecimalMaxScale128, scale));
    }

    public SqlExpression ToDecimal128OrDefault(SqlExpression number, SqlExpression scale, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: decimal })
        {
            defaultValue = ToDecimal128(defaultValue, scale);
        }

        return Function(
            name: "toDecimal128OrDefault",
            arguments: [number, scale, defaultValue],
            nullable: true,
            argumentsPropagateNullability: [true, true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision128, DecimalMaxScale128, scale));
    }

    public SqlExpression ToDecimal256(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal256",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision256, DecimalMaxScale256, scale));
    }

    public SqlExpression ToDecimal256OrZero(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal256OrZero",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision256, DecimalMaxScale256, scale));
    }

    public SqlExpression ToDecimal256OrNull(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal256OrNull",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision256, DecimalMaxScale256, scale));
    }

    public SqlExpression ToDecimal256OrDefault(SqlExpression number, SqlExpression scale)
    {
        return Function(
            name: "toDecimal256OrDefault",
            arguments: [number, scale],
            nullable: true,
            argumentsPropagateNullability: [true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision256, DecimalMaxScale256, scale));
    }

    public SqlExpression ToDecimal256OrDefault(SqlExpression number, SqlExpression scale, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: decimal })
        {
            defaultValue = ToDecimal256(defaultValue, scale);
        }

        return Function(
            name: "toDecimal256OrDefault",
            arguments: [number, scale, defaultValue],
            nullable: true,
            argumentsPropagateNullability: [true, true, true],
            returnType: typeof(decimal),
            typeMapping: GetDecimalTypaMapping(DecimalPrecision256, DecimalMaxScale256, scale));
    }

    private RelationalTypeMapping GetDecimalTypaMapping(byte precision, byte maxScale, SqlExpression scale)
    {
        if (scale is SqlConstantExpression { Value: byte scaleValue })
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(scaleValue, maxScale);

            return Dependencies.TypeMappingSource.FindMapping($"Decimal({precision}, {scaleValue})");
        }

        return null;
    }

    #endregion

    #region Bool

    public SqlExpression ToBool(SqlExpression expression)
    {
        return Function(
            name: "toBool",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(bool),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(bool)));
    }

    #endregion

    #region Int8

    public SqlExpression ToInt8(SqlExpression expression)
    {
        return Function(
            name: "toInt8",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(sbyte),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(sbyte)));
    }

    public SqlExpression ToInt8OrZero(SqlExpression expression)
    {
        return Function(
            name: "toInt8OrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(sbyte),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(sbyte)));
    }

    public SqlExpression ToInt8OrNull(SqlExpression expression)
    {
        return Function(
            name: "toInt8OrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(sbyte),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(sbyte)));
    }

    public SqlExpression ToInt8OrDefault(SqlExpression expression)
    {
        return Function(
            name: "toInt8OrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(sbyte),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(sbyte)));
    }

    public SqlExpression ToInt8OrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: sbyte })
        {
            defaultValue = ToInt8(defaultValue);
        }

        return Function(
            name: "toInt8OrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(sbyte),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(sbyte)));
    }

    #endregion

    #region Int16

    public SqlExpression ToInt16(SqlExpression expression)
    {
        return Function(
            name: "toInt16",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(short),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(short)));
    }

    public SqlExpression ToInt16OrZero(SqlExpression expression)
    {
        return Function(
            name: "toInt16OrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(short),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(short)));
    }

    public SqlExpression ToInt16OrNull(SqlExpression expression)
    {
        return Function(
            name: "toInt16OrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(short),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(short)));
    }

    public SqlExpression ToInt16OrDefault(SqlExpression expression)
    {
        return Function(
            name: "toInt16OrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(short),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(short)));
    }
    
    public SqlExpression ToInt16OrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: short })
        {
            defaultValue = ToInt16(defaultValue);
        }

        return Function(
            name: "toInt16OrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(short),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(short)));
    }

    #endregion

    #region Int32

    public SqlExpression ToInt32(SqlExpression expression)
    {
        return Function(
            name: "toInt32",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(int),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(int)));
    }

    public SqlExpression ToInt32OrZero(SqlExpression expression)
    {
        return Function(
            name: "toInt32OrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(int),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(int)));
    }

    public SqlExpression ToInt32OrNull(SqlExpression expression)
    {
        return Function(
            name: "toInt32OrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(int),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(int)));
    }

    public SqlExpression ToInt32OrDefault(SqlExpression expression)
    {
        return Function(
            name: "toInt32OrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(int),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(int)));
    }
    
    public SqlExpression ToInt32OrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: int })
        {
            defaultValue = ToInt32(defaultValue);
        }

        return Function(
            name: "toInt32OrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(int),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(int)));
    }

    #endregion

    #region Int64

    public SqlExpression ToInt64(SqlExpression expression)
    {
        return Function(
            name: "toInt64",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(long),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(long)));
    }

    public SqlExpression ToInt64OrZero(SqlExpression expression)
    {
        return Function(
            name: "toInt64OrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(long),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(long)));
    }

    public SqlExpression ToInt64OrNull(SqlExpression expression)
    {
        return Function(
            name: "toInt64OrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(long),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(long)));
    }

    public SqlExpression ToInt64OrDefault(SqlExpression expression)
    {
        return Function(
            name: "toInt64OrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(long),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(long)));
    }
    
    public SqlExpression ToInt64OrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: long })
        {
            defaultValue = ToInt64(defaultValue);
        }

        return Function(
            name: "toInt64OrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(long),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(long)));
    }

    #endregion

    #region Int128

    public SqlExpression ToInt128(SqlExpression expression)
    {
        return Function(
            name: "toInt128",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(Int128),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(Int128)));
    }

    public SqlExpression ToInt128OrZero(SqlExpression expression)
    {
        return Function(
            name: "toInt128OrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(Int128),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(Int128)));
    }

    public SqlExpression ToInt128OrNull(SqlExpression expression)
    {
        return Function(
            name: "toInt128OrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(Int128),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(Int128)));
    }

    public SqlExpression ToInt128OrDefault(SqlExpression expression)
    {
        return Function(
            name: "toInt128OrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(Int128),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(Int128)));
    }
    
    public SqlExpression ToInt128OrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: Int128 })
        {
            defaultValue = ToInt128(defaultValue);
        }

        return Function(
            name: "toInt128OrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(Int128),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(Int128)));
    }

    #endregion
    
    #region UInt8

    public SqlExpression ToUInt8(SqlExpression expression)
    {
        return Function(
            name: "toUInt8",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(byte),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(byte)));
    }

    public SqlExpression ToUInt8OrZero(SqlExpression expression)
    {
        return Function(
            name: "toUInt8OrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(byte),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(byte)));
    }

    public SqlExpression ToUInt8OrNull(SqlExpression expression)
    {
        return Function(
            name: "toUInt8OrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(byte),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(byte)));
    }

    public SqlExpression ToUInt8OrDefault(SqlExpression expression)
    {
        return Function(
            name: "toUInt8OrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(byte),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(byte)));
    }

    public SqlExpression ToUInt8OrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: byte })
        {
            defaultValue = ToUInt8(defaultValue);
        }

        return Function(
            name: "toUInt8OrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(byte),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(byte)));
    }

    #endregion

    #region UInt16

    public SqlExpression ToUInt16(SqlExpression expression)
    {
        return Function(
            name: "toUInt16",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(ushort),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(ushort)));
    }

    public SqlExpression ToUInt16OrZero(SqlExpression expression)
    {
        return Function(
            name: "toUInt16OrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(ushort),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(ushort)));
    }

    public SqlExpression ToUInt16OrNull(SqlExpression expression)
    {
        return Function(
            name: "toUInt16OrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(ushort),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(ushort)));
    }

    public SqlExpression ToUInt16OrDefault(SqlExpression expression)
    {
        return Function(
            name: "toUInt16OrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(ushort),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(ushort)));
    }

    public SqlExpression ToUInt16OrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: ushort })
        {
            defaultValue = ToUInt16(defaultValue);
        }

        return Function(
            name: "toUInt16OrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(ushort),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(ushort)));
    }

    #endregion

    #region UInt32

    public SqlExpression ToUInt32(SqlExpression expression)
    {
        return Function(
            name: "toUInt32",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(uint),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(uint)));
    }

    public SqlExpression ToUInt32OrZero(SqlExpression expression)
    {
        return Function(
            name: "toUInt32OrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(uint),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(uint)));
    }

    public SqlExpression ToUInt32OrNull(SqlExpression expression)
    {
        return Function(
            name: "toUInt32OrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(uint),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(uint)));
    }

    public SqlExpression ToUInt32OrDefault(SqlExpression expression)
    {
        return Function(
            name: "toUInt32OrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(uint),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(uint)));
    }

    public SqlExpression ToUInt32OrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: uint })
        {
            defaultValue = ToUInt32(defaultValue);
        }

        return Function(
            name: "toUInt32OrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(uint),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(uint)));
    }

    #endregion

    #region UInt64

    public SqlExpression ToUInt64(SqlExpression expression)
    {
        return Function(
            name: "toUInt64",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(ulong),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(ulong)));
    }

    public SqlExpression ToUInt64OrZero(SqlExpression expression)
    {
        return Function(
            name: "toUInt64OrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(ulong),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(ulong)));
    }

    public SqlExpression ToUInt64OrNull(SqlExpression expression)
    {
        return Function(
            name: "toUInt64OrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(ulong),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(ulong)));
    }

    public SqlExpression ToUInt64OrDefault(SqlExpression expression)
    {
        return Function(
            name: "toUInt64OrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(ulong),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(ulong)));
    }

    public SqlExpression ToUInt64OrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: ulong })
        {
            defaultValue = ToUInt64(defaultValue);
        }

        return Function(
            name: "toUInt64OrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(ulong),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(ulong)));
    }

    #endregion

    #region UInt128

    public SqlExpression ToUInt128(SqlExpression expression)
    {
        return Function(
            name: "toUInt128",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(UInt128),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(UInt128)));
    }

    public SqlExpression ToUInt128OrZero(SqlExpression expression)
    {
        return Function(
            name: "toUInt128OrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(UInt128),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(UInt128)));
    }

    public SqlExpression ToUInt128OrNull(SqlExpression expression)
    {
        return Function(
            name: "toUInt128OrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(UInt128),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(UInt128)));
    }

    public SqlExpression ToUInt128OrDefault(SqlExpression expression)
    {
        return Function(
            name: "toUInt128OrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(UInt128),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(UInt128)));
    }

    public SqlExpression ToUInt128OrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: UInt128 })
        {
            defaultValue = ToUInt128(defaultValue);
        }

        return Function(
            name: "toUInt128OrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(UInt128),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(UInt128)));
    }

    #endregion

    #region Guid

    public SqlExpression GenerateUuidV4()
    {
        return NiladicFunction(
            name: "generateUUIDv4",
            nullable: false,
            returnType: typeof(Guid),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(Guid)));
    }

    public SqlExpression ToUuid(SqlExpression expression)
    {
        return Function(
            name: "toUUID",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(Guid),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(Guid)));
    }

    public SqlExpression ToUuidOrZero(SqlExpression expression)
    {
        return Function(
            name: "toUUIDOrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(Guid),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(Guid)));
    }

    public SqlExpression ToUuidOrNull(SqlExpression expression)
    {
        return Function(
            name: "toUUIDOrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(Guid),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(Guid)));
    }
    
    public SqlExpression ToUuidOrDefault(SqlExpression expression)
    {
        return Function(
            name: "toUUIDOrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(Guid),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(Guid)));
    }
    
    public SqlExpression ToUuidOrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: Guid })
        {
            defaultValue = ToUuid(defaultValue);
        }
        
        return Function(
            name: "toUUIDOrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(Guid),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(Guid)));
    }
    
    #endregion

    #region Float32

    public SqlExpression ToFloat32(SqlExpression expression)
    {
        return Function(
            name: "toFloat32",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(float),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(float)));
    }

    public SqlExpression ToFloat32OrZero(SqlExpression expression)
    {
        return Function(
            name: "toFloat32OrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(float),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(float)));
    }
    
    public SqlExpression ToFloat32OrNull(SqlExpression expression)
    {
        return Function(
            name: "toFloat32OrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(float),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(float)));
    }
    
    public SqlExpression ToFloat32OrDefault(SqlExpression expression)
    {
        return Function(
            name: "toFloat32OrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(float),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(float)));
    }
    
    public SqlExpression ToFloat32OrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: float })
        {
            defaultValue = ToFloat32(defaultValue);
        }
        
        return Function(
            name: "toFloat32OrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(float),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(float)));
    }
    
    #endregion

    #region Float64

    public SqlExpression ToFloat64(SqlExpression expression)
    {
        return Function(
            name: "toFloat64",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(double),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(double)));
    }

    public SqlExpression ToFloat64OrZero(SqlExpression expression)
    {
        return Function(
            name: "toFloat64OrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(double),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(double)));
    }
    
    public SqlExpression ToFloat64OrNull(SqlExpression expression)
    {
        return Function(
            name: "toFloat64OrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(double),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(double)));
    }
    
    public SqlExpression ToFloat64OrDefault(SqlExpression expression)
    {
        return Function(
            name: "toFloat64OrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(double),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(double)));
    }
    
    public SqlExpression ToFloat64OrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: double })
        {
            defaultValue = ToFloat64(defaultValue);
        }
        
        return Function(
            name: "toFloat64OrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(double),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(double)));
    }
    
    #endregion

    #region Date

    public SqlExpression ToDate(SqlExpression expression)
    {
        return Function(
            name: "toDate",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(DateOnly),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateOnly)));
    }
    
    public SqlExpression ToDate(SqlExpression expression, SqlExpression timeZone)
    {
        return Function(
            name: "toDate",
            arguments: [expression, timeZone],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(DateOnly),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateOnly)));
    }

    public SqlExpression ToDateOrZero(SqlExpression expression)
    {
        return Function(
            name: "toDateOrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(DateOnly),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateOnly)));
    }
    
    public SqlExpression ToDateOrNull(SqlExpression expression)
    {
        return Function(
            name: "toDateOrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(DateOnly),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateOnly)));
    }
    
    public SqlExpression ToDateOrDefault(SqlExpression expression)
    {
        return Function(
            name: "toDateOrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(DateOnly),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateOnly)));
    }
    
    public SqlExpression ToDateOrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: DateOnly })
        {
            defaultValue = ToDate(defaultValue);
        }
        
        return Function(
            name: "toDateOrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(DateOnly),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateOnly)));
    }
    
    #endregion

    #region DateTime

    public SqlExpression ToDateTime(SqlExpression expression)
    {
        return Function(
            name: "toDateTime",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(DateTime),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateTime)));
    }

    public SqlExpression ToDateTime(SqlExpression expression, SqlExpression timeZone)
    {
        return Function(
            name: "toDateTime",
            arguments: [expression, timeZone],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(DateTime),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateTime)));
    }

    public SqlExpression ToDateTimeOrZero(SqlExpression expression)
    {
        return Function(
            name: "toDateTimeOrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(DateTime),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateTime)));
    }

    public SqlExpression ToDateTimeOrNull(SqlExpression expression)
    {
        return Function(
            name: "toDateTimeOrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(DateTime),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateTime)));
    }

    public SqlExpression ToDateTimeOrDefault(SqlExpression expression)
    {
        return Function(
            name: "toDateTimeOrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(DateTime),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateTime)));
    }

    public SqlExpression ToDateTimeOrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: DateTime })
        {
            defaultValue = ToDateTime(defaultValue);
        }
        
        return Function(
            name: "toDateTimeOrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(DateTime),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateTime)));
    }

    #endregion

    #region Date32

    public SqlExpression ToDate32(SqlExpression expression)
    {
        return Function(
            name: "toDate32",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(DateOnly),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateOnly)));
    }

    public SqlExpression ToDate32OrZero(SqlExpression expression)
    {
        return Function(
            name: "toDate32OrZero",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(DateOnly),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateOnly)));
    }

    public SqlExpression ToDate32OrNull(SqlExpression expression)
    {
        return Function(
            name: "toDate32OrNull",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(DateOnly),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateOnly)));
    }

    public SqlExpression ToDate32OrDefault(SqlExpression expression)
    {
        return Function(
            name: "toDate32OrDefault",
            arguments: [expression],
            argumentsPropagateNullability: [true],
            nullable: true,
            returnType: typeof(DateOnly),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateOnly)));
    }

    public SqlExpression ToDate32OrDefault(SqlExpression expression, SqlExpression defaultValue)
    {
        if (defaultValue is SqlConstantExpression { Value: DateOnly })
        {
            defaultValue = ToDate32(defaultValue);
        }
        
        return Function(
            name: "toDate32OrDefault",
            arguments: [expression, defaultValue],
            argumentsPropagateNullability: [true, true],
            nullable: true,
            returnType: typeof(DateOnly),
            typeMapping: Dependencies.TypeMappingSource.FindMapping(typeof(DateOnly)));
    }

    #endregion

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
