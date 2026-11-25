using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class SharedTypeQueryClickHouseTest : SharedTypeQueryRelationalTestBase
{
    public SharedTypeQueryClickHouseTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Ad_hoc_query_for_default_shared_type_entity_type_throws()
    {
        await base.Ad_hoc_query_for_default_shared_type_entity_type_throws();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Ad_hoc_query_for_shared_type_entity_type_works()
    {
        await base.Ad_hoc_query_for_shared_type_entity_type_works();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_shared_type_entity_type_in_query_filter(bool async)
    {
        await base.Can_use_shared_type_entity_type_in_query_filter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_shared_type_entity_type_in_query_filter_with_from_sql(bool async)
    {
        await base.Can_use_shared_type_entity_type_in_query_filter_with_from_sql(async);
    }

#if NET10_0
    protected override ITestStoreFactory TestStoreFactory
#else
    protected override ITestStoreFactory NonSharedTestStoreFactory
#endif
        => ClickHouseTestStoreFactory.Instance;
}
