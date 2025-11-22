using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.ValueConversion.Internal;

public class ClickHousePolygonValueConverter : ValueConverter<Polygon, byte[]>
{
    public ClickHousePolygonValueConverter()
        : base(
            x => Array.Empty<byte>(),
            x => new Polygon(null))
    {
    }
}
