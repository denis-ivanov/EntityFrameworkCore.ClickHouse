using NetTopologySuite.Geometries;
using System.Runtime.InteropServices.Swift;

namespace EntityFrameworkCore.ClickHouse.NTS.Extensions;

internal static class GeometryExtensions
{
    public static object ToClickHouse(this Geometry geometry)
    {
        return geometry.OgcGeometryType switch
        {
            OgcGeometryType.Point => ToClickHouse((Point)geometry),
            OgcGeometryType.LineString => ToClickHouse((LineString)geometry),
            OgcGeometryType.Polygon => throw new NotImplementedException(),
            OgcGeometryType.MultiPoint => throw new NotImplementedException(),
            OgcGeometryType.MultiLineString => ToClickHouse((MultiLineString)geometry),
            OgcGeometryType.MultiPolygon => throw new NotImplementedException(),
            OgcGeometryType.GeometryCollection => throw new NotImplementedException(),
            OgcGeometryType.CircularString => throw new NotImplementedException(),
            OgcGeometryType.CompoundCurve => throw new NotImplementedException(),
            OgcGeometryType.CurvePolygon => throw new NotImplementedException(),
            OgcGeometryType.MultiCurve => throw new NotImplementedException(),
            OgcGeometryType.MultiSurface => throw new NotImplementedException(),
            OgcGeometryType.Curve => throw new NotImplementedException(),
            OgcGeometryType.Surface => throw new NotImplementedException(),
            OgcGeometryType.PolyhedralSurface => throw new NotImplementedException(),
            OgcGeometryType.TIN => throw new NotImplementedException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static Tuple<double, double> ToClickHouse(Coordinate coordinate) => new(coordinate.X, coordinate.Y);
    
    public static Tuple<double, double> ToClickHouse(Point point) => new(point.X, point.Y);

    public static Tuple<double, double>[] ToClickHouse(LineString lineString) => lineString.Coordinates.Select(ToClickHouse).ToArray();

    public static Tuple<double, double>[][] ToClickHouse(MultiLineString multiLineString)
    {
        throw new NotImplementedException();
    }
}
