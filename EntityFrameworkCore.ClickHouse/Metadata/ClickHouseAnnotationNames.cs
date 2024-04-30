namespace ClickHouse.EntityFrameworkCore.Metadata;

public static class ClickHouseAnnotationNames
{
    public const string Prefix = "ClickHouse:";

    public const string TableEngine = Prefix + "TableEngine";

    #region Merge tree

    public const string MergeTreeEngine = TableEngine + ":MergeTreeEngine";

    public const string MergeTreeOrderBy = MergeTreeEngine + ":OrderBy";

    public const string MergeTreePartitionBy = MergeTreeEngine + ":PartitionaBy";

    public const string MergeTreePrimaryKey = MergeTreeEngine + ":PrimaryKey";

    public const string MergeTreeSampleBy = MergeTreeEngine + ":SampleBy";

    #endregion

    #region StripeLog

    public const string StripeLogEngine = TableEngine + ":StripeLog";

    #endregion
}
