using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.ValueConversion.Internal;

public class GeometryValueConverter<TGeometry> : ValueConverter<TGeometry, byte[]> where TGeometry : Geometry
{
    // TODO
    public GeometryValueConverter()
        : base(
            g => Array.Empty<byte>(),
            b => (TGeometry)null)
    {
    }
}
