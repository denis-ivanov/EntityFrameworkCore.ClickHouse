namespace ClickHouse.EntityFrameworkCore.Metadata;

public static class ClickHouseAnnotationNames
{
    public const string Prefix = "ClickHouse:";

    public const string TableEngine = Prefix + "TableEngine";

    public const string ColumnTtl = Prefix + "ColumnTtl";

    public const string PartitionBy = TableEngine + ":PartitionBy";

    public const string OrderBy = TableEngine + ":OrderBy";

    public const string PrimaryKey = TableEngine + ":PrimaryKey";

    public const string SampleBy = TableEngine + ":SampleBy";

    #region Merge tree

    public const string MergeTreeEngine = "MergeTree";

    #endregion

    #region ReplacingMergeTree

    public const string ReplacingMergeTree = "ReplacingMergeTree";

    public const string ReplacingMergeTreeVersion = TableEngine + ":ReplacingMergeTree:Version";

    public const string ReplacingMergeTreeIsDeleted = TableEngine + ":ReplacingMergeTree:IsDeleted";

    #endregion

    #region SummingMergeTree

    public const string SummingMergeTree = "SummingMergeTree";

    public const string SummingMergeTreeColumn = TableEngine + ":SummingMergeTree:Column";

    #endregion

    #region AggregatingMergeTree

    public const string AggregatingMergeTree = "AggregatingMergeTree";

    #endregion

    #region CollapsingMergeTree

    public const string CollapsingMergeTree = "CollapsingMergeTree";

    public const string CollapsingMergeTreeSign = TableEngine + ":Sign";

    #endregion

    #region VersionedCollapsingMergeTree

    public const string VersionedCollapsingMergeTree = "VersionedCollapsingMergeTree";

    public const string VersionedCollapsingMergeTreeSign = TableEngine + ":Sign";

    public const string VersionedCollapsingMergeTreeVersion = TableEngine + ":Version";

    #endregion

    #region GraphiteMergeTree

    public const string GraphiteMergeTree = "GraphiteMergeTree";

    public const string GraphiteMergeTreeConfigSection = GraphiteMergeTree + ":ConfigSection";

    #endregion

    #region TinyLog

    public const string TinyLogEngine = "TinyLog";

    #endregion

    #region StripeLog

    public const string StripeLogEngine = "StripeLog";

    #endregion

    #region Log

    public const string LogEngine = "Log";

    #endregion
}
