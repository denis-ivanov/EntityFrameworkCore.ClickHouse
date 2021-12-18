using ClickHouse.EntityFrameworkCore.Storage.ValueConversation;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping
{
    public class ClickHouseBoolTypeMapping : BoolTypeMapping
    {
        public ClickHouseBoolTypeMapping() : base(
            new RelationalTypeMappingParameters(
                new CoreTypeMappingParameters(typeof(bool), new ClickHouseBoolValueConverter()),
                "UInt8", 
                StoreTypePostfix.None,
                System.Data.DbType.Byte))
        {
        }

        public override MethodInfo GetDataReaderMethod()
        {
            return typeof(DbDataReader).GetRuntimeMethod(nameof(DbDataReader.GetByte), new[] { typeof(int) });
        }

        protected override string GenerateNonNullSqlLiteral(object value)
        {
            return Convert.ToString(Convert.ToByte(value));
        }
    }
}
