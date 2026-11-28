using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindFunctionsQueryClickHouseTest : NorthwindFunctionsQueryRelationalTestBase<
    NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindFunctionsQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }

    [Theory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Order_by_length_twice_followed_by_projection_of_naked_collection_navigation(bool async)
    {
        return base.Order_by_length_twice_followed_by_projection_of_naked_collection_navigation(async);
    }

    [Theory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Sum_over_round_works_correctly_in_projection(bool async)
    {
        return base.Sum_over_round_works_correctly_in_projection(async);
    }

    [Theory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Sum_over_round_works_correctly_in_projection_2(bool async)
    {
        return base.Sum_over_round_works_correctly_in_projection_2(async);
    }

    [Theory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Sum_over_truncate_works_correctly_in_projection(bool async)
    {
        return base.Sum_over_truncate_works_correctly_in_projection(async);
    }

    [Theory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Sum_over_truncate_works_correctly_in_projection_2(bool async)
    {
        return base.Sum_over_truncate_works_correctly_in_projection_2(async);
    }
}
