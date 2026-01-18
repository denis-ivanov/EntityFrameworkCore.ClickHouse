using ClickHouse.Driver.ADO.Parameters;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;
using System.Text.Json;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseJsonTypeMapping : JsonTypeMapping
{
    public ClickHouseJsonTypeMapping()
        : base("Json", typeof(JsonElement), System.Data.DbType.String)
    {
    }

    protected ClickHouseJsonTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseJsonTypeMapping(parameters);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        ((ClickHouseDbParameter)parameter).ClickHouseType = GetStoreType(parameter.Value);
    }

    protected virtual string GetStoreType(bool? isNullable)
    {
        return isNullable == true ? $"Nullable({StoreType})" : StoreType;
    }
    
    protected virtual string GetStoreType(object? parameterValue)
    {
        return GetStoreType(parameterValue == null || parameterValue == DBNull.Value);
    }
}