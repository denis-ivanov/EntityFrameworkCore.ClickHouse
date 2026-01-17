using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation;

public sealed class ClickHouseCharToBytesConverter : ValueConverter<char, byte[]>
{
    private static readonly MethodInfo EncodingGetBytesMethodInfo =
        typeof(Encoding).GetMethod(nameof(Encoding.GetBytes), [typeof(string)])!;

    private static readonly MethodInfo EncodingGetStringMethodInfo =
        typeof(Encoding).GetMethod(nameof(Encoding.GetString), [typeof(byte[])])!;

    private static readonly MethodInfo EncodingGetEncodingMethodInfo =
        typeof(Encoding).GetMethod(nameof(Encoding.GetEncoding), [typeof(int)])!;

    private static readonly MethodInfo StringGetCharsMethodInfo =
        typeof(string).GetMethod("get_Chars", [typeof(int)])!;

    public ClickHouseCharToBytesConverter(Encoding encoding, ConverterMappingHints mappingHints)
        : base(ToProvider(encoding), FromProvider(encoding), mappingHints)
    {
    }

    private static Expression<Func<char, byte[]>> ToProvider(Encoding encoding)
    {
        // c => Encoding.GetEncoding(cp).GetBytes(c.ToString())
        var prm = Expression.Parameter(typeof(char), "c");
        var toStringMethod = typeof(char).GetMethod(nameof(char.ToString), Type.EmptyTypes)!;

        var getEncodingCall = Expression.Call(
            EncodingGetEncodingMethodInfo,
            Expression.Constant(encoding.CodePage));

        var getBytesCall = Expression.Call(
            getEncodingCall,
            EncodingGetBytesMethodInfo,
            Expression.Call(prm, toStringMethod));

        return Expression.Lambda<Func<char, byte[]>>(getBytesCall, prm);
    }

    private static Expression<Func<byte[], char>> FromProvider(Encoding encoding)
    {
        // v => Encoding.GetEncoding(cp).GetString(v)[0]
        var prm = Expression.Parameter(typeof(byte[]), "v");

        var getStringCall = Expression.Call(
            Expression.Call(EncodingGetEncodingMethodInfo, Expression.Constant(encoding.CodePage)),
            EncodingGetStringMethodInfo,
            prm);

        var getChar = Expression.Call(getStringCall, StringGetCharsMethodInfo, Expression.Constant(0));

        return Expression.Lambda<Func<byte[], char>>(getChar, prm);
    }
}