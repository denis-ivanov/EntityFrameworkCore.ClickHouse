using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseStringTypeMapping : StringTypeMapping
{
    public ClickHouseStringTypeMapping()
        : base("String", System.Data.DbType.String, true, null)
    {
    }

    protected ClickHouseStringTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseStringTypeMapping(parameters);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        parameter.SetStoreType(StoreType);
    }
}
