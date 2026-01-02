using ClickHouse.EntityFrameworkCore.Extensions;
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
                    converter: GetConverter(clrType, unicode, size),
                    jsonValueReaderWriter: clrType == typeof(char)
                        ? JsonCharReaderWriter.Instance
                        : clrType == typeof(string)
                            ? JsonStringReaderWriter.Instance
                            : throw new ArgumentException("Argument type must be char or string", nameof(clrType))),
                storeType: "FixedString",
                storeTypePostfix: StoreTypePostfix.Size,
                dbType: unicode ? System.Data.DbType.StringFixedLength : System.Data.DbType.AnsiStringFixedLength,
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
        parameter.SetStoreType(StoreType);
    }

    public override MethodInfo GetDataReaderMethod()
    {
        return typeof(DbDataReader).GetRuntimeMethod(nameof(DbDataReader.GetValue), [typeof(int)])!;
    }

    private static ValueConverter GetConverter(Type clrType, bool unicode, int size)
    {
        var mappingHints = new ConverterMappingHints(
            size: size,
            precision: null,
            scale: null,
            unicode: unicode);

        var stringConverter = new StringToBytesConverter(
            unicode ? Encoding.UTF8 : Encoding.ASCII,
            mappingHints);

        if (clrType == typeof(string))
        {
            return stringConverter;
        }

        return clrType == typeof(char)
            ? new CharToStringConverter(mappingHints).ComposeWith(stringConverter)
            : throw new ArgumentException("Argument type must be char or string", nameof(clrType));
    }

    protected override string GenerateNonNullSqlLiteral(object value)
    {
        if (value is byte[])
        {
            return "'" + Converter!.ConvertFromProvider(value) + "'";
        }

        return base.GenerateNonNullSqlLiteral(value);
    }
}
