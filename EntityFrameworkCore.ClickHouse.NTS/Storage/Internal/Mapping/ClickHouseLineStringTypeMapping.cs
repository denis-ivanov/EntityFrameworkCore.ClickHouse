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

public class ClickHouseLineStringTypeMapping : RelationalGeometryTypeMapping<LineString, Tuple<double, double>[]>
{
    public ClickHouseLineStringTypeMapping()
        : base(
            ClickHouseLineStringValueConverter.Instance,
            Geometry.TypeNameLineString,
            ClickHouseJsonGeometryWktReaderWriter.Instance)
    {
    }

    protected ClickHouseLineStringTypeMapping(RelationalTypeMappingParameters parameters, ValueConverter<LineString, Tuple<double, double>[]>? converter)
        : base(parameters, converter)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseLineStringTypeMapping(
            parameters,
            (ValueConverter<LineString, Tuple<double, double>[]>)Converter!);
    }

    protected override string AsText(object value)
    {
        return ((LineString)value).AsText();
    }

    protected override int GetSrid(object value)
    {
        return ((LineString)value).SRID;
    }

    protected override Type WktReaderType => typeof(WKTReader);

    protected override void ConfigureParameter(DbParameter parameter)
    {
        base.ConfigureParameter(parameter);
        parameter.SetStoreType(StoreType);
    }
}
