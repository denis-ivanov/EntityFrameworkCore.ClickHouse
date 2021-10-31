using Microsoft.EntityFrameworkCore.Storage;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal
{
    internal static class ClickHouseSqlGenerationHelperExtensions
    {
        internal static string GenerateParameterNamePlaceholder(
            this ISqlGenerationHelper helper,
            string name,
            string type)
        {
            return ((ClickHouseSqlGenerationHelper)helper).GenerateParameterNamePlaceholder(name, type);
        }
    }
}
