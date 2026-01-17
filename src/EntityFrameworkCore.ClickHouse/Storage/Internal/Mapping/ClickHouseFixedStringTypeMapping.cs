using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Storage.ValueConversation;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
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

        var encoding = unicode ? Encoding.UTF8 : Encoding.ASCII;

        return clrType switch
        {
            var t when t == typeof(char) => new ClickHouseCharToBytesConverter(encoding, mappingHints),
            var t when t == typeof(char?) => new ClickHouseNullableCharToBytesConverter(encoding, mappingHints),
            var t when t == typeof(string) => new ClickHouseStringToBytesConverter(encoding, mappingHints),
            _ => throw new ArgumentException("Argument type must be char, char? or string", nameof(clrType))
        };
    }

    protected override string GenerateNonNullSqlLiteral(object value)
    {
        if (value is byte[])
        {
            return "'" + Converter!.ConvertFromProvider(value) + "'";
        }

        return base.GenerateNonNullSqlLiteral(value);
    }

    // File: `src/EntityFrameworkCore.ClickHouse/Storage/Internal/Mapping/ClickHouseFixedStringTypeMapping.cs`
    public override Expression CustomizeDataReaderExpression(Expression expression)
    {
        // expression is (object)reader.GetValue(ordinal); we need byte[] for checks
        var byteArrayExpr = Expression.Convert(expression, typeof(byte[]));

        var nullCheck = Expression.Equal(byteArrayExpr, Expression.Constant(null, typeof(byte[])));
        var lengthProperty = Expression.Property(byteArrayExpr, nameof(Array.Length));
        var lengthZeroCheck = Expression.Equal(lengthProperty, Expression.Constant(0));

        // Array.TrueForAll<byte>(v, b => b == 0)
        var trueForAllMethod = typeof(Array)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(m =>
                m.Name == nameof(Array.TrueForAll) &&
                m.IsGenericMethodDefinition &&
                m.GetGenericArguments().Length == 1 &&
                m.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(byte));

        var b = Expression.Parameter(typeof(byte), "b");
        var predicate = Expression.Lambda<Predicate<byte>>(
            Expression.Equal(b, Expression.Constant((byte)0)),
            b);

        var allZeroCheck = Expression.Call(trueForAllMethod, byteArrayExpr, predicate);

        // return null only for (null || empty || all-zero)
        var condition = Expression.OrElse(Expression.OrElse(nullCheck, lengthZeroCheck), allZeroCheck);

        // keep type as object for EF shaper, but return the byte[] value in the "else" branch
        var result = Expression.Condition(
            condition,
            Expression.Constant(null, typeof(object)),
            Expression.Convert(byteArrayExpr, typeof(object)));

        return result;
    }


}
