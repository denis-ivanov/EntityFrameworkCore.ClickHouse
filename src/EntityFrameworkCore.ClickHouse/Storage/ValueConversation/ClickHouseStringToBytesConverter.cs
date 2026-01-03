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
        // v => v == null || v.Length == 0 || Array.TrueForAll(v, b => b == 0) ? null : encoding.GetString(v)
        var prm = Expression.Parameter(typeof(byte[]), "v");

        var isNullCheck = Expression.Equal(prm, Expression.Constant(null, typeof(byte[])));
        var lengthProperty = Expression.Property(prm, nameof(Array.Length));
        var isEmptyCheck = Expression.Equal(lengthProperty, Expression.Constant(0));

        // Array.TrueForAll<byte>(v, b => b == 0)
        var trueForAllMethod = typeof(Array)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .First(m => m is { Name: nameof(Array.TrueForAll), IsGenericMethodDefinition: true } && m.GetGenericArguments().Length == 1)
            .MakeGenericMethod(typeof(byte));

        var byteParam = Expression.Parameter(typeof(byte), "b");
        var predicate = Expression.Lambda<Predicate<byte>>(
            Expression.Equal(byteParam, Expression.Constant((byte)0)),
            byteParam);
        var allZeroCheck = Expression.Call(trueForAllMethod, prm, predicate);

        var conditionCheck = Expression.OrElse(
            Expression.OrElse(isNullCheck, isEmptyCheck),
            allZeroCheck);

        var nullConstant = Expression.Constant(null, typeof(string));
        var getStringCall = Expression.Call(
            Expression.Call(
                EncodingGetEncodingMethodInfo,
                Expression.Constant(encoding.CodePage)),
            EncodingGetStringMethodInfo, prm);

        var conditionalExpression = Expression.Condition(conditionCheck, nullConstant, getStringCall);

        var result = Expression.Lambda<Func<byte[]?, string?>>(conditionalExpression, prm);
        return result;
    }
}
