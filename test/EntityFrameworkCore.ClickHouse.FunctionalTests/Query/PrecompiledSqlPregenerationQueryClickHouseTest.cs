using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class PrecompiledSqlPregenerationQueryClickHouseTest : PrecompiledSqlPregenerationQueryRelationalTestBase,
    IClassFixture<PrecompiledSqlPregenerationQueryClickHouseTest.PrecompiledSqlPregenerationQueryClickHouseFixture>
{
    public PrecompiledSqlPregenerationQueryClickHouseTest(PrecompiledSqlPregenerationQueryRelationalFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Final_GroupBy()
    {
        await base.Final_GroupBy();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_single_query()
    {
        await base.Include_single_query();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_split_query()
    {
        await base.Include_split_query();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Many_non_nullable_parameters_do_not_prevent_pregeneration()
    {
        await base.Many_non_nullable_parameters_do_not_prevent_pregeneration();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task No_parameters()
    {
        await base.No_parameters();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Non_nullable_reference_type()
    {
        await base.Non_nullable_reference_type();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Non_nullable_value_type()
    {
        await base.Non_nullable_value_type();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nullable_and_non_nullable_reference_types()
    {
        await base.Nullable_and_non_nullable_reference_types();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nullable_and_non_nullable_value_types()
    {
        await base.Nullable_and_non_nullable_value_types();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nullable_reference_type()
    {
        await base.Nullable_reference_type();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nullable_value_type()
    {
        await base.Nullable_value_type();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Too_many_nullable_parameters_prevent_pregeneration()
    {
        await base.Too_many_nullable_parameters_prevent_pregeneration();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Two_non_nullable_reference_types()
    {
        await base.Two_non_nullable_reference_types();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Two_nullable_reference_types()
    {
        await base.Two_nullable_reference_types();
    }

    protected override bool AlwaysPrintGeneratedSources
        => false;
    
    public class PrecompiledSqlPregenerationQueryClickHouseFixture : PrecompiledSqlPregenerationQueryRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;

        public override PrecompiledQueryTestHelpers PrecompiledQueryTestHelpers
            => ClickHousePrecompiledQueryTestHelpers.Instance;
    }
}
