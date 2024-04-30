using ClickHouse.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace ClickHouse.EntityFrameworkCore.Extensions;

public static class ClickHouseEntityTypeExtensions
{
    #region MergeTreeEngine

    public static IMutableAnnotatable SetMergeTreeTableEngine(this IMutableEntityType table)
    {
        ArgumentNullException.ThrowIfNull(table);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.TableEngine, ClickHouseAnnotationNames.MergeTreeEngine);

        return table;
    }

    public static IMutableAnnotatable SetMergeTreeOrderBy(this IMutableEntityType table, string[] columns)
    {
        ArgumentNullException.ThrowIfNull(table);
        ArgumentNullException.ThrowIfNull(columns);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.MergeTreeOrderBy, columns);

        return table;
    }

    public static IMutableAnnotatable SetMergeTreePartitionBy(this IMutableAnnotatable table, string[] columns)
    {
        ArgumentNullException.ThrowIfNull(table);
        ArgumentNullException.ThrowIfNull(columns);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.MergeTreePartitionBy, columns);

        return table;
    }

    public static IMutableAnnotatable SetMergeTreePrimaryKey(this IMutableAnnotatable table, string[] columns)
    {
        ArgumentNullException.ThrowIfNull(table);
        ArgumentNullException.ThrowIfNull(columns);

        table.RemoveAnnotation(ClickHouseAnnotationNames.MergeTreePrimaryKey);
        table.AddAnnotation(ClickHouseAnnotationNames.MergeTreePrimaryKey, columns);

        return table;
    }

    public static IMutableAnnotatable SetMergeTreeSampleBy(this IMutableAnnotatable table, string[] columns)
    {
        ArgumentNullException.ThrowIfNull(table);
        ArgumentNullException.ThrowIfNull(columns);

        table.SetOrRemoveAnnotation(ClickHouseAnnotationNames.MergeTreeSampleBy, columns);

        return table;
    }

    public static string[] GetMergeTreeOrderBy(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var annotation = table.FindAnnotation(ClickHouseAnnotationNames.MergeTreeOrderBy);

        return (string[])annotation?.Value;
    }

    public static string[] GetMergeTreePartitionBy(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var annotation = table.FindAnnotation(ClickHouseAnnotationNames.MergeTreePartitionBy);

        return (string[])annotation?.Value;
    }

    public static string[] GetMergeTreePrimaryKey(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var annotation = table.FindAnnotation(ClickHouseAnnotationNames.MergeTreePrimaryKey);

        return (string[])annotation?.Value;
    }

    public static string[] GetMergeTreeSampleBy(this IAnnotatable table)
    {
        ArgumentNullException.ThrowIfNull(table);

        var annotation = table.FindAnnotation(ClickHouseAnnotationNames.MergeTreeSampleBy);

        return (string[])annotation?.Value;
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
