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

    public override async Task Where_compare_constructed_equal(bool async)
    {
        //  Anonymous type to constant comparison. Issue #14672.
        await AssertTranslationFailed(() => base.Where_compare_constructed_equal(async));

        AssertSql();
    }

    public override async Task Where_compare_constructed_multi_value_equal(bool async)
    {
        //  Anonymous type to constant comparison. Issue #14672.
        await AssertTranslationFailed(() => base.Where_compare_constructed_multi_value_equal(async));

        AssertSql();
    }

    public override async Task Where_compare_constructed_multi_value_not_equal(bool async)
    {
        //  Anonymous type to constant comparison. Issue #14672.
        await AssertTranslationFailed(() => base.Where_compare_constructed_multi_value_not_equal(async));

        AssertSql();
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_contains_on_navigation(bool async)
    {
        return base.Where_contains_on_navigation(async);
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

    /*
     * Re-write to
SELECT "c"."CustomerID",
       "o0"."CustomerID",
       "o0"."OrderID"
  FROM "Customers" AS "c"
 INNER
  JOIN
     ( SELECT DISTINCT "CustomerID"
         FROM "Orders" WHERE "CustomerID" = 'ALFKI'
     ) AS "subq"
    ON "c"."CustomerID" = "subq"."CustomerID"
  LEFT
  JOIN "Orders" AS "o0"
    ON "c"."CustomerID" = "o0"."CustomerID"
 ORDER BY "c"."CustomerID";
     */
    [ConditionalTheory(Skip = "")]
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

    [ConditionalTheory(Skip = "TBD"), MemberData(nameof(IsAsyncData))]
    public override Task Two_parameters_with_same_case_insensitive_name_get_uniquified(bool async)
    {
        return base.Two_parameters_with_same_case_insensitive_name_get_uniquified(async);
    }

    [ConditionalTheory(Skip = "TBD"), MemberData(nameof(IsAsyncData))]
    public override Task Using_same_parameter_twice_in_query_generates_one_sql_parameter(bool async)
    {
        return base.Using_same_parameter_twice_in_query_generates_one_sql_parameter(async);
    }

    [ConditionalTheory(Skip = "TBD"), MemberData(nameof(IsAsyncData))]
    public override Task Where_array_of_object_contains_over_value_type(bool async)
    {
        return base.Where_array_of_object_contains_over_value_type(async);
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}
