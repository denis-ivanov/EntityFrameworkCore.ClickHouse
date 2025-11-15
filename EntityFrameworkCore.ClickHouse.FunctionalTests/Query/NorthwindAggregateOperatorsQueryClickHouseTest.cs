using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindAggregateOperatorsQueryClickHouseTest : NorthwindAggregateOperatorsQueryRelationalTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindAggregateOperatorsQueryClickHouseTest(
        NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        ClearLog();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Average_no_data_subquery(bool async)
    {
        return base.Average_no_data_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Average_on_float_column_in_subquery(bool async)
    {
        return base.Average_on_float_column_in_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Average_on_float_column_in_subquery_with_cast(bool async)
    {
        return base.Average_on_float_column_in_subquery_with_cast(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Average_on_nav_subquery_in_projection(bool async)
    {
        return base.Average_on_nav_subquery_in_projection(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Cast_before_aggregate_is_preserved(bool async)
    {
        return base.Cast_before_aggregate_is_preserved(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Collection_Last_member_access_in_projection_translated(bool async)
    {
        return base.Collection_Last_member_access_in_projection_translated(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Collection_LastOrDefault_member_access_in_projection_translated(bool async)
    {
        return base.Collection_LastOrDefault_member_access_in_projection_translated(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Contains_over_entityType_should_materialize_when_composite(bool async)
    {
        return base.Contains_over_entityType_should_materialize_when_composite(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Contains_over_entityType_should_materialize_when_composite2(bool async)
    {
        return base.Contains_over_entityType_should_materialize_when_composite2(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Contains_over_keyless_entity_throws(bool async)
    {
        return base.Contains_over_keyless_entity_throws(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Contains_with_local_anonymous_type_array_closure(bool async)
    {
        return base.Contains_with_local_anonymous_type_array_closure(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Contains_with_local_enumerable_inline(bool async)
    {
        return base.Contains_with_local_enumerable_inline(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Contains_with_local_enumerable_inline_closure_mix(bool async)
    {
        return base.Contains_with_local_enumerable_inline_closure_mix(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Contains_with_local_tuple_array_closure(bool async)
    {
        return base.Contains_with_local_tuple_array_closure(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Contains_with_subquery_and_local_array_closure(bool async)
    {
        return base.Contains_with_subquery_and_local_array_closure(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Enumerable_min_is_mapped_to_Queryable_1(bool async)
    {
        return base.Enumerable_min_is_mapped_to_Queryable_1(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Enumerable_min_is_mapped_to_Queryable_2(bool async)
    {
        return base.Enumerable_min_is_mapped_to_Queryable_2(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task First_inside_subquery_gets_client_evaluated(bool async)
    {
        return base.First_inside_subquery_gets_client_evaluated(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task FirstOrDefault_inside_subquery_gets_server_evaluated(bool async)
    {
        return base.FirstOrDefault_inside_subquery_gets_server_evaluated(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task List_Contains_over_entityType_should_rewrite_to_identity_equality(bool async)
    {
        return base.List_Contains_over_entityType_should_rewrite_to_identity_equality(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Max_no_data_subquery(bool async)
    {
        return base.Max_no_data_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Min_no_data_cast_to_nullable(bool async)
    {
        return base.Min_no_data_cast_to_nullable(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Min_no_data_nullable(bool async)
    {
        return base.Min_no_data_nullable(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Min_no_data_subquery(bool async)
    {
        return base.Min_no_data_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Multiple_collection_navigation_with_FirstOrDefault_chained(bool async)
    {
        return base.Multiple_collection_navigation_with_FirstOrDefault_chained(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Multiple_collection_navigation_with_FirstOrDefault_chained_projecting_scalar(bool async)
    {
        return base.Multiple_collection_navigation_with_FirstOrDefault_chained_projecting_scalar(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Max_no_data_cast_to_nullable(bool async)
    {
        return base.Max_no_data_cast_to_nullable(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Max_no_data_nullable(bool async)
    {
        return base.Max_no_data_nullable(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task OrderBy_Skip_Last_gives_correct_result(bool async)
    {
        return base.OrderBy_Skip_Last_gives_correct_result(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Sum_on_float_column_in_subquery(bool async)
    {
        return base.Sum_on_float_column_in_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Average_over_max_subquery(bool async)
    {
        return base.Average_over_max_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Average_over_nested_subquery(bool async)
    {
        return base.Average_over_nested_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Average_over_subquery(bool async)
    {
        return base.Average_over_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Max_over_nested_subquery(bool async)
    {
        return base.Max_over_nested_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Max_over_subquery(bool async)
    {
        return base.Max_over_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Max_over_sum_subquery(bool async)
    {
        return base.Max_over_sum_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Min_over_max_subquery(bool async)
    {
        return base.Min_over_max_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Min_over_nested_subquery(bool async)
    {
        return base.Min_over_nested_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Min_over_subquery(bool async)
    {
        return base.Min_over_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Sum_over_Any_subquery(bool async)
    {
        return base.Sum_over_Any_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Sum_over_min_subquery(bool async)
    {
        return base.Sum_over_min_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Sum_over_nested_subquery(bool async)
    {
        return base.Sum_over_nested_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Sum_over_scalar_returning_subquery(bool async)
    {
        return base.Sum_over_scalar_returning_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Sum_over_subquery(bool async)
    {
        return base.Sum_over_subquery(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Type_casting_inside_sum(bool async)
    {
        return base.Type_casting_inside_sum(async);
    }

    [ConditionalTheory(Skip = "TBD"), MemberData(nameof(IsAsyncData))]
    public override Task Average_after_DefaultIfEmpty_does_not_throw(bool async)
    {
        return base.Average_after_DefaultIfEmpty_does_not_throw(async);
    }

    [ConditionalTheory(Skip = "TBD"), MemberData(nameof(IsAsyncData))]
    public override Task Contains_with_local_collection_complex_predicate_and(bool async)
    {
        return base.Contains_with_local_collection_complex_predicate_and(async);
    }

    [ConditionalTheory(Skip = "TBD"), MemberData(nameof(IsAsyncData))]
    public override Task Contains_with_local_collection_complex_predicate_not_matching_ins1(bool async)
    {
        return base.Contains_with_local_collection_complex_predicate_not_matching_ins1(async);
    }

    [ConditionalTheory(Skip = "TBD"), MemberData(nameof(IsAsyncData))]
    public override Task Contains_with_local_collection_complex_predicate_not_matching_ins2(bool async)
    {
        return base.Contains_with_local_collection_complex_predicate_not_matching_ins2(async);
    }

    [ConditionalTheory(Skip = "TBD"), MemberData(nameof(IsAsyncData))]
    public override Task Contains_with_local_collection_false(bool async)
    {
        return base.Contains_with_local_collection_false(async);
    }

    [ConditionalTheory(Skip = "TBD"), MemberData(nameof(IsAsyncData))]
    public override Task Contains_with_local_collection_sql_injection(bool async)
    {
        return base.Contains_with_local_collection_sql_injection(async);
    }

    [ConditionalTheory(Skip = "TBD"), MemberData(nameof(IsAsyncData))]
    public override Task Contains_with_local_nullable_uint_array_closure(bool async)
    {
        return base.Contains_with_local_nullable_uint_array_closure(async);
    }

    [ConditionalTheory(Skip = "TBD"), MemberData(nameof(IsAsyncData))]
    public override Task Where_subquery_where_any(bool async)
    {
        return base.Where_subquery_where_any(async);
    }
}
