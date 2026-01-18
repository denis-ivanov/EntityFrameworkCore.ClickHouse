using ClickHouse.Driver.ADO.Parameters;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;
using System.Diagnostics;
using System.Text;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseArrayTypeMapping : RelationalTypeMapping
{
    public ClickHouseArrayTypeMapping(string storeType, RelationalTypeMapping elementMapping)
        : this(storeType, elementMapping, elementMapping.ClrType.MakeArrayType())
    {
    }

    ClickHouseArrayTypeMapping(string storeType, RelationalTypeMapping elementMapping, Type arrayType)
        : this(
            new RelationalTypeMappingParameters(
                new CoreTypeMappingParameters(
                    arrayType,
                    null,
                    CreateComparer(elementMapping, arrayType),
                    elementMapping: elementMapping),
                storeType),
            elementMapping)
    {
    }

    protected ClickHouseArrayTypeMapping(RelationalTypeMappingParameters parameters, RelationalTypeMapping elementMapping)
        : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        => new ClickHouseArrayTypeMapping(parameters, (RelationalTypeMapping)parameters.CoreParameters.ElementTypeMapping!);

    protected override string GenerateNonNullSqlLiteral(object value)
    {
        var arr = (Array)value;

        if (arr.Rank != 1)
        {
            throw new NotSupportedException("Multidimensional array literals aren't supported");
        }

        var elementTypeMapping = (RelationalTypeMapping)ElementTypeMapping!;

        var sb = new StringBuilder();
        sb.Append('[');
        
        for (var i = 0; i < arr.Length; i++)
        {
            sb.Append(elementTypeMapping.GenerateSqlLiteral(arr.GetValue(i)));
            
            if (i < arr.Length - 1)
            {
                sb.Append(',');
            }
        }

        sb.Append(']');
        return sb.ToString();
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        ((ClickHouseDbParameter)parameter).ClickHouseType = GetStoreType(parameter.Value);
    }

    protected virtual string GetStoreType(bool? isNullable)
    {
        return isNullable == true ? $"Nullable({StoreType})" : StoreType;
    }
    
    protected virtual string GetStoreType(object? parameterValue)
    {
        return GetStoreType(parameterValue == null || parameterValue == DBNull.Value);
    }
    
    #region Value Comparison

    static ValueComparer? CreateComparer(RelationalTypeMapping elementMapping, Type arrayType)
    {
        Debug.Assert(arrayType.IsArray);
        var elementType = arrayType.GetElementType();

        if (arrayType.GetArrayRank() != 1)
        {
            return null;
        }

        return (ValueComparer)Activator.CreateInstance(typeof(SingleDimComparerWithComparer<>).MakeGenericType(elementType!), elementMapping)!;
    }

    class SingleDimComparerWithComparer<TElem> : ValueComparer<TElem[]?>
    {
        public SingleDimComparerWithComparer(RelationalTypeMapping elementMapping) : base(
            (a, b) => Compare(a, b, (ValueComparer<TElem>)elementMapping.Comparer),
            o => o!.GetHashCode(), // TODO: Need to get hash code of elements...
            source => Snapshot(source, (ValueComparer<TElem>)elementMapping.Comparer)) {}

        public override Type Type => typeof(TElem[]);

        static bool Compare(TElem[]? a, TElem[]? b, ValueComparer<TElem> elementComparer)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null)
            {
                return false;
            }
            
            if (a.Length != b.Length)
            {
                return false;
            }

            for (var i = 0; i < a.Length; i++)
            {
                if (!elementComparer.Equals(a[i], b[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static TElem[]? Snapshot(TElem[]? source, ValueComparer<TElem> elementComparer)
        {
            if (source == null)
            {
                return null;
            }

            var snapshot = new TElem[source.Length];
            
            for (var i = 0; i < source.Length; i++)
            {
                snapshot[i] = elementComparer.Snapshot(source[i]);
            }
            
            return snapshot;
        }
    }

    class SingleDimComparerWithIEquatable<TElem> : ValueComparer<TElem[]?> where TElem : IEquatable<TElem>
    {
        public SingleDimComparerWithIEquatable() : base(
            (a, b) => Compare(a, b),
            o => o!.GetHashCode(), // TODO: Need to get hash code of elements...
            source => DoSnapshot(source))
        {
        }

        public override Type Type => typeof(TElem[]);

        static bool Compare(TElem[]? a, TElem[]? b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null)
            {
                return false;
            }
            
            if (a.Length != b.Length)
            {
                return false;
            }

            for (var i = 0; i < a.Length; i++)
            {
                var elem1 = a[i];
                var elem2 = b[i];
                
                if (elem1 == null)
                {
                    if (elem2 == null)
                    {
                        continue;
                    }
                
                    return false;
                }

                if (!elem1.Equals(elem2))
                {
                    return false;
                }
            }

            return true;
        }

        static TElem[]? DoSnapshot(TElem[]? source)
        {
            if (source == null)
            {
                return null;
            }
            
            var snapshot = new TElem[source.Length];
            
            for (var i = 0; i < source.Length; i++)
            {
                snapshot[i] = source[i];
            }
            
            return snapshot;
        }
    }

    class SingleDimComparerWithEquals<TElem> : ValueComparer<TElem[]?>
    {
        public SingleDimComparerWithEquals() : base(
            (a, b) => Compare(a, b),
            o => o!.GetHashCode(), // TODO: Need to get hash code of elements...
            source => DoSnapshot(source)) {}

        public override Type Type => typeof(TElem[]);

        static bool Compare(TElem[]? a, TElem[]? b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null)
            {
                return false;
            }
            
            if (a.Length != b.Length)
            {
                return false;
            }

            for (var i = 0; i < a.Length; i++)
            {
                var elem1 = a[i];
                var elem2 = b[i];
                
                if (elem1 == null)
                {
                    if (elem2 == null)
                    {
                        continue;
                    }
                    
                    return false;
                }

                if (!elem1.Equals(elem2))
                {
                    return false;
                }
            }

            return true;
        }

        static TElem[]? DoSnapshot(TElem[]? source)
        {
            if (source == null)
            {
                return null;
            }

            var snapshot = new TElem[source.Length];

            for (var i = 0; i < source.Length; i++)
            {
                snapshot[i] = source[i];
            }

            return snapshot;
        }
    }

    #endregion Value Comparison
}
