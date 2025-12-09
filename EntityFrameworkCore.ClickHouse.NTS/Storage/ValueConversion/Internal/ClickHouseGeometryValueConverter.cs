using EntityFrameworkCore.ClickHouse.NTS.Extensions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.ValueConversion.Internal;

public class ClickHouseGeometryValueConverter : ValueConverter<Geometry, object>
{
    internal static readonly ClickHouseGeometryValueConverter Instance = new();

    public ClickHouseGeometryValueConverter()
        : base(
            v => ToProvider(v),
            v => FromProvider(v))
    {
    }

    private static object ToProvider(Geometry geometry)
    {
        return geometry.ToClickHouse();
    }

    private static Geometry FromProvider(object obj)
    {
        throw new NotImplementedException();
    }
}