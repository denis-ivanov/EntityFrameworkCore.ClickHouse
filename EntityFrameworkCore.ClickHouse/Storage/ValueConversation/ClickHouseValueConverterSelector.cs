using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation
{
    public class ClickHouseValueConverterSelector : ValueConverterSelector
    {
        public ClickHouseValueConverterSelector(ValueConverterSelectorDependencies dependencies)
            : base(dependencies)
        {
            
        }
    }
}