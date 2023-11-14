using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseMathTranslator: IMethodCallTranslator, IMemberTranslator
{
    private static readonly MethodInfo Exp = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Exp), new []{ typeof(double) });

    private static readonly MethodInfo Log = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Log), new[] { typeof(double) });

    private static readonly MethodInfo Log10 = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Log10), new[] { typeof(double) });

    private static readonly MethodInfo Sqrt = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Sqrt), new[] { typeof(double) });

    private static readonly MethodInfo Cbrt = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Cbrt), new[] { typeof(double) });

    private static readonly MethodInfo Sin = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Sin), new[] { typeof(double) });

    private static readonly MethodInfo Cos = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Cos), new[] { typeof(double) });

    private static readonly MethodInfo Tan = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Tan), new[] { typeof(double) });

    private static readonly MethodInfo Asin = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Asin), new[] { typeof(double) });
        
    private static readonly MethodInfo Acos = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Acos), new[] { typeof(double) });
        
    private static readonly MethodInfo Atan = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Atan), new[] { typeof(double) });

    private static readonly MethodInfo Pow = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Pow), new[] { typeof(double), typeof(double) });

    private static readonly MethodInfo Cosh = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Cosh), new[] { typeof(double) });

    private static readonly MethodInfo Acosh = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Acosh), new[] { typeof(double) });

    private static readonly MethodInfo CeilingDouble = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Ceiling), new[] { typeof(double) });

    private static readonly MethodInfo CeilingDecimal = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Ceiling), new[] { typeof(decimal) });

    private static readonly MethodInfo RoundDouble = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Round), new[] { typeof(double) });

    private static readonly MethodInfo RoundDecimal = typeof(Math)
        .GetRuntimeMethod(nameof(Math.Round), new[] { typeof(decimal) });
        
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public ClickHouseMathTranslator(ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    public SqlExpression Translate(SqlExpression instance, MethodInfo method, IReadOnlyList<SqlExpression> arguments, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (Exp.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "exp",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }
            
        if (Log.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "log",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }
            
        if (Log10.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "log10",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }
            
        if (Sqrt.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "sqrt",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }
            
        if (Cbrt.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "cbrt",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }
            
        if (Sin.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "sin",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }
            
        if (Cos.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "cos",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }
            
        if (Tan.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "tan",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if (Asin.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "asin",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }
            
        if (Acos.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "Acos",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }
            
        if (Atan.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "atan",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }
            
        if (Pow.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "pow",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }
           
        /*
        if (Cosh.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "cosh",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: typeof(double));
        }

        if (Acosh.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "acosh",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: typeof(double));
        }
        */

        if (CeilingDouble.Equals(method) || CeilingDecimal.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "ceiling",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        if (RoundDouble.Equals(method) || RoundDecimal.Equals(method))
        {
            return _sqlExpressionFactory.Function(
                name: "round",
                arguments: arguments,
                nullable: false,
                argumentsPropagateNullability: new[] { true },
                returnType: method.ReturnType);
        }

        return null;
    }

    public SqlExpression Translate(SqlExpression instance, MemberInfo member, Type returnType, IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        return null;
    }
}
