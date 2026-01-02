using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseFixedStringTypeMapping : RelationalTypeMapping
{
    public ClickHouseFixedStringTypeMapping(
        Type clrType,
        bool unicode,
        int size)
        : base(
            new RelationalTypeMappingParameters(
                new CoreTypeMappingParameters(
                    clrType: clrType,
                    converter: new StringToBytesConverter(
                        unicode ? Encoding.UTF8 : Encoding.ASCII,
                        new ConverterMappingHints(
                            size: size,
                            precision: null,
                            scale: null,
                            unicode: unicode)),
                    jsonValueReaderWriter: clrType == typeof(char)
                        ? JsonCharReaderWriter.Instance
                        : clrType == typeof(string)
                            ? JsonStringReaderWriter.Instance
                            : throw new ArgumentException("Argument type must be char or string", nameof(clrType))),
                storeType: "FixedString",
                storeTypePostfix: StoreTypePostfix.Size,
                dbType: System.Data.DbType.Binary,
                unicode: unicode,
                size: size,
                fixedLength: true,
                precision: null,
                scale: null))
    {
    }

    protected ClickHouseFixedStringTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseFixedStringTypeMapping(parameters);
    }

    public override MethodInfo GetDataReaderMethod()
    {
        return typeof(DbDataReader).GetRuntimeMethod(nameof(DbDataReader.GetValue), [typeof(int)])!;
    }
}
