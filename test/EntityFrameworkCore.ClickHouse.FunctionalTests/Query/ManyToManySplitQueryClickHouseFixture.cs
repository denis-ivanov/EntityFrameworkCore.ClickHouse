using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class ManyToManySplitQueryClickHouseFixture : ManyToManyQueryClickHouseFixture
{
    protected override string StoreName
        => "ManyToManySplitQuery";

    public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
        => base.AddOptions(builder.UseClickHouse(b => b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
}
