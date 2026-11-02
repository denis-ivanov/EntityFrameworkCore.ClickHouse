using Microsoft.EntityFrameworkCore.Query;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class WarningsClickHouseTest : WarningsTestBase<QueryNoClientEvalClickHouseFixture>
{
    public WarningsClickHouseTest(QueryNoClientEvalClickHouseFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void FirstOrDefault_without_orderby_and_filter_issues_warning_subquery()
    {
        base.FirstOrDefault_without_orderby_and_filter_issues_warning_subquery();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void LastOrDefault_with_order_by_does_not_issue_client_eval_warning()
    {
        base.LastOrDefault_with_order_by_does_not_issue_client_eval_warning();
    }
}
