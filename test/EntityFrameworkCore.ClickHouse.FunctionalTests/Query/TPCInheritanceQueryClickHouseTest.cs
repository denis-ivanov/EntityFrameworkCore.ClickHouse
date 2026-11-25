using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
#if NET11_0_OR_GREATER
using Microsoft.EntityFrameworkCore.Query.Inheritance;
#endif
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPCInheritanceQueryClickHouseTest : TPCInheritanceQueryTestBase<TPCInheritanceQueryClickHouseFixture>
{
    public TPCInheritanceQueryClickHouseTest(TPCInheritanceQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_include_prey(bool async)
    {
        await base.Can_include_prey(async);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_insert_update_delete()
    {
        await base.Can_insert_update_delete();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_all_birds(bool async)
    {
        await base.Can_query_all_birds(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_is_kiwi_in_projection(bool async)
    {
        await base.Can_use_is_kiwi_in_projection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_is_kiwi_with_cast(bool async)
    {
        await base.Can_use_is_kiwi_with_cast(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_animal(bool async)
    {
        await base.Can_use_of_type_animal(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_bird(bool async)
    {
        await base.Can_use_of_type_bird(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_bird_with_projection(bool async)
    {
        await base.Can_use_of_type_bird_with_projection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetType_in_hierarchy_in_leaf_type_with_sibling(bool async)
    {
        await base.GetType_in_hierarchy_in_leaf_type_with_sibling(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Selecting_only_base_properties_on_base_type(bool async)
    {
        await base.Selecting_only_base_properties_on_base_type(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Selecting_only_base_properties_on_derived_type(bool async)
    {
        await base.Selecting_only_base_properties_on_derived_type(async);
    }

#if NET10_0
    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
#else
    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
#endif
    public override async Task Setting_foreign_key_to_a_different_type_throws()
    {
        await base.Setting_foreign_key_to_a_different_type_throws();
    }

    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());
}
