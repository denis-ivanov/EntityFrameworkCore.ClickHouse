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
        .GetRuntimeMethod(nameof(string.ToUpper), Array.Empty<Type>());

    private static readonly MethodInfo ToLower = typeof(string)
        .GetTypeInfo()
        .GetRuntimeMethod(nameof(string.ToLower), Array.Empty<Type>());

    private static readonly MethodInfo IsNullOrEmpty = typeof(string)
        .GetTypeInfo()
        .GetRuntimeMethod(nameof(string.IsNullOrEmpty), new [] { typeof(string) });

    private static readonly MethodInfo IsNullOrWhiteSpace = typeof(string)
        .GetTypeInfo()
        .GetRuntimeMethod(nameof(string.IsNullOrWhiteSpace), new [] { typeof(string) });

    private static readonly PropertyInfo Length = typeof(string)
        .GetTypeInfo()
        .GetRuntimeProperty(nameof(string.Length));

    private static readonly MethodInfo TrimStart = typeof(string)
        .GetRuntimeMethod(nameof(string.TrimStart), Array.Empty<Type>());

    private static readonly MethodInfo TrimEnd = typeof(string)
        .GetRuntimeMethod(nameof(string.TrimEnd), Array.Empty<Type>());

    private static readonly MethodInfo Trim = typeof(string)
        .GetRuntimeMethod(nameof(string.Trim), Array.Empty<Type>());

    private static readonly MethodInfo StartsWith = typeof(string)
        .GetRuntimeMethod(nameof(string.StartsWith), new[] { typeof(string) });

    private static readonly MethodInfo EndsWith = typeof(string)
        .GetRuntimeMethod(nameof(string.EndsWith), new[] { typeof(string) });

    private static readonly MethodInfo Contains = typeof(string)
        .GetRuntimeMethod(nameof(string.Contains), new[] { typeof(string) });

    private static readonly MethodInfo IsMatch = typeof(Regex)
        .GetRuntimeMethod(nameof(Regex.IsMatch), new[] { typeof(string), typeof(string) });

    private static readonly MethodInfo FirstOrDefaultWithoutArgs = typeof(Enumerable)
        .GetRuntimeMethods().Single(m => m.Name == nameof(Enumerable.FirstOrDefault)
                                         && m.GetParameters().Length == 1).MakeGenericMethod(typeof(char));

    private static readonly MethodInfo LastOrDefaultWithoutArgs = typeof(Enumerable)
        .GetRuntimeMethods().Single(m => m.Name == nameof(Enumerable.LastOrDefault)
                                         && m.GetParameters().Length == 1).MakeGenericMethod(typeof(char));

    private static readonly MethodInfo SubstringWithStartIndex = typeof(string)
        .GetRuntimeMethod(nameof(string.Substring), new[] { typeof(int) });
    
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
                new[] { instance },
                true,
                new[] { true },
                method.ReturnType,
                instance.TypeMapping);
        }

        if (ToUpper.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                "upperUTF8",
                new[] { instance },
                true,
                new[] { true },
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
                    new[] { true },
                    method.ReturnType,
                    arguments[0].TypeMapping));
        }

        if (IsNullOrWhiteSpace.Equals(method))
        {
            return _sqlExpressionFactory.OrElse(
                _sqlExpressionFactory.IsNull(arguments[0]),
                _sqlExpressionFactory.Function(
                    "empty",
                    new[]
                    {
                        _sqlExpressionFactory.Function(
                            name: "trim",
                            arguments: arguments,
                            nullable: true,
                            argumentsPropagateNullability: new[] { true },
                            returnType: method.ReturnType)
                    },
                    false,
                    new[] { true },
                    method.ReturnType,
                    arguments[0].TypeMapping));
        }
        
        if (TrimStart.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "trimLeft",
                arguments: new [] { instance },
                nullable: true,
                argumentsPropagateNullability: new [] { true },
                returnType: method.ReturnType);
        }

        if (TrimEnd.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "trimRight",
                arguments: new [] { instance },
                nullable: true,
                argumentsPropagateNullability: new [] { true },
                returnType: method.ReturnType);
        }

        if (Trim.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "trim",
                arguments: new [] { instance },
                nullable: true,
                argumentsPropagateNullability: new [] { true },
                returnType: method.ReturnType);
        }

        if (StartsWith.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "startsWith",
                arguments: arguments.Prepend(instance),
                nullable: true,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if (EndsWith.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "endsWith",
                arguments: arguments.Prepend(instance),
                nullable: true,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if (Contains.Equals(method))
        {
            return _sqlExpressionFactory.GreaterThan(
                _sqlExpressionFactory.Function(
                    name: "positionUTF8",
                    arguments: arguments.Prepend(instance),
                    nullable: false,
                    argumentsPropagateNullability: new[] { true },
                    returnType: typeof(int)),
                _sqlExpressionFactory.Constant(0));
        }

        if (IsMatch.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "match",
                arguments: arguments,
                nullable: true,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if (FirstOrDefaultWithoutArgs.Equals(method))
        {
            var argument = arguments[0];

            return _sqlExpressionFactory.Function(
                "substring",
                new[] { argument, _sqlExpressionFactory.Constant(1), _sqlExpressionFactory.Constant(1) },
                nullable: true,
                argumentsPropagateNullability: new[] { true, true, true },
                method.ReturnType);
        }

        if (LastOrDefaultWithoutArgs.Equals(method))
        {
            var argument = arguments[0];
            return _sqlExpressionFactory.Function(
                "substring",
                new[]
                {
                    argument,
                    _sqlExpressionFactory.Function(
                        "lengthUTF8",
                        new[] { argument },
                        nullable: true,
                        argumentsPropagateNullability: new[] { true },
                        typeof(int)),
                    _sqlExpressionFactory.Constant(1)
                },
                nullable: true,
                argumentsPropagateNullability: new[] { true, true, true },
                method.ReturnType);
        }

        if (SubstringWithStartIndex.Equals(method))
        {
            var startIndex = arguments[0];
            
            return _sqlExpressionFactory.Function(
                "substring",
                new[] { instance, _sqlExpressionFactory.Add(startIndex, _sqlExpressionFactory.Constant(1)) },
                nullable: true,
                argumentsPropagateNullability: new[] { true, true, true },
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
                new[] { instance },
                nullable: true,
                argumentsPropagateNullability: new[] { true },
                returnType);
        }

        return null;
    }
}
