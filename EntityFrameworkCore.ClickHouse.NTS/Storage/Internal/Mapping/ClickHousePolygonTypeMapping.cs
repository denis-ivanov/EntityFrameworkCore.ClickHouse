using ClickHouse.Driver.ADO.Parameters;
using ClickHouse.EntityFrameworkCore.Extensions;
using EntityFrameworkCore.ClickHouse.NTS.Storage.Json;
using EntityFrameworkCore.ClickHouse.NTS.Storage.ValueConversion.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System.Data.Common;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.Internal.Mapping;

public class ClickHousePolygonTypeMapping : RelationalGeometryTypeMapping<Polygon, byte[]>
{
    public ClickHousePolygonTypeMapping()
        : base(new ClickHousePolygonValueConverter(), Geometry.TypeNamePolygon, ClickHouseJsonGeometryWktReaderWriter.Instance)
    {
    }

    protected ClickHousePolygonTypeMapping(RelationalTypeMappingParameters parameters, ValueConverter<Polygon, byte[]>? converter) : base(parameters, converter)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHousePolygonTypeMapping(parameters, SpatialConverter);
    }

    protected override string AsText(object value)
    {
        return ((Polygon)value).AsText();
    }

    protected override int GetSrid(object value)
    {
        return ((Polygon)value).SRID;
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        base.ConfigureParameter(parameter);
        parameter.SetStoreType(StoreType);
    }

    protected override Type WktReaderType => typeof(WKTReader);
}
