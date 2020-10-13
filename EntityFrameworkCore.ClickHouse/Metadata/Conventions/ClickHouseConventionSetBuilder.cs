using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace ClickHouse.EntityFrameworkCore.Metadata.Conventions
{
    public class ClickHouseConventionSetBuilder : RelationalConventionSetBuilder
    {
        public ClickHouseConventionSetBuilder(ProviderConventionSetBuilderDependencies dependencies, RelationalConventionSetBuilderDependencies relationalDependencies)
            : base(dependencies, relationalDependencies)
        {
        }
    }
}
