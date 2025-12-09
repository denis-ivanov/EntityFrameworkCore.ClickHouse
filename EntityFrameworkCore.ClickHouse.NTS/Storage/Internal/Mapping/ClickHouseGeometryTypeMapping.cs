using ClickHouse.EntityFrameworkCore.Extensions;
using EntityFrameworkCore.ClickHouse.NTS.Storage.Json;
using EntityFrameworkCore.ClickHouse.NTS.Storage.ValueConversion.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System.Data.Common;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.Internal.Mapping;

public class ClickHouseGeometryTypeMapping : RelationalGeometryTypeMapping<Geometry, object>
{
    public ClickHouseGeometryTypeMapping()
        : base(ClickHouseGeometryValueConverter.Instance, "Geometry", ClickHouseJsonGeometryWktReaderWriter.Instance)
    {
    }

    protected ClickHouseGeometryTypeMapping(RelationalTypeMappingParameters parameters, ValueConverter<Geometry, object>? converter)
        : base(parameters, converter)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseGeometryTypeMapping(parameters, (ValueConverter<Geometry, object>)base.Converter!);
    }

    protected override string AsText(object value)
    {
        return ((Geometry)value).AsText();
    }

    protected override int GetSrid(object value)
    {
        return ((Geometry)value).SRID;
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        base.ConfigureParameter(parameter);
        parameter.SetStoreType(StoreType);
        parameter.
    }

    protected override Type WktReaderType => typeof(WKTReader);
}
