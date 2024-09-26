using ClickHouse.Driver.ADO.Parameters;
using EntityFrameworkCore.ClickHouse.NTS.Storage.Json;
using EntityFrameworkCore.ClickHouse.NTS.Storage.ValueConversion.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System.Data.Common;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.Internal.Mapping;

public class ClickHousePointTypeMapping : RelationalGeometryTypeMapping<Point, Tuple<double, double>>
{
    public ClickHousePointTypeMapping()
        : base(new ClickHousePointValueConverter(), "Point", ClickHouseJsonGeometryWktReaderWriter.Instance)
    {
    }

    protected ClickHousePointTypeMapping(RelationalTypeMappingParameters parameters, ValueConverter<Point, Tuple<double, double>>? converter)
        : base(parameters, converter)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHousePointTypeMapping(parameters, SpatialConverter);
    }

    protected override string AsText(object value)
        => ((Geometry)value).AsText();

    protected override int GetSrid(object value)
        => ((Geometry)value).SRID;

    protected override Type WktReaderType
        => typeof(WKTReader);

    protected override void ConfigureParameter(DbParameter parameter)
    {
        if (parameter is ClickHouseDbParameter p)
        {
            p.ClickHouseType = StoreType;
        }
    }
}
