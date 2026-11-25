namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPHFiltersInheritanceQueryClickHouseFixture : TPHInheritanceQueryClickHouseFixture
{
    protected override string StoreName => nameof(TPHFiltersInheritanceQueryClickHouseFixture);

    public override bool EnableFilters
        => true;
}
