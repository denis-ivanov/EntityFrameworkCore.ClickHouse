using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.ValueConversion.Internal;

public class ClickHouseLineStringValueConverter : ValueConverter<LineString, Tuple<double, double>[]>
{
    internal static readonly ClickHouseLineStringValueConverter Instance = new();
    
    public ClickHouseLineStringValueConverter()
        : base(
            v => ConvertToProvider(v),
            v => ConvertFromProvider(v))
    {
    }

    private static Tuple<double, double>[] ConvertToProvider(LineString value) => value.Coordinates.Select(c => new Tuple<double, double>(c.X, c.Y)).ToArray();
    
    private static LineString ConvertFromProvider(Tuple<double, double>[] value) => new(value.Select(c => new Coordinate(c.Item1, c.Item2)).ToArray());
}
