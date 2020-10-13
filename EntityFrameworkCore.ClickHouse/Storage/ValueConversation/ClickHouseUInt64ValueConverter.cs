using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation
{
    public class ClickHouseUInt64ValueConverter : ValueConverter<ulong, decimal>
    {
        public ClickHouseUInt64ValueConverter() : base(e => (decimal)e, e => (ulong)e)
        {
        }
    }
}
