using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation;

public sealed class ClickHouseNullableCharToBytesConverter : ValueConverter<char?, byte[]?>
{
    private static readonly MethodInfo EncodingGetBytesMethodInfo =
        typeof(Encoding).GetMethod(nameof(Encoding.GetBytes), [typeof(string)])!;

    private static readonly MethodInfo EncodingGetStringMethodInfo =
        typeof(Encoding).GetMethod(nameof(Encoding.GetString), [typeof(byte[])])!;

    private static readonly MethodInfo EncodingGetEncodingMethodInfo =
        typeof(Encoding).GetMethod(nameof(Encoding.GetEncoding), [typeof(int)])!;

    private static readonly MethodInfo StringGetCharsMethodInfo =
        typeof(string).GetMethod("get_Chars", [typeof(int)])!;

    public ClickHouseNullableCharToBytesConverter(Encoding encoding, ConverterMappingHints mappingHints)
        : base(ToProvider(encoding), FromProvider(encoding), mappingHints)
    {
    }

    private static Expression<Func<char?, byte[]?>> ToProvider(Encoding encoding)
    {
        // c => c.HasValue ? Encoding.GetEncoding(cp).GetBytes(c.Value.ToString()) : null
        var prm = Expression.Parameter(typeof(char?), "c");

        var hasValue = Expression.Property(prm, nameof(Nullable<char>.HasValue));
        var value = Expression.Property(prm, nameof(Nullable<char>.Value));
        var toStringMethod = typeof(char).GetMethod(nameof(char.ToString), Type.EmptyTypes)!;

        var getEncodingCall = Expression.Call(
            EncodingGetEncodingMethodInfo,
            Expression.Constant(encoding.CodePage));

        var getBytesCall = Expression.Call(
            getEncodingCall,
            EncodingGetBytesMethodInfo,
            Expression.Call(value, toStringMethod));

        var conditional = Expression.Condition(
            hasValue,
            Expression.Convert(getBytesCall, typeof(byte[])),
            Expression.Constant(null, typeof(byte[])));

        return Expression.Lambda<Func<char?, byte[]?>>(conditional, prm);
    }

    private static Expression<Func<byte[]?, char?>> FromProvider(Encoding encoding)
    {
        // v => v == null || v.Length == 0 ? null : (char?)Encoding.GetEncoding(cp).GetString(v)[0]
        var prm = Expression.Parameter(typeof(byte[]), "v");

        var isNull = Expression.Equal(prm, Expression.Constant(null, typeof(byte[])));

        var lengthProperty = Expression.Property(prm, nameof(Array.Length));
        var isEmpty = Expression.Equal(lengthProperty, Expression.Constant(0));

        var nullConstant = Expression.Constant(null, typeof(char?));

        var getStringCall = Expression.Call(
            Expression.Call(EncodingGetEncodingMethodInfo, Expression.Constant(encoding.CodePage)),
            EncodingGetStringMethodInfo,
            prm);

        var getChar = Expression.Convert(
            Expression.Call(getStringCall, StringGetCharsMethodInfo, Expression.Constant(0)),
            typeof(char?));

        var condition = Expression.OrElse(isNull, isEmpty);
        var conditional = Expression.Condition(condition, nullConstant, getChar);

        return Expression.Lambda<Func<byte[]?, char?>>(conditional, prm);
    }
}