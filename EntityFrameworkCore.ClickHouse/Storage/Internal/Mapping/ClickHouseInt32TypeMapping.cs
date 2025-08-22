using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseInt32TypeMapping : IntTypeMapping
{
    public ClickHouseInt32TypeMapping() : base("Int32", System.Data.DbType.Int32)
    {
    }

    protected ClickHouseInt32TypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseInt32TypeMapping(parameters);
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
            typeof(Convert).GetMethod(nameof(Convert.ToInt32), [typeof(object)])!,
            expression
        );
    }
}
