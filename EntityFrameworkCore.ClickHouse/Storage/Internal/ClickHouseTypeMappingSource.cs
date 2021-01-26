using ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal
{
    public class ClickHouseTypeMappingSource : RelationalTypeMappingSource
    {
        private static readonly Dictionary<Type, RelationalTypeMapping> ClrTypeMappings = new()
        {
            { typeof(string), new StringTypeMapping("String", DbType.String) },
            { typeof(byte[]), new ByteArrayTypeMapping("Array(UInt8)") },
            { typeof(bool), new BoolTypeMapping("UInt8", DbType.Byte) },
            { typeof(byte), new ByteTypeMapping("UInt8") },
            { typeof(char), new CharTypeMapping("FixedString(1)") },
            { typeof(int), new IntTypeMapping("Int32") },
            { typeof(ulong), new ULongTypeMapping("UInt64") },
            { typeof(long), new LongTypeMapping("Int64") },
            { typeof(sbyte), new SByteTypeMapping("Int8") },
            { typeof(short), new ShortTypeMapping("Int16") },
            { typeof(uint), new UIntTypeMapping("UInt32") },
            { typeof(ushort), new UShortTypeMapping("UInt16") },
            { typeof(DateTime), new DateTimeTypeMapping("DateTime") },
            { typeof(decimal), new DecimalTypeMapping("Decimal32", DbType.Decimal) },
            { typeof(double), new DoubleTypeMapping("Float64") },
            { typeof(float), new FloatTypeMapping("Float32") },
            { typeof(Guid), new GuidTypeMapping("UUID") }
        };

        public ClickHouseTypeMappingSource(TypeMappingSourceDependencies dependencies, RelationalTypeMappingSourceDependencies relationalDependencies)
            : base(dependencies, relationalDependencies)
        {
        }

        protected override RelationalTypeMapping FindMapping(in RelationalTypeMappingInfo mappingInfo)
        {
            return FindExistingMapping(mappingInfo) ?? FindArrayMapping(mappingInfo) ?? base.FindMapping(in mappingInfo);
        }

        private RelationalTypeMapping FindExistingMapping(in RelationalTypeMappingInfo mappingInfo)
        {
            if (mappingInfo.ClrType != null && ClrTypeMappings.TryGetValue(mappingInfo.ClrType, out var map))
            {
                return map;
            }

            return null;
        }

        private RelationalTypeMapping FindArrayMapping(in RelationalTypeMappingInfo mappingInfo)
        {
            if (mappingInfo.ClrType == null || !mappingInfo.ClrType.IsArray)
            {
                return null;
            }

            var elementType = mappingInfo.ClrType.GetElementType();
            var elementTypeMapping = ClrTypeMappings[elementType];
            return new ClickHouseArrayTypeMapping($"Array({elementTypeMapping.StoreType})", elementTypeMapping);
        }
    }
}
