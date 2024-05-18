using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseMathTranslator: IMethodCallTranslator, IMemberTranslator
{
    private static readonly Dictionary<MethodInfo, string> SupportedMethods = new()
    {
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), [typeof(decimal)])!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), [typeof(double)])!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), [typeof(float)])!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), [typeof(int)])!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), [typeof(long)])!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), [typeof(nint)])!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), [typeof(sbyte)])!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), [typeof(short)])!, "abs" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Abs), [typeof(float)])!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Atan2), [typeof(double), typeof(double)])!, "atan2" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Atan2), [typeof(float), typeof(float)])!, "atan2" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Exp), [typeof(double)])!, "exp" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Exp), [typeof(float)])!, "exp" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Log), [typeof(double)])!, "log" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Log), [typeof(float)])!, "log" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Log10), [typeof(double)])!, "log10" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Log10), [typeof(float)])!, "log10" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sqrt), [typeof(double)])!, "sqrt" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Sqrt), [typeof(float)])!, "sqrt" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Cbrt), [typeof(double)])!, "cbrt" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sin), [typeof(double)])!, "sin" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Sin), [typeof(float)])!, "sin" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Cos), [typeof(double)])!, "cos" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Cos), [typeof(float)])!, "cos" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Tan), [typeof(double)])!, "tan" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Tan), [typeof(float)])!, "tan" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Asin), [typeof(double)])!, "asin" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Asin), [typeof(float)])!, "asin" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Acos), [typeof(double)])!, "acos" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Acos), [typeof(float)])!, "acos" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Atan), [typeof(double)])!, "atan" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Atan), [typeof(float)])!, "atan" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Pow), [typeof(double), typeof(double)])!, "pow" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Pow), [typeof(float), typeof(float)])!, "pow" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Cosh), [typeof(double)])!, "cosh" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Acosh), [typeof(double)])!, "acosh" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Ceiling), [typeof(double)])!, "ceiling" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Ceiling), [typeof(decimal)])!, "ceiling" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Ceiling), [typeof(float)])!, "ceiling" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Round), [typeof(double)])!, "round" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Round), [typeof(double), typeof(int)])!, "round" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Round), [typeof(decimal)])!, "round" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Round), [typeof(decimal), typeof(int)])!, "round" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Round), [typeof(float), typeof(int)])!, "round" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Truncate), [typeof(double)])!, "truncate" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Truncate), [typeof(decimal)])!, "truncate" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Truncate), [typeof(float)])!, "truncate" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Floor), [typeof(decimal)])!, "floor" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Floor), [typeof(double)])!, "floor" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Floor), [typeof(float)])!, "floor" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), [typeof(byte), typeof(byte)])!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), [typeof(decimal), typeof(decimal)])!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), [typeof(double), typeof(double)])!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), [typeof(float), typeof(float)])!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), [typeof(int), typeof(int)])!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), [typeof(long), typeof(long)])!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), [typeof(nint), typeof(nint)])!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), [typeof(nuint), typeof(nuint)])!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), [typeof(sbyte), typeof(sbyte)])!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), [typeof(short), typeof(short)])!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), [typeof(uint), typeof(uint)])!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), [typeof(ulong), typeof(ulong)])!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), [typeof(ushort), typeof(ushort)])!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), [typeof(byte), typeof(byte)])!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), [typeof(decimal), typeof(decimal)])!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), [typeof(double), typeof(double)])!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), [typeof(float), typeof(float)])!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), [typeof(int), typeof(int)])!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), [typeof(long), typeof(long)])!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), [typeof(nint), typeof(nint)])!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), [typeof(nuint), typeof(nuint)])!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), [typeof(sbyte), typeof(sbyte)])!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), [typeof(short), typeof(short)])!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), [typeof(uint), typeof(uint)])!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), [typeof(ulong), typeof(ulong)])!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), [typeof(ushort), typeof(ushort)])!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sign), [typeof(decimal)])!, "sign" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sign), [typeof(double)])!, "sign" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sign), [typeof(float)])!, "sign" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sign), [typeof(int)])!, "sign" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sign), [typeof(long)])!, "sign" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sign), [typeof(nint)])!, "sign" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sign), [typeof(short)])!, "sign" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Sign), [typeof(float)])!, "sign" },
        { typeof(double).GetRuntimeMethod(nameof(double.RadiansToDegrees), [typeof(double)])!, "degrees" },
        { typeof(float).GetRuntimeMethod(nameof(float.RadiansToDegrees), [typeof(float)])!, "degrees" },
        { typeof(double).GetRuntimeMethod(nameof(double.DegreesToRadians), [typeof(double)])!, "radians" },
        { typeof(float).GetRuntimeMethod(nameof(float.DegreesToRadians), [typeof(float)])!, "radians" }
    };

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseMathTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression Translate(SqlExpression instance, MethodInfo method, IReadOnlyList<SqlExpression> arguments, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (SupportedMethods.TryGetValue(method, out var functionName))
        {
            return _sqlExpressionFactory.Function(
                name: functionName,
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
