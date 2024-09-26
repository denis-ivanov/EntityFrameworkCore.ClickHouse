using ClickHouse.Driver.ADO.Parameters;
using EntityFrameworkCore.ClickHouse.NTS.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
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
