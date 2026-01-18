using ClickHouse.Driver.ADO.Parameters;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseFixedStringTypeMapping : RelationalTypeMapping
{
    public ClickHouseFixedStringTypeMapping(Type clrType, bool unicode, int size)
        : base(
            new RelationalTypeMappingParameters(
                new CoreTypeMappingParameters(
                    clrType: clrType,
                    converter: GetConverter(clrType, unicode, size),
                    jsonValueReaderWriter: GetJsonValueReaderWriter(clrType)),
                storeType: "FixedString",
                storeTypePostfix: StoreTypePostfix.Size,
                dbType: GetDbType(clrType, unicode),
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

    protected override void ConfigureParameter(DbParameter parameter)
    {
        ((ClickHouseDbParameter)parameter).ClickHouseType = GetStoreType(parameter.Value);
    }

    public override MethodInfo GetDataReaderMethod()
    {
        return typeof(DbDataReader).GetRuntimeMethod(nameof(DbDataReader.GetValue), [typeof(int)])!;
    }

    private static ValueConverter? GetConverter(Type clrType, bool unicode, int size)
    {
        return clrType == typeof(char)
            ? null
            : clrType == typeof(string)
                ? new StringToBytesConverter(
                    unicode ? Encoding.UTF8 : Encoding.ASCII,
                    new ConverterMappingHints(
                        size: size,
                        precision: null,
                        scale: null,
                        unicode: unicode))
                : clrType == typeof(byte[])
                    ? null
                    : throw new ArgumentException("Argument type must be char, string or byte[]", nameof(clrType));
    }

    private static JsonValueReaderWriter GetJsonValueReaderWriter(Type clrType)
    {
        return clrType == typeof(char)
            ? JsonCharReaderWriter.Instance
            : clrType == typeof(string)
                ? JsonStringReaderWriter.Instance
                : clrType == typeof(byte[])
                    ? JsonByteArrayReaderWriter.Instance
                    : throw new ArgumentException("Argument type must be char, string or byte[]", nameof(clrType));
    }

    private static DbType GetDbType(Type clrType, bool unicode)
    {
        return clrType == typeof(byte[])
            ? System.Data.DbType.Binary
            : (unicode ? System.Data.DbType.StringFixedLength : System.Data.DbType.AnsiStringFixedLength);
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
