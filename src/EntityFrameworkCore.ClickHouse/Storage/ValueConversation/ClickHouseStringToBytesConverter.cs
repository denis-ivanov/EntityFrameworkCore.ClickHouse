using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation;

public class ClickHouseStringToBytesConverter : ValueConverter<string, byte[]>
{
    private static readonly MethodInfo EncodingGetBytesMethodInfo =
        typeof(Encoding).GetMethod(nameof(Encoding.GetBytes), [typeof(string)])!;

    private static readonly MethodInfo EncodingGetStringMethodInfo =
        typeof(Encoding).GetMethod(nameof(Encoding.GetString), [typeof(byte[])])!;

    private static readonly MethodInfo EncodingGetEncodingMethodInfo =
        typeof(Encoding).GetMethod(nameof(Encoding.GetEncoding), [typeof(int)])!;

    private static readonly MethodInfo StringGetCharsMethodInfo =
        typeof(string).GetProperty("Chars", [typeof(int)])!.GetGetMethod()!;

    public ClickHouseStringToBytesConverter(
        Encoding encoding,
        ConverterMappingHints mappingHints = null)
        : base(
            FromProvider(encoding),
            ToProvider(encoding),
            mappingHints)
    {
    }

    public static ValueConverterInfo DefaultInfo { get; }
        = new(typeof(string), typeof(byte[]), i => new StringToBytesConverter(Encoding.UTF8, i.MappingHints));

    private static Expression<Func<string, byte[]>> FromProvider(Encoding encoding)
    {
        // v => v == null || v.Length == 0 || (v.Length == 1 && v[0] == '\0') ? null : encoding.GetBytes(v)
        var prm = Expression.Parameter(typeof(string), "v");
        
        var nullCheck = Expression.Equal(prm, Expression.Constant(null));
        var lengthZeroCheck = Expression.Equal(
            Expression.PropertyOrField(prm, nameof(string.Length)),
            Expression.Constant(0));
        
        var singleNullCharCheck = Expression.AndAlso(
            Expression.Equal(
                Expression.PropertyOrField(prm, nameof(string.Length)),
                Expression.Constant(1)),
            Expression.Equal(
                Expression.Call(prm, StringGetCharsMethodInfo, Expression.Constant(0)),
                Expression.Constant('\0')));
        
        var shouldReturnNull = Expression.OrElse(
            Expression.OrElse(nullCheck, lengthZeroCheck),
            singleNullCharCheck);
        
        var encodeBytes = Expression.Call(
            Expression.Call(
                EncodingGetEncodingMethodInfo,
                Expression.Constant(encoding.CodePage)),
            EncodingGetBytesMethodInfo, 
            prm);
        
        var result = Expression.Lambda<Func<string?, byte[]?>>(
            Expression.Condition(
                shouldReturnNull,
                Expression.Constant(null, typeof(byte[])),
                encodeBytes),
            prm);

        return result;
    }

    private static Expression<Func<byte[]?, string?>> ToProvider(Encoding encoding)
    {
        // v => encoding.GetString(v!)
        var prm = Expression.Parameter(typeof(byte[]), "v");
        var result = Expression.Lambda<Func<byte[]?, string?>>(
            Expression.Call(
                Expression.Call(
                    EncodingGetEncodingMethodInfo,
                    Expression.Constant(encoding.CodePage)),
                EncodingGetStringMethodInfo, prm),
            prm);

        return result;
    }
}
