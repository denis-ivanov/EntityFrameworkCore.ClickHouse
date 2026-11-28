using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class AdHocQueryFiltersQueryClickHouseTest : AdHocQueryFiltersQueryRelationalTestBase
{
    public AdHocQueryFiltersQueryClickHouseTest(NonSharedFixture fixture) : base(fixture)
    {
    }
    
#if NET10_0
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;
#else
    protected override ITestStoreFactory NonSharedTestStoreFactory
        => ClickHouseTestStoreFactory.WithClientKeys;
#endif

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Named_query_filters_anonymous()
    {
        await base.Named_query_filters_anonymous();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Named_query_filters_removing()
    {
        await base.Named_query_filters_removing();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_filter_with_contains_evaluates_correctly()
    {
        await base.Query_filter_with_contains_evaluates_correctly();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Named_query_filters_ignore_some()
    {
        await base.Named_query_filters_ignore_some();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Query_filter_with_pk_fk_optimization()
    {
        await base.Query_filter_with_pk_fk_optimization();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Named_query_filters_overwriting()
    {
        await base.Named_query_filters_overwriting();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_multiple_aggregate_joining_different_tables_with_query_filter(bool async)
    {
        await base.Group_by_multiple_aggregate_joining_different_tables_with_query_filter(async);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Self_reference_in_query_filter_works()
    {
        await base.Self_reference_in_query_filter_works();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Named_query_filters_caching()
    {
        await base.Named_query_filters_caching();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Weak_entities_with_query_filter_subquery_flattening()
    {
        await base.Weak_entities_with_query_filter_subquery_flattening();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Named_query_filters()
    {
        await base.Named_query_filters();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Named_query_filters_ignore_all()
    {
        await base.Named_query_filters_ignore_all();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task MultiContext_query_filter_test()
    {
        await base.MultiContext_query_filter_test();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Group_by_multiple_aggregate_joining_different_tables(bool async)
    {
        await base.Group_by_multiple_aggregate_joining_different_tables(async);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Named_query_filters_anonymous_ignore()
    {
        await base.Named_query_filters_anonymous_ignore();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Invoke_inside_query_filter_gets_correctly_evaluated_during_translation()
    {
        await base.Invoke_inside_query_filter_gets_correctly_evaluated_during_translation();
    }
}
