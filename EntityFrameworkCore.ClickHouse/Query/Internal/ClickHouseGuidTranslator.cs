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
    private static readonly MethodInfo New = typeof(Guid).GetRuntimeMethod(nameof(Guid.NewGuid), Type.EmptyTypes);
    private static readonly MethodInfo Parse = typeof(Guid).GetRuntimeMethod(nameof(Guid.Parse), [typeof(string)]);

    private readonly ClickHouseSqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseGuidTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = (ClickHouseSqlExpressionFactory)sqlExpressionFactory;
    }

    public SqlExpression Translate(
        SqlExpression instance, 
        MethodInfo method, 
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.Equals(New))
        {
            return _sqlExpressionFactory.GenerateUuidV4();
        }

        if (method.Equals(Parse))
        {
            return _sqlExpressionFactory.ToUuid(arguments[0]);
        }

        if (method.DeclaringType == typeof(ClickHouseUuidDbFunctionsExtensions))
        {
            // TODO Write functional tests for this.
            switch (method.Name)
            {
                case nameof(ClickHouseUuidDbFunctionsExtensions.ToUuid):
                    return _sqlExpressionFactory.ToUuid(arguments[1]);

                case nameof(ClickHouseUuidDbFunctionsExtensions.ToUuidOrZero):
                    return _sqlExpressionFactory.ToUuidOrZero(arguments[1]);

                case nameof(ClickHouseUuidDbFunctionsExtensions.ToUuidOrNull):
                    return _sqlExpressionFactory.ToUuidOrNull(arguments[1]);

                case nameof(ClickHouseUuidDbFunctionsExtensions.ToUuidOrDefault):
                    return arguments.Count == 2
                        ? _sqlExpressionFactory.ToUuidOrDefault(arguments[1])
                        : _sqlExpressionFactory.ToUuidOrDefault(arguments[1], arguments[2]);
            }
        }

        return null;
    }
}
