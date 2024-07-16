using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseTupleTypeMapping : RelationalTypeMapping
{
    private readonly IRelationalTypeMappingSource _typeMappingSource;

    public ClickHouseTupleTypeMapping(string storeType, Type clrType, IRelationalTypeMappingSource typeMappingSource)
        : base(storeType, clrType, System.Data.DbType.Object)
    {
        _typeMappingSource = typeMappingSource;
    }

    protected override string SqlLiteralFormatString => "tuple{0}";

    protected ClickHouseTupleTypeMapping(RelationalTypeMappingParameters parameters, IRelationalTypeMappingSource typeMappingSource)
        : base(parameters)
    {
        _typeMappingSource = typeMappingSource;
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseTupleTypeMapping(parameters, _typeMappingSource);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        parameter.SetStoreType(StoreType);
    }

    public override string GenerateSqlLiteral(object value)
    {
        var tuple = (ITuple)value;
        var argsType = ClrType.GetGenericArguments();

        var sb = new StringBuilder("tuple(");

        var args = argsType.Select((e, i) => _typeMappingSource.FindMapping(e)!.GenerateSqlLiteral(tuple[i]!));
        sb.AppendJoin(", ", args).Append(')');

        return sb.ToString();
    }
}
