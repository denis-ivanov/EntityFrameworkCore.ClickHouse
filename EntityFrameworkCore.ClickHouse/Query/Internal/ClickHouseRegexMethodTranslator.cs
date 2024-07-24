using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseRegexMethodTranslator : IMethodCallTranslator
{
    private static readonly MethodInfo IsMatch =
        typeof(Regex).GetRuntimeMethod(nameof(Regex.IsMatch), [typeof(string), typeof(string)]);

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseRegexMethodTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression Translate(
        SqlExpression instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (method == IsMatch)
        {
            _sqlExpressionFactory.GreaterThan(
                _sqlExpressionFactory.Function(
                    name: "match",
                    arguments: arguments,
                    nullable: true,
                    argumentsPropagateNullability: [true, true],
                    returnType: typeof(int)),
                _sqlExpressionFactory.Constant(0));
        }

        return null;
    }
}
