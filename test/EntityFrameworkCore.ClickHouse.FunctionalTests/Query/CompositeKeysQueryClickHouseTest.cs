using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class CompositeKeysQueryClickHouseTest : CompositeKeysQueryRelationalTestBase<CompositeKeysQueryClickHouseFixture>
{
    public CompositeKeysQueryClickHouseTest(CompositeKeysQueryClickHouseFixture fixture)
        : base(fixture)
    {
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_collections_multi_level(bool async)
    {
        await base.Projecting_collections_multi_level(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_multiple_collections_on_multiple_levels_no_explicit_ordering(bool async)
    {
        await base.Projecting_multiple_collections_on_multiple_levels_no_explicit_ordering(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_multiple_collections_on_multiple_levels_some_explicit_ordering(bool async)
    {
        await base.Projecting_multiple_collections_on_multiple_levels_some_explicit_ordering(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_multiple_collections_same_level_top_level_ordering(bool async)
    {
        await base.Projecting_multiple_collections_same_level_top_level_ordering(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_multiple_collections_same_level_top_level_ordering_using_entire_composite_key(bool async)
    {
        await base.Projecting_multiple_collections_same_level_top_level_ordering_using_entire_composite_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_multiple_collections_with_ordering_same_level(bool async)
    {
        await base.Projecting_multiple_collections_with_ordering_same_level(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_multiple_collections_with_ordering_same_level_top_level_ordering(bool async)
    {
        await base.Projecting_multiple_collections_with_ordering_same_level_top_level_ordering(async);
    }
}