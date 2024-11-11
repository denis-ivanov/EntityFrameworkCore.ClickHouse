using ClickHouse.EntityFrameworkCore.Metadata;
using ClickHouse.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Design.Internal;

public class ClickHouseAnnotationCodeGenerator : AnnotationCodeGenerator
{
    private static readonly MethodInfo EntityTypeToTableMethodInfo
        = typeof(RelationalEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(RelationalEntityTypeBuilderExtensions.ToTable), [typeof(EntityTypeBuilder), typeof(string), typeof(Action<TableBuilder>)])!;

    private static readonly MethodInfo HasMergeTreeEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.HasMergeTreeEngine), [typeof(TableBuilder)])!;

    private static readonly MethodInfo MergeTreeOrderByMethodInfo
        = typeof(ClickHouseMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseMergeTreeEngineBuilder.WithOrderBy), [typeof(string[])]);

    private static readonly MethodInfo MergeTreePartitionByMethodInfo
        = typeof(ClickHouseMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseMergeTreeEngineBuilder.WithPartitionBy), [typeof(string[])]);

    private static readonly MethodInfo MergeTreePrimaryKeyMethodInfo
        = typeof(ClickHouseMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseMergeTreeEngineBuilder.WithPrimaryKey), [typeof(string[])]);

    private static readonly MethodInfo MergeTreeSampleByMethodInfo
        = typeof(ClickHouseMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseMergeTreeEngineBuilder.WithSampleBy), [typeof(string[])]);

    private static readonly MethodInfo HasReplacingMergeTreeEngineNoArgsMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.HasReplacingMergeTreeEngine), [typeof(TableBuilder)]);

    private static readonly MethodInfo HasReplacingMergeTreeEngineWithVersionMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.HasReplacingMergeTreeEngine), [typeof(TableBuilder), typeof(string)]);

    private static readonly MethodInfo HasReplacingMergeTreeEngineFullMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.HasReplacingMergeTreeEngine), [typeof(TableBuilder), typeof(string), typeof(string)]);

    private static readonly MethodInfo ReplacingMergeTreePartitionByMethodInfo
        = typeof(ClickHouseReplacingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseReplacingMergeTreeEngineBuilder.WithPartitionBy), [typeof(string[])]);

    private static readonly MethodInfo ReplacingMergeTreeOrderByMethodInfo
        = typeof(ClickHouseReplacingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseReplacingMergeTreeEngineBuilder.WithOrderBy), [typeof(string[])]);

    private static readonly MethodInfo ReplacingMergeTreePrimaryKeyMethodInfo
        = typeof(ClickHouseReplacingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseReplacingMergeTreeEngineBuilder.WithPrimaryKey), [typeof(string[])]);

    private static readonly MethodInfo ReplacingMergeTreeSampleByMethodInfo
        = typeof(ClickHouseReplacingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseReplacingMergeTreeEngineBuilder.WithSampleBy), [typeof(string[])]);

    private static readonly MethodInfo HasSummingMergeTreeEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.HasSummingMergeTreeEngine), [typeof(TableBuilder), typeof(string[])]);

    private static readonly MethodInfo SummingMergeTreePartitionByMethodInfo
        = typeof(ClickHouseSummingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseSummingMergeTreeEngineBuilder.WithPartitionBy), [typeof(string[])]);

    private static readonly MethodInfo SummingMergeTreeOrderByMethodInfo
        = typeof(ClickHouseSummingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseSummingMergeTreeEngineBuilder.WithOrderBy), [typeof(string[])]);

    private static readonly MethodInfo SummingMergeTreeSampleByMethodInfo
        = typeof(ClickHouseSummingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseSummingMergeTreeEngineBuilder.WithSampleBy), [typeof(string[])]);

    private static readonly MethodInfo HasAggregatingMergeTreeEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.HasAggregatingMergeTreeEngine), [typeof(TableBuilder)]);

    private static readonly MethodInfo AggregatingMergeTreePartitionByMethodInfo
        = typeof(ClickHouseAggregatingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseAggregatingMergeTreeEngineBuilder.WithPartitionBy), [typeof(string[])]);

    private static readonly MethodInfo AggregatingMergeTreeOrderByMethodInfo
        = typeof(ClickHouseAggregatingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseAggregatingMergeTreeEngineBuilder.WithOrderBy), [typeof(string[])]);

    private static readonly MethodInfo AggregatingMergeTreeSampleByMethodInfo
        = typeof(ClickHouseAggregatingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseAggregatingMergeTreeEngineBuilder.WithSampleBy), [typeof(string[])]);

    private static readonly MethodInfo HasCollapsingMergeTreeEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.HasCollapsingMergeTreeEngine), [typeof(TableBuilder)]);

    private static readonly MethodInfo CollapsingMergeTreeOrderByByMethodInfo
        = typeof(ClickHouseCollapsingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseCollapsingMergeTreeEngineBuilder.WithOrderBy), [typeof(string[])]);

    private static readonly MethodInfo CollapsingMergeTreeSampleByByMethodInfo
        = typeof(ClickHouseCollapsingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseCollapsingMergeTreeEngineBuilder.WithSampleBy), [typeof(string[])]);

    private static readonly MethodInfo CollapsingMergeTreePartitionByMethodInfo
        = typeof(ClickHouseCollapsingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseCollapsingMergeTreeEngineBuilder.WithPartitionBy), [typeof(string[])]);

    private static readonly MethodInfo HasVersionedCollapsingMergeTreeEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.HasVersionedCollapsingMergeTreeEngine), [typeof(TableBuilder)]);

    private static readonly MethodInfo VersionedCollapsingMergeTreePartitionByMethodInfo
        = typeof(ClickHouseVersionedCollapsingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseVersionedCollapsingMergeTreeEngineBuilder.WithPartitionBy), [typeof(string[])]);

    private static readonly MethodInfo VersionedCollapsingMergeTreeOrderByMethodInfo
        = typeof(ClickHouseVersionedCollapsingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseVersionedCollapsingMergeTreeEngineBuilder.WithOrderBy), [typeof(string[])]);

    private static readonly MethodInfo VersionedCollapsingMergeTreeSampleByMethodInfo
        = typeof(ClickHouseVersionedCollapsingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseVersionedCollapsingMergeTreeEngineBuilder.WithSampleBy), [typeof(string[])]);

    private static readonly MethodInfo HasGraphiteMergeTreeEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.HasGraphiteMergeTreeEngine), [typeof(TableBuilder)]);

    private static readonly MethodInfo GraphiteMergeTreePartitionByMethodInfo
        = typeof(ClickHouseGraphiteMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseGraphiteMergeTreeEngineBuilder.WithPartitionBy), [typeof(string[])]);

    private static readonly MethodInfo GraphiteMergeTreeOrderByMethodInfo
        = typeof(ClickHouseGraphiteMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseGraphiteMergeTreeEngineBuilder.WithOrderBy), [typeof(string[])]);

    private static readonly MethodInfo GraphiteMergeTreeSampleByMethodInfo
        = typeof(ClickHouseGraphiteMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseGraphiteMergeTreeEngineBuilder.WithSampleBy), [typeof(string[])]);

    public ClickHouseAnnotationCodeGenerator(AnnotationCodeGeneratorDependencies dependencies) : base(dependencies)
    {
    }

    public override IReadOnlyList<MethodCallCodeFragment> GenerateFluentApiCalls(IEntityType entityType, IDictionary<string, IAnnotation> annotations)
    {
        var fragments = new List<MethodCallCodeFragment>(base.GenerateFluentApiCalls(entityType, annotations));
        var tableEngine = GetAndRemove<string>(annotations, ClickHouseAnnotationNames.TableEngine);

        if (!string.IsNullOrWhiteSpace(tableEngine))
        {
            var primaryKey = GetAndRemove<string[]>(annotations, ClickHouseAnnotationNames.PrimaryKey);
            var partitionBy = GetAndRemove<string[]>(annotations, ClickHouseAnnotationNames.PartitionBy);
            var orderBy = GetAndRemove<string[]>(annotations, ClickHouseAnnotationNames.OrderBy);
            var sampleBy = GetAndRemove<string[]>(annotations, ClickHouseAnnotationNames.SampleBy);
            MethodCallCodeFragment engineCall = null;

            switch (tableEngine)
            {
                case ClickHouseAnnotationNames.MergeTreeEngine:
                    engineCall = new MethodCallCodeFragment(HasMergeTreeEngineMethodInfo);
                    engineCall = MakeEngineCallChain(
                        engineCall,
                        (MergeTreeOrderByMethodInfo, orderBy),
                        (MergeTreePartitionByMethodInfo, partitionBy),
                        (MergeTreePrimaryKeyMethodInfo, primaryKey),
                        (MergeTreeSampleByMethodInfo, sampleBy));

                    break;

                case ClickHouseAnnotationNames.ReplacingMergeTree:
                    var version = GetAndRemove<string>(annotations, ClickHouseAnnotationNames.ReplacingMergeTreeVersion);
                    var isDeleted = GetAndRemove<string>(annotations, ClickHouseAnnotationNames.ReplacingMergeTreeIsDeleted);
                    engineCall = !string.IsNullOrWhiteSpace(version) && !string.IsNullOrWhiteSpace(isDeleted)
                        ? new MethodCallCodeFragment(HasReplacingMergeTreeEngineFullMethodInfo, version, isDeleted)
                            : !string.IsNullOrWhiteSpace(version)
                              ? new MethodCallCodeFragment(HasReplacingMergeTreeEngineWithVersionMethodInfo, version)
                                  : new MethodCallCodeFragment(HasReplacingMergeTreeEngineNoArgsMethodInfo);

                    engineCall = MakeEngineCallChain(
                        engineCall,
                        (ReplacingMergeTreePartitionByMethodInfo, partitionBy),
                        (ReplacingMergeTreeOrderByMethodInfo, orderBy),
                        (ReplacingMergeTreePrimaryKeyMethodInfo, primaryKey),
                        (ReplacingMergeTreeSampleByMethodInfo, sampleBy));

                    break;

                case ClickHouseAnnotationNames.SummingMergeTree:
                    var summingMergeTreeColumns = GetAndRemove<string[]>(annotations, ClickHouseAnnotationNames.SummingMergeTreeColumn);
                    engineCall = new MethodCallCodeFragment(HasSummingMergeTreeEngineMethodInfo, summingMergeTreeColumns);

                    engineCall = MakeEngineCallChain(
                        engineCall,
                        (SummingMergeTreePartitionByMethodInfo, partitionBy),
                        (SummingMergeTreeOrderByMethodInfo, orderBy),
                        (SummingMergeTreeSampleByMethodInfo, sampleBy));

                    break;

                case ClickHouseAnnotationNames.AggregatingMergeTree:
                    engineCall = new MethodCallCodeFragment(HasAggregatingMergeTreeEngineMethodInfo);

                    engineCall = MakeEngineCallChain(
                        engineCall,
                        (AggregatingMergeTreePartitionByMethodInfo, partitionBy),
                        (AggregatingMergeTreeOrderByMethodInfo, orderBy),
                        (AggregatingMergeTreeSampleByMethodInfo, sampleBy));

                    break;

                case ClickHouseAnnotationNames.CollapsingMergeTree:
                    var collapsingMergeTreeSign = GetAndRemove<string>(annotations, ClickHouseAnnotationNames.CollapsingMergeTreeSign);
                    engineCall = new MethodCallCodeFragment(HasCollapsingMergeTreeEngineMethodInfo, collapsingMergeTreeSign);

                    engineCall = MakeEngineCallChain(
                        engineCall,
                        (CollapsingMergeTreePartitionByMethodInfo, partitionBy),
                        (CollapsingMergeTreeOrderByByMethodInfo, orderBy),
                        (CollapsingMergeTreeSampleByByMethodInfo, sampleBy));

                    break;

                case ClickHouseAnnotationNames.VersionedCollapsingMergeTree:
                    var versionedCollapsingMergeTreeSign = GetAndRemove<string>(annotations, ClickHouseAnnotationNames.VersionedCollapsingMergeTreeSign);
                    var versionedCollapsingMergeTreeVersion = GetAndRemove<string>(annotations, ClickHouseAnnotationNames.VersionedCollapsingMergeTreeVersion);
                    engineCall = new MethodCallCodeFragment(HasVersionedCollapsingMergeTreeEngineMethodInfo, versionedCollapsingMergeTreeSign, versionedCollapsingMergeTreeVersion);

                    engineCall = MakeEngineCallChain(
                        engineCall,
                        (VersionedCollapsingMergeTreePartitionByMethodInfo, partitionBy),
                        (VersionedCollapsingMergeTreeOrderByMethodInfo, orderBy),
                        (VersionedCollapsingMergeTreeSampleByMethodInfo, sampleBy));

                    break;

                case ClickHouseAnnotationNames.GraphiteMergeTree:
                    var configSection = GetAndRemove<string>(annotations, ClickHouseAnnotationNames.GraphiteMergeTreeConfigSection);
                    engineCall = new MethodCallCodeFragment(HasGraphiteMergeTreeEngineMethodInfo, configSection);

                    engineCall = MakeEngineCallChain(
                        engineCall,
                        (GraphiteMergeTreePartitionByMethodInfo, partitionBy),
                        (GraphiteMergeTreeOrderByMethodInfo, orderBy),
                        (GraphiteMergeTreeSampleByMethodInfo, sampleBy));

                    break;
            }

            if (engineCall != null)
            {
                entityType.RemoveRuntimeAnnotation(RelationalAnnotationNames.TableName);

                var toTableCall = new MethodCallCodeFragment(
                    EntityTypeToTableMethodInfo,
                    entityType.GetTableName(),
                    new NestedClosureCodeFragment("tb", engineCall));

                fragments.Add(toTableCall);
            }
        }

        return fragments;
    }

    private static T? GetAndRemove<T>(IDictionary<string, IAnnotation> annotations, string annotationName)
    {
        if (annotations.TryGetValue(annotationName, out var annotation)
            && annotation.Value != null)
        {
            annotations.Remove(annotationName);
            return (T)annotation.Value;
        }

        return default;
    }

    private static MethodCallCodeFragment MakeEngineCallChain(MethodCallCodeFragment fragment, params (MethodInfo Method, string[] Arguments)[] calls)
    {
        var result = fragment;

        foreach (var (method, arguments) in calls)
        {
            if (arguments is { Length: > 0 })
            {
                result = result.Chain(method, arguments);
            }
        }

        return result;
    }
}
