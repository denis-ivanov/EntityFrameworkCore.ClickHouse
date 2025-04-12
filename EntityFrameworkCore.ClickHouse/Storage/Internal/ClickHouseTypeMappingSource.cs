using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using BindingFlags = System.Reflection.BindingFlags;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal;

public class ClickHouseTypeMappingSource : RelationalTypeMappingSource
{
    private static readonly RelationalTypeMapping StringTypeMapping = new ClickHouseStringTypeMapping();
    private static readonly RelationalTypeMapping BoolTypeMapping = new ClickHouseBoolTypeMapping();
    private static readonly RelationalTypeMapping ByteTypeMapping = new ClickHouseByteTypeMapping();
    private static readonly RelationalTypeMapping CharTypeMapping = new ClickHouseCharTypeMapping();
    private static readonly RelationalTypeMapping Int32TypeMapping = new ClickHouseInt32TypeMapping();
    private static readonly RelationalTypeMapping UInt64TypeMapping = new ClickHouseUInt64TypeMapping();
    private static readonly RelationalTypeMapping Int64TypeMapping = new ClickHouseInt64TypeMapping();
    private static readonly RelationalTypeMapping Int8TypeMapping = new ClickHouseInt8TypeMapping();
    private static readonly RelationalTypeMapping Int16TypeMapping = new ClickHouseInt16TypeMapping();
    private static readonly RelationalTypeMapping UInt32TypeMapping = new ClickHouseUInt32TypeMapping();
    private static readonly RelationalTypeMapping UInt16TypeMapping = new ClickHouseUInt16TypeMapping();
    private static readonly RelationalTypeMapping DateTimeTypeMapping = new ClickHouseDateTimeTypeMapping();
    private static readonly RelationalTypeMapping DateTypeMapping = new ClickHouseDateTypeMapping();
    private static readonly RelationalTypeMapping Float64TypeMapping = new ClickHouseFloat64TypeMapping();
    private static readonly RelationalTypeMapping Float32TypeMapping = new ClickHouseFloat32TypeMapping();
    private static readonly RelationalTypeMapping UuidTypeMapping = new ClickHouseUuidTypeMapping();
    private static readonly RelationalTypeMapping JsonTypeMapping = new ClickHouseJsonTypeMapping();

    private static readonly Dictionary<Type, RelationalTypeMapping> ClrTypeMappings = new()
    {
        { typeof(string), StringTypeMapping },
        { typeof(bool), BoolTypeMapping },
        { typeof(byte), ByteTypeMapping },
        { typeof(char), CharTypeMapping },
        { typeof(int), Int32TypeMapping },
        { typeof(ulong), UInt64TypeMapping },
        { typeof(long), Int64TypeMapping },
        { typeof(sbyte), Int8TypeMapping },
        { typeof(short), Int16TypeMapping },
        { typeof(uint), UInt32TypeMapping },
        { typeof(ushort), UInt16TypeMapping },
        { typeof(DateTime), DateTimeTypeMapping },
        { typeof(DateOnly), DateTypeMapping },
        { typeof(double), Float64TypeMapping },
        { typeof(float), Float32TypeMapping },
        { typeof(Guid), UuidTypeMapping },
        { typeof(JsonElement), JsonTypeMapping }
    };

    private static readonly Dictionary<string, RelationalTypeMapping> AliasTypeMapping = new(StringComparer.InvariantCultureIgnoreCase)
    {
        // https://clickhouse.com/docs/en/sql-reference/data-types/string
        ["String"] = StringTypeMapping,
        ["LONGTEXT"] = StringTypeMapping,
        ["MEDIUMTEXT"] = StringTypeMapping,
        ["TINYTEXT"] = StringTypeMapping,
        ["TEXT"] = StringTypeMapping,
        ["LONGBLOB"] = StringTypeMapping,
        ["MEDIUMBLOB"] = StringTypeMapping,
        ["TINYBLOB"] = StringTypeMapping,
        ["BLOB"] = StringTypeMapping,
        ["VARCHAR"] = StringTypeMapping,
        ["CHAR"] = StringTypeMapping,
        ["FixedString(1)"] = CharTypeMapping,

        // https://clickhouse.com/docs/en/sql-reference/data-types/int-uint
        ["Int8"] = Int8TypeMapping,
        ["TINYINT"] = Int8TypeMapping,
        ["INT1"] = Int8TypeMapping,
        ["BYTE"] = Int8TypeMapping,
        ["TINYINT SIGNED"] = Int8TypeMapping,
        ["INT1 SIGNED"] = Int8TypeMapping,

        ["Int16"] = Int16TypeMapping,
        ["SMALLINT"] = Int16TypeMapping,
        ["SMALLINT SIGNED"] = Int16TypeMapping,

        ["Int32"] = Int32TypeMapping,
        ["INTEGER"] = Int32TypeMapping,
        ["MEDIUMINT"] = Int32TypeMapping,
        ["MEDIUMINT SIGNED"] = Int32TypeMapping,
        ["INT SIGNED"] = Int32TypeMapping,
        ["INTEGER SIGNED"] = Int32TypeMapping,

        ["Int64"] = Int64TypeMapping,
        ["BIGINT"] = Int64TypeMapping,
        ["SIGNED"] = Int64TypeMapping,
        ["BIGINT SIGNED"] = Int64TypeMapping,
        ["TIME"] = Int64TypeMapping,

        ["UInt8"] = ByteTypeMapping,
        ["TINYINT UNSIGNED"] = ByteTypeMapping,
        ["INT1 UNSIGNED"] = ByteTypeMapping,

        ["UInt16"] = UInt16TypeMapping,
        ["SMALLINT UNSIGNED"] = UInt16TypeMapping,

        ["UInt32"] = UInt32TypeMapping,
        ["MEDIUMINT UNSIGNED"] = UInt32TypeMapping,
        ["INT UNSIGNED"] = UInt32TypeMapping,
        ["INTEGER UNSIGNED"] = UInt32TypeMapping,

        ["UInt64"] = UInt64TypeMapping,
        ["UNSIGNED"] = UInt64TypeMapping,
        ["BIGINT UNSIGNED"] = UInt64TypeMapping,
        ["BIT"] = UInt64TypeMapping,
        ["SET"] = UInt64TypeMapping,

        // UInt128
        // UInt256

        // https://clickhouse.com/docs/en/sql-reference/data-types/float
        ["Float32"] = Float32TypeMapping,
        ["FLOAT"] = Float32TypeMapping,
        ["REAL"] = Float32TypeMapping,
        ["SINGLE"] = Float32TypeMapping,

        ["Float64"] = Float64TypeMapping,
        ["DOUBLE"] = Float64TypeMapping,
        ["DOUBLE PRECISION"] = Float64TypeMapping,

        ["bool"] = BoolTypeMapping,

        ["UUID"] = UuidTypeMapping,

        ["Date"] = DateTypeMapping,
        ["Date32"] = DateTypeMapping,
        ["DateTime"] = DateTimeTypeMapping,
        ["DateTime64"] = DateTimeTypeMapping,
        ["Json"] = JsonTypeMapping
    };

    public ClickHouseTypeMappingSource(TypeMappingSourceDependencies dependencies, RelationalTypeMappingSourceDependencies relationalDependencies)
        : base(dependencies, relationalDependencies)
    {
    }

    public override RelationalTypeMapping FindMapping(Type type)
    {
        return FindMapping(new RelationalTypeMappingInfo(type)) ?? base.FindMapping(type);
    }

    protected override RelationalTypeMapping FindMapping(in RelationalTypeMappingInfo mappingInfo) =>
        FindExistingMapping(mappingInfo) ??
        FindTupleMapping(mappingInfo) ??
        FindDecimalMapping(mappingInfo) ??
        base.FindMapping(in mappingInfo);

    private RelationalTypeMapping FindExistingMapping(in RelationalTypeMappingInfo mappingInfo)
    {
        if (mappingInfo.ClrType != null && ClrTypeMappings.TryGetValue(mappingInfo.ClrType, out var map))
        {
            return map;
        }

        if (!string.IsNullOrWhiteSpace(mappingInfo.StoreTypeNameBase) &&
            AliasTypeMapping.TryGetValue(mappingInfo.StoreTypeNameBase, out var mapAsAlias1))
        {
            return mapAsAlias1;
        }

        if (!string.IsNullOrWhiteSpace(mappingInfo.StoreTypeName) &&
            AliasTypeMapping.TryGetValue(mappingInfo.StoreTypeName, out var mapAsAlias2))
        {
            return mapAsAlias2;
        }

        return null;
    }

    protected override RelationalTypeMapping FindCollectionMapping(
        RelationalTypeMappingInfo info,
        Type modelType,
        Type providerType,
        CoreTypeMapping elementMapping)
    {
        if (elementMapping is not null and not RelationalTypeMapping)
        {
            return null;
        }

        if (info.StoreTypeName != null &&
            info.StoreTypeName.StartsWith("Array(") &&
            info.StoreTypeName.EndsWith(')'))
        {
            var elementTypeName = info.StoreTypeName.Substring(6, info.StoreTypeName.Length - 7).Trim();

            if (AliasTypeMapping.TryGetValue(elementTypeName, out var elementTypeMapping))
            {
                var concreteCollectionType = FindTypeToInstantiate(modelType, elementTypeMapping.ClrType);

                return (RelationalTypeMapping)Activator.CreateInstance(
                    typeof(ClickHouseArrayTypeMapping<,,>).MakeGenericType(modelType, concreteCollectionType, elementTypeMapping.ClrType),
                    elementTypeMapping);
            }
        }

        modelType = modelType.UnwrapNullableType();

        if (info.ClrType is { IsArray: true } || modelType.IsEnumerable())
        {
            var elementType = modelType.IsArray
                ? modelType.GetElementType()!/*.UnwrapNullableType()*/
                : modelType.GenericTypeArguments[0]/*.UnwrapNullableType()*/;

            ValueConverter? converter = null;

            if (elementType.IsEnum)
            {
                var enumType = elementType;
                elementType = Enum.GetUnderlyingType(elementType);
                converter = (ValueConverter)Activator.CreateInstance(typeof(EnumToNumberConverter<,>).MakeGenericType(enumType, elementType));
            }

            var elementTypeMapping = FindMapping(elementType);

            if (elementTypeMapping == null && !ClrTypeMappings.TryGetValue(elementType, out elementTypeMapping))
            {
                return null;
            }

            var concreteCollectionType = FindTypeToInstantiate(modelType, elementType);

            if (converter != null)
            {
                elementTypeMapping = (RelationalTypeMapping)elementTypeMapping.WithComposedConverter(converter);
            }

            return (RelationalTypeMapping)Activator.CreateInstance(
                typeof(ClickHouseArrayTypeMapping<,,>).MakeGenericType(modelType, concreteCollectionType, elementType),
                elementTypeMapping);
        }

        return null;
    }

    private RelationalTypeMapping FindDecimalMapping(in RelationalTypeMappingInfo mappingInfo)
    {
        return mappingInfo.ClrType == typeof(decimal) || mappingInfo.StoreTypeNameBase == "Decimal"
            ? new ClickHouseDecimalTypeMapping(mappingInfo.Precision, mappingInfo.Scale, mappingInfo.Size)
            : null;
    }

    private RelationalTypeMapping FindTupleMapping(in RelationalTypeMappingInfo mappingInfo)
    {
        if (mappingInfo.ClrType is not { IsGenericType: true })
        {
            return null;
        }

        var genericTypeDefinition = mappingInfo.ClrType.GetGenericTypeDefinition();

        if (genericTypeDefinition == typeof(Tuple<>) ||
            genericTypeDefinition == typeof(Tuple<,>) ||
            genericTypeDefinition == typeof(Tuple<,,>) ||
            genericTypeDefinition == typeof(Tuple<,,,>) ||
            genericTypeDefinition == typeof(Tuple<,,,,>) ||
            genericTypeDefinition == typeof(Tuple<,,,,,>) ||
            genericTypeDefinition == typeof(Tuple<,,,,,,>) ||
            genericTypeDefinition == typeof(Tuple<,,,,,,,>))
        {
            var genericArguments = mappingInfo.ClrType.GetGenericArguments();
            var storeType = "tuple(" + string.Join(", ", genericArguments.Select(e => FindMapping(new RelationalTypeMappingInfo(e))!.StoreType)) + ")";
            return new ClickHouseTupleTypeMapping(storeType, mappingInfo.ClrType, this);
        }

        return null;
    }

    private static Type FindTypeToInstantiate(Type collectionType, Type elementType)
    {
        if (collectionType.IsArray)
        {
            return collectionType;
        }

        var listOfT = typeof(List<>).MakeGenericType(elementType);

        if (collectionType.IsAssignableFrom(listOfT))
        {
            if (!collectionType.IsAbstract)
            {
                var constructor = collectionType.GetConstructor(BindingFlags.Public, Type.EmptyTypes);
                if (constructor != null)
                {
                    return collectionType;
                }
            }

            return listOfT;
        }

        return collectionType;
    }
}