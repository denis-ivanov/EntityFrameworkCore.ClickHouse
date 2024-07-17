using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Linq;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseTrimFunction : SqlFunctionExpression
{
    public const byte Leading = 1;
    public const byte Trailing = 2;
    public const byte Both = 3;

    public ClickHouseTrimFunction(IEnumerable<SqlExpression> arguments, RelationalTypeMapping typeMapping, byte trimMode)
        : base(
            "trim",
            arguments,
            true,
            Enumerable.Repeat(false, arguments.Count()),
            typeof(string),
            typeMapping)
    {
        TrimMode = trimMode;
    }

    public byte TrimMode { get; }

    public string TrimModeName
    {
        get
        {
            return TrimMode switch
            {
                Leading => "LEADING",
                Trailing => "TRAILING",
                _ => "BOTH"
            };
        }
    }
}
