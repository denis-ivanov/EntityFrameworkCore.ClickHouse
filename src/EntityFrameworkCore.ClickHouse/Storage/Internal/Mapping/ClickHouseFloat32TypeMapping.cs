using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseFloat32TypeMapping : FloatTypeMapping
{
    public ClickHouseFloat32TypeMapping() : base("Float32", System.Data.DbType.Single)
    {
    }

    protected ClickHouseFloat32TypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseFloat32TypeMapping(parameters);
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
            typeof(Convert).GetMethod(nameof(Convert.ToSingle), [typeof(object)])!,
            expression
        );
    }

    protected override string GenerateNonNullSqlLiteral(object value)
    {
        return Convert.ToSingle(value) switch
        {
            var f when float.IsNaN(f) => "'Nan'::Float32",
            var f when float.IsNegativeInfinity(f) => "'-Inf'::Float32",
            var f when float.IsPositiveInfinity(f) => "'Inf'::Float32",
            _ => base.GenerateNonNullSqlLiteral(value) + "::Float32"
        };
    }
}
