namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPTFiltersInheritanceQueryClickHouseFixture : TPTInheritanceQueryClickHouseFixture
{
    protected override string StoreName => nameof(TPTFiltersInheritanceQueryClickHouseFixture);

    public override bool EnableFilters
        => true;
}
