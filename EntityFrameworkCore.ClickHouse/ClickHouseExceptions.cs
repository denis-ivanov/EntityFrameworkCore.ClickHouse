namespace ClickHouse.EntityFrameworkCore;

internal static class ClickHouseExceptions
{
    public const string DoesNotSupportSequences = "ClickHouse does not support sequences";
    public const string DoesNotSupportSchemas = "ClickHouse does not support schemas";
    public const string DoesNotSupportUniqueConstraints = "ClickHouse does not support unique constraints";
    public const string DoesNotSupportUniqueIndexes = "ClickHouse does not support unique indexes";
}
