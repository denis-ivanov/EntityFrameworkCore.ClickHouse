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

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Auto_initialized_view_set(bool async)
    {
        await base.Auto_initialized_view_set(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_correlated_with_keyless_entity_in_predicate_works(bool async)
    {
        await base.Collection_correlated_with_keyless_entity_in_predicate_works(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Count_over_keyless_entity(bool async)
    {
        await base.Count_over_keyless_entity(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Count_over_keyless_entity_with_pushdown(bool async)
    {
        await base.Count_over_keyless_entity_with_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Count_over_keyless_entity_with_pushdown_empty_projection(bool async)
    {
        await base.Count_over_keyless_entity_with_pushdown_empty_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Entity_mapped_to_view_on_right_side_of_join(bool async)
    {
        await base.Entity_mapped_to_view_on_right_side_of_join(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_by_database_view(bool async)
    {
        await base.KeylessEntity_by_database_view(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_groupby(bool async)
    {
        await base.KeylessEntity_groupby(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_select_where_navigation(bool async)
    {
        await base.KeylessEntity_select_where_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_select_where_navigation_multi_level(bool async)
    {
        await base.KeylessEntity_select_where_navigation_multi_level(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_simple(bool async)
    {
        await base.KeylessEntity_simple(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_where_simple(bool async)
    {
        await base.KeylessEntity_where_simple(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_with_defining_query(bool async)
    {
        await base.KeylessEntity_with_defining_query(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_with_included_nav(bool async)
    {
        await base.KeylessEntity_with_included_nav(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_with_mixed_tracking(bool async)
    {
        await base.KeylessEntity_with_mixed_tracking(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task KeylessEntity_with_nav_defining_query(bool async)
    {
        await base.KeylessEntity_with_nav_defining_query(async);
    }
}
