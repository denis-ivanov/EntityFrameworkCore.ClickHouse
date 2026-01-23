using ClickHouse.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace ClickHouse.EntityFrameworkCore.Extensions;

public static partial class ClickHouseEntityTypeExtensions
{
    public static string? GetTableEngine(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var engine = table.FindAnnotation(ClickHouseAnnotationNames.TableEngine);

        return (string?)engine?.Value;
    }

    public static void SetTableEngine(this AnnotatableBase table, string engine)
    {
        ArgumentNullException.ThrowIfNull(table);
        ArgumentException.ThrowIfNullOrWhiteSpace(engine);

        table.SetAnnotation(ClickHouseAnnotationNames.TableEngine, engine);
    }

    public static IMutableAnnotatable SetOrderBy(this IMutableAnnotatable table, string[] columns)
    {
        ArgumentNullException.ThrowIfNull(table);
        ArgumentNullException.ThrowIfNull(columns);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.OrderBy, columns);

        return table;
    }

    public static IMutableAnnotatable SetPartitionBy(this IMutableAnnotatable table, string[] columns)
    {
        ArgumentNullException.ThrowIfNull(table);
        ArgumentNullException.ThrowIfNull(columns);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.PartitionBy, columns);

        return table;
    }

    public static IMutableAnnotatable SetPrimaryKey(this IMutableAnnotatable table, string[] columns)
    {
        ArgumentNullException.ThrowIfNull(table);
        ArgumentNullException.ThrowIfNull(columns);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.PrimaryKey, columns);

        return table;
    }

    public static IMutableAnnotatable SetSampleBy(this IMutableAnnotatable table, string[] columns)
    {
        ArgumentNullException.ThrowIfNull(table);
        ArgumentNullException.ThrowIfNull(columns);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.SampleBy, columns);

        return table;
    }

    public static string[]? GetOrderBy(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var annotation = table.FindAnnotation(ClickHouseAnnotationNames.OrderBy);

        return (string[]?)annotation?.Value;
    }

    public static string[]? GetPartitionBy(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var annotation = table.FindAnnotation(ClickHouseAnnotationNames.PartitionBy);

        return (string[]?)annotation?.Value;
    }

    public static string[]? GetPrimaryKey(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var annotation = table.FindAnnotation(ClickHouseAnnotationNames.PrimaryKey);

        return (string[]?)annotation?.Value;
    }

    public static string[]? GetSampleBy(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var annotation = table.FindAnnotation(ClickHouseAnnotationNames.SampleBy);

        return (string[]?)annotation?.Value;
    }

    #region MergeTreeEngine

    public static T SetMergeTreeTableEngine<T>(this T table) where T: AnnotatableBase
    {
        table.SetTableEngine(ClickHouseAnnotationNames.MergeTreeEngine);

        return table;
    }

    public static IMutableAnnotatable SetMergeTreeTableEngine(this IMutableEntityType table)
    {
        ArgumentNullException.ThrowIfNull(table);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.MergeTreeEngine);

        return table;
    }

    #endregion

    #region ReplacingMergeTree

    public static T SetReplacingMergeTreeTableEngine<T>(this T table) where T : AnnotatableBase
    {
        table.SetTableEngine(ClickHouseAnnotationNames.ReplacingMergeTree);

        return table;
    }

    public static T SetReplacingMergeTreeTableEngine<T>(this T table, string? version) where T : AnnotatableBase
    {
        table.SetTableEngine(ClickHouseAnnotationNames.ReplacingMergeTree);
        table.SetAnnotation(ClickHouseAnnotationNames.ReplacingMergeTreeVersion, version);

        return table;
    }

    public static T SetReplacingMergeTreeTableEngine<T>(this T table, string? version, string? isDeleted) where T : AnnotatableBase
    {
        table.SetTableEngine(ClickHouseAnnotationNames.ReplacingMergeTree);
        table.SetAnnotation(ClickHouseAnnotationNames.ReplacingMergeTreeVersion, version);
        table.SetAnnotation(ClickHouseAnnotationNames.ReplacingMergeTreeIsDeleted, isDeleted);
        
        return table;
    }

    public static IMutableAnnotatable SetReplacingMergeTreeTableEngine(this IMutableEntityType table, string? version, string? isDeleted)
    {
        ArgumentNullException.ThrowIfNull(table);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.ReplacingMergeTree);
        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.ReplacingMergeTreeVersion, version);
        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.ReplacingMergeTreeIsDeleted, isDeleted);

        return table;
    }

    public static void SetReplacingMergeTreeTableEngineVersion(this AnnotatableBase table, string version)
    {
        ArgumentNullException.ThrowIfNull(table);

        table.SetAnnotation(ClickHouseAnnotationNames.ReplacingMergeTreeVersion, version);
    }

    public static void SetReplacingMergeTreeTableEngineIsDeleted(this AnnotatableBase table, string isDeleted)
    {
        ArgumentNullException.ThrowIfNull(table);

        table.SetAnnotation(ClickHouseAnnotationNames.ReplacingMergeTreeIsDeleted, isDeleted);
    }

    public static string? GetReplacingMergeTreeVersion(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var version = table.FindAnnotation(ClickHouseAnnotationNames.ReplacingMergeTreeVersion);

        return (string?)version?.Value;
    }

    public static string? GetReplacingMergeTreeIsDeleted(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var version = table.FindAnnotation(ClickHouseAnnotationNames.ReplacingMergeTreeIsDeleted);

        return (string?)version?.Value;
    }

    #endregion

    #region SummingMergeTree

    public static T SetSummingMergeTreeTableEngine<T>(this T table, string[] columns) where T : AnnotatableBase
    {
        table.SetTableEngine(ClickHouseAnnotationNames.SummingMergeTree);

        if (columns is { Length: > 0 })
        {
            table.SetAnnotation(ClickHouseAnnotationNames.SummingMergeTreeColumns, columns);
        }

        return table;
    }
    
    public static IMutableAnnotatable SetSummingMergeTreeTableEngine(this IMutableEntityType table, string[] columns)
    {
        ArgumentNullException.ThrowIfNull(table);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.SummingMergeTree);

        if (columns is { Length: > 0 })
        {
            table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.SummingMergeTreeColumns, columns);
        }

        return table;
    }

    public static string[]? GetSummingMergeTreeColumns(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var columns = table.FindAnnotation(ClickHouseAnnotationNames.SummingMergeTreeColumns);

        return (string[]?)columns?.Value;
    }

    #endregion

    #region AggregatingMergeTree

    public static T SetAggregatingMergeTreeTableEngine<T>(this T table) where T : AnnotatableBase
    {
        table.SetTableEngine(ClickHouseAnnotationNames.AggregatingMergeTree);

        return table;
    }
    
    public static IMutableAnnotatable SetAggregatingMergeTreeTableEngine(this IMutableEntityType table)
    {
        ArgumentNullException.ThrowIfNull(table);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.AggregatingMergeTree);

        return table;
    }

    #endregion

    #region CollapsingMergeTree

    public static T SetCollapsingMergeTreeTableEngine<T>(this T table, string sign) where T : AnnotatableBase
    {
        table.SetTableEngine(ClickHouseAnnotationNames.CollapsingMergeTree);
        table.SetAnnotation(ClickHouseAnnotationNames.CollapsingMergeTreeSign, sign);

        return table;
    }

    public static IMutableAnnotatable SetCollapsingMergeTreeTableEngine(this IMutableEntityType table, string sign)
    {
        ArgumentNullException.ThrowIfNull(table);
        ArgumentException.ThrowIfNullOrWhiteSpace(sign);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.CollapsingMergeTree);
        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.CollapsingMergeTreeSign, sign);

        return table;
    }

    public static string? GetCollapsingMergeTreeSign(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var sign = table.FindAnnotation(ClickHouseAnnotationNames.CollapsingMergeTreeSign);

        return (string?)sign?.Value;
    }

    #endregion

    #region VersionedCollapsingMergeTree

    public static T SetVersionedCollapsingMergeTreeTableEngine<T>(this T table, string sign, string version)
        where T : AnnotatableBase
    {
        table.SetTableEngine(ClickHouseAnnotationNames.VersionedCollapsingMergeTree);
        table.SetAnnotation(ClickHouseAnnotationNames.VersionedCollapsingMergeTreeSign, sign);
        table.SetAnnotation(ClickHouseAnnotationNames.VersionedCollapsingMergeTreeVersion, version);

        return table;
    }

    public static IMutableAnnotatable SetVersionedCollapsingMergeTreeTableEngine(
        this IMutableEntityType table,
        string sign, string version)
    {
        ArgumentNullException.ThrowIfNull(table);
        ArgumentException.ThrowIfNullOrWhiteSpace(sign);
        ArgumentException.ThrowIfNullOrWhiteSpace(version);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.VersionedCollapsingMergeTree);
        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.VersionedCollapsingMergeTreeSign, sign);
        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.VersionedCollapsingMergeTreeVersion, version);

        return table;
    }

    public static string? GetVersionedCollapsingMergeTreeSign(this IMutableAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var sign = table.FindAnnotation(ClickHouseAnnotationNames.VersionedCollapsingMergeTreeSign);

        return (string?)sign?.Value;
    }

    public static string? GetVersionedCollapsingMergeTreeVersion(this IMutableAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var version = table.FindAnnotation(ClickHouseAnnotationNames.VersionedCollapsingMergeTreeVersion);

        return (string?)version?.Value;
    }


    #endregion

    #region GraphiteMergeTree

    public static T SetGraphiteMergeTreeTableEngine<T>(this T table, string configSection) where T : AnnotatableBase
    {
        table.SetTableEngine(ClickHouseAnnotationNames.GraphiteMergeTree);
        table.SetAnnotation(ClickHouseAnnotationNames.GraphiteMergeTreeConfigSection, configSection);

        return table;
    }
    
    public static IMutableAnnotatable SetGraphiteMergeTreeTableEngine(this IMutableAnnotatable table, string configSection)
    {
        ArgumentNullException.ThrowIfNull(table);
        ArgumentException.ThrowIfNullOrWhiteSpace(configSection);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.GraphiteMergeTree);
        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.GraphiteMergeTreeConfigSection, configSection);

        return table;
    }

    public static string? GetGraphiteMergeTreeConfigSection(this IMutableAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var configSection = table.FindAnnotation(ClickHouseAnnotationNames.GraphiteMergeTreeConfigSection);

        return (string?)configSection?.Value;
    }

    #endregion

    #region TinyLog

    public static T SetTinyLogTableEngine<T>(this T table) where T : AnnotatableBase
    {
        table.SetTableEngine(ClickHouseAnnotationNames.TinyLogEngine);

        return table;
    }
    
    public static IMutableAnnotatable SetTinyLogTableEngine(this IMutableEntityType table)
    {
        ArgumentNullException.ThrowIfNull(table);

        table.SetAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.TinyLogEngine);

        return table;
    }

    #endregion

    #region StripeLog

    public static T SetStripeLogTableEngine<T>(this T table) where T : AnnotatableBase
    {
        table.SetTableEngine(ClickHouseAnnotationNames.StripeLogEngine);

        return table;
    }
    
    public static IMutableAnnotatable SetStripeLogTableEngine(this IMutableEntityType table)
    {
        ArgumentNullException.ThrowIfNull(table);

        table.SetAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.StripeLogEngine);

        return table;
    }

    #endregion

    #region Log

    public static T SetLogTableEngine<T>(this T table) where T : AnnotatableBase
    {
        table.SetTableEngine(ClickHouseAnnotationNames.LogEngine);

        return table;
    }
    
    public static IMutableAnnotatable SetLogTableEngine(this IMutableEntityType table)
    {
        ArgumentNullException.ThrowIfNull(table);

        table.SetAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.LogEngine);

        return table;
    }

    #endregion
    
    public static T SetViewEngine<T>(this T table) where T : AnnotatableBase
    {
        table.SetTableEngine(ClickHouseAnnotationNames.ViewEngine);

        return table;
    }
}
