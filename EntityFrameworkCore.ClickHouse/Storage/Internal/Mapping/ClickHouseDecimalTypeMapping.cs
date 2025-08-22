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
    private const byte DefaultPrecision = 36;
    private const byte DefaultScale = 24;

    public ClickHouseDecimalTypeMapping(int? precision, int? scale, int? size) :
        base(
            new RelationalTypeMappingParameters(
                new CoreTypeMappingParameters(typeof(decimal), new ClickHouseDecimalValueConverter()),
                GetStoreType(precision ?? DefaultPrecision, scale ?? DefaultScale),
                StoreTypePostfix.None,
                System.Data.DbType.Decimal,
                false,
                size))
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
        var clickHouseParameter = (Driver.ADO.Parameters.ClickHouseDbParameter)parameter;
        clickHouseParameter.Precision = (byte)(Precision ?? DefaultPrecision);
        clickHouseParameter.Scale = (byte)(Scale ?? DefaultScale);
        parameter.SetStoreType(StoreType);
    }

    private static string GetStoreType(int precision, int scale) => $"Decimal({precision}, {scale})";
    
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
}
