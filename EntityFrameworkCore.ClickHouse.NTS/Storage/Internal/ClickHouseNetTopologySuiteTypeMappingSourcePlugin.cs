using EntityFrameworkCore.ClickHouse.NTS.Storage.Internal.Mapping;
using Microsoft.EntityFrameworkCore.Storage;
using NetTopologySuite.Geometries;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.Internal;

public class ClickHouseNetTopologySuiteTypeMappingSourcePlugin : IRelationalTypeMappingSourcePlugin
{
    private static readonly RelationalTypeMapping PointTypeMapping = new ClickHousePointTypeMapping();
    private static readonly RelationalTypeMapping RingTypeMapping = new ClickHouseRingTypeMapping();
    private static readonly RelationalTypeMapping PolygonTypeMapping = new ClickHousePolygonTypeMapping();
    private static readonly RelationalTypeMapping MultiPolygonTypeMapping = new ClickHouseMultiPolygonTypeMapping();
    private static readonly RelationalTypeMapping GeometryTypeMapping = new ClickHouseGeometryTypeMapping();

    private static readonly Dictionary<string, RelationalTypeMapping> StoreTypeMappings = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Point", PointTypeMapping },
        { "Ring", RingTypeMapping },
        { "Polygon", PolygonTypeMapping },
        { "MultiPolygon", MultiPolygonTypeMapping },
        { "Geometry", GeometryTypeMapping }
    };

    private static readonly Dictionary<Type, RelationalTypeMapping> ClrTypeMappings = new()
    {
        { typeof(Point), PointTypeMapping },
        { typeof(MultiPoint), RingTypeMapping },
        { typeof(Polygon), PolygonTypeMapping },
        { typeof(MultiPolygon), MultiPolygonTypeMapping },
        { typeof(Geometry), GeometryTypeMapping }
    };

    public RelationalTypeMapping? FindMapping(in RelationalTypeMappingInfo mappingInfo)
    {
        if (!string.IsNullOrWhiteSpace(mappingInfo.StoreTypeName) &&
            StoreTypeMappings.TryGetValue(mappingInfo.StoreTypeName, out var mapping))
        {
            return mapping;
        }

        return ClrTypeMappings.TryGetValue(mappingInfo.ClrType, out mapping) ? mapping : null;
    }
}
