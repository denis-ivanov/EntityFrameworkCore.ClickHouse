using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseGuidTranslator : IMethodCallTranslator
{
    private static readonly MethodInfo New = typeof(Guid)
        .GetRuntimeMethod(nameof(Guid.NewGuid), Type.EmptyTypes);

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseGuidTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression Translate(
        SqlExpression instance, 
        MethodInfo method, 
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.Equals(New))
        {
            return _sqlExpressionFactory.Function(
                name: "generateUUIDv4",
                arguments: arguments,
                false,
                Array.Empty<bool>(),
                returnType: method.ReturnType);
        }

        return null;
    }
}
