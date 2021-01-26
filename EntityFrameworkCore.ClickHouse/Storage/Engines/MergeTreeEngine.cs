using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickHouse.EntityFrameworkCore.Storage.Engines
{
    public class MergeTreeEngine<T> : ClickHouseEngine
    {
        public override string Name => "MergeTree";

        [NotNull]public object[] OrderBy { get; set; }

        [AllowNull]public object[] PartitionBy { get; set; }

        [AllowNull]public object[] PrimaryKey { get; set; }

        [AllowNull]public object[] SampleBy { get; set; }

        [AllowNull]public MergeTreeSettings Settings { get; set; }

        public override void SpecifyEngine(MigrationCommandListBuilder builder, IModel model)
        {
            builder.Append(" ENGINE = " + Name + "()").AppendLine();

            if (OrderBy != null && OrderBy.Length > 0)
            {
                builder.AppendLine($"ORDER BY ({string.Join(", ", GetFields(OrderBy, model))})");
            }

            if (PartitionBy != null && PartitionBy.Length > 0)
            {
                builder.AppendLine($"$PARTITION BY ({string.Join(", ", GetFields(PartitionBy, model))})");
            }

            if (PrimaryKey != null && PrimaryKey.Length > 0)
            {
                builder.AppendLine($"PRIMARY KEY ({string.Join(", ", GetFields(PrimaryKey, model))})");
            }

            if (SampleBy != null && SampleBy.Length > 0)
            {
                builder.AppendLine($"SAMPLE BY ({string.Join(", ", GetFields(SampleBy, model))})");
            }

            if (Settings != null && !Settings.IsDefault)
            {
                builder.AppendLine("SETTINGS");

                using (builder.Indent())
                {
                    if (Settings.IndexGranularity != MergeTreeSettings.DefaultIndexGranularity)
                    {
                        builder.AppendLine("index_granularity = " + Settings.IndexGranularity);
                    }

                    if (Settings.IndexGranularityBytes != MergeTreeSettings.DefaultIndexGranularityBytes)
                    {
                        builder.AppendLine("index_granularity_bytes = " + Settings.IndexGranularityBytes);
                    }

                    if (Settings.MinIndexGranularityBytes != MergeTreeSettings.DefaultMinIndexGranularityBytes)
                    {
                        builder.AppendLine("min_index_granularity_bytes = " + Settings.MinIndexGranularityBytes);
                    }

                    if (Settings.EnableMixedGranularityParts != MergeTreeSettings.DefaultEnableMixedGranularityParts)
                    {
                        builder.AppendLine("enable_mixed_granularity_parts = " + Convert.ToInt32(Settings.EnableMixedGranularityParts));
                    }

                    if (Settings.UseMinimalisticPartHeaderInZookeeper != MergeTreeSettings.DefaultUseMinimalisticPartHeaderInZookeeper)
                    {
                        builder.AppendLine("use_minimalistic_part_header_in_zookeeper = " +
                                           Convert.ToInt32(Settings.UseMinimalisticPartHeaderInZookeeper));
                    }

                    if (Settings.MinMergeBytesToUseDirectIo != MergeTreeSettings.DefaultMinMergeBytesToUseDirectIo)
                    {
                        builder.AppendLine("min_merge_bytes_to_use_direct_io = " + Settings.MinMergeBytesToUseDirectIo);
                    }

                    if (Settings.MergeWithTtlTimeout != MergeTreeSettings.DefaultMergeWithTtlTimeout)
                    {
                        builder.AppendLine("merge_with_ttl_timeout = " + (int) Settings.MergeWithTtlTimeout.TotalSeconds);
                    }

                    if (Settings.WriteFinalMark != MergeTreeSettings.DefaultWriteFinalMark)
                    {
                        builder.AppendLine("write_final_mark = " + Convert.ToInt32(Settings.WriteFinalMark));
                    }

                    if (Settings.MergeMaxBlockSize != MergeTreeSettings.DefaultMergeMaxBlockSize)
                    {
                        builder.AppendLine("merge_max_block_size = " + Settings.MergeMaxBlockSize);
                    }

                    if (!string.IsNullOrEmpty(Settings.StoragePolicy))
                    {
                        builder.AppendLine("storage_policy = " + Settings.StoragePolicy);
                    }

                    if (Settings.MinBytesForWidePart != null)
                    {
                        builder.AppendLine("min_bytes_for_wide_part = " + Settings.MinBytesForWidePart.Value);
                    }

                    if (Settings.MinRowsForWidePart != null)
                    {
                        builder.AppendLine("min_rows_for_wide_part = " + Settings.MinRowsForWidePart.Value);
                    }

                    if (Settings.MaxPartsInTotal != null)
                    {
                        builder.AppendLine("max_parts_in_total = " + Settings.MaxPartsInTotal.Value);
                    }

                    if (Settings.MaxCompressBlockSize != null)
                    {
                        builder.AppendLine("max_compress_block_size = " + Settings.MaxCompressBlockSize.Value);
                    }

                    if (Settings.MinCompressBlockSize != null)
                    {
                        builder.AppendLine("min_compress_block_size = " + Settings.MinCompressBlockSize.Value);
                    }
                }
            }
        }

        private string[] GetFields(object[] args, IModel model)
        {
            var result = new string[args.Length];

            for (var i = 0; i < args.Length; i++)
            {
                var arg = args[i];

                switch (arg)
                {
                    case string argString:
                        result[i] = argString;
                        break;

                    case Expression<Func<T, object>> argExpression:
                    {
                        var entity = model.FindEntityType(argExpression.Parameters[0].Type);
                        var member = ((MemberExpression)((UnaryExpression)argExpression.Body).Operand).Member;
                        var property = entity.FindProperty(member);
                        result[i] = property.GetColumnName();
                        break;
                    }
                }
            }

            return result;
        }
    }
}
