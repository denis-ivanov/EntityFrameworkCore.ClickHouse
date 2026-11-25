using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace ClickHouse.EntityFrameworkCore.Metadata.Conventions;

public class ClickHouseConventionSetBuilder : RelationalConventionSetBuilder
{
    public ClickHouseConventionSetBuilder(ProviderConventionSetBuilderDependencies dependencies, RelationalConventionSetBuilderDependencies relationalDependencies)
        : base(dependencies, relationalDependencies)
    {
    }

    public override ConventionSet CreateConventionSet()
    {
        var conventionSet = base.CreateConventionSet();
        conventionSet.Remove(typeof(ForeignKeyIndexConvention));
#if NET11_0_OR_GREATER
        conventionSet.ModelFinalizingConventions.Add(new ClickHouseForeignKeyConvention());
#else
        // EF Core 10 lacks a convention API to exclude foreign keys from migration DDL.
        conventionSet.ForeignKeyAddedConventions.Clear();
        conventionSet.ForeignKeyAnnotationChangedConventions.Clear();
        conventionSet.ForeignKeyDependentRequirednessChangedConventions.Clear();
        conventionSet.ForeignKeyOwnershipChangedConventions.Clear();
        conventionSet.ForeignKeyPrincipalEndChangedConventions.Clear();
        conventionSet.ForeignKeyPropertiesChangedConventions.Clear();
        conventionSet.ForeignKeyRemovedConventions.Clear();
        conventionSet.ForeignKeyRequirednessChangedConventions.Clear();
        conventionSet.ForeignKeyUniquenessChangedConventions.Clear();
        conventionSet.SkipNavigationForeignKeyChangedConventions.Clear();
        conventionSet.ModelFinalizingConventions.Add(new ClickHouseJsonOwnershipConvention());
#endif
        conventionSet.Replace<RuntimeModelConvention>(new ClickHouseRuntimeModelConvention(Dependencies, RelationalDependencies));

        return conventionSet;
    }

#if NET11_0_OR_GREATER
    private sealed class ClickHouseForeignKeyConvention : IModelFinalizingConvention
    {
        public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
        {
            foreach (var entityType in modelBuilder.Metadata.GetEntityTypes())
            {
                foreach (var foreignKey in entityType.GetDeclaredForeignKeys())
                {
                    foreignKey.Builder.ExcludeForeignKeyFromMigrations(true);
                }
            }
        }
    }
#else
    private sealed class ClickHouseJsonOwnershipConvention : IModelFinalizingConvention
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
}
