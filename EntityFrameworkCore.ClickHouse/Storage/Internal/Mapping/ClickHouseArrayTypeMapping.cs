using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Storage.ValueConversation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Data.Common;
using System.Diagnostics;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseArrayTypeMapping<TCollection, TConcreteCollection, TElement> : RelationalTypeMapping
{
    public ClickHouseArrayTypeMapping(RelationalTypeMapping elementTypeMapping)
        : this($"Array(Nullable({elementTypeMapping.StoreType}))", elementTypeMapping)
    {
    }

    public ClickHouseArrayTypeMapping(string storeType, RelationalTypeMapping elementTypeMapping)
        : this(CreateParameters(storeType, elementTypeMapping))
    {
    }

    protected ClickHouseArrayTypeMapping(RelationalTypeMappingParameters parameters)
        : base(parameters)
    {
    }

    private static RelationalTypeMappingParameters CreateParameters(
        string storeType,
        RelationalTypeMapping elementMapping)
    {
        ValueConverter? converter = null;
        var elementType = elementMapping.ClrType;

        if (elementMapping.Converter is { } elementConverter)
        {
            var providerElementType = elementConverter.ProviderClrType;

            converter = (ValueConverter)Activator.CreateInstance(
                typeof(ClickHouseArrayConverter<,,>).MakeGenericType(
                    typeof(TCollection),
                    typeof(TConcreteCollection),
                    providerElementType.MakeArrayType()),
                elementConverter)!;
        }
        else if (typeof(TCollection) != typeof(TConcreteCollection))
        {
            converter = (ValueConverter)Activator.CreateInstance(
                typeof(ClickHouseArrayConverter<,,>).MakeGenericType(
                    typeof(TCollection),
                    typeof(TConcreteCollection),
                    elementType.MakeArrayType()),
                elementMapping.Converter)!;
        }

        var comparer = typeof(TCollection).IsArray && typeof(TCollection).GetArrayRank() > 1
            ? null // TODO: Value comparer for multidimensional arrays
            : (ValueComparer?)Activator.CreateInstance(
                elementType.IsNullableValueType()
                    ? typeof(ListOfNullableValueTypesComparer<,>)
                        .MakeGenericType(typeof(TConcreteCollection), elementType.UnwrapNullableType())
                    : elementType.IsValueType
                        ? typeof(ListOfValueTypesComparer<,>).MakeGenericType(typeof(TConcreteCollection), elementType)
                        : typeof(ListOfReferenceTypesComparer<,>).MakeGenericType(typeof(TConcreteCollection), elementType),
                elementMapping.Comparer.ToNullableComparer(elementType)!);

        return new RelationalTypeMappingParameters(
            new CoreTypeMappingParameters(
                typeof(TCollection), converter, comparer, elementMapping: elementMapping),
            storeType);
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        => new ClickHouseArrayTypeMapping<TCollection, TConcreteCollection, TElement>(parameters);

    protected override string GenerateNonNullSqlLiteral(object value)
    {
        throw new NotImplementedException();
        // var arr = (Array)value;
        //
        // if (arr.Rank != 1)
        //     throw new NotSupportedException("Multidimensional array literals aren't supported");
        //
        // var sb = new StringBuilder();
        // sb.Append('[');
        // for (var i = 0; i < arr.Length; i++)
        // {
        //     sb.Append(ElementMapping.GenerateSqlLiteral(arr.GetValue(i)));
        //     if (i < arr.Length - 1)
        //         sb.Append(',');
        // }
        //
        // sb.Append(']');
        // return sb.ToString();
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        parameter.SetStoreType(StoreType);
    }

    #region Value Comparison

    static ValueComparer CreateComparer(RelationalTypeMapping elementMapping, Type arrayType)
    {
        Debug.Assert(arrayType.IsArray);
        var elementType = arrayType.GetElementType();

        // We currently don't support mapping multi-dimensional arrays.
        if (arrayType.GetArrayRank() != 1)
            return null;

        // We use different comparer implementations based on whether we have a non-null element comparer,
        // and if not, whether the element is IEquatable<TElem>

        if (elementMapping.Comparer != null)
            return (ValueComparer)Activator.CreateInstance(
                typeof(SingleDimComparerWithComparer<>).MakeGenericType(elementType), elementMapping);

        if (typeof(IEquatable<>).MakeGenericType(elementType).IsAssignableFrom(elementType))
            return (ValueComparer)Activator.CreateInstance(typeof(SingleDimComparerWithIEquatable<>).MakeGenericType(elementType));

        // There's no custom comparer, and the element type doesn't implement IEquatable<TElem>. We have
        // no choice but to use the non-generic Equals method.
        return (ValueComparer)Activator.CreateInstance(typeof(SingleDimComparerWithEquals<>).MakeGenericType(elementType));
    }

    class SingleDimComparerWithComparer<TElem> : ValueComparer<TElem[]>
    {
        public SingleDimComparerWithComparer(RelationalTypeMapping elementMapping) : base(
            (a, b) => Compare(a, b, (ValueComparer<TElem>)elementMapping.Comparer),
            o => o.GetHashCode(), // TODO: Need to get hash code of elements...
            source => Snapshot(source, (ValueComparer<TElem>)elementMapping.Comparer)) {}

        public override Type Type => typeof(TElem[]);

        static bool Compare(TElem[] a, TElem[] b, ValueComparer<TElem> elementComparer)
        {
            if (a.Length != b.Length)
                return false;

            // Note: the following currently boxes every element access because ValueComparer isn't really
            // generic (see https://github.com/aspnet/EntityFrameworkCore/issues/11072)
            for (var i = 0; i < a.Length; i++)
                if (!elementComparer.Equals(a[i], b[i]))
                    return false;

            return true;
        }

        static TElem[] Snapshot(TElem[] source, ValueComparer<TElem> elementComparer)
        {
            if (source == null)
                return null;

            var snapshot = new TElem[source.Length];
            // Note: the following currently boxes every element access because ValueComparer isn't really
            // generic (see https://github.com/aspnet/EntityFrameworkCore/issues/11072)
            for (var i = 0; i < source.Length; i++)
                snapshot[i] = elementComparer.Snapshot(source[i]);
            return snapshot;
        }
    }

    class SingleDimComparerWithIEquatable<TElem> : ValueComparer<TElem[]>
        where TElem : IEquatable<TElem>
    {
        public SingleDimComparerWithIEquatable() : base(
            (a, b) => Compare(a, b),
            o => o.GetHashCode(), // TODO: Need to get hash code of elements...
            source => DoSnapshot(source)) {}

        public override Type Type => typeof(TElem[]);

        static bool Compare(TElem[] a, TElem[] b)
        {
            if (a.Length != b.Length)
                return false;

            for (var i = 0; i < a.Length; i++)
            {
                var elem1 = a[i];
                var elem2 = b[i];
                // Note: the following null checks are elided if TElem is a value type
                if (elem1 == null)
                {
                    if (elem2 == null)
                        continue;
                    return false;
                }

                if (!elem1.Equals(elem2))
                    return false;
            }

            return true;
        }

        static TElem[] DoSnapshot(TElem[] source)
        {
            if (source == null)
                return null;
            var snapshot = new TElem[source.Length];
            for (var i = 0; i < source.Length; i++)
                snapshot[i] = source[i];
            return snapshot;
        }
    }

    class SingleDimComparerWithEquals<TElem> : ValueComparer<TElem[]>
    {
        public SingleDimComparerWithEquals() : base(
            (a, b) => Compare(a, b),
            o => o.GetHashCode(), // TODO: Need to get hash code of elements...
            source => DoSnapshot(source)) {}

        public override Type Type => typeof(TElem[]);

        static bool Compare(TElem[] a, TElem[] b)
        {
            if (a.Length != b.Length)
                return false;

            // Note: the following currently boxes every element access because ValueComparer isn't really
            // generic (see https://github.com/aspnet/EntityFrameworkCore/issues/11072)
            for (var i = 0; i < a.Length; i++)
            {
                var elem1 = a[i];
                var elem2 = b[i];
                if (elem1 == null)
                {
                    if (elem2 == null)
                        continue;
                    return false;
                }

                if (!elem1.Equals(elem2))
                    return false;
            }

            return true;
        }

        static TElem[] DoSnapshot(TElem[] source)
        {
            if (source == null)
                return null;

            var snapshot = new TElem[source.Length];
            // Note: the following currently boxes every element access because ValueComparer isn't really
            // generic (see https://github.com/aspnet/EntityFrameworkCore/issues/11072)
            for (var i = 0; i < source.Length; i++)
                snapshot[i] = source[i];
            return snapshot;
        }
    }

    #endregion Value Comparison
}