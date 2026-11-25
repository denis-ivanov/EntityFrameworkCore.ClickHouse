using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class FunkyDataQueryClickHouseTest : FunkyDataQueryTestBase<FunkyDataQueryClickHouseTest.FunkyDataQueryClickHouseFixture>
{
    public FunkyDataQueryClickHouseTest(FunkyDataQueryClickHouseFixture fixture) : base(fixture)
    {
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_Contains_and_StartsWith_with_same_parameter(bool async)
    {
        await base.String_Contains_and_StartsWith_with_same_parameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_contains_on_argument_with_wildcard_column(bool async)
    {
        await base.String_contains_on_argument_with_wildcard_column(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_contains_on_argument_with_wildcard_column_negated(bool async)
    {
        await base.String_contains_on_argument_with_wildcard_column_negated(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_contains_on_argument_with_wildcard_constant(bool async)
    {
        await base.String_contains_on_argument_with_wildcard_constant(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_contains_on_argument_with_wildcard_parameter(bool async)
    {
        await base.String_contains_on_argument_with_wildcard_parameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_ends_with_equals_nullable_column(bool async)
    {
        await base.String_ends_with_equals_nullable_column(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_ends_with_inside_conditional(bool async)
    {
        await base.String_ends_with_inside_conditional(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_ends_with_inside_conditional_negated(bool async)
    {
        await base.String_ends_with_inside_conditional_negated(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_ends_with_not_equals_nullable_column(bool async)
    {
        await base.String_ends_with_not_equals_nullable_column(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_ends_with_on_argument_with_wildcard_column(bool async)
    {
        await base.String_ends_with_on_argument_with_wildcard_column(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_ends_with_on_argument_with_wildcard_column_negated(bool async)
    {
        await base.String_ends_with_on_argument_with_wildcard_column_negated(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_ends_with_on_argument_with_wildcard_constant(bool async)
    {
        await base.String_ends_with_on_argument_with_wildcard_constant(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_ends_with_on_argument_with_wildcard_parameter(bool async)
    {
        await base.String_ends_with_on_argument_with_wildcard_parameter(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_FirstOrDefault_and_LastOrDefault(bool async)
    {
        await base.String_FirstOrDefault_and_LastOrDefault(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_starts_with_on_argument_with_bracket(bool async)
    {
        await base.String_starts_with_on_argument_with_bracket(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_starts_with_on_argument_with_wildcard_column(bool async)
    {
        await base.String_starts_with_on_argument_with_wildcard_column(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_starts_with_on_argument_with_wildcard_column_negated(bool async)
    {
        await base.String_starts_with_on_argument_with_wildcard_column_negated(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_starts_with_on_argument_with_wildcard_constant(bool async)
    {
        await base.String_starts_with_on_argument_with_wildcard_constant(async);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task String_starts_with_on_argument_with_wildcard_parameter(bool async)
    {
        await base.String_starts_with_on_argument_with_wildcard_parameter(async);
    }

    public class FunkyDataQueryClickHouseFixture : FunkyDataQueryFixtureBase, ITestSqlLoggerFactory
    {
        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;

        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;
    }
}
