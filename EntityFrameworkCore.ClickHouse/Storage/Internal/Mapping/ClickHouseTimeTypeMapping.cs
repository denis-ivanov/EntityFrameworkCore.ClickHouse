using ClickHouse.Driver.ADO.Readers;
using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Data.Common;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseTimeTypeMapping : TimeSpanTypeMapping
{
    internal const string Time = nameof(Time);
    internal const string Time64 = "Time64(9)";

    public ClickHouseTimeTypeMapping(string storeType)
        : base(
            new RelationalTypeMappingParameters(
                new CoreTypeMappingParameters(typeof(TimeSpan), jsonValueReaderWriter: JsonTimeSpanReaderWriter.Instance),
                storeType,
                StoreTypePostfix.Precision,
                System.Data.DbType.Time))
    {
    }

    public override MethodInfo GetDataReaderMethod()
    {
        return typeof(DbDataReader).GetRuntimeMethod(nameof(ClickHouseDataReader.GetValue), [typeof(int)])!;
    }

    protected ClickHouseTimeTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseTimeTypeMapping(parameters);
    }
    
    protected override void ConfigureParameter(DbParameter parameter)
    {
        parameter.SetStoreType(StoreType);
    }
}
