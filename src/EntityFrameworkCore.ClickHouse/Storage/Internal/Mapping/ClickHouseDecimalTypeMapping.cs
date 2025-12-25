using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Storage.ValueConversation;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseDecimalTypeMapping : DecimalTypeMapping
{
    private const byte DefaultPrecision = 38;
    private const byte DefaultScale = 19;

    public ClickHouseDecimalTypeMapping(int? precision, int? scale) :
        base(
            new RelationalTypeMappingParameters(
                new CoreTypeMappingParameters(typeof(decimal), new ClickHouseDecimalValueConverter()),
                "Decimal",
                StoreTypePostfix.PrecisionAndScale,
                System.Data.DbType.Decimal,
                precision: precision ?? DefaultPrecision,
                scale: scale ?? DefaultScale))
    {
    }

    protected ClickHouseDecimalTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseDecimalTypeMapping(parameters);
    }

    protected override void ConfigureParameter(DbParameter parameter)
    {
        parameter.Precision = (byte)(Precision ?? DefaultPrecision);
        parameter.Scale = (byte)(Scale ?? DefaultScale);
        parameter.SetStoreType(StoreType);
    }

    public override MethodInfo GetDataReaderMethod()
    {
        return typeof(DbDataReader).GetRuntimeMethod(nameof(DbDataReader.GetValue), [typeof(int)])!;
    }

    public override Expression CustomizeDataReaderExpression(Expression expression)
    {
        return Expression.Call(
            typeof(Convert).GetMethod(nameof(Convert.ToDecimal), [typeof(object)])!,
            expression
        );
    }

    protected override string GenerateNonNullSqlLiteral(object value)
    {
        return base.GenerateNonNullSqlLiteral(value) + "::" + StoreType;
    }
}
