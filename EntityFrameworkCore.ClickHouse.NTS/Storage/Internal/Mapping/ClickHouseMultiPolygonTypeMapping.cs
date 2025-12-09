using ClickHouse.EntityFrameworkCore.Extensions;
using EntityFrameworkCore.ClickHouse.NTS.Storage.Json;
using EntityFrameworkCore.ClickHouse.NTS.Storage.ValueConversion.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System.Data.Common;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.Internal.Mapping;

public class ClickHouseMultiPolygonTypeMapping : RelationalGeometryTypeMapping<MultiPolygon, byte[]>
{
    public ClickHouseMultiPolygonTypeMapping()
        : base(new ClickHouseMultiPolygonValueConverter(), Geometry.TypeNameMultiPolygon, ClickHouseJsonGeometryWktReaderWriter.Instance)
    {
    }

    protected ClickHouseMultiPolygonTypeMapping(RelationalTypeMappingParameters parameters, ValueConverter<MultiPolygon, byte[]>? converter) : base(parameters, converter)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseMultiPolygonTypeMapping(parameters, SpatialConverter);
    }

    protected override string AsText(object value)
    {
        return ((MultiPolygon)value).AsText();
    }

    protected override int GetSrid(object value)
    {
        return ((MultiPolygon)value).SRID;
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        base.ConfigureParameter(parameter);
        parameter.SetStoreType(StoreType);
    }

    protected override Type WktReaderType => typeof(WKTReader);
}
