using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping
{
    public class ClickHouseFloat64TypeMapping : DoubleTypeMapping
    {
        public ClickHouseFloat64TypeMapping() : base("Float64", System.Data.DbType.Double)
        {
        }

        protected ClickHouseFloat64TypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
        {
        }

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        {
            return new ClickHouseFloat64TypeMapping(parameters);
        }

        protected override void ConfigureParameter(DbParameter parameter)
        {
            parameter.SetStoreType(StoreType);
        }
    }
}
