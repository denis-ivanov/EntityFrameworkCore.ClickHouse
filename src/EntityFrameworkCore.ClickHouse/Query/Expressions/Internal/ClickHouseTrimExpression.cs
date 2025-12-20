using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Expressions.Internal;

public class ClickHouseTrimExpression : SqlExpression
{
    private static readonly ConstructorInfo Constructor = typeof(ClickHouseTrimExpression).GetConstructor(
    [
        typeof(SqlExpression),
        typeof(SqlExpression),
        typeof(ClickHouseStringTrimMode)
    ]);

    public ClickHouseTrimExpression(
        SqlExpression inputString,
        SqlExpression trimCharacters,
        ClickHouseStringTrimMode trimMode)
        : base(typeof(string), inputString.TypeMapping)
    {
        InputString = inputString;
        TrimCharacters = trimCharacters;
        TrimMode = trimMode;
    }

    public SqlExpression InputString { get; }

    public SqlExpression TrimCharacters { get; }

    public ClickHouseStringTrimMode TrimMode { get; private set; }

    public virtual ClickHouseTrimExpression Update(SqlExpression inputString, SqlExpression trimCharacters)
    {
        return inputString != InputString || trimCharacters != trimCharacters
            ? new ClickHouseTrimExpression(inputString, trimCharacters, TrimMode)
            : this;
    }

    public override Expression Quote()
    {
        return New(
            Constructor,
            InputString.Quote(),
            TrimCharacters.Quote(),
            Constant(TrimMode));
    }

    protected override Expression VisitChildren(ExpressionVisitor visitor)
    {
        visitor.Visit(InputString);
        visitor.Visit(TrimCharacters);

        return this;
    }

    protected override void Print(ExpressionPrinter expressionPrinter)
    {
        expressionPrinter.Append("trim(")
            .Append(TrimMode switch
            {
                ClickHouseStringTrimMode.Both => "BOTH ",
                ClickHouseStringTrimMode.Leading => "LEADING ",
                ClickHouseStringTrimMode.Trailing => "TRAILING ",
                _ => throw new InvalidEnumArgumentException("Invalid trim mode", (int)TrimMode, typeof(ClickHouseStringTrimMode))
            });

        expressionPrinter.Visit(TrimCharacters);

        expressionPrinter.Append(" FROM ");
        expressionPrinter.Visit(InputString);
        expressionPrinter.Append(")");
    }
}