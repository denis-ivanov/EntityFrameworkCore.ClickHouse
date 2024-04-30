using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseDateTimeTypeMapping : DateTimeTypeMapping
{
    private const string Format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";

    public ClickHouseDateTimeTypeMapping() : base("DateTime", System.Data.DbType.DateTime)
    {
    }

    protected ClickHouseDateTimeTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseDateTimeTypeMapping(parameters);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        parameter.SetStoreType(StoreType);
    }

    public override string GenerateSqlLiteral(object value)
    {
        var dateTime = (DateTime)value;
        var format = Format;

        if (Precision is > 0 and <= 7)
        {
            format = format + '.' + new string('s', Precision.Value);
        }

        return $"'{dateTime.ToString(format)}'";
    }
}
