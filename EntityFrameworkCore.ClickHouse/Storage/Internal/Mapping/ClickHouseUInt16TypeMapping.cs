using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping
{
    public class ClickHouseUInt16TypeMapping : UShortTypeMapping
    {
        public ClickHouseUInt16TypeMapping() : base("UInt16", System.Data.DbType.UInt16)
        {
        }

        protected ClickHouseUInt16TypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
        {
        }

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        {
            return new ClickHouseUInt16TypeMapping(parameters);
        }

        protected override void ConfigureParameter(DbParameter parameter)
        {
            parameter.SetStoreType(StoreType);
        }
    }
}
