using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.Navigations;

public class NavigationsIncludeClickHouseTest : NavigationsIncludeRelationalTestBase<NavigationsClickHouseFixture>
{
    public NavigationsIncludeClickHouseTest(NavigationsClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_nested_collection_on_collection(bool async) => base.Include_nested_collection_on_collection(async);

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_required(bool async) => base.Include_required(async);

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_nested(bool async) => base.Include_nested(async);

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_collection(bool async) => base.Include_collection(async);

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_optional(bool async) => base.Include_optional(async);

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_nested_collection_on_optional(bool async) => base.Include_nested_collection_on_optional(async);

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_required_optional_and_collection(bool async) => base.Include_required_optional_and_collection(async);

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_nested_collection(bool async) => base.Include_nested_collection(async);

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_nested_optional(bool async) => base.Include_nested_optional(async);
}