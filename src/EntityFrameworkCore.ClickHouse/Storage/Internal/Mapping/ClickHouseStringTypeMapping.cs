using ClickHouse.Driver.ADO.Parameters;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseStringTypeMapping : StringTypeMapping
{
    public ClickHouseStringTypeMapping()
        : base("String", System.Data.DbType.String, true, null)
    {
    }

    protected ClickHouseStringTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseStringTypeMapping(parameters);
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
