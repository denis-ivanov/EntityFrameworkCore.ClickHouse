using ClickHouse.Driver.ADO.Parameters;
using ClickHouse.EntityFrameworkCore.Extensions;
using EntityFrameworkCore.ClickHouse.NTS.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System.Data.Common;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.Internal.Mapping;

public class ClickHouseRingTypeMapping : RelationalGeometryTypeMapping<MultiPoint, byte[]>
{
    public ClickHouseRingTypeMapping()
        : base(null, "Ring", ClickHouseJsonGeometryWktReaderWriter.Instance)
    {
    }

    protected ClickHouseRingTypeMapping(RelationalTypeMappingParameters parameters, ValueConverter<MultiPoint, byte[]>? converter) : base(parameters, converter)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseRingTypeMapping(parameters, SpatialConverter);
    }

    protected override string AsText(object value)
    {
        return ((MultiPoint)value).AsText();
    }

    protected override int GetSrid(object value)
    {
        return ((MultiPoint)value).SRID;
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        base.ConfigureParameter(parameter);
        parameter.SetStoreType(StoreType);
    }

    protected override Type WktReaderType => typeof(WKTReader);
}
