using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindKeylessEntitiesQueryClickHouseTest : NorthwindKeylessEntitiesQueryRelationalTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindKeylessEntitiesQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Auto_initialized_view_set(bool async)
    {
        await base.Auto_initialized_view_set(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_correlated_with_keyless_entity_in_predicate_works(bool async)
    {
        await base.Collection_correlated_with_keyless_entity_in_predicate_works(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Count_over_keyless_entity(bool async)
    {
        await base.Count_over_keyless_entity(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Count_over_keyless_entity_with_pushdown(bool async)
    {
        await base.Count_over_keyless_entity_with_pushdown(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Count_over_keyless_entity_with_pushdown_empty_projection(bool async)
    {
        await base.Count_over_keyless_entity_with_pushdown_empty_projection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Entity_mapped_to_view_on_right_side_of_join(bool async)
    {
        await base.Entity_mapped_to_view_on_right_side_of_join(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_by_database_view(bool async)
    {
        await base.KeylessEntity_by_database_view(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_groupby(bool async)
    {
        await base.KeylessEntity_groupby(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_select_where_navigation(bool async)
    {
        await base.KeylessEntity_select_where_navigation(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_select_where_navigation_multi_level(bool async)
    {
        await base.KeylessEntity_select_where_navigation_multi_level(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_simple(bool async)
    {
        await base.KeylessEntity_simple(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_where_simple(bool async)
    {
        await base.KeylessEntity_where_simple(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_with_defining_query(bool async)
    {
        await base.KeylessEntity_with_defining_query(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_with_included_nav(bool async)
    {
        await base.KeylessEntity_with_included_nav(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_with_mixed_tracking(bool async)
    {
        await base.KeylessEntity_with_mixed_tracking(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_with_nav_defining_query(bool async)
    {
        await base.KeylessEntity_with_nav_defining_query(async);
    }
}
