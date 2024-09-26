using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.ValueConversion.Internal;

public class ClickHouseMultiPolygonValueConverter : ValueConverter<MultiPolygon, byte[]>
{
    public ClickHouseMultiPolygonValueConverter()
        : base(
            x => Array.Empty<byte>(),
            x => new MultiPolygon(Array.Empty<Polygon>()))
    {
    }
}
