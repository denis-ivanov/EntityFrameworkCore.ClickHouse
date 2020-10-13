using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation
{
    public class ClickHouseUInt16ValueConverter : ValueConverter<ushort, int>
    {
        public ClickHouseUInt16ValueConverter() : base(e => (int)e, e => (ushort)e)
        {
        }
    }
}
