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

public class TPTInheritanceQueryClickHouseTest : TPTInheritanceQueryTestBase<TPTInheritanceQueryClickHouseFixture>
{
    public TPTInheritanceQueryClickHouseTest(TPTInheritanceQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_all_animal_views(bool async)
    {
        await base.Can_query_all_animal_views(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Discriminator_used_when_projection_over_derived_type(bool async)
    {
        await base.Discriminator_used_when_projection_over_derived_type(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Discriminator_used_when_projection_over_derived_type2(bool async)
    {
        await base.Discriminator_used_when_projection_over_derived_type2(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Discriminator_used_when_projection_over_of_type(bool async)
    {
        await base.Discriminator_used_when_projection_over_of_type(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Discriminator_with_cast_in_shadow_property(bool async)
    {
        await base.Discriminator_with_cast_in_shadow_property(async);
    }

#if NET10_0
    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
#else
    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
#endif
    public override void Using_from_sql_throws()
    {
        base.Using_from_sql_throws();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_when_shared_column(bool async)
    {
        await base.Can_query_when_shared_column(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_all_types_when_shared_column(bool async)
    {
        await base.Can_query_all_types_when_shared_column(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_animal(bool async)
    {
        await base.Can_use_of_type_animal(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_is_kiwi(bool async)
    {
        await base.Can_use_is_kiwi(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_is_kiwi_with_cast(bool async)
    {
        await base.Can_use_is_kiwi_with_cast(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_backwards_is_animal(bool async)
    {
        await base.Can_use_backwards_is_animal(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_is_kiwi_with_other_predicate(bool async)
    {
        await base.Can_use_is_kiwi_with_other_predicate(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_is_kiwi_in_projection(bool async)
    {
        await base.Can_use_is_kiwi_in_projection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_bird(bool async)
    {
        await base.Can_use_of_type_bird(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_bird_predicate(bool async)
    {
        await base.Can_use_of_type_bird_predicate(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_bird_with_projection(bool async)
    {
        await base.Can_use_of_type_bird_with_projection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_bird_first(bool async)
    {
        await base.Can_use_of_type_bird_first(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_kiwi(bool async)
    {
        await base.Can_use_of_type_kiwi(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_backwards_of_type_animal(bool async)
    {
        await base.Can_use_backwards_of_type_animal(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_rose(bool async)
    {
        await base.Can_use_of_type_rose(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_all_animals(bool async)
    {
        await base.Can_query_all_animals(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_all_plants(bool async)
    {
        await base.Can_query_all_plants(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
#if NET10_0
    public override async Task Filter_on_property_inside_complex_type_on_derived_type(bool async)
    {
        await base.Filter_on_property_inside_complex_type_on_derived_type(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
#endif
    public override async Task Can_filter_all_animals(bool async)
    {
        await base.Can_filter_all_animals(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_all_birds(bool async)
    {
        await base.Can_query_all_birds(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_just_kiwis(bool async)
    {
        await base.Can_query_just_kiwis(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_just_roses(bool async)
    {
        await base.Can_query_just_roses(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_include_animals(bool async)
    {
        await base.Can_include_animals(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_include_prey(bool async)
    {
        await base.Can_include_prey(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_kiwi_where_south_on_derived_property(bool async)
    {
        await base.Can_use_of_type_kiwi_where_south_on_derived_property(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_kiwi_where_north_on_derived_property(bool async)
    {
        await base.Can_use_of_type_kiwi_where_north_on_derived_property(async);
    }

#if NET10_0
    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
#else
    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
#endif
    public override async Task Can_insert_update_delete()
    {
        await base.Can_insert_update_delete();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_siblings_with_duplicate_property_in_subquery(bool async)
    {
        await base.Union_siblings_with_duplicate_property_in_subquery(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OfType_Union_subquery(bool async)
    {
        await base.OfType_Union_subquery(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OfType_Union_OfType(bool async)
    {
        await base.OfType_Union_OfType(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_OfType(bool async)
    {
        await base.Subquery_OfType(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_entity_equality(bool async)
    {
        await base.Union_entity_equality(async);
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

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Byte_enum_value_constant_used_in_projection(bool async)
    {
        await base.Byte_enum_value_constant_used_in_projection(async);
    }

#if NET10_0
    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
#else
    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
#endif
    public override async Task Member_access_on_intermediate_type_works()
    {
        await base.Member_access_on_intermediate_type_works();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Is_operator_on_result_of_FirstOrDefault(bool async)
    {
        await base.Is_operator_on_result_of_FirstOrDefault(async);
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

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Using_is_operator_on_multiple_type_with_no_result(bool async)
    {
        await base.Using_is_operator_on_multiple_type_with_no_result(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Using_is_operator_with_of_type_on_multiple_type_with_no_result(bool async)
    {
        await base.Using_is_operator_with_of_type_on_multiple_type_with_no_result(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Using_OfType_on_multiple_type_with_no_result(bool async)
    {
        await base.Using_OfType_on_multiple_type_with_no_result(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetType_in_hierarchy_in_abstract_base_type(bool async)
    {
        await base.GetType_in_hierarchy_in_abstract_base_type(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetType_in_hierarchy_in_intermediate_type(bool async)
    {
        await base.GetType_in_hierarchy_in_intermediate_type(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetType_in_hierarchy_in_leaf_type_with_sibling(bool async)
    {
        await base.GetType_in_hierarchy_in_leaf_type_with_sibling(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetType_in_hierarchy_in_leaf_type_with_sibling2(bool async)
    {
        await base.GetType_in_hierarchy_in_leaf_type_with_sibling2(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetType_in_hierarchy_in_leaf_type_with_sibling2_reverse(bool async)
    {
        await base.GetType_in_hierarchy_in_leaf_type_with_sibling2_reverse(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GetType_in_hierarchy_in_leaf_type_with_sibling2_not_equal(bool async)
    {
        await base.GetType_in_hierarchy_in_leaf_type_with_sibling2_not_equal(async);
    }

    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());
}
