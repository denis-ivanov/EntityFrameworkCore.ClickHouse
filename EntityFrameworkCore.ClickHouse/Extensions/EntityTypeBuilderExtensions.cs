using System;
using System.Linq.Expressions;
using ClickHouse.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClickHouse.EntityFrameworkCore.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        private static EntityTypeBuilder<T> HasEngine<T>(this EntityTypeBuilder<T> builder, string engine) where T: class
        {
            builder.Metadata.SetOrRemoveAnnotation(ClickHouseAnnotationNames.Engine, engine);
            return builder;
        }

        public static EntityTypeBuilder<T> HasMergeTreeEngine<T>(this EntityTypeBuilder<T> builder) where T : class
            => builder.HasEngine(ClickHouseEngineNames.MergeTree);

        public static EntityTypeBuilder<T> HasAggregatingMergeTreeEngine<T>(this EntityTypeBuilder<T> builder) where T : class
            => builder.HasEngine(ClickHouseEngineNames.AggregatingMergeTree);

        public static EntityTypeBuilder<T> HasCollapsingMergeTreeEngine<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, object>> sign) where T : class
        {
            throw new NotImplementedException();
        }

        public static EntityTypeBuilder<T> HasCollapsingMergeTreeEngine<T>(this EntityTypeBuilder<T> builder, string sign) where T : class =>
            builder.HasEngine($"CollapsingMergeTree({sign})");

        public static EntityTypeBuilder<T> HasGraphiteMergeTreeEngine<T>(this EntityTypeBuilder<T> builder, string configSection) where T : class =>
            builder.HasEngine($"GraphiteMergeTree({configSection})");

        public static EntityTypeBuilder<T> HasReplacingMergeTreeEngine<T>(this EntityTypeBuilder<T> builder) where T : class =>
            builder.HasEngine("ReplacingMergeTree()");

        public static EntityTypeBuilder<T> HasReplacingMergeTreeEngine<T>(
            this EntityTypeBuilder<T> builder, 
            string ver) where T : class =>
            builder.HasEngine($"ReplacingMergeTree({ver})");

        public static EntityTypeBuilder<T> HasReplacingMergeTreeEngine<T>(
            this EntityTypeBuilder<T> builder, 
            Expression<Func<T, object>> ver) where T : class
        {
            throw new NotImplementedException();
        }

        public static EntityTypeBuilder<T> HasSummingMergeTreeEngine<T>(
            this EntityTypeBuilder<T> builder, 
            params string[] columns) where T : class =>
            builder.HasEngine($"SummingMergeTree({string.Join(",", columns)})");

        public static EntityTypeBuilder<T> HasSummingMergeTreeEngine<T>(
            this EntityTypeBuilder<T> builder,
            params Expression<Func<T, object>>[] columns) where T : class
        {
            throw new NotImplementedException();
        }

        public static EntityTypeBuilder<T> HasVersionedCollapsingMergeTreeEngine<T>(
            this EntityTypeBuilder<T> builder,
            string sign,
            string version) where T: class
        {
            builder.HasEngine($"VersionedCollapsingMergeTree({sign}, {version})");
            return builder;
        }
        
        public static EntityTypeBuilder<T> HasVersionedCollapsingMergeTreeEngine<T>(
            this EntityTypeBuilder<T> builder,
            Expression<Func<T, byte>> sign,
            Expression<Func<T, object>> version) where T: class
        {
            throw new NotImplementedException();
        }
    }
}
