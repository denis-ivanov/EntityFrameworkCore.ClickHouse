using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;

internal sealed class ClickHouseMutationFixtureConvention : IConventionSetPlugin, IModelFinalizingConvention
{
    public ConventionSet ModifyConventions(ConventionSet conventionSet)
    {
        conventionSet.ModelFinalizingConventions.Add(this);

        return conventionSet;
    }

    public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
    {
        foreach (IConventionEntityType entity in modelBuilder.Metadata.GetEntityTypes())
        {
            if (entity.GetTableName() != null && entity.FindOwnership() == null)
            {
                ((IMutableEntityType)entity).SetMergeTreeTableEngine().SetOrderBy(["tuple()"]);
            }
        }
    }
}
