using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseConvertTranslator : IMethodCallTranslator, IMemberTranslator
{
    private const int DecimalScale = 28;
    
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseConvertTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression Translate(SqlExpression instance, MethodInfo method, IReadOnlyList<SqlExpression> arguments, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        var argc = method.GetParameters().Length;

        if (argc != 1)
        {
            return null;
        }

        if ((method.DeclaringType == typeof(Convert) && method.Name == nameof(Convert.ToSByte)) ||
            (method.DeclaringType == typeof(sbyte) && method.Name == nameof(byte.Parse)))
        {
            return _sqlExpressionFactory.Function(
                name: "toInt8",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if ((method.DeclaringType == typeof(Convert) && method.Name == nameof(Convert.ToInt16)) ||
            (method.DeclaringType == typeof(short) && method.Name == nameof(short.Parse)))
        {
            return _sqlExpressionFactory.Function(
                name: "toInt16",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if ((method.DeclaringType == typeof(Convert) && method.Name == nameof(Convert.ToInt32)) ||
            (method.DeclaringType == typeof(int) && method.Name == nameof(int.Parse)))
        {
            return _sqlExpressionFactory.Function(
                name: "toInt32",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if ((method.DeclaringType == typeof(Convert) && method.Name == nameof(Convert.ToInt64)) ||
            (method.DeclaringType == typeof(long) && method.Name == nameof(long.Parse)))
        {
            return _sqlExpressionFactory.Function(
                name: "toInt64",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if ((method.DeclaringType == typeof(Convert) && method.Name == nameof(Convert.ToByte)) ||
            method.DeclaringType == typeof(byte) && method.Name == nameof(byte.Parse))
        {
            return _sqlExpressionFactory.Function(
                name: "toUInt8",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if ((method.DeclaringType == typeof(Convert) && method.Name == nameof(Convert.ToUInt16)) ||
            (method.DeclaringType == typeof(ushort) && method.Name == nameof(ushort.Parse)))
        {
            return _sqlExpressionFactory.Function(
                name: "toUInt16",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if ((method.DeclaringType == typeof(Convert) && method.Name == nameof(Convert.ToUInt32)) ||
            (method.DeclaringType == typeof(uint) && method.Name == nameof(uint.Parse)))
        {
            return _sqlExpressionFactory.Function(
                name: "toUInt32",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if ((method.DeclaringType == typeof(Convert) && method.Name == nameof(Convert.ToUInt64)) ||
            (method.DeclaringType == typeof(ulong) && method.Name == nameof(ulong.Parse)))
        {
            return _sqlExpressionFactory.Function(
                name: "toUInt64",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if ((method.DeclaringType == typeof(Convert) && method.Name == nameof(Convert.ToSingle)) ||
            (method.DeclaringType == typeof(float) && method.Name == nameof(float.Parse)))
        {
            return _sqlExpressionFactory.Function(
                name: "toFloat32",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if ((method.DeclaringType == typeof(Convert) && method.Name == nameof(Convert.ToDouble)) ||
            (method.DeclaringType == typeof(double) && method.Name == nameof(double.Parse)))
        {
            return _sqlExpressionFactory.Function(
                name: "toFloat64",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if ((method.DeclaringType == typeof(Convert) && method.Name == nameof(Convert.ToDateTime)) ||
            (method.DeclaringType == typeof(DateTime) && method.Name == nameof(DateTime.Parse)))
        {
            return _sqlExpressionFactory.Function(
                name: "toDateTime",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if ((method.DeclaringType == typeof(Convert) && method.Name == nameof(Convert.ToBoolean)) ||
            (method.DeclaringType == typeof(bool) && method.Name == nameof(bool.Parse)))
        {
            return _sqlExpressionFactory.Function(
                name: "toUInt8",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if ((method.DeclaringType == typeof(Convert) && method.Name == nameof(Convert.ToDecimal)) ||
            (method.DeclaringType == typeof(decimal) && method.Name == nameof(decimal.Parse)))
        {
            return _sqlExpressionFactory.Function(
                name: "toDecimal128",
                arguments: arguments.Append(_sqlExpressionFactory.Constant(DecimalScale)),
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if (method.DeclaringType == typeof(Convert) && method.Name == nameof(Convert.ToString))
        {
            return _sqlExpressionFactory.Function(
                name: "toString",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        return null;
    }

    public SqlExpression Translate(SqlExpression instance, MemberInfo member, Type returnType, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        return null;
    }
}
