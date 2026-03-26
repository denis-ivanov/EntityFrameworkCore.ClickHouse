namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPHFiltersInheritanceQueryClickHouseFixture : TPHInheritanceQueryClickHouseFixture
{
    public override bool EnableFilters
        => true;
}
