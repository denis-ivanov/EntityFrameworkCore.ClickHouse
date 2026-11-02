using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class OwnedQueryClickHouseTest : OwnedQueryRelationalTestBase<OwnedQueryClickHouseTest.OwnedQueryClickHouseFixture>
{
    public OwnedQueryClickHouseTest(OwnedQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_on_indexer_properties_split(bool async)
    {
        await base.Can_query_on_indexer_properties_split(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_multiple_owned_navigations_split(bool async)
    {
        await base.Project_multiple_owned_navigations_split(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_for_base_type_loads_all_owned_navs_split(bool async)
    {
        await base.Query_for_base_type_loads_all_owned_navs_split(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_for_branch_type_loads_all_owned_navs_split(bool async)
    {
        await base.Query_for_branch_type_loads_all_owned_navs_split(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_when_subquery_split(bool async)
    {
        await base.Query_when_subquery_split(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_with_OfType_eagerly_loads_correct_owned_navigations_split(bool async)
    {
        await base.Query_with_OfType_eagerly_loads_correct_owned_navigations_split(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Any_with_predicate_over_owned_collection(bool async)
    {
        await base.Any_with_predicate_over_owned_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Any_without_predicate_over_owned_collection(bool async)
    {
        await base.Any_without_predicate_over_owned_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_OrderBy_indexer_properties(bool async)
    {
        await base.Can_OrderBy_indexer_properties(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_owner_with_different_owned_types_having_same_property_name_in_hierarchy(bool async)
    {
        await base.Can_query_owner_with_different_owned_types_having_same_property_name_in_hierarchy(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_method_skip_loads_owned_navigations(bool async)
    {
        await base.Client_method_skip_loads_owned_navigations(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_on_indexer_properties(bool async)
    {
        await base.Can_query_on_indexer_properties(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_method_skip_loads_owned_navigations_variation_2(bool async)
    {
        await base.Client_method_skip_loads_owned_navigations_variation_2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_method_skip_take_loads_owned_navigations(bool async)
    {
        await base.Client_method_skip_take_loads_owned_navigations(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_method_skip_take_loads_owned_navigations_variation_2(bool async)
    {
        await base.Client_method_skip_take_loads_owned_navigations_variation_2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_method_take_loads_owned_navigations(bool async)
    {
        await base.Client_method_take_loads_owned_navigations(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_method_take_loads_owned_navigations_variation_2(bool async)
    {
        await base.Client_method_take_loads_owned_navigations_variation_2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Count_over_owned_collection(bool async)
    {
        await base.Count_over_owned_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Distinct_over_owned_collection(bool async)
    {
        await base.Distinct_over_owned_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_on_indexer_using_closure(bool async)
    {
        await base.Filter_on_indexer_using_closure(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Left_join_on_entity_with_owned_navigations(bool async)
    {
        await base.Left_join_on_entity_with_owned_navigations(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Left_join_on_entity_with_owned_navigations_complex(bool async)
    {
        await base.Left_join_on_entity_with_owned_navigations_complex(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_rewrite_on_owned_reference_followed_by_regular_entity_and_another_reference(bool async)
    {
        await base.Navigation_rewrite_on_owned_reference_followed_by_regular_entity_and_another_reference(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_rewrite_on_owned_reference_followed_by_regular_entity_and_another_reference_in_predicate_and_projection(bool async)
    {
        await base.Navigation_rewrite_on_owned_reference_followed_by_regular_entity_and_another_reference_in_predicate_and_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_for_base_type_loads_all_owned_navs(bool async)
    {
        await base.Query_for_base_type_loads_all_owned_navs(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_for_branch_type_loads_all_owned_navs(bool async)
    {
        await base.Query_for_branch_type_loads_all_owned_navs(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_for_branch_type_loads_all_owned_navs_tracking(bool async)
    {
        await base.Query_for_branch_type_loads_all_owned_navs_tracking(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_for_leaf_type_loads_all_owned_navs(bool async)
    {
        await base.Query_for_leaf_type_loads_all_owned_navs(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_when_subquery(bool async)
    {
        await base.Query_when_subquery(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_owned_reference_navigation_which_owns_additional(bool async)
    {
        await base.Project_owned_reference_navigation_which_owns_additional(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_rewrite_on_owned_reference_projecting_entity(bool async)
    {
        await base.Navigation_rewrite_on_owned_reference_projecting_entity(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_multiple_owned_navigations(bool async)
    {
        await base.Project_multiple_owned_navigations(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_rewrite_on_owned_reference_followed_by_regular_entity_filter(bool async)
    {
        await base.Navigation_rewrite_on_owned_reference_followed_by_regular_entity_filter(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Navigation_rewrite_on_owned_reference_followed_by_regular_entity_and_collection_count(bool async)
    {
        await base.Navigation_rewrite_on_owned_reference_followed_by_regular_entity_and_collection_count(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_with_OfType_eagerly_loads_correct_owned_navigations(bool async)
    {
        await base.Query_with_OfType_eagerly_loads_correct_owned_navigations(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_loads_reference_nav_automatically_in_projection(bool async)
    {
        await base.Query_loads_reference_nav_automatically_in_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Preserve_includes_when_applying_skip_take_after_anonymous_type_select(bool async)
    {
        await base.Preserve_includes_when_applying_skip_take_after_anonymous_type_select(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_owned_collection_navigation_ToList_Count(bool async)
    {
        await base.Where_owned_collection_navigation_ToList_Count(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_collection_navigation_ToArray_Count(bool async)
    {
        await base.Where_collection_navigation_ToArray_Count(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_collection_navigation_AsEnumerable_Count(bool async)
    {
        await base.Where_collection_navigation_AsEnumerable_Count(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_collection_navigation_ToList_Count_member(bool async)
    {
        await base.Where_collection_navigation_ToList_Count_member(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_collection_navigation_ToArray_Length_member(bool async)
    {
        await base.Where_collection_navigation_ToArray_Length_member(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task NoTracking_Include_with_cycles_throws(bool async)
    {
        await base.NoTracking_Include_with_cycles_throws(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Ordering_by_identifying_projection(bool async)
    {
        await base.Ordering_by_identifying_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Simple_query_entity_with_owned_collection(bool async)
    {
        await base.Simple_query_entity_with_owned_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OrderBy_ElementAt_over_owned_collection(bool async)
    {
        await base.OrderBy_ElementAt_over_owned_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_over_owned_collection(bool async)
    {
        await base.Union_over_owned_collection(async);
    }

    public class OwnedQueryClickHouseFixture : RelationalOwnedQueryFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;
    }
}
