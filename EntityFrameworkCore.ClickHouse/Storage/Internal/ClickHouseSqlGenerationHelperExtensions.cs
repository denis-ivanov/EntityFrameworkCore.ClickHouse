using Microsoft.EntityFrameworkCore.Storage;
using System.Text;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal
{
    internal static class ClickHouseSqlGenerationHelperExtensions
    {
        internal static void GenerateParameterNamePlaceholder(
            this ISqlGenerationHelper helper,
            StringBuilder stringBuilder,
            string name,
            string type)
        {
            ((ClickHouseSqlGenerationHelper)helper).GenerateParameterNamePlaceholder(stringBuilder, name, type);
        }
    }
}
