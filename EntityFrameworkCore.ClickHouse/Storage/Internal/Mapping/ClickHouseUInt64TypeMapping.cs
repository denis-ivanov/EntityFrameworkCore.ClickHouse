using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping
{
    public class ClickHouseUInt64TypeMapping : ULongTypeMapping
    {
        public ClickHouseUInt64TypeMapping() : base("UInt64", System.Data.DbType.UInt64)
        {
        }

        protected ClickHouseUInt64TypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
        {
        }

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        {
            return new ClickHouseUInt64TypeMapping(parameters);
        }

        protected override void ConfigureParameter(DbParameter parameter)
        {
            parameter.SetStoreType(StoreType);
        }
    }
}
