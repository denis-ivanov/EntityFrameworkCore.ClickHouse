using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping
{
    public class ClickHouseByteTypeMapping : ByteTypeMapping
    {
        public ClickHouseByteTypeMapping() : base("UInt8", System.Data.DbType.Byte)
        {
        }

        protected ClickHouseByteTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
        {
        }

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        {
            return new ClickHouseByteTypeMapping(parameters);
        }

        protected override void ConfigureParameter(DbParameter parameter)
        {
            parameter.SetStoreType(StoreType);
        }
    }
}
