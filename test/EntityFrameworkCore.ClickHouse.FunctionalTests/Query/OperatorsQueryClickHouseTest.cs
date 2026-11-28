using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class OperatorsQueryClickHouseTest : OperatorsQueryTestBase
{
    public OperatorsQueryClickHouseTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_predicate_with_bitwise_and_arithmetic_operations()
    {
        await base.Complex_predicate_with_bitwise_and_arithmetic_operations();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Complex_predicate_with_bitwise_and_modulo_and_negation()
    {
        await base.Complex_predicate_with_bitwise_and_modulo_and_negation();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Concat_and_json_scalar(bool async)
    {
        await base.Concat_and_json_scalar(async);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projection_with_not_and_negation_on_integer()
    {
        await base.Projection_with_not_and_negation_on_integer();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Double_negate_on_column()
    {
        await base.Double_negate_on_column();
    }

#if NET10_0
    protected override ITestStoreFactory TestStoreFactory
#else
    protected override ITestStoreFactory NonSharedTestStoreFactory
#endif
        => ClickHouseTestStoreFactory.Instance;
}
