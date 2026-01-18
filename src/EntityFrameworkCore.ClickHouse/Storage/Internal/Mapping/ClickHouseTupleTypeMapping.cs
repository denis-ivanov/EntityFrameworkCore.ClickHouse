using ClickHouse.Driver.ADO.Parameters;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseTupleTypeMapping : RelationalTypeMapping
{
    public ClickHouseTupleTypeMapping(Type clrType, IReadOnlyList<RelationalTypeMapping> elementsMappings)
        : base("Tuple", clrType, System.Data.DbType.Object)
    {
        ElementsMappings = elementsMappings;
    }

    protected ClickHouseTupleTypeMapping(
        RelationalTypeMappingParameters parameters,
        IReadOnlyList<RelationalTypeMapping> elementsMappings)
        : base(parameters)
    {
        ElementsMappings = elementsMappings;
    }

    protected override string SqlLiteralFormatString => "tuple{0}";

    protected IReadOnlyList<RelationalTypeMapping> ElementsMappings { get; set; }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseTupleTypeMapping(parameters, ElementsMappings);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        ((ClickHouseDbParameter)parameter).ClickHouseType = GetStoreType(parameter.Value);
    }

    protected override string GenerateNonNullSqlLiteral(object value)
    {
        var tuple = (ITuple)value;

        var sb = new StringBuilder("tuple(");

        for (var i = 0; i < ElementsMappings.Count; i++)
        {
            var elementValue = tuple[i];
            var elementMapping = ElementsMappings[i];
            sb.Append(elementMapping.GenerateSqlLiteral(elementValue));

            if (i < ElementsMappings.Count - 1)
            {
                sb.Append(", ");
            }
        }

        sb.Append(')');

        return sb.ToString();
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
