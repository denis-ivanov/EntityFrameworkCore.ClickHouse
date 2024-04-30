using ClickHouse.EntityFrameworkCore.Metadata;
using ClickHouse.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ClickHouse.EntityFrameworkCore.Extensions;

public static class ClickHouseTableOperationExtensions
{
    public static ClickHouseEngineBuilder GetEngineBuilder(this TableOperation operation)
    {
        var engine = operation.FindAnnotation(ClickHouseAnnotationNames.TableEngine);

        return (string)engine?.Value switch
        {
            ClickHouseAnnotationNames.MergeTreeEngine => new ClickMergeTreeEngineBuilder(operation),
            ClickHouseAnnotationNames.StripeLogEngine => new ClickStripeLogEngineBuilder(operation),
            _ => new ClickStripeLogEngineBuilder(operation)
        };
    }
}
