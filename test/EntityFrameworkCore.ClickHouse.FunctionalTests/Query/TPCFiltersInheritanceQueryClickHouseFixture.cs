namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPCFiltersInheritanceQueryClickHouseFixture : TPCInheritanceQueryClickHouseFixture
{
    public override bool EnableFilters
        => true;

    public override bool UseGeneratedKeys
        => false;
}
