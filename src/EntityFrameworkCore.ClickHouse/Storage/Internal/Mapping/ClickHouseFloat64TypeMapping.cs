using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseFloat64TypeMapping : DoubleTypeMapping
{
    public ClickHouseFloat64TypeMapping() : base("Float64", System.Data.DbType.Double)
    {
    }

    protected ClickHouseFloat64TypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseFloat64TypeMapping(parameters);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        parameter.SetStoreType(StoreType);
    }
    
    public override MethodInfo GetDataReaderMethod()
    {
        return typeof(DbDataReader).GetRuntimeMethod(nameof(DbDataReader.GetValue), [typeof(int)])!;
    }

    public override Expression CustomizeDataReaderExpression(Expression expression)
    {
        return Expression.Call(
            typeof(Convert).GetMethod(nameof(Convert.ToDouble), [typeof(object)])!,
            expression
        );
    }

    protected override string GenerateNonNullSqlLiteral(object value)
    {
        return Convert.ToDouble(value) switch
        {
            var d when double.IsNaN(d) => "'NaN'::Float64",
            var d when double.IsNegativeInfinity(d) => "'-Inf'::Float64",
            var d when double.IsPositiveInfinity(d) => "'Inf'::Float64",
            _ => base.GenerateNonNullSqlLiteral(value) + "::Float64"
        };
    }
}
