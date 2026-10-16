using Microsoft.EntityFrameworkCore.Query.Associations.Navigations;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.Navigations;

public class NavigationsIncludeClickHouseTest : NavigationsIncludeRelationalTestBase<NavigationsClickHouseFixture>
{
    public NavigationsIncludeClickHouseTest(NavigationsClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_nested_collection_on_collection(bool async) => base.Include_nested_collection_on_collection(async);

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_required(bool async) => base.Include_required(async);

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_nested(bool async) => base.Include_nested(async);

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_collection(bool async) => base.Include_collection(async);

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_optional(bool async) => base.Include_optional(async);

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_nested_collection_on_optional(bool async) => base.Include_nested_collection_on_optional(async);

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_required_optional_and_collection(bool async) => base.Include_required_optional_and_collection(async);

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_nested_collection(bool async) => base.Include_nested_collection(async);

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Include_nested_optional(bool async) => base.Include_nested_optional(async);
}