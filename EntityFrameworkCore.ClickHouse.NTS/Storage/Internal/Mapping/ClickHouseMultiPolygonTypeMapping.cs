using ClickHouse.Driver.ADO.Parameters;
using EntityFrameworkCore.ClickHouse.NTS.Storage.Json;
using EntityFrameworkCore.ClickHouse.NTS.Storage.ValueConversion.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using System.Data.Common;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.Internal.Mapping;

public class ClickHouseMultiPolygonTypeMapping : RelationalGeometryTypeMapping<MultiPolygon, byte[]>
{
    public ClickHouseMultiPolygonTypeMapping()
        : base(new ClickHouseMultiPolygonValueConverter(), "MultiPolygon", ClickHouseJsonGeometryWktReaderWriter.Instance)
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
