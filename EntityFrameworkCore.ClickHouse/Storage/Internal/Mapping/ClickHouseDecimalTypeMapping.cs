using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping
{
    public class ClickHouseDecimalTypeMapping : DecimalTypeMapping
    {
        private const byte DefaultPrecision = 32;
        private const byte DefaultScale = 9;

        public ClickHouseDecimalTypeMapping(int? precision, int? scale, int? size) : 
            base(
                new RelationalTypeMappingParameters(
                    new CoreTypeMappingParameters(typeof(decimal)),
                    GetStoreType(precision, scale), 
                    StoreTypePostfix.None, 
                    System.Data.DbType.Decimal,
                    false,
                    size))
        {
        }

        private static string GetStoreType(int? precision, int? scale) => $"Decimal({precision ?? DefaultPrecision}, {scale ?? DefaultScale})";

        protected override void ConfigureParameter(DbParameter parameter)
        {
            var clickHouseParameter = (Client.ADO.Parameters.ClickHouseDbParameter)parameter;
            clickHouseParameter.Precision = (byte)(Precision ?? DefaultPrecision);
            clickHouseParameter.Scale = (byte)(Scale ?? DefaultScale);

            if (clickHouseParameter.Value is DBNull)
            {
                clickHouseParameter.ClickHouseType = $"Nullable({StoreType})";
            }
            else
            {
                clickHouseParameter.ClickHouseType = StoreType;
            }
        }
    }
}
