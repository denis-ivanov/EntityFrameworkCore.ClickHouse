using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

// TODO Wait for dotnet 11.
public abstract class AdHocMiscellaneousQueryClickHouseTest : AdHocMiscellaneousQueryRelationalTestBase
{
    public AdHocMiscellaneousQueryClickHouseTest(NonSharedFixture fixture) : base(fixture)
    {
    }
    
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;

    protected override DbContextOptionsBuilder SetParameterizedCollectionMode(DbContextOptionsBuilder optionsBuilder,
        ParameterTranslationMode parameterizedCollectionMode)
    {
        return optionsBuilder;
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Check_inlined_constants_redacting(bool async, bool enableSensitiveDataLogging)
    {
        await base.Check_inlined_constants_redacting(async, enableSensitiveDataLogging);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task GroupBy_Aggregate_over_navigations_repeated(bool async)
    {
        await base.GroupBy_Aggregate_over_navigations_repeated(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Enum_has_flag_applies_explicit_cast_for_constant()
    {
        await base.Enum_has_flag_applies_explicit_cast_for_constant();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Enum_with_value_converter_matching_take_value(bool async)
    {
        await base.Enum_with_value_converter_matching_take_value(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_first_member_compared_to_null(bool async)
    {
        await base.Subquery_first_member_compared_to_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Aggregate_over_subquery_in_group_by_projection_2(bool async)
    {
        await base.Aggregate_over_subquery_in_group_by_projection_2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Unwrap_convert_node_over_projection_when_translating_contains_over_subquery_2(bool async)
    {
        await base.Unwrap_convert_node_over_projection_when_translating_contains_over_subquery_2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_where_Select(bool async)
    {
        await base.SelectMany_where_Select(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_and_insert_works_correctly_together()
    {
        await base.Union_and_insert_works_correctly_together();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Bool_discriminator_column_works(bool async)
    {
        await base.Bool_discriminator_column_works(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task First_FirstOrDefault_ix_async()
    {
        await base.First_FirstOrDefault_ix_async();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Null_check_removal_in_ternary_maintain_appropriate_cast(bool async)
    {
        await base.Null_check_removal_in_ternary_maintain_appropriate_cast(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Operators_combine_nullability_of_entity_shapers()
    {
        await base.Operators_combine_nullability_of_entity_shapers();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameterless_ctor_on_inner_DTO_gets_called_for_every_row()
    {
        await base.Parameterless_ctor_on_inner_DTO_gets_called_for_every_row();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task QueryBuffer_requirement_is_computed_when_querying_base_type_while_derived_type_has_shadow_prop()
    {
        await base.QueryBuffer_requirement_is_computed_when_querying_base_type_while_derived_type_has_shadow_prop();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Repeated_parameters_in_generated_query_sql()
    {
        await base.Repeated_parameters_in_generated_query_sql();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Aggregate_over_subquery_in_group_by_projection(bool async)
    {
        await base.Aggregate_over_subquery_in_group_by_projection(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Mapping_JsonElement_property_throws_a_meaningful_exception()
    {
        await base.Mapping_JsonElement_property_throws_a_meaningful_exception();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_aggregate_in_subquery_projection_after_group_by(bool async)
    {
        await base.Group_by_aggregate_in_subquery_projection_after_group_by(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_different_entity_type_from_different_namespaces(bool async)
    {
        await base.Multiple_different_entity_type_from_different_namespaces(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Discriminator_type_is_handled_correctly()
    {
        await base.Discriminator_type_is_handled_correctly();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Unwrap_convert_node_over_projection_when_translating_contains_over_subquery(bool async)
    {
        await base.Unwrap_convert_node_over_projection_when_translating_contains_over_subquery(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Enum_has_flag_does_not_apply_explicit_cast_for_non_constant()
    {
        await base.Enum_has_flag_does_not_apply_explicit_cast_for_non_constant();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Shadow_property_with_inheritance()
    {
        await base.Shadow_property_with_inheritance();
    }

    // TODO Wait for dotnet 11.
    // [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    // public override async Task Query_when_null_key_in_database_should_throw()
    // {
    //     await base.Query_when_null_key_in_database_should_throw();
    // }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Conditional_expression_with_conditions_does_not_collapse_if_nullable_bool()
    {
        await base.Conditional_expression_with_conditions_does_not_collapse_if_nullable_bool();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task New_instances_in_projection_are_not_shared_across_results()
    {
        await base.New_instances_in_projection_are_not_shared_across_results();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Unwrap_convert_node_over_projection_when_translating_contains_over_subquery_3(bool async)
    {
        await base.Unwrap_convert_node_over_projection_when_translating_contains_over_subquery_3(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Average_with_cast()
    {
        await base.Average_with_cast();
    }

    protected override Task Seed2951(Context2951 context)
    {
        return Task.CompletedTask;
    }
}
