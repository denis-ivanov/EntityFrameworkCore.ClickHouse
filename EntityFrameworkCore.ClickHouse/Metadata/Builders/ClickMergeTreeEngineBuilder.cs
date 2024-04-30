using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ClickHouse.EntityFrameworkCore.Metadata.Builders;

public class ClickMergeTreeEngineBuilder : ClickHouseEngineBuilder
{
    public ClickMergeTreeEngineBuilder(IMutableAnnotatable builder) : base(builder)
    {
    }

    [AllowNull]
    public MergeTreeSettings Settings { get; set; }

    public ClickMergeTreeEngineBuilder WithPartitionBy([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetMergeTreePartitionBy(columns);

        return this;
    }

    public ClickMergeTreeEngineBuilder WithPrimaryKey([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetMergeTreePrimaryKey(columns);

        return this;
    }

    public ClickMergeTreeEngineBuilder WithSampleBy([NotNull] params string[] columns)
    {
        ArgumentNullException.ThrowIfNull(columns);

        Builder.SetMergeTreeSampleBy(columns);

        return this;
    }

    public ClickMergeTreeEngineBuilder WithSettings([NotNull] Action<MergeTreeSettings> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);

        Settings ??= new MergeTreeSettings();

        configure(Settings);
        return this;
    }

    public override void SpecifyEngine(MigrationCommandListBuilder builder, TableOperation table,
        ISqlGenerationHelper sql)
    {
        builder.Append(" ENGINE = MergeTree()").AppendLine();

        var orderBy = table.GetMergeTreeOrderBy();
        var partitionBy = table.GetMergeTreePartitionBy();
        var primaryKey = table.GetMergeTreePrimaryKey();
        var sampleBy = table.GetMergeTreeSampleBy();

        if (orderBy is { Length: > 0 })
        {
            builder.AppendLine($"ORDER BY ({ConcatColumns(orderBy, sql)})");
        }

        if (partitionBy is { Length: > 0 })
        {
            builder.AppendLine($"PARTITION BY ({ConcatColumns(partitionBy, sql)})");
        }

        if (primaryKey is { Length: > 0 })
        {
            builder.AppendLine($"PRIMARY KEY ({ConcatColumns(primaryKey, sql)})");
        }

        if (sampleBy is { Length: > 0 })
        {
            builder.AppendLine($"SAMPLE BY ({ConcatColumns(sampleBy, sql)})");
        }

        if (Settings is { IsDefault: false })
        {
            // TODO Implement settings.
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
                    builder.AppendLine("merge_with_ttl_timeout = " + (int)Settings.MergeWithTtlTimeout.TotalSeconds);
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

    private static string ConcatColumns(string[] columns, ISqlGenerationHelper sql)
    {
        return string.Join(", ", columns.Select(sql.DelimitIdentifier));
    }
}
