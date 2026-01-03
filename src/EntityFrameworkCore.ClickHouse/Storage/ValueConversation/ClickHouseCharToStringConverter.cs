using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation;

public class ClickHouseCharToStringConverter : ValueConverter<char?, string>
{
    public ClickHouseCharToStringConverter(ConverterMappingHints mappingHints = null)
        : base(
            c => c == null ? null : c.ToString(),
            s => string.IsNullOrEmpty(s) ? null : s[0],
            mappingHints)
    {
    }
}
