using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using ClickHouse.EntityFrameworkCore.Metadata;
using ClickHouse.EntityFrameworkCore.Storage.Engines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClickHouse.EntityFrameworkCore.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<T> HasMergeTreeEngine<T>(
            this EntityTypeBuilder<T> builder,
            [NotNull]Expression<Func<T, object>>[] orderBy,
            Expression<Func<T, object>>[] primaryKey = null,
            Expression<Func<T, object>>[] sampleBy = null,
            Action<MergeTreeSettings> settingsConfiguration = null) where T : class
        {
            var mergeTree = new MergeTreeEngine<T>
            {
                OrderBy = orderBy,
                PrimaryKey = primaryKey,
                SampleBy = sampleBy
            };

            if (settingsConfiguration != null)
            {
                mergeTree.Settings = new MergeTreeSettings();
                settingsConfiguration(mergeTree.Settings);
            }

            builder.Metadata.SetOrRemoveAnnotation(ClickHouseAnnotationNames.Engine, mergeTree);
            return builder;
        }

        public static EntityTypeBuilder<T> HasMergeTreeEngine<T>(
            this EntityTypeBuilder<T> builder,
            string[] orderBy,
            string[] primaryKey = null,
            string[] sampleBy = null,
            Action<MergeTreeSettings> settingsConfiguration = null) where T : class
        {
            var mergeTree = new MergeTreeEngine<T>
            {
                OrderBy = orderBy,
                PrimaryKey = primaryKey,
                SampleBy = sampleBy
            };

            if (settingsConfiguration != null)
            {
                mergeTree.Settings = new MergeTreeSettings();
                settingsConfiguration(mergeTree.Settings);
            }

            builder.Metadata.SetOrRemoveAnnotation(ClickHouseAnnotationNames.Engine, mergeTree);
            return builder;
        }
        /*
        public static EntityTypeBuilder<T> HasAggregatingMergeTreeEngine<T>(this EntityTypeBuilder<T> builder)
            where T : class
        {
            builder.Metadata.SetOrRemoveAnnotation(
                ClickHouseAnnotationNames.Engine,
                new ClickHouseEngine("AggregatingMergeTree"));
            return builder;
        }

        public static EntityTypeBuilder<T> HasCollapsingMergeTreeEngine<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, object>> sign) where T : class
        {
            builder.Metadata.SetOrRemoveAnnotation(
                ClickHouseAnnotationNames.Engine,
                new ClickHouseEngine("CollapsingMergeTree", sign));
            return builder;
        }

        public static EntityTypeBuilder<T> HasCollapsingMergeTreeEngine<T>(this EntityTypeBuilder<T> builder, string sign) where T : class
        {
            builder.Metadata.SetOrRemoveAnnotation(
                ClickHouseAnnotationNames.Engine,
                new ClickHouseEngine("CollapsingMergeTree", sign));
            return builder;
        }

        public static EntityTypeBuilder<T> HasGraphiteMergeTreeEngine<T>(this EntityTypeBuilder<T> builder, string configSection) where T : class
        {
            builder.Metadata.SetOrRemoveAnnotation(
                ClickHouseAnnotationNames.Engine,
                new ClickHouseEngine("GraphiteMergeTree", configSection));
            return builder;
        }

        public static EntityTypeBuilder<T> HasReplacingMergeTreeEngine<T>(this EntityTypeBuilder<T> builder)
            where T : class
        {
            builder.Metadata.SetOrRemoveAnnotation(
                ClickHouseAnnotationNames.Engine, 
                new ClickHouseEngine("ReplacingMergeTree"));
            return builder;
        }

        public static EntityTypeBuilder<T> HasReplacingMergeTreeEngine<T>(this EntityTypeBuilder<T> builder, string ver) where T : class
        {
            builder.Metadata.SetOrRemoveAnnotation(
                ClickHouseAnnotationNames.Engine,
                new ClickHouseEngine("ReplacingMergeTree", ver));
            return builder;
        }

        public static EntityTypeBuilder<T> HasReplacingMergeTreeEngine<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, object>> ver) where T : class
        {
            builder.Metadata.SetOrRemoveAnnotation(
                ClickHouseAnnotationNames.Engine,
                new ClickHouseEngine("ReplacingMergeTree", ver));
            return builder;
        }

        public static EntityTypeBuilder<T> HasSummingMergeTreeEngine<T>(this EntityTypeBuilder<T> builder, params string[] columns) where T : class
        {
            builder.Metadata.SetOrRemoveAnnotation(
                ClickHouseAnnotationNames.Engine,
                new ClickHouseEngine("SummingMergeTree", columns));
            return builder;
        }

        public static EntityTypeBuilder<T> HasSummingMergeTreeEngine<T>(this EntityTypeBuilder<T> builder, params Expression<Func<T, object>>[] columns) where T : class
        {
            builder.Metadata.SetOrRemoveAnnotation(
                ClickHouseAnnotationNames.Engine,
                new ClickHouseEngine("HasSummingMergeTree", columns));
            return builder;
        }

        public static EntityTypeBuilder<T> HasVersionedCollapsingMergeTreeEngine<T>(this EntityTypeBuilder<T> builder, string sign, string version) where T: class
        {
            builder.Metadata.SetOrRemoveAnnotation(
                ClickHouseAnnotationNames.Engine,
                new ClickHouseEngine("VersionedCollapsingMergeTree", sign, version));
            return builder;
        }
        
        public static EntityTypeBuilder<T> HasVersionedCollapsingMergeTreeEngine<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, byte>> sign,
            Expression<Func<T, object>> version) where T: class
        {
            builder.Metadata.SetOrRemoveAnnotation(
                ClickHouseAnnotationNames.Engine,
                new ClickHouseEngine("VersionedCollapsingMergeTree", sign, version));
            return builder;
        }**/
    }
}
