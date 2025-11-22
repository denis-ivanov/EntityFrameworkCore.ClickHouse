using ClickHouse.Driver.ADO.Parameters;
using EntityFrameworkCore.ClickHouse.NTS.Storage.Json;
using EntityFrameworkCore.ClickHouse.NTS.Storage.ValueConversion.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using System.Data.Common;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.Internal.Mapping;

public class ClickHousePolygonTypeMapping : RelationalGeometryTypeMapping<Polygon, byte[]>
{
    public ClickHousePolygonTypeMapping()
        : base(new ClickHousePolygonValueConverter(), "Polygon", ClickHouseJsonGeometryWktReaderWriter.Instance)
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
        throw new NotImplementedException();
    }

    protected override int GetSrid(object value)
    {
        throw new NotImplementedException();
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        if (parameter is ClickHouseDbParameter p)
        {
            p.ClickHouseType = StoreType;
        }
    }

    protected override Type WktReaderType { get; }
}
