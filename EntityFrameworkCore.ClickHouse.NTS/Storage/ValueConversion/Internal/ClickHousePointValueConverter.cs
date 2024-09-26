using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.ValueConversion.Internal;

public class ClickHousePointValueConverter : ValueConverter<Point, Tuple<double, double>>
{
    public ClickHousePointValueConverter()
        : base(
            x => new Tuple<double, double>(x.X, x.Y),
            y => new Point(y.Item1, y.Item2))
    {
    }
}
