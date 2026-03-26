namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPTFiltersInheritanceQueryClickHouseFixture : TPTInheritanceQueryClickHouseFixture
{
    public override bool EnableFilters
        => true;
}
