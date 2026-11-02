using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class PrecompiledQueryClickHouseTest : PrecompiledQueryRelationalTestBase, IClassFixture<PrecompiledQueryClickHouseTest.PrecompiledQueryClickHouseFixture>
{
    public PrecompiledQueryClickHouseTest(PrecompiledQueryRelationalFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task BinaryExpression()
    {
        await base.BinaryExpression();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Concat()
    {
        await base.Concat();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Conditional_contains_captured_variable()
    {
        await base.Conditional_contains_captured_variable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Conditional_no_evaluatable()
    {
        await base.Conditional_no_evaluatable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_with_parameterized_collection()
    {
        await base.Contains_with_parameterized_collection();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DbContext_as_captured_variable()
    {
        await base.DbContext_as_captured_variable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DbContext_as_field()
    {
        await base.DbContext_as_field();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DbContext_as_local_variable()
    {
        await base.DbContext_as_local_variable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DbContext_as_method_invocation_result()
    {
        await base.DbContext_as_method_invocation_result();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Dynamic_query_does_not_get_precompiled()
    {
        await base.Dynamic_query_does_not_get_precompiled();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task EF_Constant_is_not_supported()
    {
        await base.EF_Constant_is_not_supported();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DbContext_as_property()
    {
        await base.DbContext_as_property();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Except()
    {
        await base.Except();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Final_GroupBy()
    {
        await base.Final_GroupBy();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Foreach_async_is_not_supported()
    {
        await base.Foreach_async_is_not_supported();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Foreach_sync_over_DbSet_property_is_not_supported()
    {
        await base.Foreach_sync_over_DbSet_property_is_not_supported();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Foreach_sync_over_operator()
    {
        await base.Foreach_sync_over_operator();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_with_FormattableString_parameters()
    {
        await base.FromSql_with_FormattableString_parameters();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_single()
    {
        await base.Include_single();
    }
    
    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_split()
    {
        await base.Include_split();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Intersect()
    {
        await base.Intersect();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Invoke_no_evaluatability_is_not_supported()
    {
        await base.Invoke_no_evaluatability_is_not_supported();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ListInit_fully_evaluatable()
    {
        await base.ListInit_fully_evaluatable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ListInit_no_evaluatability()
    {
        await base.ListInit_no_evaluatability();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ListInit_with_evaluatable_with_captured_variable()
    {
        await base.ListInit_with_evaluatable_with_captured_variable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ListInit_with_evaluatable_without_captured_variable()
    {
        await base.ListInit_with_evaluatable_without_captured_variable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MemberInit_contains_captured_variable()
    {
        await base.MemberInit_contains_captured_variable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MemberInit_evaluatable_as_constant()
    {
        await base.MemberInit_evaluatable_as_constant();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MemberInit_evaluatable_as_parameter()
    {
        await base.MemberInit_evaluatable_as_parameter();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MemberInit_no_evaluatable()
    {
        await base.MemberInit_no_evaluatable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MethodCallExpression_fully_evaluatable()
    {
        await base.MethodCallExpression_fully_evaluatable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw()
    {
        await base.FromSqlRaw();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MethodCallExpression_no_evaluatability()
    {
        await base.MethodCallExpression_no_evaluatability();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MethodCallExpression_with_evaluatable_with_captured_variable()
    {
        await base.MethodCallExpression_with_evaluatable_with_captured_variable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MethodCallExpression_with_evaluatable_without_captured_variable()
    {
        await base.MethodCallExpression_with_evaluatable_without_captured_variable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_queries_with_captured_variables()
    {
        await base.Multiple_queries_with_captured_variables();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task New_with_no_arguments()
    {
        await base.New_with_no_arguments();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task NewArray()
    {
        await base.NewArray();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task NotParameterizedAttribute_is_not_supported_with_non_constant_argument()
    {
        await base.NotParameterizedAttribute_is_not_supported_with_non_constant_argument();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task NotParameterizedAttribute_with_constant()
    {
        await base.NotParameterizedAttribute_with_constant();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OrderBy()
    {
        await base.OrderBy();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_compilation_failure()
    {
        await base.Query_compilation_failure();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_syntax_is_not_supported()
    {
        await base.Query_syntax_is_not_supported();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Same_captured_variable_twice_in_different_lambdas()
    {
        await base.Same_captured_variable_twice_in_different_lambdas();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_anonymous_object()
    {
        await base.Select_anonymous_object();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_changes_type()
    {
        await base.Select_changes_type();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_New_with_captured_variable()
    {
        await base.Select_New_with_captured_variable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_with_constant()
    {
        await base.Skip_with_constant();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_with_parameter()
    {
        await base.Skip_with_parameter();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Take_with_constant()
    {
        await base.Take_with_constant();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Take_with_parameter()
    {
        await base.Take_with_parameter();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Same_captured_variable_twice_in_same_lambda()
    {
        await base.Same_captured_variable_twice_in_same_lambda();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_All()
    {
        await base.Terminating_All();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_AllAsync()
    {
        await base.Terminating_AllAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Any()
    {
        await base.Terminating_Any();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_AnyAsync()
    {
        await base.Terminating_AnyAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_AsAsyncEnumerable_on_DbSet()
    {
        await base.Terminating_AsAsyncEnumerable_on_DbSet();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_AsAsyncEnumerable_on_IQueryable()
    {
        await base.Terminating_AsAsyncEnumerable_on_IQueryable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_AsEnumerable()
    {
        await base.Terminating_AsEnumerable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Average()
    {
        await base.Terminating_Average();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_AverageAsync()
    {
        await base.Terminating_AverageAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Contains()
    {
        await base.Terminating_Contains();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ContainsAsync()
    {
        await base.Terminating_ContainsAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Count()
    {
        await base.Terminating_Count();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_New_with_captured_variable()
    {
        await base.Where_New_with_captured_variable();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Unary()
    {
        await base.Unary();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToArray()
    {
        await base.Terminating_ToArray();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToArrayAsync()
    {
        await base.Terminating_ToArrayAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToDictionary()
    {
        await base.Terminating_ToDictionary();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToDictionaryAsync()
    {
        await base.Terminating_ToDictionaryAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToDictionary_over_anonymous_type()
    {
        await base.ToDictionary_over_anonymous_type();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToDictionaryAsync_over_anonymous_type()
    {
        await base.ToDictionaryAsync_over_anonymous_type();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToHashSet()
    {
        await base.Terminating_ToHashSet();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToHashSetAsync()
    {
        await base.Terminating_ToHashSetAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToLookup()
    {
        await base.Terminating_ToLookup();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToList()
    {
        await base.Terminating_ToList();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToListAsync()
    {
        await base.Terminating_ToListAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_CountAsync()
    {
        await base.Terminating_CountAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ElementAt()
    {
        await base.Terminating_ElementAt();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ElementAtAsync()
    {
        await base.Terminating_ElementAtAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ElementAtOrDefault()
    {
        await base.Terminating_ElementAtOrDefault();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ElementAtOrDefaultAsync()
    {
        await base.Terminating_ElementAtOrDefaultAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_First()
    {
        await base.Terminating_First();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_FirstAsync()
    {
        await base.Terminating_FirstAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_FirstOrDefault()
    {
        await base.Terminating_FirstOrDefault();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_FirstOrDefaultAsync()
    {
        await base.Terminating_FirstOrDefaultAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_GetEnumerator()
    {
        await base.Terminating_GetEnumerator();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Last()
    {
        await base.Terminating_Last();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_LastAsync()
    {
        await base.Terminating_LastAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_LastOrDefault()
    {
        await base.Terminating_LastOrDefault();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_LastOrDefaultAsync()
    {
        await base.Terminating_LastOrDefaultAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_LongCount()
    {
        await base.Terminating_LongCount();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_LongCountAsync()
    {
        await base.Terminating_LongCountAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Max()
    {
        await base.Terminating_Max();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_MaxAsync()
    {
        await base.Terminating_MaxAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Min()
    {
        await base.Terminating_Min();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_MinAsync()
    {
        await base.Terminating_MinAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Single()
    {
        await base.Terminating_Single();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_SingleAsync()
    {
        await base.Terminating_SingleAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_SingleOrDefault()
    {
        await base.Terminating_SingleOrDefault();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_SingleOrDefaultAsync()
    {
        await base.Terminating_SingleOrDefaultAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Sum()
    {
        await base.Terminating_Sum();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_SumAsync()
    {
        await base.Terminating_SumAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ExecuteDelete()
    {
        await base.Terminating_ExecuteDelete();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ExecuteDeleteAsync()
    {
        await base.Terminating_ExecuteDeleteAsync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ExecuteUpdate_with_lambda()
    {
        await base.Terminating_ExecuteUpdate_with_lambda();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ExecuteUpdate_without_lambda()
    {
        await base.Terminating_ExecuteUpdate_without_lambda();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ExecuteUpdateAsync_with_lambda()
    {
        await base.Terminating_ExecuteUpdateAsync_with_lambda();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ExecuteUpdateAsync_without_lambda()
    {
        await base.Terminating_ExecuteUpdateAsync_without_lambda();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_with_cancellation_token()
    {
        await base.Terminating_with_cancellation_token();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union()
    {
        await base.Union();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task UnionOnEntitiesWithJson()
    {
        await base.UnionOnEntitiesWithJson();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ConcatOnEntitiesWithJson()
    {
        await base.ConcatOnEntitiesWithJson();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task IntersectOnEntitiesWithJson()
    {
        await base.IntersectOnEntitiesWithJson();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ExceptOnEntitiesWithJson()
    {
        await base.ExceptOnEntitiesWithJson();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ValuesExpression()
    {
        await base.ValuesExpression();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Two_captured_variables_in_same_lambda()
    {
        await base.Two_captured_variables_in_same_lambda();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Two_captured_variables_in_different_lambdas()
    {
        await base.Two_captured_variables_in_different_lambdas();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToList_over_objects_does_not_get_precompiled()
    {
        await base.ToList_over_objects_does_not_get_precompiled();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Unsafe_accessor_gets_generated_once_for_multiple_queries()
    {
        await base.Unsafe_accessor_gets_generated_once_for_multiple_queries();
    }

    public class PrecompiledQueryClickHouseFixture : PrecompiledQueryRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;

        public override PrecompiledQueryTestHelpers PrecompiledQueryTestHelpers
            => ClickHousePrecompiledQueryTestHelpers.Instance;
    }
}
