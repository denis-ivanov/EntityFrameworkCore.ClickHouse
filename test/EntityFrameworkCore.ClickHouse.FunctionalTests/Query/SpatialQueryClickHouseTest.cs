using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class SpatialQueryClickHouseTest : SpatialQueryRelationalTestBase<SpatialQueryClickHouseFixture>
{
    public SpatialQueryClickHouseTest(SpatialQueryClickHouseFixture fixture) : base(fixture)
    {
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Area(bool async)
    {
        await base.Area(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task AsBinary(bool async)
    {
        await base.AsBinary(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task AsBinary_with_null_check(bool async)
    {
        await base.AsBinary_with_null_check(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task AsText(bool async)
    {
        await base.AsText(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Boundary(bool async)
    {
        await base.Boundary(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Buffer(bool async)
    {
        await base.Buffer(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Centroid(bool async)
    {
        await base.Centroid(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains(bool async)
    {
        await base.Contains(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ConvexHull(bool async)
    {
        await base.ConvexHull(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Buffer_quadrantSegments(bool async)
    {
        await base.Buffer_quadrantSegments(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Covers(bool async)
    {
        await base.Covers(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Crosses(bool async)
    {
        await base.Crosses(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Difference(bool async)
    {
        await base.Difference(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Dimension(bool async)
    {
        await base.Dimension(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Disjoint_with_cast_to_nullable(bool async)
    {
        await base.Disjoint_with_cast_to_nullable(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task InteriorPoint(bool async)
    {
        await base.InteriorPoint(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Combine_aggregate(bool async)
    {
        await base.Combine_aggregate(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ConvexHull_aggregate(bool async)
    {
        await base.ConvexHull_aggregate(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task CoveredBy(bool async)
    {
        await base.CoveredBy(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Disjoint_with_null_check(bool async)
    {
        await base.Disjoint_with_null_check(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distance_constant(bool async)
    {
        await base.Distance_constant(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distance_constant_lhs(bool async)
    {
        await base.Distance_constant_lhs(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distance_constant_srid_4326(bool async)
    {
        await base.Distance_constant_srid_4326(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distance_geometry(bool async)
    {
        await base.Distance_geometry(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distance_on_converted_geometry_type(bool async)
    {
        await base.Distance_on_converted_geometry_type(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SimpleSelect(bool async)
    {
        await base.SimpleSelect(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task WithConversion(bool async)
    {
        await base.WithConversion(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task EnvelopeCombine_aggregate(bool async)
    {
        await base.EnvelopeCombine_aggregate(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task IGeometryCollection_Count(bool async)
    {
        await base.IGeometryCollection_Count(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task LineString_Count(bool async)
    {
        await base.LineString_Count(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distance_with_null_check(bool async)
    {
        await base.Distance_with_null_check(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distance_with_cast_to_nullable(bool async)
    {
        await base.Distance_with_cast_to_nullable(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distance_on_converted_geometry_type_lhs(bool async)
    {
        await base.Distance_on_converted_geometry_type_lhs(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distance_on_converted_geometry_type_constant(bool async)
    {
        await base.Distance_on_converted_geometry_type_constant(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distance_on_converted_geometry_type_constant_lhs(bool async)
    {
        await base.Distance_on_converted_geometry_type_constant_lhs(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task EndPoint(bool async)
    {
        await base.EndPoint(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Envelope(bool async)
    {
        await base.Envelope(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task EqualsTopologically(bool async)
    {
        await base.EqualsTopologically(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ExteriorRing(bool async)
    {
        await base.ExteriorRing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GeometryType(bool async)
    {
        await base.GeometryType(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetGeometryN(bool async)
    {
        await base.GetGeometryN(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetGeometryN_with_null_argument(bool async)
    {
        await base.GetGeometryN_with_null_argument(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetInteriorRingN(bool async)
    {
        await base.GetInteriorRingN(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetPointN(bool async)
    {
        await base.GetPointN(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Intersection(bool async)
    {
        await base.Intersection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Intersects(bool async)
    {
        await base.Intersects(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ICurve_IsClosed(bool async)
    {
        await base.ICurve_IsClosed(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task IMultiCurve_IsClosed(bool async)
    {
        await base.IMultiCurve_IsClosed(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task IsEmpty(bool async)
    {
        await base.IsEmpty(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task IsRing(bool async)
    {
        await base.IsRing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task IsSimple(bool async)
    {
        await base.IsSimple(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task IsValid(bool async)
    {
        await base.IsValid(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task IsWithinDistance(bool async)
    {
        await base.IsWithinDistance(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Item(bool async)
    {
        await base.Item(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Length(bool async)
    {
        await base.Length(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task M(bool async)
    {
        await base.M(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Normalized(bool async)
    {
        await base.Normalized(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task NumGeometries(bool async)
    {
        await base.NumGeometries(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task NumInteriorRings(bool async)
    {
        await base.NumInteriorRings(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task NumPoints(bool async)
    {
        await base.NumPoints(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OgcGeometryType(bool async)
    {
        await base.OgcGeometryType(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Overlaps(bool async)
    {
        await base.Overlaps(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task PointOnSurface(bool async)
    {
        await base.PointOnSurface(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Relate(bool async)
    {
        await base.Relate(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Reverse(bool async)
    {
        await base.Reverse(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SRID(bool async)
    {
        await base.SRID(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SRID_geometry(bool async)
    {
        await base.SRID_geometry(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task StartPoint(bool async)
    {
        await base.StartPoint(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SymmetricDifference(bool async)
    {
        await base.SymmetricDifference(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToBinary(bool async)
    {
        await base.ToBinary(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToText(bool async)
    {
        await base.ToText(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Touches(bool async)
    {
        await base.Touches(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union(bool async)
    {
        await base.Union(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_aggregate(bool async)
    {
        await base.Union_aggregate(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_void(bool async)
    {
        await base.Union_void(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Within(bool async)
    {
        await base.Within(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task X(bool async)
    {
        await base.X(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Y(bool async)
    {
        await base.Y(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Z(bool async)
    {
        await base.Z(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task XY_with_collection_join(bool async)
    {
        await base.XY_with_collection_join(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task IsEmpty_equal_to_null(bool async)
    {
        await base.IsEmpty_equal_to_null(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task IsEmpty_not_equal_to_null(bool async)
    {
        await base.IsEmpty_not_equal_to_null(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Intersects_equal_to_null(bool async)
    {
        await base.Intersects_equal_to_null(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Intersects_not_equal_to_null(bool async)
    {
        await base.Intersects_not_equal_to_null(async);
    }
}
