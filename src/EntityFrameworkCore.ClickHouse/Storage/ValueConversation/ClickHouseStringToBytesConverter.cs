using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation;

public class ClickHouseStringToBytesConverter : ValueConverter<string?, byte[]?>
{
    private static readonly MethodInfo EncodingGetBytesMethodInfo =
        typeof(Encoding).GetMethod(nameof(Encoding.GetBytes), [typeof(string)])!;

    private static readonly MethodInfo EncodingGetStringMethodInfo =
        typeof(Encoding).GetMethod(nameof(Encoding.GetString), [typeof(byte[])])!;

    private static readonly MethodInfo EncodingGetEncodingMethodInfo =
        typeof(Encoding).GetMethod(nameof(Encoding.GetEncoding), [typeof(int)])!;

    public ClickHouseStringToBytesConverter(
        Encoding encoding,
        ConverterMappingHints? mappingHints = null)
        : base(
            ToProvider(encoding),
            FromProvider(encoding),
            mappingHints)
    {
    }

    private static Expression<Func<string?, byte[]?>> ToProvider(Encoding encoding)
    {
        // v => encoding.GetBytes(v!),
        var prm = Expression.Parameter(typeof(string), "v");
        var result = Expression.Lambda<Func<string?, byte[]?>>(
            Expression.Call(
                Expression.Call(
                    EncodingGetEncodingMethodInfo,
                    Expression.Constant(encoding.CodePage)),
                EncodingGetBytesMethodInfo, prm),
            prm);

        return result;
    }

    private static Expression<Func<byte[]?, string?>> FromProvider(Encoding encoding)
    {
        // v => v == null ? null : Encoding.GetEncoding(cp).GetString(v)
        var prm = Expression.Parameter(typeof(byte[]), "v");

        var isNullCheck = Expression.Equal(prm, Expression.Constant(null, typeof(byte[])));
        var nullConstant = Expression.Constant(null, typeof(string));

        var getStringCall = Expression.Call(
            Expression.Call(
                EncodingGetEncodingMethodInfo,
                Expression.Constant(encoding.CodePage)),
            EncodingGetStringMethodInfo,
            prm);

        var conditionalExpression = Expression.Condition(isNullCheck, nullConstant, getStringCall);
        return Expression.Lambda<Func<byte[]?, string?>>(conditionalExpression, prm);
    }
}
