using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ClickHouse.EntityFrameworkCore.Metadata.Conventions;

public class ClickHouseJsonStorageConvention : IModelFinalizingConvention
{
    public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
    {
        foreach (IConventionEntityType entityType in modelBuilder.Metadata.GetEntityTypes())
        {
            if (entityType.IsMappedToJson())
            {
                if (entityType.FindOwnership() is IConventionForeignKey ownership && !ownership.PrincipalEntityType.IsMappedToJson() && (!ownership.IsUnique || !ownership.IsRequiredDependent))
                {
                    ConfigureJsonTextStorage(entityType);
                }
            }
            else
            {
                ProcessComplexProperties(entityType);
            }
        }
    }

    private static void ProcessComplexProperties(IConventionTypeBase typeBase)
    {
        foreach (IConventionComplexProperty property in typeBase.GetDeclaredComplexProperties())
        {
            IConventionComplexType complexType = property.ComplexType;

            if (!complexType.IsMappedToJson())
            {
                ProcessComplexProperties(complexType);
            }
            else if (property.IsCollection || property.IsNullable)
            {
                ConfigureJsonTextStorage(complexType);
            }
        }
    }

    private static void ConfigureJsonTextStorage(IConventionTypeBase typeBase)
    {
        // Text storage supports root arrays and preserves SQL NULL for optional JSON columns.
        if (typeBase.GetContainerColumnType() == null)
        {
            typeBase.SetContainerColumnType("String");
        }
    }
}
