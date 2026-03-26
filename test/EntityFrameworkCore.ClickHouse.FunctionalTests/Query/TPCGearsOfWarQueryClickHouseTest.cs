using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPCGearsOfWarQueryClickHouseTest : TPCGearsOfWarQueryRelationalTestBase<TPCGearsOfWarQueryClickHouseFixture>
{
    public TPCGearsOfWarQueryClickHouseTest(TPCGearsOfWarQueryClickHouseFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_eval_followed_by_aggregate_operation(bool async)
    {
        await base.Client_eval_followed_by_aggregate_operation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_member_and_unsupported_string_Equals_in_the_same_query(bool async)
    {
        await base.Client_member_and_unsupported_string_Equals_in_the_same_query(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Client_side_equality_with_parameter_works_with_optional_navigations(bool async)
    {
        await base.Client_side_equality_with_parameter_works_with_optional_navigations(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_after_distinct_3_levels(bool async)
    {
        await base.Correlated_collection_after_distinct_3_levels(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_with_distinct_3_levels(bool async)
    {
        await base.Correlated_collection_with_distinct_3_levels(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_with_aggregate_max_on_entity_type(bool async)
    {
        await base.Group_by_with_aggregate_max_on_entity_type(async);
    }
}
