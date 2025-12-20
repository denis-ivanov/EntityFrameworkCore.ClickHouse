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

    [ConditionalFact(Skip = "TBD")]
    public override void Keyless_query()
    {
        base.Keyless_query();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Keyless_query_async()
    {
        return base.Keyless_query_async();
    }

    [ConditionalFact(Skip = "TBD")]
    public override void Keyless_query_first()
    {
        base.Keyless_query_first();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Keyless_query_first_async()
    {
        return base.Keyless_query_first_async();
    }

    [ConditionalFact(Skip = "TBD")]
    public override void Query_with_array_parameter()
    {
        base.Query_with_array_parameter();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Query_with_array_parameter_async()
    {
        return base.Query_with_array_parameter_async();
    }
}
