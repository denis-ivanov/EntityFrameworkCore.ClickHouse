namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPCFiltersInheritanceQueryClickHouseFixture : TPCInheritanceQueryClickHouseFixture
{
    protected override string StoreName => nameof(TPCFiltersInheritanceQueryClickHouseFixture);

    public override bool EnableFilters
        => true;

    public override bool UseGeneratedKeys
        => false;
}
