using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindWhereQueryClickHouseTest : NorthwindWhereQueryRelationalTestBase<
    NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindWhereQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task ElementAt_over_custom_projection_compared_to_not_null(bool async)
    {
        return base.ElementAt_over_custom_projection_compared_to_not_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task ElementAtOrDefault_over_custom_projection_compared_to_null(bool async)
    {
        return base.ElementAtOrDefault_over_custom_projection_compared_to_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task First_over_custom_projection_compared_to_not_null(bool async)
    {
        return base.First_over_custom_projection_compared_to_not_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task First_over_custom_projection_compared_to_null(bool async)
    {
        return base.First_over_custom_projection_compared_to_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task FirstOrDefault_over_custom_projection_compared_to_not_null(bool async)
    {
        return base.FirstOrDefault_over_custom_projection_compared_to_not_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task FirstOrDefault_over_custom_projection_compared_to_null(bool async)
    {
        return base.FirstOrDefault_over_custom_projection_compared_to_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task FirstOrDefault_over_scalar_projection_compared_to_not_null(bool async)
    {
        return base.FirstOrDefault_over_scalar_projection_compared_to_not_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task FirstOrDefault_over_scalar_projection_compared_to_null(bool async)
    {
        return base.FirstOrDefault_over_scalar_projection_compared_to_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Last_over_custom_projection_compared_to_not_null(bool async)
    {
        return base.Last_over_custom_projection_compared_to_not_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Last_over_custom_projection_compared_to_null(bool async)
    {
        return base.Last_over_custom_projection_compared_to_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task LastOrDefault_over_custom_projection_compared_to_not_null(bool async)
    {
        return base.LastOrDefault_over_custom_projection_compared_to_not_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task LastOrDefault_over_custom_projection_compared_to_null(bool async)
    {
        return base.LastOrDefault_over_custom_projection_compared_to_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Single_over_custom_projection_compared_to_not_null(bool async)
    {
        return base.Single_over_custom_projection_compared_to_not_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Single_over_custom_projection_compared_to_null(bool async)
    {
        return base.Single_over_custom_projection_compared_to_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task SingleOrDefault_over_custom_projection_compared_to_not_null(bool async)
    {
        return base.SingleOrDefault_over_custom_projection_compared_to_not_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task SingleOrDefault_over_custom_projection_compared_to_null(bool async)
    {
        return base.SingleOrDefault_over_custom_projection_compared_to_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_as_queryable_expression(bool async)
    {
        return base.Where_as_queryable_expression(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [InlineData(false)]
    public override Task Where_bitwise_xor(bool async)
    {
        return base.Where_bitwise_xor(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_collection_navigation_AsEnumerable_Contains(bool async)
    {
        return base.Where_collection_navigation_AsEnumerable_Contains(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_collection_navigation_AsEnumerable_Count(bool async)
    {
        return base.Where_collection_navigation_AsEnumerable_Count(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_collection_navigation_ToArray_Contains(bool async)
    {
        return base.Where_collection_navigation_ToArray_Contains(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_collection_navigation_ToArray_Count(bool async)
    {
        return base.Where_collection_navigation_ToArray_Count(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_collection_navigation_ToArray_Length_member(bool async)
    {
        return base.Where_collection_navigation_ToArray_Length_member(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_collection_navigation_ToList_Contains(bool async)
    {
        return base.Where_collection_navigation_ToList_Contains(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_collection_navigation_ToList_Count(bool async)
    {
        return base.Where_collection_navigation_ToList_Count(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_collection_navigation_ToList_Count_member(bool async)
    {
        return base.Where_collection_navigation_ToList_Count_member(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_compare_constructed_equal(bool async)
    {
        return base.Where_compare_constructed_equal(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_compare_constructed_multi_value_equal(bool async)
    {
        return base.Where_compare_constructed_multi_value_equal(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_compare_constructed_multi_value_not_equal(bool async)
    {
        return base.Where_compare_constructed_multi_value_not_equal(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_compare_tuple_constructed_equal(bool async)
    {
        return base.Where_compare_tuple_constructed_equal(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_compare_tuple_constructed_multi_value_equal(bool async)
    {
        return base.Where_compare_tuple_constructed_multi_value_equal(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_compare_tuple_constructed_multi_value_not_equal(bool async)
    {
        return base.Where_compare_tuple_constructed_multi_value_not_equal(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_contains_on_navigation(bool async)
    {
        return base.Where_contains_on_navigation(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_datetime_millisecond_component(bool async)
    {
        return base.Where_datetime_millisecond_component(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_datetimeoffset_now_component(bool async)
    {
        return base.Where_datetimeoffset_now_component(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_datetimeoffset_utcnow(bool async)
    {
        return base.Where_datetimeoffset_utcnow(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_datetimeoffset_utcnow_component(bool async)
    {
        return base.Where_datetimeoffset_utcnow_component(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_method_call_nullable_type_closure_via_query_cache(bool async)
    {
        return base.Where_method_call_nullable_type_closure_via_query_cache(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_Queryable_AsEnumerable_Contains(bool async)
    {
        return base.Where_Queryable_AsEnumerable_Contains(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_Queryable_AsEnumerable_Contains_negated(bool async)
    {
        return base.Where_Queryable_AsEnumerable_Contains_negated(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_Queryable_AsEnumerable_Count(bool async)
    {
        return base.Where_Queryable_AsEnumerable_Count(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_Queryable_ToArray_Contains(bool async)
    {
        return base.Where_Queryable_ToArray_Contains(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_Queryable_ToArray_Count(bool async)
    {
        return base.Where_Queryable_ToArray_Count(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_Queryable_ToArray_Length_member(bool async)
    {
        return base.Where_Queryable_ToArray_Length_member(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_Queryable_ToList_Contains(bool async)
    {
        return base.Where_Queryable_ToList_Contains(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_Queryable_ToList_Count(bool async)
    {
        return base.Where_Queryable_ToList_Count(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_Queryable_ToList_Count_member(bool async)
    {
        return base.Where_Queryable_ToList_Count_member(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_simple_closure_via_query_cache_nullable_type(bool async)
    {
        return base.Where_simple_closure_via_query_cache_nullable_type(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_simple_closure_via_query_cache_nullable_type_reverse(bool async)
    {
        return base.Where_simple_closure_via_query_cache_nullable_type_reverse(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_subquery_closure_via_query_cache(bool async)
    {
        return base.Where_subquery_closure_via_query_cache(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_subquery_correlated(bool async)
    {
        return base.Where_subquery_correlated(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_subquery_FirstOrDefault_compared_to_entity(bool async)
    {
        return base.Where_subquery_FirstOrDefault_compared_to_entity(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_subquery_FirstOrDefault_is_null(bool async)
    {
        return base.Where_subquery_FirstOrDefault_is_null(async);
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Skip_and_Where_evaluation_order(bool async)
    {
        return base.Skip_and_Where_evaluation_order(async);
    }
}
