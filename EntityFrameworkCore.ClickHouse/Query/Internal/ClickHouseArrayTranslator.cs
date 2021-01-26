using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal
{
    public class ClickHouseArrayTranslator : IMethodCallTranslator, IMemberTranslator
    {
        private readonly ISqlExpressionFactory _sqlExpressionFactory;

        public ClickHouseArrayTranslator(ISqlExpressionFactory sqlExpressionFactory)
        {
            _sqlExpressionFactory = sqlExpressionFactory;
        }

        public SqlExpression Translate(SqlExpression instance, MemberInfo member, Type returnType, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
        {
            return instance.Type.IsArray &&
                   member.Name == nameof(Array.Length)
                ? _sqlExpressionFactory.Function(
                    "length",
                    new[] { instance },
                    nullable: true,
                    argumentsPropagateNullability: new[] { true },
                    returnType)
                : null;
        }

        public SqlExpression Translate(SqlExpression instance, MethodInfo method, IReadOnlyList<SqlExpression> arguments, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
        {
            return null;
        }
    }
}
