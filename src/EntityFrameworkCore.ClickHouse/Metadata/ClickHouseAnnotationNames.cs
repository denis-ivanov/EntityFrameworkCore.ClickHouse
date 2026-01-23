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

    public const string SummingMergeTreeColumns = TableEngine + ":SummingMergeTree:Columns";

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

    #region MyRegion

    public const string CoalescingMergeTree = "CoalescingMergeTree";

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

    // Integration engines
    public const string OdbcEngine = "ODBC";
    public const string JdbcEngine = "JDBC";
    public const string MySqlEngine = "MySQL";
    public const string MongoDbEngine = "MongoDB";
    public const string RedisEngine = "Redis";
    public const string HdfsEngine = "HDFS";
    public const string S3Engine = "S3";
    public const string Kafka = "Kafka";
    public const string EmbeddedRocksDb = "EmbeddedRocksDB";
    public const string RabbitMqEngine = "RabbitMQ";
    public const string PostgreSqlEngine = "PostgreSQL";
    public const string S3QueueEngine = "S3Queue";
    public const string TimeSeriesEngine = "TimeSeries";

    // Special Engines
    public const string DistributedEngine = "Distributed";
    public const string DictionaryEngine = "Dictionary";
    public const string MergeEngine = "Merge";
    public const string ExecutableEngine = "Executable";
    public const string FileEngine = "File";
    public const string NullEngine = "Null";
    public const string SetEngine = "Set";
    public const string JoinEngine = "Join";
    public const string UrlEngine = "URL";
    public const string ViewEngine = "View";
    public const string MemoryEngine = "Memory";
    public const string BufferEngine = "Buffer";
    public const string GenerateRandomEngine = "GenerateRandom";
    public const string KeeperMap = "KeeperMap";
    public const string FileLog = "FileLog";
}
