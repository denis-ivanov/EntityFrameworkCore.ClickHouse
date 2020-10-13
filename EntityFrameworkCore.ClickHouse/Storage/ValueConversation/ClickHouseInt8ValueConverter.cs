using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation
{
    public class ClickHouseInt8ValueConverter : ValueConverter<sbyte, short>
    {
        public ClickHouseInt8ValueConverter() : base(e => (short)e, e => (sbyte)e)
        {
        }
    }
}
