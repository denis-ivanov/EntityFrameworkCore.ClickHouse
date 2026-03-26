using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindDbFunctionsQueryClickHouseTest : NorthwindDbFunctionsQueryRelationalTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindDbFunctionsQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collate_case_insensitive(bool async)
    {
        await base.Collate_case_insensitive(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collate_case_sensitive(bool async)
    {
        await base.Collate_case_sensitive(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collate_case_sensitive_constant(bool async)
    {
        await base.Collate_case_sensitive_constant(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collate_is_null(bool async)
    {
        await base.Collate_is_null(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Like_literal(bool async)
    {
        await base.Like_literal(async);
    }

    protected override string CaseInsensitiveCollation { get; }

    protected override string CaseSensitiveCollation { get; }
}
