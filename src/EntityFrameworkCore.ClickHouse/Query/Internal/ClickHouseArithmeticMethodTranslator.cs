using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseArithmeticMethodTranslator : IMethodCallTranslator
{
    private readonly ISqlExpressionFactory _sqlExpressionFactory;
    private readonly IRelationalTypeMappingSource _typeMappingSource;

    public ClickHouseArithmeticMethodTranslator(
        ISqlExpressionFactory sqlExpressionFactory,
        IRelationalTypeMappingSource typeMappingSource)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
        _typeMappingSource = typeMappingSource;
    }

    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method.DeclaringType != typeof(ClickHouseArithmeticDbFunctionsExtensions))
        {
            return null;
        }

        return method.Name switch
        {
            nameof(ClickHouseArithmeticDbFunctionsExtensions.Divide) => _sqlExpressionFactory.Function(
                name: "divide",
                arguments: [arguments[1], arguments[2]],
                nullable: true,
                argumentsPropagateNullability: [true, true],
                returnType: typeof(double),
                typeMapping: _typeMappingSource.FindMapping(typeof(double))),
            _ => null
        };
    }
}
