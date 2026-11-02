using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class OptionalDependentQueryClickHouseTest : OptionalDependentQueryTestBase<OptionalDependentQueryClickHouseFixture>
{
    public OptionalDependentQueryClickHouseTest(OptionalDependentQueryClickHouseFixture fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_projection_entity_with_all_optional(bool async)
    {
        await base.Basic_projection_entity_with_all_optional(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Basic_projection_entity_with_some_required(bool async)
    {
        await base.Basic_projection_entity_with_some_required(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_nested_optional_dependent_with_all_optional_compared_to_not_null(bool async)
    {
        await base.Filter_nested_optional_dependent_with_all_optional_compared_to_not_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_nested_optional_dependent_with_all_optional_compared_to_null(bool async)
    {
        await base.Filter_nested_optional_dependent_with_all_optional_compared_to_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_nested_optional_dependent_with_some_required_compared_to_not_null(bool async)
    {
        await base.Filter_nested_optional_dependent_with_some_required_compared_to_not_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_nested_optional_dependent_with_some_required_compared_to_null(bool async)
    {
        await base.Filter_nested_optional_dependent_with_some_required_compared_to_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_optional_dependent_with_all_optional_compared_to_not_null(bool async)
    {
        await base.Filter_optional_dependent_with_all_optional_compared_to_not_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_optional_dependent_with_all_optional_compared_to_null(bool async)
    {
        await base.Filter_optional_dependent_with_all_optional_compared_to_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_optional_dependent_with_some_required_compared_to_not_null(bool async)
    {
        await base.Filter_optional_dependent_with_some_required_compared_to_not_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_optional_dependent_with_some_required_compared_to_null(bool async)
    {
        await base.Filter_optional_dependent_with_some_required_compared_to_null(async);
    }
}
