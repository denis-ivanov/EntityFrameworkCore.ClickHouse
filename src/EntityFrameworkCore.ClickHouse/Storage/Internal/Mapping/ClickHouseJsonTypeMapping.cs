using ClickHouse.Driver.ADO.Parameters;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;
using System.Text.Json;

#if NET11_0_OR_GREATER
using JsonTypeMappingBase = Microsoft.EntityFrameworkCore.Storage.StructuralJsonTypeMapping;
#else
using JsonTypeMappingBase = Microsoft.EntityFrameworkCore.Storage.JsonTypeMapping;
#endif

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseJsonTypeMapping : JsonTypeMappingBase
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