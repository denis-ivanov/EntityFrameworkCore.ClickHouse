using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal
{
    public class ClickHouseStringTranslator : IMethodCallTranslator, IMemberTranslator
    {
        private static readonly MethodInfo ToUpperMethodInfo =
            typeof(string).GetTypeInfo().GetRuntimeMethod(nameof(string.ToUpper), Array.Empty<Type>());

        private static readonly MethodInfo ToLowerMethodInfo =
            typeof(string).GetTypeInfo().GetRuntimeMethod(nameof(string.ToLower), Array.Empty<Type>());

        private static readonly MethodInfo IsNullOrEmptyMethodInfo =
            typeof(string).GetTypeInfo().GetRuntimeMethod(nameof(string.IsNullOrEmpty), new [] { typeof(string) });

        private static readonly PropertyInfo LengthPropertyInfo =
            typeof(string).GetTypeInfo().GetRuntimeProperty(nameof(string.Length));

        private readonly ISqlExpressionFactory _sqlExpressionFactory;
        
        public ClickHouseStringTranslator([NotNull]ISqlExpressionFactory sqlExpressionFactory)
        {
            _sqlExpressionFactory = sqlExpressionFactory;
        }

        public SqlExpression Translate(SqlExpression instance, MethodInfo method, IReadOnlyList<SqlExpression> arguments, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
        {
            if (ToLowerMethodInfo.Equals(method))
            {
                return _sqlExpressionFactory.Function(
                    "lowerUTF8",
                    new[] { instance },
                    true,
                    new[] { true },
                    method.ReturnType,
                    instance.TypeMapping);
            }
            
            if (ToUpperMethodInfo.Equals(method))
            {
                return _sqlExpressionFactory.Function(
                    "upperUTF8",
                    new[] { instance },
                    true,
                    new[] { true },
                    method.ReturnType,
                    instance.TypeMapping);
            }

            if (IsNullOrEmptyMethodInfo.Equals(method))
            {
                return _sqlExpressionFactory.Function(
                    "empty",
                    arguments.ToArray(),
                    false,
                    new [] { true },
                    method.ReturnType,
                    arguments[0].TypeMapping);
            }

            return null;
        }

        public SqlExpression Translate(SqlExpression instance, MemberInfo member, Type returnType, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
        {
            if (member.Equals(LengthPropertyInfo))
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
}
