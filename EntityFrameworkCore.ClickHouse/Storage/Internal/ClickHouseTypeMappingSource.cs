using ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal
{
    public class ClickHouseTypeMappingSource : RelationalTypeMappingSource
    {
        private static readonly Dictionary<Type, RelationalTypeMapping> ClrTypeMappings = new()
        {
            { typeof(string), new ClickHouseStringTypeMapping() },
            { typeof(bool), new ClickHouseBoolTypeMapping() },
            { typeof(byte), new ClickHouseByteTypeMapping() },
            { typeof(char), new ClickHouseCharTypeMapping() },
            { typeof(int), new ClickHouseInt32TypeMapping() },
            { typeof(ulong), new ClickHouseUInt64TypeMapping() },
            { typeof(long), new ClickHouseInt64TypeMapping() },
            { typeof(sbyte), new ClickHouseInt8TypeMapping() },
            { typeof(short), new ClickHouseInt16TypeMapping() },
            { typeof(uint), new ClickHouseUInt32TypeMapping() },
            { typeof(ushort), new ClickHouseUInt16TypeMapping() },
            { typeof(DateTime), new ClickHouseDateTimeTypeMapping() },
            { typeof(double), new ClickHouseFloat64TypeMapping() },
            { typeof(float), new ClickHouseFloat32TypeMapping() },
            { typeof(Guid), new ClickHouseUuidTypeMapping() }
        };

        public ClickHouseTypeMappingSource(TypeMappingSourceDependencies dependencies, RelationalTypeMappingSourceDependencies relationalDependencies)
            : base(dependencies, relationalDependencies)
        {
        }

        protected override RelationalTypeMapping FindMapping(in RelationalTypeMappingInfo mappingInfo) =>
            FindExistingMapping(mappingInfo) ??
            FindArrayMapping(mappingInfo) ??
            GetDecimalMapping(mappingInfo) ??
            base.FindMapping(in mappingInfo);

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

        private RelationalTypeMapping GetDecimalMapping(in RelationalTypeMappingInfo mappingInfo)
        {
            if (mappingInfo.ClrType == typeof(decimal))
            {
                return new ClickHouseDecimalTypeMapping(mappingInfo.Precision, mappingInfo.Scale, mappingInfo.Size);
            }

            return null;
        }
    }
}
