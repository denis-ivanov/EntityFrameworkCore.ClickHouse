using ClickHouse.Client.Numerics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation
{
    public class ClickHouseDecimalValueConverter : ValueConverter<decimal, ClickHouseDecimal>
    {
        public ClickHouseDecimalValueConverter(ConverterMappingHints mappingHints = null)
            : base(
                value => new ClickHouseDecimal(value),
                value => (decimal)value, mappingHints)
        {
        }
    }
}
