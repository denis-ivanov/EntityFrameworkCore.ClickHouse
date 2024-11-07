using ClickHouse.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace ClickHouse.EntityFrameworkCore.Extensions;

public static class ClickHouseEntityTypeExtensions
{
    public static string GetTableEngine(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var engine = table.FindAnnotation(ClickHouseAnnotationNames.TableEngine);

        return (string)engine?.Value;
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

    public static string[] GetOrderBy(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var annotation = table.FindAnnotation(ClickHouseAnnotationNames.OrderBy);

        return (string[])annotation?.Value;
    }

    public static string[] GetPartitionBy(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var annotation = table.FindAnnotation(ClickHouseAnnotationNames.PartitionBy);

        return (string[])annotation?.Value;
    }

    public static string[] GetPrimaryKey(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var annotation = table.FindAnnotation(ClickHouseAnnotationNames.PrimaryKey);

        return (string[])annotation?.Value;
    }

    public static string[] GetSampleBy(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var annotation = table.FindAnnotation(ClickHouseAnnotationNames.SampleBy);

        return (string[])annotation?.Value;
    }

    #region MergeTreeEngine

    public static IMutableAnnotatable SetMergeTreeTableEngine(this IMutableEntityType table)
    {
        ArgumentNullException.ThrowIfNull(table);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.MergeTreeEngine);

        return table;
    }

    #endregion

    #region ReplacingMergeTree

    public static IMutableAnnotatable SetReplacingMergeTreeTableEngine(this IMutableEntityType table, string version, string isDeleted)
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

    public static string GetReplacingMergeTreeVersion(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var version = table.FindAnnotation(ClickHouseAnnotationNames.ReplacingMergeTreeVersion);

        return (string)version?.Value;
    }

    public static string GetReplacingMergeTreeIsDeleted(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var version = table.FindAnnotation(ClickHouseAnnotationNames.ReplacingMergeTreeIsDeleted);

        return (string)version?.Value;
    }

    #endregion

    #region SummingMergeTree

    public static IMutableAnnotatable SetSummingMergeTreeTableEngine(this IMutableEntityType table, string column)
    {
        ArgumentNullException.ThrowIfNull(table);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.SummingMergeTree);

        if (!string.IsNullOrWhiteSpace(column))
        {
            table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.SummingMergeTreeColumn, column);
        }

        return table;
    }

    public static void SetSummingMergeTreeTableEngineColumn(this AnnotatableBase table, string column)
    {
        ArgumentNullException.ThrowIfNull(table);

        if (!string.IsNullOrWhiteSpace(column))
        {
            table.SetAnnotation(ClickHouseAnnotationNames.SummingMergeTreeColumn, column);
        }
    }

    public static string GetSummingMergeTreeColumn(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var columns = table.FindAnnotation(ClickHouseAnnotationNames.SummingMergeTreeColumn);

        return (string)columns?.Value;
    }

    #endregion

    #region AggregatingMergeTree

    public static IMutableAnnotatable SetAggregatingMergeTreeTableEngine(this IMutableEntityType table)
    {
        ArgumentNullException.ThrowIfNull(table);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.AggregatingMergeTree);

        return table;
    }

    #endregion

    #region CollapsingMergeTree

    public static IMutableAnnotatable SetCollapsingMergeTreeTableEngine(this IMutableEntityType table, string sign)
    {
        ArgumentNullException.ThrowIfNull(table);
        ArgumentException.ThrowIfNullOrWhiteSpace(sign);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.CollapsingMergeTree);
        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.CollapsingMergeTreeSign, sign);

        return table;
    }

    public static string GetCollapsingMergeTreeSign(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var sign = table.FindAnnotation(ClickHouseAnnotationNames.CollapsingMergeTreeSign);

        return (string)sign?.Value;
    }

    #endregion

    #region VersionedCollapsingMergeTree

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

    public static string GetVersionedCollapsingMergeTreeSign(this IMutableAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var sign = table.FindAnnotation(ClickHouseAnnotationNames.VersionedCollapsingMergeTreeSign);

        return (string)sign?.Value;
    }

    public static string GetVersionedCollapsingMergeTreeVersion(this IMutableAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var version = table.FindAnnotation(ClickHouseAnnotationNames.VersionedCollapsingMergeTreeVersion);

        return (string)version?.Value;
    }


    #endregion

    #region GraphiteMergeTree

    public static IMutableAnnotatable SetGraphiteMergeTreeTableEngine(this IMutableAnnotatable table, string configSection)
    {
        ArgumentNullException.ThrowIfNull(table);
        ArgumentException.ThrowIfNullOrWhiteSpace(configSection);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.GraphiteMergeTree);
        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.GraphiteMergeTreeConfigSection, configSection);

        return table;
    }

    public static string GetGraphiteMergeTreeConfigSection(this IMutableAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var configSection = table.FindAnnotation(ClickHouseAnnotationNames.GraphiteMergeTreeConfigSection);

        return (string)configSection?.Value;
    }

    #endregion

    #region StripeLog

    public static IMutableAnnotatable SetStripeLogTableEngine(this IMutableEntityType table)
    {
        ArgumentNullException.ThrowIfNull(table);

        table.SetAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.StripeLogEngine);

        return table;
    }

    #endregion
}
