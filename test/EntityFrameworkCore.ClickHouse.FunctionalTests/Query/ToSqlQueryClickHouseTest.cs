using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class ToSqlQueryClickHouseTest : ToSqlQueryTestBase
{
    public ToSqlQueryClickHouseTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Entity_type_with_navigation_mapped_to_SqlQuery(bool async)
    {
        await base.Entity_type_with_navigation_mapped_to_SqlQuery(async);
    }

    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;
}
