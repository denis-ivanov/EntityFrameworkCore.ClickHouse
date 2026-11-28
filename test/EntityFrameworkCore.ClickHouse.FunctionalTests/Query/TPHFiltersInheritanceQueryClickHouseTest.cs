using Microsoft.EntityFrameworkCore.Query;
#if NET11_0_OR_GREATER
using Microsoft.EntityFrameworkCore.Query.Inheritance;
#endif
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class TPHFiltersInheritanceQueryClickHouseTest : FiltersInheritanceQueryTestBase<TPHFiltersInheritanceQueryClickHouseFixture>
{
    public TPHFiltersInheritanceQueryClickHouseTest(TPHFiltersInheritanceQueryClickHouseFixture fixture) : base(fixture)
    {
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_derived_set(bool async)
    {
        await base.Can_use_derived_set(async);
    }
    
    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_IgnoreQueryFilters_and_GetDatabaseValues(bool async)
    {
        await base.Can_use_IgnoreQueryFilters_and_GetDatabaseValues(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_is_kiwi(bool async)
    {
        await base.Can_use_is_kiwi(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_is_kiwi_in_projection(bool async)
    {
        await base.Can_use_is_kiwi_in_projection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_is_kiwi_with_other_predicate(bool async)
    {
        await base.Can_use_is_kiwi_with_other_predicate(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_animal(bool async)
    {
        await base.Can_use_of_type_animal(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_bird(bool async)
    {
        await base.Can_use_of_type_bird(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_bird_first(bool async)
    {
        await base.Can_use_of_type_bird_first(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_bird_with_projection(bool async)
    {
        await base.Can_use_of_type_bird_with_projection(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_kiwi(bool async)
    {
        await base.Can_use_of_type_kiwi(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_use_of_type_bird_predicate(bool async)
    {
        await base.Can_use_of_type_bird_predicate(async);
    }
}
