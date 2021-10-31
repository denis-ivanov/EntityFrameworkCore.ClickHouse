using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System.Collections.Generic;

namespace ClickHouse.EntityFrameworkCore.Metadata.Conventions
{
    public class ClickHouseConventionSetBuilder : RelationalConventionSetBuilder
    {
        public ClickHouseConventionSetBuilder(ProviderConventionSetBuilderDependencies dependencies, RelationalConventionSetBuilderDependencies relationalDependencies)
            : base(dependencies, relationalDependencies)
        {
        }

        public override ConventionSet CreateConventionSet()
        {
            var convensionSet =  base.CreateConventionSet();
            RemoveForeignKeyIndexConvension(convensionSet.EntityTypeBaseTypeChangedConventions);
            convensionSet.ForeignKeyAddedConventions.Clear();
            convensionSet.ForeignKeyAnnotationChangedConventions.Clear();
            convensionSet.ForeignKeyDependentRequirednessChangedConventions.Clear();
            convensionSet.ForeignKeyOwnershipChangedConventions.Clear();
            convensionSet.ForeignKeyPrincipalEndChangedConventions.Clear();
            convensionSet.ForeignKeyPropertiesChangedConventions.Clear();
            convensionSet.ForeignKeyRemovedConventions.Clear();
            convensionSet.ForeignKeyRequirednessChangedConventions.Clear();
            convensionSet.ForeignKeyUniquenessChangedConventions.Clear();
            convensionSet.SkipNavigationForeignKeyChangedConventions.Clear();
            return convensionSet;
        }

        private void RemoveForeignKeyIndexConvension(IList<IEntityTypeBaseTypeChangedConvention> convensions)
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
}
