#if NET11_0_OR_GREATER
using ClickHouse.EntityFrameworkCore.Extensions;
#endif
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
#if NET11_0_OR_GREATER
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
#endif
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
#if NET11_0_OR_GREATER
using System.Text.Json;
#endif
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class PrecompiledQueryClickHouseTest : PrecompiledQueryRelationalTestBase, IClassFixture<PrecompiledQueryClickHouseTest.PrecompiledQueryClickHouseFixture>
{
#if NET10_0
    public PrecompiledQueryClickHouseTest(PrecompiledQueryRelationalFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
#else
    public PrecompiledQueryClickHouseTest(PrecompiledQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
#endif
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task BinaryExpression()
    {
        await base.BinaryExpression();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Concat()
    {
        await base.Concat();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Conditional_contains_captured_variable()
    {
        await base.Conditional_contains_captured_variable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Conditional_no_evaluatable()
    {
        await base.Conditional_no_evaluatable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_with_parameterized_collection()
    {
        await base.Contains_with_parameterized_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DbContext_as_captured_variable()
    {
        await base.DbContext_as_captured_variable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DbContext_as_field()
    {
        await base.DbContext_as_field();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DbContext_as_local_variable()
    {
        await base.DbContext_as_local_variable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DbContext_as_method_invocation_result()
    {
        await base.DbContext_as_method_invocation_result();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Dynamic_query_does_not_get_precompiled()
    {
        await base.Dynamic_query_does_not_get_precompiled();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task EF_Constant_is_not_supported()
    {
        await base.EF_Constant_is_not_supported();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task DbContext_as_property()
    {
        await base.DbContext_as_property();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Except()
    {
        await base.Except();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Final_GroupBy()
    {
        await base.Final_GroupBy();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Foreach_async_is_not_supported()
    {
        await base.Foreach_async_is_not_supported();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Foreach_sync_over_DbSet_property_is_not_supported()
    {
        await base.Foreach_sync_over_DbSet_property_is_not_supported();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Foreach_sync_over_operator()
    {
        await base.Foreach_sync_over_operator();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSql_with_FormattableString_parameters()
    {
        await base.FromSql_with_FormattableString_parameters();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_single()
    {
        await base.Include_single();
    }
    
    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_split()
    {
        await base.Include_split();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Intersect()
    {
        await base.Intersect();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Invoke_no_evaluatability_is_not_supported()
    {
        await base.Invoke_no_evaluatability_is_not_supported();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ListInit_fully_evaluatable()
    {
        await base.ListInit_fully_evaluatable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ListInit_no_evaluatability()
    {
        await base.ListInit_no_evaluatability();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ListInit_with_evaluatable_with_captured_variable()
    {
        await base.ListInit_with_evaluatable_with_captured_variable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ListInit_with_evaluatable_without_captured_variable()
    {
        await base.ListInit_with_evaluatable_without_captured_variable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MemberInit_contains_captured_variable()
    {
        await base.MemberInit_contains_captured_variable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MemberInit_evaluatable_as_constant()
    {
        await base.MemberInit_evaluatable_as_constant();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MemberInit_evaluatable_as_parameter()
    {
        await base.MemberInit_evaluatable_as_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MemberInit_no_evaluatable()
    {
        await base.MemberInit_no_evaluatable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MethodCallExpression_fully_evaluatable()
    {
        await base.MethodCallExpression_fully_evaluatable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task FromSqlRaw()
    {
        await base.FromSqlRaw();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MethodCallExpression_no_evaluatability()
    {
        await base.MethodCallExpression_no_evaluatability();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MethodCallExpression_with_evaluatable_with_captured_variable()
    {
        await base.MethodCallExpression_with_evaluatable_with_captured_variable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MethodCallExpression_with_evaluatable_without_captured_variable()
    {
        await base.MethodCallExpression_with_evaluatable_without_captured_variable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multiple_queries_with_captured_variables()
    {
        await base.Multiple_queries_with_captured_variables();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task New_with_no_arguments()
    {
        await base.New_with_no_arguments();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task NewArray()
    {
        await base.NewArray();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task NotParameterizedAttribute_is_not_supported_with_non_constant_argument()
    {
        await base.NotParameterizedAttribute_is_not_supported_with_non_constant_argument();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task NotParameterizedAttribute_with_constant()
    {
        await base.NotParameterizedAttribute_with_constant();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task OrderBy()
    {
        await base.OrderBy();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_compilation_failure()
    {
        await base.Query_compilation_failure();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_syntax_is_not_supported()
    {
        await base.Query_syntax_is_not_supported();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Same_captured_variable_twice_in_different_lambdas()
    {
        await base.Same_captured_variable_twice_in_different_lambdas();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_anonymous_object()
    {
        await base.Select_anonymous_object();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_changes_type()
    {
        await base.Select_changes_type();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_New_with_captured_variable()
    {
        await base.Select_New_with_captured_variable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_with_constant()
    {
        await base.Skip_with_constant();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Skip_with_parameter()
    {
        await base.Skip_with_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Take_with_constant()
    {
        await base.Take_with_constant();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Take_with_parameter()
    {
        await base.Take_with_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Same_captured_variable_twice_in_same_lambda()
    {
        await base.Same_captured_variable_twice_in_same_lambda();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_All()
    {
        await base.Terminating_All();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_AllAsync()
    {
        await base.Terminating_AllAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Any()
    {
        await base.Terminating_Any();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_AnyAsync()
    {
        await base.Terminating_AnyAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_AsAsyncEnumerable_on_DbSet()
    {
        await base.Terminating_AsAsyncEnumerable_on_DbSet();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_AsAsyncEnumerable_on_IQueryable()
    {
        await base.Terminating_AsAsyncEnumerable_on_IQueryable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_AsEnumerable()
    {
        await base.Terminating_AsEnumerable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Average()
    {
        await base.Terminating_Average();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_AverageAsync()
    {
        await base.Terminating_AverageAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Contains()
    {
        await base.Terminating_Contains();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ContainsAsync()
    {
        await base.Terminating_ContainsAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Count()
    {
        await base.Terminating_Count();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Where_New_with_captured_variable()
    {
        await base.Where_New_with_captured_variable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Unary()
    {
        await base.Unary();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToArray()
    {
        await base.Terminating_ToArray();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToArrayAsync()
    {
        await base.Terminating_ToArrayAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToDictionary()
    {
        await base.Terminating_ToDictionary();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToDictionaryAsync()
    {
        await base.Terminating_ToDictionaryAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToDictionary_over_anonymous_type()
    {
        await base.ToDictionary_over_anonymous_type();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToDictionaryAsync_over_anonymous_type()
    {
        await base.ToDictionaryAsync_over_anonymous_type();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToHashSet()
    {
        await base.Terminating_ToHashSet();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToHashSetAsync()
    {
        await base.Terminating_ToHashSetAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToLookup()
    {
        await base.Terminating_ToLookup();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToList()
    {
        await base.Terminating_ToList();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ToListAsync()
    {
        await base.Terminating_ToListAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_CountAsync()
    {
        await base.Terminating_CountAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ElementAt()
    {
        await base.Terminating_ElementAt();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ElementAtAsync()
    {
        await base.Terminating_ElementAtAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ElementAtOrDefault()
    {
        await base.Terminating_ElementAtOrDefault();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ElementAtOrDefaultAsync()
    {
        await base.Terminating_ElementAtOrDefaultAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_First()
    {
        await base.Terminating_First();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_FirstAsync()
    {
        await base.Terminating_FirstAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_FirstOrDefault()
    {
        await base.Terminating_FirstOrDefault();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_FirstOrDefaultAsync()
    {
        await base.Terminating_FirstOrDefaultAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_GetEnumerator()
    {
        await base.Terminating_GetEnumerator();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Last()
    {
        await base.Terminating_Last();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_LastAsync()
    {
        await base.Terminating_LastAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_LastOrDefault()
    {
        await base.Terminating_LastOrDefault();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_LastOrDefaultAsync()
    {
        await base.Terminating_LastOrDefaultAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_LongCount()
    {
        await base.Terminating_LongCount();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_LongCountAsync()
    {
        await base.Terminating_LongCountAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Max()
    {
        await base.Terminating_Max();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_MaxAsync()
    {
        await base.Terminating_MaxAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Min()
    {
        await base.Terminating_Min();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_MinAsync()
    {
        await base.Terminating_MinAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Single()
    {
        await base.Terminating_Single();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_SingleAsync()
    {
        await base.Terminating_SingleAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_SingleOrDefault()
    {
        await base.Terminating_SingleOrDefault();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_SingleOrDefaultAsync()
    {
        await base.Terminating_SingleOrDefaultAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_Sum()
    {
        await base.Terminating_Sum();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_SumAsync()
    {
        await base.Terminating_SumAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ExecuteDelete()
    {
        await base.Terminating_ExecuteDelete();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ExecuteDeleteAsync()
    {
        await base.Terminating_ExecuteDeleteAsync();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ExecuteUpdate_with_lambda()
    {
        await base.Terminating_ExecuteUpdate_with_lambda();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ExecuteUpdate_without_lambda()
    {
        await base.Terminating_ExecuteUpdate_without_lambda();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ExecuteUpdateAsync_with_lambda()
    {
        await base.Terminating_ExecuteUpdateAsync_with_lambda();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_ExecuteUpdateAsync_without_lambda()
    {
        await base.Terminating_ExecuteUpdateAsync_without_lambda();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Terminating_with_cancellation_token()
    {
        await base.Terminating_with_cancellation_token();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union()
    {
        await base.Union();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task UnionOnEntitiesWithJson()
    {
        await base.UnionOnEntitiesWithJson();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ConcatOnEntitiesWithJson()
    {
        await base.ConcatOnEntitiesWithJson();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task IntersectOnEntitiesWithJson()
    {
        await base.IntersectOnEntitiesWithJson();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ExceptOnEntitiesWithJson()
    {
        await base.ExceptOnEntitiesWithJson();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ValuesExpression()
    {
        await base.ValuesExpression();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Two_captured_variables_in_same_lambda()
    {
        await base.Two_captured_variables_in_same_lambda();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Two_captured_variables_in_different_lambdas()
    {
        await base.Two_captured_variables_in_different_lambdas();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ToList_over_objects_does_not_get_precompiled()
    {
        await base.ToList_over_objects_does_not_get_precompiled();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
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
#if NET11_0_OR_GREATER

        protected override async Task SeedAsync(PrecompiledQueryContext context)
        {
            await context.Database.ExecuteSqlRawAsync(
                """
                ALTER TABLE "EntitiesWithPrimitiveCollection"
                MODIFY SETTING enable_block_number_column = 1, enable_block_offset_column = 1
                """,
                TestContext.Current.CancellationToken);

            await base.SeedAsync(context);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
        {
            base.OnModelCreating(modelBuilder, context);

            // The specification fixture seeds a JSON null token into this collection column.
            modelBuilder.Entity<EntityWithPrimitiveCollection>()
                .Property(entity => entity.Tags)
                .HasConversion(
                    static tags => JsonSerializer.Serialize(tags, (JsonSerializerOptions?)null),
                    static json => JsonSerializer.Deserialize<string[]>(json, (JsonSerializerOptions?)null),
                    ValueComparer.CreateDefault<string[]>(favorStructuralComparisons: true));

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetMergeTreeTableEngine().SetOrderBy(["tuple()"]);
            }
        }
#endif
    }
}
