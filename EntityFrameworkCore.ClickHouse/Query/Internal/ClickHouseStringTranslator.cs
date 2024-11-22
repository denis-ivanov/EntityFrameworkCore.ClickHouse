using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseStringTranslator : IMethodCallTranslator, IMemberTranslator
{
    private static readonly MethodInfo ToUpper = typeof(string)
        .GetTypeInfo()
        .GetRuntimeMethod(nameof(string.ToUpper), Type.EmptyTypes);

    private static readonly MethodInfo ToLower = typeof(string)
        .GetTypeInfo()
        .GetRuntimeMethod(nameof(string.ToLower), Type.EmptyTypes);

    private static readonly MethodInfo IsNullOrEmpty = typeof(string)
        .GetTypeInfo()
        .GetRuntimeMethod(nameof(string.IsNullOrEmpty), [typeof(string)]);

    private static readonly MethodInfo IsNullOrWhiteSpace = typeof(string)
        .GetTypeInfo()
        .GetRuntimeMethod(nameof(string.IsNullOrWhiteSpace), [typeof(string)]);

    private static readonly PropertyInfo Length = typeof(string)
        .GetTypeInfo()
        .GetRuntimeProperty(nameof(string.Length));

    private static readonly MethodInfo TrimStart = typeof(string)
        .GetRuntimeMethod(nameof(string.TrimStart), Type.EmptyTypes);

    private static readonly MethodInfo TrimEnd = typeof(string)
        .GetRuntimeMethod(nameof(string.TrimEnd), Type.EmptyTypes);

    private static readonly MethodInfo Trim = typeof(string)
        .GetRuntimeMethod(nameof(string.Trim), Type.EmptyTypes);

    private static readonly MethodInfo StartsWith = typeof(string)
        .GetRuntimeMethod(nameof(string.StartsWith), [typeof(string)]);

    private static readonly MethodInfo EndsWith = typeof(string)
        .GetRuntimeMethod(nameof(string.EndsWith), [typeof(string)]);

    private static readonly MethodInfo Contains = typeof(string)
        .GetRuntimeMethod(nameof(string.Contains), [typeof(string)]);

    private static readonly MethodInfo IndexOf = typeof(string)
        .GetRuntimeMethod(nameof(string.IndexOf), [typeof(string)]);

    private static readonly MethodInfo IndexOfWithStartingPosition = typeof(string)
        .GetRuntimeMethod(nameof(string.IndexOf), [typeof(string), typeof(int)]);

    private static readonly MethodInfo IsMatch = typeof(Regex)
        .GetRuntimeMethod(nameof(Regex.IsMatch), [typeof(string), typeof(string)]);

    private static readonly MethodInfo FirstOrDefaultWithoutArgs = typeof(Enumerable)
        .GetRuntimeMethods().Single(m => m.Name == nameof(Enumerable.FirstOrDefault)
                                         && m.GetParameters().Length == 1).MakeGenericMethod(typeof(char));

    private static readonly MethodInfo LastOrDefaultWithoutArgs = typeof(Enumerable)
        .GetRuntimeMethods().Single(m => m.Name == nameof(Enumerable.LastOrDefault)
                                         && m.GetParameters().Length == 1).MakeGenericMethod(typeof(char));

    private static readonly MethodInfo SubstringWithStartIndex = typeof(string)
        .GetRuntimeMethod(nameof(string.Substring), [typeof(int)]);

    private static readonly MethodInfo SubstringWithIndexAndLength = typeof(string)
        .GetRuntimeMethod(nameof(string.Substring), [typeof(int), typeof(int)]);

    private static readonly MethodInfo ReplaceAll = typeof(string)
        .GetRuntimeMethod(nameof(string.Replace), [typeof(string), typeof(string)]);

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseStringTranslator([NotNull]ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression Translate(SqlExpression instance, MethodInfo method, IReadOnlyList<SqlExpression> arguments, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (ToLower.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                "lowerUTF8",
                [instance],
                true,
                [true],
                method.ReturnType,
                instance.TypeMapping);
        }

        if (ToUpper.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                "upperUTF8",
                [instance],
                true,
                [true],
                method.ReturnType,
                instance.TypeMapping);
        }

        if (IsNullOrEmpty.Equals(method))
        {
            return _sqlExpressionFactory.OrElse(
                _sqlExpressionFactory.IsNull(arguments[0]),
                _sqlExpressionFactory.Function(
                    "empty",
                    arguments.ToArray(),
                    false,
                    [true],
                    method.ReturnType,
                    arguments[0].TypeMapping));
        }

        if (IsNullOrWhiteSpace.Equals(method))
        {
            return _sqlExpressionFactory.OrElse(
                _sqlExpressionFactory.IsNull(arguments[0]),
                _sqlExpressionFactory.Function(
                    "empty",
                    [
                        _sqlExpressionFactory.Function(
                            name: "trim",
                            arguments: arguments,
                            nullable: true,
                            argumentsPropagateNullability: [true],
                            returnType: method.ReturnType)
                    ],
                    false,
                    [true],
                    method.ReturnType,
                    arguments[0].TypeMapping));
        }

        if (TrimStart.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "trimLeft",
                arguments: [instance],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: method.ReturnType);
        }

        if (TrimEnd.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "trimRight",
                arguments: [instance],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: method.ReturnType);
        }

        if (Trim.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "trim",
                arguments: [instance],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType: method.ReturnType);
        }

        if (StartsWith.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "startsWith",
                arguments: arguments.Prepend(instance),
                nullable: true,
                argumentsPropagateNullability: Enumerable.Repeat(true, arguments.Count + 1),
                returnType: method.ReturnType);
        }

        if (EndsWith.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "endsWith",
                arguments: arguments.Prepend(instance),
                nullable: true,
                argumentsPropagateNullability: Enumerable.Repeat(true, arguments.Count + 1),
                returnType: method.ReturnType);
        }

        if (Contains.Equals(method))
        {
            return _sqlExpressionFactory.GreaterThan(
                _sqlExpressionFactory.Function(
                    name: "positionUTF8",
                    arguments: arguments.Prepend(instance),
                    nullable: false,
                    argumentsPropagateNullability: Enumerable.Repeat(true, arguments.Count + 1),
                    returnType: typeof(int)),
                _sqlExpressionFactory.Constant(0));
        }

        if (IsMatch.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "match",
                arguments: arguments,
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: method.ReturnType);
        }

        if (FirstOrDefaultWithoutArgs.Equals(method))
        {
            var argument = arguments[0];

            return _sqlExpressionFactory.Function(
                "substring",
                [argument, _sqlExpressionFactory.Constant(1), _sqlExpressionFactory.Constant(1)],
                nullable: true,
                argumentsPropagateNullability: [true, true, true],
                method.ReturnType);
        }

        if (LastOrDefaultWithoutArgs.Equals(method))
        {
            var argument = arguments[0];
            return _sqlExpressionFactory.Function(
                "substring",
                [
                    argument,
                    _sqlExpressionFactory.Function(
                        "lengthUTF8",
                        [argument],
                        nullable: true,
                        argumentsPropagateNullability: [true],
                        typeof(int)),
                    _sqlExpressionFactory.Constant(1)
                ],
                nullable: true,
                argumentsPropagateNullability: [true, true, true],
                method.ReturnType);
        }

        if (SubstringWithStartIndex.Equals(method))
        {
            var startIndex = arguments[0];
            
            return _sqlExpressionFactory.Function(
                "substring",
                [instance, _sqlExpressionFactory.Add(startIndex, _sqlExpressionFactory.Constant(1))],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                method.ReturnType);
        }

        if (SubstringWithIndexAndLength.Equals(method))
        {
            var startIndex = arguments[0];
            var length = arguments[1];

            return _sqlExpressionFactory.Function(
                "substring",
                [instance, _sqlExpressionFactory.Add(startIndex, _sqlExpressionFactory.Constant(1)), length],
                nullable: true,
                argumentsPropagateNullability: [true, true, true],
                method.ReturnType);
        }

        if (IndexOf.Equals(method))
        {
            return _sqlExpressionFactory.Subtract(_sqlExpressionFactory.Function(
                    name: "positionUTF8",
                    arguments: arguments.Prepend(instance),
                    nullable: true,
                    argumentsPropagateNullability: Enumerable.Repeat(true, arguments.Count + 1),
                    method.ReturnType),
                _sqlExpressionFactory.Constant(1));
        }

        if (IndexOfWithStartingPosition.Equals(method))
        {
            return TranslateIndexOf(method, instance, arguments[0], arguments[1]);
        }

        if (ReplaceAll.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                "replaceAll",
                arguments: arguments.Prepend(instance),
                nullable: true,
                argumentsPropagateNullability: [true, true, true],
                method.ReturnType);
        }

        if (method.Name == nameof(string.Concat))
        {
            return _sqlExpressionFactory.Function(
                "concat",
                arguments: arguments,
                nullable: true,
                argumentsPropagateNullability: Enumerable.Repeat(true, arguments.Count),
                method.ReturnType);
        }

        if (method.DeclaringType == typeof(string) && method.Name == nameof(string.Join))
        {
            return _sqlExpressionFactory.Function(
                name: "concatWithSeparator",
                arguments: arguments,
                nullable: true,
                argumentsPropagateNullability: Enumerable.Repeat(true, arguments.Count),
                method.ReturnType);
        }

        return null;
    }

    public SqlExpression Translate(SqlExpression instance, MemberInfo member, Type returnType, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (member.Equals(Length))
        {
            return _sqlExpressionFactory.Function(
                "char_length",
                [instance],
                nullable: true,
                argumentsPropagateNullability: [true],
                returnType);
        }

        return null;
    }

    private SqlExpression TranslateIndexOf(
        MethodInfo method,
        SqlExpression instance,
        SqlExpression searchExpression,
        SqlExpression startIndex)
    {
        var indexOfArguments = new[]
        {
            instance,
            searchExpression,
            startIndex is SqlConstantExpression { Value : int constantStartIndex }
                ? _sqlExpressionFactory.Constant(constantStartIndex + 1, typeof(int))
                : _sqlExpressionFactory.Convert(
                    _sqlExpressionFactory.Add(startIndex, _sqlExpressionFactory.Constant(1)),
                    typeof(uint))
        };

        return _sqlExpressionFactory.Subtract(_sqlExpressionFactory.Function(
                name: "positionUTF8",
                arguments: indexOfArguments,
                nullable: true,
                argumentsPropagateNullability: [true, true, true],
                method.ReturnType),
            _sqlExpressionFactory.Constant(1));
    }
}
