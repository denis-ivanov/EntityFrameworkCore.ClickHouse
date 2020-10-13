using Microsoft.EntityFrameworkCore.Storage;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal
{
    public class ClickHouseSqlGenerationHelper : RelationalSqlGenerationHelper
    {
        public ClickHouseSqlGenerationHelper(RelationalSqlGenerationHelperDependencies dependencies)
            : base(dependencies)
        {
        }
    }
}
