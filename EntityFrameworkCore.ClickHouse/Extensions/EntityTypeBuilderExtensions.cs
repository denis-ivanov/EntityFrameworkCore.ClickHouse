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
    }
}
