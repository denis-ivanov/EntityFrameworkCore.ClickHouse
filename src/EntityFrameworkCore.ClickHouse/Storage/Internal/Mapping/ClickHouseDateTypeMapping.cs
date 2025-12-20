using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Storage.ValueConversation;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseDateTypeMapping : DateOnlyTypeMapping
{
    public ClickHouseDateTypeMapping()
        : this (new RelationalTypeMappingParameters(
            new CoreTypeMappingParameters(
                typeof(DateOnly),
                new ClickHouseDateValueConverter()),
            "Date",
            StoreTypePostfix.None,
            System.Data.DbType.Date))
    {
    }

    protected ClickHouseDateTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseDateTypeMapping(parameters);
    }

    public override MethodInfo GetDataReaderMethod()
    {
        return typeof(DbDataReader).GetRuntimeMethod(nameof(DbDataReader.GetDateTime), [typeof(int)])!;
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        parameter.SetStoreType(StoreType);
    }
}
