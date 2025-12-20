using System;
using System.Numerics;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore;

public static class ClickHouseArithmeticDbFunctionsExtensions
{
    /// <summary>
    /// Calculates the quotient of two values <c>x</c> and <c>y</c>.
    /// The result type is always <c>double</c>.
    /// Integer division is provided by the intDiv function.
    /// </summary>
    /// <param name="_">DbFunctions instance.</param>
    /// <param name="x">Dividend.</param>
    /// <param name="y">Divisor</param>
    /// <typeparam name="TDividend"></typeparam>
    /// <typeparam name="TDivisor"></typeparam>
    /// <returns>The quotient of x and y.</returns>
    /// <remarks>
    /// Division by <c>0</c> returns <c>double.PositiveInfinity</c>, <c>double.NegativeInfinity</c>, or <c>double.NaN</c>.
    /// </remarks>
    public static double Divide<TDividend, TDivisor>(this DbFunctions _, TDividend x, TDivisor y)
        where TDividend : INumber<TDividend>
        where TDivisor: INumber<TDivisor>
    {
        throw new InvalidOperationException();
    }
}
