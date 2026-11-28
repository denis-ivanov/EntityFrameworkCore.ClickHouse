using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class EntitySplittingQueryClickHouseTest : EntitySplittingQueryTestBase
{
    public EntitySplittingQueryClickHouseTest(NonSharedFixture fixture) : base(fixture)
    {
    }
    
#if NET10_0
    protected override ITestStoreFactory TestStoreFactory
#else
    protected override ITestStoreFactory NonSharedTestStoreFactory
#endif
        => ClickHouseTestStoreFactory.Instance;

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_entity_which_is_split_in_three(bool async)
    {
        await base.Can_query_entity_which_is_split_in_three(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_entity_which_is_split_in_two(bool async)
    {
        await base.Can_query_entity_which_is_split_in_two(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_entity_which_is_split_selecting_only_main_properties(bool async)
    {
        await base.Can_query_entity_which_is_split_selecting_only_main_properties(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_entity_which_is_split_selecting_only_part_2_properties(bool async)
    {
        await base.Can_query_entity_which_is_split_selecting_only_part_2_properties(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_entity_which_is_split_selecting_only_part_3_properties(bool async)
    {
        await base.Can_query_entity_which_is_split_selecting_only_part_3_properties(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Custom_projection_trim_when_multiple_tables(bool async)
    {
        await base.Custom_projection_trim_when_multiple_tables(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_on_split_entity(bool async)
    {
        await base.Include_collection_on_split_entity(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_to_split_entity(bool async)
    {
        await base.Include_collection_to_split_entity(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_to_split_entity_including_collection(bool async)
    {
        await base.Include_collection_to_split_entity_including_collection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_on_split_entity(bool async)
    {
        await base.Include_reference_on_split_entity(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_to_split_entity(bool async)
    {
        await base.Include_reference_to_split_entity(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_reference_to_split_entity_including_reference(bool async)
    {
        await base.Include_reference_to_split_entity_including_reference(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Normal_entity_owning_a_split_collection(bool async)
    {
        await base.Normal_entity_owning_a_split_collection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Normal_entity_owning_a_split_reference_with_main_fragment_not_sharing(bool async)
    {
        await base.Normal_entity_owning_a_split_reference_with_main_fragment_not_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Normal_entity_owning_a_split_reference_with_main_fragment_not_sharing_custom_projection(bool async)
    {
        await base.Normal_entity_owning_a_split_reference_with_main_fragment_not_sharing_custom_projection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Normal_entity_owning_a_split_reference_with_main_fragment_sharing(bool async)
    {
        await base.Normal_entity_owning_a_split_reference_with_main_fragment_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Normal_entity_owning_a_split_reference_with_main_fragment_sharing_custom_projection(bool async)
    {
        await base.Normal_entity_owning_a_split_reference_with_main_fragment_sharing_custom_projection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Normal_entity_owning_a_split_reference_with_main_fragment_sharing_multiple_level(bool async)
    {
        await base.Normal_entity_owning_a_split_reference_with_main_fragment_sharing_multiple_level(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Split_entity_owning_a_collection(bool async)
    {
        await base.Split_entity_owning_a_collection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Split_entity_owning_a_reference(bool async)
    {
        await base.Split_entity_owning_a_reference(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Split_entity_owning_a_split_collection(bool async)
    {
        await base.Split_entity_owning_a_split_collection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Split_entity_owning_a_split_reference_with_table_sharing_1(bool async)
    {
        await base.Split_entity_owning_a_split_reference_with_table_sharing_1(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Split_entity_owning_a_split_reference_with_table_sharing_4(bool async)
    {
        await base.Split_entity_owning_a_split_reference_with_table_sharing_4(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Split_entity_owning_a_split_reference_with_table_sharing_6(bool async)
    {
        await base.Split_entity_owning_a_split_reference_with_table_sharing_6(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Split_entity_owning_a_split_reference_without_table_sharing(bool async)
    {
        await base.Split_entity_owning_a_split_reference_without_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpc_entity_owning_a_split_collection_on_base(bool async)
    {
        await base.Tpc_entity_owning_a_split_collection_on_base(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpc_entity_owning_a_split_collection_on_leaf(bool async)
    {
        await base.Tpc_entity_owning_a_split_collection_on_leaf(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpc_entity_owning_a_split_collection_on_middle(bool async)
    {
        await base.Tpc_entity_owning_a_split_collection_on_middle(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpc_entity_owning_a_split_reference_on_base_without_table_sharing(bool async)
    {
        await base.Tpc_entity_owning_a_split_reference_on_base_without_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpc_entity_owning_a_split_reference_on_leaf_with_table_sharing(bool async)
    {
        await base.Tpc_entity_owning_a_split_reference_on_leaf_with_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpc_entity_owning_a_split_reference_on_leaf_with_table_sharing_querying_sibling(bool async)
    {
        await base.Tpc_entity_owning_a_split_reference_on_leaf_with_table_sharing_querying_sibling(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpc_entity_owning_a_split_reference_on_leaf_without_table_sharing(bool async)
    {
        await base.Tpc_entity_owning_a_split_reference_on_leaf_without_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpc_entity_owning_a_split_reference_on_middle_without_table_sharing(bool async)
    {
        await base.Tpc_entity_owning_a_split_reference_on_middle_without_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tph_entity_owning_a_split_collection_on_base(bool async)
    {
        await base.Tph_entity_owning_a_split_collection_on_base(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tph_entity_owning_a_split_collection_on_leaf(bool async)
    {
        await base.Tph_entity_owning_a_split_collection_on_leaf(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tph_entity_owning_a_split_collection_on_middle(bool async)
    {
        await base.Tph_entity_owning_a_split_collection_on_middle(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tph_entity_owning_a_split_reference_on_base_with_table_sharing(bool async)
    {
        await base.Tph_entity_owning_a_split_reference_on_base_with_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tph_entity_owning_a_split_reference_on_base_with_table_sharing_querying_sibling(bool async)
    {
        await base.Tph_entity_owning_a_split_reference_on_base_with_table_sharing_querying_sibling(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tph_entity_owning_a_split_reference_on_base_without_table_sharing(bool async)
    {
        await base.Tph_entity_owning_a_split_reference_on_base_without_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tph_entity_owning_a_split_reference_on_leaf_with_table_sharing(bool async)
    {
        await base.Tph_entity_owning_a_split_reference_on_leaf_with_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tph_entity_owning_a_split_reference_on_leaf_with_table_sharing_querying_sibling(bool async)
    {
        await base.Tph_entity_owning_a_split_reference_on_leaf_with_table_sharing_querying_sibling(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tph_entity_owning_a_split_reference_on_leaf_without_table_sharing(bool async)
    {
        await base.Tph_entity_owning_a_split_reference_on_leaf_without_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tph_entity_owning_a_split_reference_on_middle_with_table_sharing(bool async)
    {
        await base.Tph_entity_owning_a_split_reference_on_middle_with_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tph_entity_owning_a_split_reference_on_middle_with_table_sharing_querying_sibling(bool async)
    {
        await base.Tph_entity_owning_a_split_reference_on_middle_with_table_sharing_querying_sibling(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tph_entity_owning_a_split_reference_on_middle_without_table_sharing(bool async)
    {
        await base.Tph_entity_owning_a_split_reference_on_middle_without_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpt_entity_owning_a_split_collection_on_base(bool async)
    {
        await base.Tpt_entity_owning_a_split_collection_on_base(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpt_entity_owning_a_split_collection_on_leaf(bool async)
    {
        await base.Tpt_entity_owning_a_split_collection_on_leaf(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpt_entity_owning_a_split_collection_on_middle(bool async)
    {
        await base.Tpt_entity_owning_a_split_collection_on_middle(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpt_entity_owning_a_split_reference_on_base_with_table_sharing(bool async)
    {
        await base.Tpt_entity_owning_a_split_reference_on_base_with_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpt_entity_owning_a_split_reference_on_base_with_table_sharing_querying_sibling(bool async)
    {
        await base.Tpt_entity_owning_a_split_reference_on_base_with_table_sharing_querying_sibling(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpt_entity_owning_a_split_reference_on_base_without_table_sharing(bool async)
    {
        await base.Tpt_entity_owning_a_split_reference_on_base_without_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpt_entity_owning_a_split_reference_on_leaf_with_table_sharing(bool async)
    {
        await base.Tpt_entity_owning_a_split_reference_on_leaf_with_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpt_entity_owning_a_split_reference_on_leaf_with_table_sharing_querying_sibling(bool async)
    {
        await base.Tpt_entity_owning_a_split_reference_on_leaf_with_table_sharing_querying_sibling(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpt_entity_owning_a_split_reference_on_leaf_without_table_sharing(bool async)
    {
        await base.Tpt_entity_owning_a_split_reference_on_leaf_without_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpt_entity_owning_a_split_reference_on_middle_with_table_sharing(bool async)
    {
        await base.Tpt_entity_owning_a_split_reference_on_middle_with_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpt_entity_owning_a_split_reference_on_middle_with_table_sharing_querying_sibling(bool async)
    {
        await base.Tpt_entity_owning_a_split_reference_on_middle_with_table_sharing_querying_sibling(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Tpt_entity_owning_a_split_reference_on_middle_without_table_sharing(bool async)
    {
        await base.Tpt_entity_owning_a_split_reference_on_middle_without_table_sharing(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Compare_split_entity_to_null(bool async)
    {
        await base.Compare_split_entity_to_null(async);
    }
}
