using ClickHouse.Driver.ADO.Parameters;
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
        ((ClickHouseDbParameter)parameter).ClickHouseType = GetStoreType(parameter.Value);
    }

    public override string GenerateSqlLiteral(object? value)
    {
        var dateTime = (DateTime)value!;
        var format = Format;

        if (Precision is > 0 and <= 7)
        {
            format = format + '.' + new string('s', Precision.Value);
        }

        return $"'{dateTime.ToString(format)}'";
    }
    
    protected virtual string GetStoreType(bool? isNullable)
    {
        return isNullable == true ? $"Nullable({StoreType})" : StoreType;
    }
    
    protected virtual string GetStoreType(object? parameterValue)
    {
        return GetStoreType(parameterValue == null || parameterValue == DBNull.Value);
    }
}
