using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class OptionalDependentQueryClickHouseTest : OptionalDependentQueryTestBase<OptionalDependentQueryClickHouseFixture>
{
    public OptionalDependentQueryClickHouseTest(OptionalDependentQueryClickHouseFixture fixture) : base(fixture)
    {
    }
}
