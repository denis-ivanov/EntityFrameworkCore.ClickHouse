using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseUInt32TypeMapping : UIntTypeMapping
{
    public ClickHouseUInt32TypeMapping() : base("UInt32", System.Data.DbType.UInt32)
    {
    }

    protected ClickHouseUInt32TypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseUInt32TypeMapping(parameters);
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
            typeof(Convert).GetMethod(nameof(Convert.ToUInt32), [typeof(object)])!,
            expression
        );
    }
}
