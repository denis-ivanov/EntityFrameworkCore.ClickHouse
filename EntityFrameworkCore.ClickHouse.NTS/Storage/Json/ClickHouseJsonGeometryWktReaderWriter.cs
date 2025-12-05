using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;

using Microsoft.EntityFrameworkCore.Storage.Json;

using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace EntityFrameworkCore.ClickHouse.NTS.Storage.Json;

public class ClickHouseJsonGeometryWktReaderWriter : JsonValueReaderWriter<Geometry>
{
    private static readonly WKTReader WktReader = new();

    private static readonly PropertyInfo InstanceProperty = typeof(ClickHouseJsonGeometryWktReaderWriter).GetProperty(nameof(Instance))!;

    public static ClickHouseJsonGeometryWktReaderWriter Instance { get; } = new();

    public override Geometry FromJsonTyped(ref Utf8JsonReaderManager manager, object? existingObject = null)
        => WktReader.Read(manager.CurrentReader.GetString());

    public override void ToJsonTyped(Utf8JsonWriter writer, Geometry value)
        => writer.WriteStringValue(value.ToText());

    public override Expression ConstructorExpression => Expression.Property(null, InstanceProperty);
}