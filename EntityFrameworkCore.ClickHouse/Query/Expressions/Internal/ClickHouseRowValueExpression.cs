using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Expressions.Internal;

public class ClickHouseRowValueExpression : SqlExpression, IEquatable<ClickHouseRowValueExpression>
{
    private static ConstructorInfo? _quotingConstructor;

    public ClickHouseRowValueExpression(IReadOnlyList<SqlExpression> values, Type type, RelationalTypeMapping? typeMapping = null)
        : base(type, typeMapping)
    {
        Values = values;
    }

    public virtual IReadOnlyList<SqlExpression> Values { get; }

    protected override Expression VisitChildren(ExpressionVisitor visitor)
    {
        SqlExpression[]? newRowValues = null;

        for (var i = 0; i < Values.Count; i++)
        {
            var rowValue = Values[i];
            var visited = (SqlExpression)visitor.Visit(rowValue);
            if (visited != rowValue && newRowValues is null)
            {
                newRowValues = new SqlExpression[Values.Count];
                for (var j = 0; j < i; j++)
                {
                    newRowValues[j] = Values[j];
                }
            }

            if (newRowValues is not null)
            {
                newRowValues[i] = visited;
            }
        }

        return newRowValues is null ? this : new ClickHouseRowValueExpression(newRowValues, Type);
    }

    public virtual ClickHouseRowValueExpression Update(IReadOnlyList<SqlExpression> values)
        => values.Count == Values.Count && values.Zip(Values, (x, y) => (x, y)).All(tup => tup.x == tup.y)
            ? this
            : new ClickHouseRowValueExpression(values, Type);

    public override Expression Quote()
        => New(
            _quotingConstructor ??= typeof(ClickHouseRowValueExpression).GetConstructor(
                [typeof(IReadOnlyList<SqlExpression>), typeof(Type), typeof(RelationalTypeMapping)])!,
            NewArrayInit(typeof(SqlExpression), initializers: Values.Select(a => a.Quote())),
            Constant(Type),
            RelationalExpressionQuotingUtilities.QuoteTypeMapping(TypeMapping));

    protected override void Print(ExpressionPrinter expressionPrinter)
    {
        expressionPrinter.Append("(");

        var count = Values.Count;
        for (var i = 0; i < count; i++)
        {
            expressionPrinter.Visit(Values[i]);

            if (i < count - 1)
            {
                expressionPrinter.Append(", ");
            }
        }

        expressionPrinter.Append(")");
    }

    public override bool Equals(object? obj)
        => obj is ClickHouseRowValueExpression other && Equals(other);

    public virtual bool Equals(ClickHouseRowValueExpression? other)
    {
        if (other is null || !base.Equals(other) || other.Values.Count != Values.Count)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        for (var i = 0; i < Values.Count; i++)
        {
            if (!other.Values[i].Equals(Values[i]))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        foreach (var rowValue in Values)
        {
            hashCode.Add(rowValue);
        }

        return hashCode.ToHashCode();
    }
}
