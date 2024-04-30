using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System.Collections.Generic;

namespace ClickHouse.EntityFrameworkCore.Metadata.Conventions;

public class ClickHouseConventionSetBuilder : RelationalConventionSetBuilder
{
    public ClickHouseConventionSetBuilder(ProviderConventionSetBuilderDependencies dependencies, RelationalConventionSetBuilderDependencies relationalDependencies)
        : base(dependencies, relationalDependencies)
    {
    }

    public override ConventionSet CreateConventionSet()
    {
        var conventionSet =  base.CreateConventionSet();
        RemoveForeignKeyIndexConvention(conventionSet.EntityTypeBaseTypeChangedConventions);
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
        conventionSet.Replace<RuntimeModelConvention>(new ClickHouseRuntimeModelConvention(Dependencies, RelationalDependencies));

        return conventionSet;
    }

    private void RemoveForeignKeyIndexConvention(IList<IEntityTypeBaseTypeChangedConvention> convensions)
    {
        for (var i = convensions.Count - 1; i > -1; i--)
        {
            if (convensions[i] is ForeignKeyIndexConvention)
            {
                convensions.RemoveAt(i);
            }
        }
    }
}
