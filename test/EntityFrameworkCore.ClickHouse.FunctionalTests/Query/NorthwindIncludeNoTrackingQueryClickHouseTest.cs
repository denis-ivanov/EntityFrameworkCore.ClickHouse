using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindIncludeNoTrackingQueryClickHouseTest : NorthwindIncludeNoTrackingQueryTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindIncludeNoTrackingQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filtered_include_with_multiple_ordering(bool async)
    {
        await base.Filtered_include_with_multiple_ordering(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection(bool async)
    {
        await base.Include_collection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_on_additional_from_clause(bool async)
    {
        await base.Include_collection_on_additional_from_clause(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_order_by_collection_column(bool async)
    {
        await base.Include_collection_order_by_collection_column(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_order_by_key(bool async)
    {
        await base.Include_collection_order_by_key(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_order_by_non_key(bool async)
    {
        await base.Include_collection_order_by_non_key(async);
    }
}
