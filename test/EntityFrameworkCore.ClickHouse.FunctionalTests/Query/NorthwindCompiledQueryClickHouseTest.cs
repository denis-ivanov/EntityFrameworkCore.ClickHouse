using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindCompiledQueryClickHouseTest : NorthwindCompiledQueryTestBase<NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindCompiledQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture)
        : base(fixture)
    {
    }

    [Fact(Skip = "TBD")]
    public override void Keyless_query()
    {
        base.Keyless_query();
    }

    [Fact(Skip = "TBD")]
    public override Task Keyless_query_async()
    {
        return base.Keyless_query_async();
    }

    [Fact(Skip = "TBD")]
    public override void Keyless_query_first()
    {
        base.Keyless_query_first();
    }

    [Fact(Skip = "TBD")]
    public override Task Keyless_query_first_async()
    {
        return base.Keyless_query_first_async();
    }

    [Fact(Skip = "TBD")]
    public override void Query_with_array_parameter()
    {
        base.Query_with_array_parameter();
    }

    [Fact(Skip = "TBD")]
    public override Task Query_with_array_parameter_async()
    {
        return base.Query_with_array_parameter_async();
    }
}
