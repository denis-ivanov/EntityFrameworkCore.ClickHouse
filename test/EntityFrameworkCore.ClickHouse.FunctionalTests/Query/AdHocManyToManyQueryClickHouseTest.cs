using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class AdHocManyToManyQueryClickHouseTest : AdHocManyToManyQueryRelationalTestBase
{
    public AdHocManyToManyQueryClickHouseTest(NonSharedFixture fixture) : base(fixture)
    {
    }
    
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_with_collection_selector_having_subquery()
    {
        await base.SelectMany_with_collection_selector_having_subquery();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Many_to_many_load_works_when_join_entity_has_custom_key(bool async)
    {
        await base.Many_to_many_load_works_when_join_entity_has_custom_key(async);
    }
}
