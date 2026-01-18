using ClickHouse.Driver.ADO.Parameters;
using ClickHouse.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Data.Common;
using System.Numerics;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseInt128TypeMapping : RelationalTypeMapping
{
    public ClickHouseInt128TypeMapping()
        : base(
            new RelationalTypeMappingParameters(
                new CoreTypeMappingParameters(
                    typeof(Int128),
                    converter: new CastingConverter<Int128, BigInteger>(),
                    jsonValueReaderWriter: JsonInt128ReaderWriter.Instance),
                "Int128",
                StoreTypePostfix.None,
                dbType: System.Data.DbType.Object))
    {
    }

    protected ClickHouseInt128TypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseInt128TypeMapping(parameters);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        ((ClickHouseDbParameter)parameter).ClickHouseType = GetStoreType(parameter.Value);
    }

    public override MethodInfo GetDataReaderMethod()
    {
        return typeof(DbDataReader).GetRuntimeMethod(nameof(DbDataReader.GetValue), [typeof(int)])!;
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
