#if !NET11_0_OR_GREATER
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ClickHouse.EntityFrameworkCore.Metadata.Conventions;

public class ClickHouseJsonOwnershipConvention : IModelFinalizingConvention
{
    public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
    {
        foreach (var entityType in modelBuilder.Metadata.GetEntityTypes())
        {
            if (entityType.IsMappedToJson())
            {
                entityType.FindOwnership()?.PrincipalToDependent?.Builder.AutoInclude(true);
            }
        }
    }
}
#endif
