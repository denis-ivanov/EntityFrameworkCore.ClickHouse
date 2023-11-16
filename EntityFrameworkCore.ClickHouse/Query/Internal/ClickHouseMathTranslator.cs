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
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(decimal) })!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(double) })!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(float) })!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(int) })!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(long) })!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(nint) })!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(sbyte) })!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Abs), new[] { typeof(short) })!, "abs" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Abs), new[] { typeof(float) })!, "abs" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Atan2), new[] { typeof(double), typeof(double) })!, "atan2" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Atan2), new[] { typeof(float), typeof(float) })!, "atan2" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Exp), new[] { typeof(double) })!, "exp" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Exp), new[] { typeof(float) })!, "exp" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Log), new[] { typeof(double) })!, "log" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Log), new[] { typeof(float) })!, "log" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Log10), new[] { typeof(double) })!, "log10" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Log10), new[] { typeof(float) })!, "log10" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sqrt), new[] { typeof(double) })!, "sqrt" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Sqrt), new[] { typeof(float) })!, "sqrt" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Cbrt), new[] { typeof(double) })!, "cbrt" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sin), new[] { typeof(double) })!, "sin" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Sin), new[] { typeof(float) })!, "sin" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Cos), new[] { typeof(double) })!, "cos" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Cos), new[] { typeof(float) })!, "cos" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Tan), new[] { typeof(double) })!, "tan" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Tan), new[] { typeof(float) })!, "tan" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Asin), new[] { typeof(double) })!, "asin" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Asin), new[] { typeof(float) })!, "asin" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Acos), new[] { typeof(double) })!, "acos" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Acos), new[] { typeof(float) })!, "acos" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Atan), new[] { typeof(double) })!, "atan" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Atan), new[] { typeof(float) })!, "atan" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Pow), new[] { typeof(double), typeof(double) })!, "pow" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Pow), new[] { typeof(float), typeof(float) })!, "pow" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Cosh), new[] { typeof(double) })!, "cosh" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Acosh), new[] { typeof(double) })!, "acosh" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Ceiling), new[] { typeof(double) })!, "ceiling" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Ceiling), new[] { typeof(decimal) })!, "ceiling" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Ceiling), new[] { typeof(float) })!, "ceiling" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Round), new[] { typeof(double) })!, "round" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Round), new[] { typeof(double), typeof(int) })!, "round" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Round), new[] { typeof(decimal) })!, "round" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Round), new[] { typeof(decimal), typeof(int) })!, "round" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Round), new[] { typeof(float), typeof(int) })!, "round" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Truncate), new[] { typeof(double) })!, "truncate" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Truncate), new[] { typeof(decimal) })!, "truncate" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Truncate), new[] { typeof(float) })!, "truncate" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Floor), new[] { typeof(decimal) })!, "floor" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Floor), new[] { typeof(double) })!, "floor" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Floor), new[] { typeof(float) })!, "floor" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(byte), typeof(byte) })!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(decimal), typeof(decimal) })!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(double), typeof(double) })!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(float), typeof(float) })!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(int), typeof(int) })!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(long), typeof(long) })!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(nint), typeof(nint) })!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(nuint), typeof(nuint) })!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(sbyte), typeof(sbyte) })!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(short), typeof(short) })!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(uint), typeof(uint) })!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(ulong), typeof(ulong) })!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Max), new[] { typeof(ushort), typeof(ushort) })!, "greatest" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(byte), typeof(byte) })!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(decimal), typeof(decimal) })!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(double), typeof(double) })!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(float), typeof(float) })!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(int), typeof(int) })!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(long), typeof(long) })!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(nint), typeof(nint) })!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(nuint), typeof(nuint) })!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(sbyte), typeof(sbyte) })!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(short), typeof(short) })!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(uint), typeof(uint) })!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(ulong), typeof(ulong) })!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Min), new[] { typeof(ushort), typeof(ushort) })!, "least" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(decimal) })!, "sign" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(double) })!, "sign" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(float) })!, "sign" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(int) })!, "sign" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(long) })!, "sign" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(nint) })!, "sign" },
        { typeof(Math).GetRuntimeMethod(nameof(Math.Sign), new[] { typeof(short) })!, "sign" },
        { typeof(MathF).GetRuntimeMethod(nameof(MathF.Sign), new[] { typeof(float) })!, "sign" }
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
