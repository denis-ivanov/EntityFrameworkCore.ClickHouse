using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindQueryFiltersQueryClickHouseTest : NorthwindQueryFiltersQueryTestBase<NorthwindQueryClickHouseFixture<NorthwindQueryFiltersCustomizer>>
{
    public NorthwindQueryFiltersQueryClickHouseTest(
        NorthwindQueryClickHouseFixture<NorthwindQueryFiltersCustomizer> fixture,
        ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Entity_Equality(bool async)
    {
        await base.Entity_Equality(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Included_many_to_one_query(bool async)
    {
        await base.Included_many_to_one_query(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Included_many_to_one_query2(bool async)
    {
        await base.Included_many_to_one_query2(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_reference_that_itself_has_query_filter_with_another_reference(bool async)
    {
        await base.Project_reference_that_itself_has_query_filter_with_another_reference(async);
    }
}
