using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation
{
    public class ClickHouseUInt32ValueConverter : ValueConverter<uint, decimal>
    {
        public ClickHouseUInt32ValueConverter() : base(e => (decimal)e, e => (uint)e)
        {
        }
    }
}
