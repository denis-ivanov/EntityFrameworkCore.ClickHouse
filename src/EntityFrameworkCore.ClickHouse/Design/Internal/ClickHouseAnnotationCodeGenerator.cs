using ClickHouse.EntityFrameworkCore.Metadata;
using ClickHouse.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ClickHouse.EntityFrameworkCore.Design.Internal;

public class ClickHouseAnnotationCodeGenerator : AnnotationCodeGenerator
{
    private static readonly MethodInfo EntityTypeToTableMethodInfo
        = typeof(RelationalEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(RelationalEntityTypeBuilderExtensions.ToTable), [typeof(EntityTypeBuilder), typeof(string), typeof(Action<TableBuilder>)])!;

    private static readonly MethodInfo UseMergeTreeEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.UseMergeTreeEngine), [typeof(TableBuilder)])!;

    private static readonly MethodInfo MergeTreeOrderByMethodInfo
        = typeof(ClickHouseMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseMergeTreeEngineBuilder.WithOrderBy), [typeof(string[])])!;

    private static readonly MethodInfo MergeTreePartitionByMethodInfo
        = typeof(ClickHouseMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseMergeTreeEngineBuilder.WithPartitionBy), [typeof(string[])])!;

    private static readonly MethodInfo MergeTreePrimaryKeyMethodInfo
        = typeof(ClickHouseMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseMergeTreeEngineBuilder.WithPrimaryKey), [typeof(string[])])!;

    private static readonly MethodInfo MergeTreeSampleByMethodInfo
        = typeof(ClickHouseMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseMergeTreeEngineBuilder.WithSampleBy), [typeof(string[])])!;

    private static readonly MethodInfo UseReplacingMergeTreeEngineNoArgsMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.UseReplacingMergeTreeEngine), [typeof(TableBuilder)])!;

    private static readonly MethodInfo UseReplacingMergeTreeEngineWithVersionMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.UseReplacingMergeTreeEngine), [typeof(TableBuilder), typeof(string)])!;

    private static readonly MethodInfo UseReplacingMergeTreeEngineFullMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.UseReplacingMergeTreeEngine), [typeof(TableBuilder), typeof(string), typeof(string)])!;

    private static readonly MethodInfo ReplacingMergeTreePartitionByMethodInfo
        = typeof(ClickHouseReplacingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseReplacingMergeTreeEngineBuilder.WithPartitionBy), [typeof(string[])])!;

    private static readonly MethodInfo ReplacingMergeTreeOrderByMethodInfo
        = typeof(ClickHouseReplacingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseReplacingMergeTreeEngineBuilder.WithOrderBy), [typeof(string[])])!;

    private static readonly MethodInfo ReplacingMergeTreePrimaryKeyMethodInfo
        = typeof(ClickHouseReplacingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseReplacingMergeTreeEngineBuilder.WithPrimaryKey), [typeof(string[])])!;

    private static readonly MethodInfo ReplacingMergeTreeSampleByMethodInfo
        = typeof(ClickHouseReplacingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseReplacingMergeTreeEngineBuilder.WithSampleBy), [typeof(string[])])!;

    private static readonly MethodInfo UseSummingMergeTreeEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.UseSummingMergeTreeEngine), [typeof(TableBuilder), typeof(string[])])!;

    private static readonly MethodInfo SummingMergeTreePartitionByMethodInfo
        = typeof(ClickHouseSummingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseSummingMergeTreeEngineBuilder.WithPartitionBy), [typeof(string[])])!;

    private static readonly MethodInfo SummingMergeTreeOrderByMethodInfo
        = typeof(ClickHouseSummingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseSummingMergeTreeEngineBuilder.WithOrderBy), [typeof(string[])])!;

    private static readonly MethodInfo SummingMergeTreeSampleByMethodInfo
        = typeof(ClickHouseSummingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseSummingMergeTreeEngineBuilder.WithSampleBy), [typeof(string[])])!;

    private static readonly MethodInfo UseAggregatingMergeTreeEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.UseAggregatingMergeTreeEngine), [typeof(TableBuilder)])!;

    private static readonly MethodInfo AggregatingMergeTreePartitionByMethodInfo
        = typeof(ClickHouseAggregatingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseAggregatingMergeTreeEngineBuilder.WithPartitionBy), [typeof(string[])])!;

    private static readonly MethodInfo AggregatingMergeTreeOrderByMethodInfo
        = typeof(ClickHouseAggregatingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseAggregatingMergeTreeEngineBuilder.WithOrderBy), [typeof(string[])])!;

    private static readonly MethodInfo AggregatingMergeTreeSampleByMethodInfo
        = typeof(ClickHouseAggregatingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseAggregatingMergeTreeEngineBuilder.WithSampleBy), [typeof(string[])])!;

    private static readonly MethodInfo UseCollapsingMergeTreeEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.UseCollapsingMergeTreeEngine), [typeof(TableBuilder)])!;

    private static readonly MethodInfo CollapsingMergeTreeOrderByByMethodInfo
        = typeof(ClickHouseCollapsingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseCollapsingMergeTreeEngineBuilder.WithOrderBy), [typeof(string[])])!;

    private static readonly MethodInfo CollapsingMergeTreeSampleByByMethodInfo
        = typeof(ClickHouseCollapsingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseCollapsingMergeTreeEngineBuilder.WithSampleBy), [typeof(string[])])!;

    private static readonly MethodInfo CollapsingMergeTreePartitionByMethodInfo
        = typeof(ClickHouseCollapsingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseCollapsingMergeTreeEngineBuilder.WithPartitionBy), [typeof(string[])])!;

    private static readonly MethodInfo UseVersionedCollapsingMergeTreeEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.UseVersionedCollapsingMergeTreeEngine), [typeof(TableBuilder)])!;

    private static readonly MethodInfo VersionedCollapsingMergeTreePartitionByMethodInfo
        = typeof(ClickHouseVersionedCollapsingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseVersionedCollapsingMergeTreeEngineBuilder.WithPartitionBy), [typeof(string[])])!;

    private static readonly MethodInfo VersionedCollapsingMergeTreeOrderByMethodInfo
        = typeof(ClickHouseVersionedCollapsingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseVersionedCollapsingMergeTreeEngineBuilder.WithOrderBy), [typeof(string[])])!;

    private static readonly MethodInfo VersionedCollapsingMergeTreeSampleByMethodInfo
        = typeof(ClickHouseVersionedCollapsingMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseVersionedCollapsingMergeTreeEngineBuilder.WithSampleBy), [typeof(string[])])!;

    private static readonly MethodInfo UseGraphiteMergeTreeEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.UseGraphiteMergeTreeEngine), [typeof(TableBuilder)])!;

    private static readonly MethodInfo GraphiteMergeTreePartitionByMethodInfo
        = typeof(ClickHouseGraphiteMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseGraphiteMergeTreeEngineBuilder.WithPartitionBy), [typeof(string[])])!;

    private static readonly MethodInfo GraphiteMergeTreeOrderByMethodInfo
        = typeof(ClickHouseGraphiteMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseGraphiteMergeTreeEngineBuilder.WithOrderBy), [typeof(string[])])!;

    private static readonly MethodInfo GraphiteMergeTreeSampleByMethodInfo
        = typeof(ClickHouseGraphiteMergeTreeEngineBuilder).GetRuntimeMethod(
            nameof(ClickHouseGraphiteMergeTreeEngineBuilder.WithSampleBy), [typeof(string[])])!;

    private static readonly MethodInfo UseTinyLogEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.UseTinyLogEngine), [typeof(TableBuilder)])!;

    private static readonly MethodInfo UseStripeLogEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.UseStripeLogEngine), [typeof(TableBuilder)])!;

    private static readonly MethodInfo UseLogEngineMethodInfo
        = typeof(ClickHouseEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(ClickHouseEntityTypeBuilderExtensions.UseLogEngine), [typeof(TableBuilder)])!;

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
            MethodCallCodeFragment? engineCall = null;

            switch (tableEngine)
            {
                case ClickHouseAnnotationNames.MergeTreeEngine:
                    engineCall = new MethodCallCodeFragment(UseMergeTreeEngineMethodInfo);
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
                        ? new MethodCallCodeFragment(UseReplacingMergeTreeEngineFullMethodInfo, version, isDeleted)
                            : !string.IsNullOrWhiteSpace(version)
                              ? new MethodCallCodeFragment(UseReplacingMergeTreeEngineWithVersionMethodInfo, version)
                                  : new MethodCallCodeFragment(UseReplacingMergeTreeEngineNoArgsMethodInfo);

                    engineCall = MakeEngineCallChain(
                        engineCall,
                        (ReplacingMergeTreePartitionByMethodInfo, partitionBy),
                        (ReplacingMergeTreeOrderByMethodInfo, orderBy),
                        (ReplacingMergeTreePrimaryKeyMethodInfo, primaryKey),
                        (ReplacingMergeTreeSampleByMethodInfo, sampleBy));

                    break;

                case ClickHouseAnnotationNames.SummingMergeTree:
                    var summingMergeTreeColumns = GetAndRemove<string[]>(annotations, ClickHouseAnnotationNames.SummingMergeTreeColumns);
                    engineCall = new MethodCallCodeFragment(UseSummingMergeTreeEngineMethodInfo, summingMergeTreeColumns);

                    engineCall = MakeEngineCallChain(
                        engineCall,
                        (SummingMergeTreePartitionByMethodInfo, partitionBy),
                        (SummingMergeTreeOrderByMethodInfo, orderBy),
                        (SummingMergeTreeSampleByMethodInfo, sampleBy));

                    break;

                case ClickHouseAnnotationNames.AggregatingMergeTree:
                    engineCall = new MethodCallCodeFragment(UseAggregatingMergeTreeEngineMethodInfo);

                    engineCall = MakeEngineCallChain(
                        engineCall,
                        (AggregatingMergeTreePartitionByMethodInfo, partitionBy),
                        (AggregatingMergeTreeOrderByMethodInfo, orderBy),
                        (AggregatingMergeTreeSampleByMethodInfo, sampleBy));

                    break;

                case ClickHouseAnnotationNames.CollapsingMergeTree:
                    var collapsingMergeTreeSign = GetAndRemove<string>(annotations, ClickHouseAnnotationNames.CollapsingMergeTreeSign);
                    engineCall = new MethodCallCodeFragment(UseCollapsingMergeTreeEngineMethodInfo, collapsingMergeTreeSign);

                    engineCall = MakeEngineCallChain(
                        engineCall,
                        (CollapsingMergeTreePartitionByMethodInfo, partitionBy),
                        (CollapsingMergeTreeOrderByByMethodInfo, orderBy),
                        (CollapsingMergeTreeSampleByByMethodInfo, sampleBy));

                    break;

                case ClickHouseAnnotationNames.VersionedCollapsingMergeTree:
                    var versionedCollapsingMergeTreeSign = GetAndRemove<string>(annotations, ClickHouseAnnotationNames.VersionedCollapsingMergeTreeSign);
                    var versionedCollapsingMergeTreeVersion = GetAndRemove<string>(annotations, ClickHouseAnnotationNames.VersionedCollapsingMergeTreeVersion);
                    engineCall = new MethodCallCodeFragment(UseVersionedCollapsingMergeTreeEngineMethodInfo, versionedCollapsingMergeTreeSign, versionedCollapsingMergeTreeVersion);

                    engineCall = MakeEngineCallChain(
                        engineCall,
                        (VersionedCollapsingMergeTreePartitionByMethodInfo, partitionBy),
                        (VersionedCollapsingMergeTreeOrderByMethodInfo, orderBy),
                        (VersionedCollapsingMergeTreeSampleByMethodInfo, sampleBy));

                    break;

                case ClickHouseAnnotationNames.GraphiteMergeTree:
                    var configSection = GetAndRemove<string>(annotations, ClickHouseAnnotationNames.GraphiteMergeTreeConfigSection);
                    engineCall = new MethodCallCodeFragment(UseGraphiteMergeTreeEngineMethodInfo, configSection);

                    engineCall = MakeEngineCallChain(
                        engineCall,
                        (GraphiteMergeTreePartitionByMethodInfo, partitionBy),
                        (GraphiteMergeTreeOrderByMethodInfo, orderBy),
                        (GraphiteMergeTreeSampleByMethodInfo, sampleBy));

                    break;

                case ClickHouseAnnotationNames.TinyLogEngine:
                    engineCall = new MethodCallCodeFragment(UseTinyLogEngineMethodInfo);
                    break;

                case ClickHouseAnnotationNames.StripeLogEngine:
                    engineCall = new MethodCallCodeFragment(UseStripeLogEngineMethodInfo);
                    break;

                case ClickHouseAnnotationNames.LogEngine:
                    engineCall = new MethodCallCodeFragment(UseLogEngineMethodInfo);
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

    private static MethodCallCodeFragment MakeEngineCallChain(MethodCallCodeFragment fragment, params (MethodInfo Method, string[]? Arguments)[] calls)
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
