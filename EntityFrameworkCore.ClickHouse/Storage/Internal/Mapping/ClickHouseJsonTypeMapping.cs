using Microsoft.EntityFrameworkCore.Storage;
using System.Text.Json;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseJsonTypeMapping : JsonTypeMapping
{
    public ClickHouseJsonTypeMapping()
        : base("Json", typeof(JsonElement), System.Data.DbType.String)
    {
    }

    protected ClickHouseJsonTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseJsonTypeMapping(parameters);
    }
}