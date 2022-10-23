using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping
{
    public class ClickHouseUuidTypeMapping : GuidTypeMapping
    {
        public ClickHouseUuidTypeMapping() : base("UUID")
        {
        }

        protected ClickHouseUuidTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
        {
        }

        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
        {
            return new ClickHouseUuidTypeMapping(parameters);
        }

        protected override void ConfigureParameter(DbParameter parameter)
        {
            parameter.SetStoreType(StoreType);
        }
    }
}
