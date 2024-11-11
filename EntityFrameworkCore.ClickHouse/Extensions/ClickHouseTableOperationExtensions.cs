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
            ClickHouseAnnotationNames.MergeTreeEngine => new ClickHouseMergeTreeEngineBuilder(operation),
            ClickHouseAnnotationNames.ReplacingMergeTree => new ClickHouseReplacingMergeTreeEngineBuilder(operation),
            ClickHouseAnnotationNames.SummingMergeTree => new ClickHouseSummingMergeTreeEngineBuilder(operation),
            ClickHouseAnnotationNames.AggregatingMergeTree => new ClickHouseAggregatingMergeTreeEngineBuilder(operation),
            ClickHouseAnnotationNames.CollapsingMergeTree => new ClickHouseCollapsingMergeTreeEngineBuilder(operation),
            ClickHouseAnnotationNames.VersionedCollapsingMergeTree => new ClickHouseVersionedCollapsingMergeTreeEngineBuilder(operation),
            ClickHouseAnnotationNames.GraphiteMergeTree => new ClickHouseGraphiteMergeTreeEngineBuilder(operation),
            ClickHouseAnnotationNames.TinyLogEngine => new ClickHouseTinyLogEngineBuilder(operation),
            ClickHouseAnnotationNames.StripeLogEngine => new ClickHouseStripeLogEngineBuilder(operation),
            ClickHouseAnnotationNames.LogEngine => new ClickHouseLogEngineBuilder(operation),
            _ => new ClickHouseStripeLogEngineBuilder(operation)
        };
    }
}
