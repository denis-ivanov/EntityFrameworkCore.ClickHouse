using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Migrations;

// TODO
internal class MigrationsInfrastructureClickHouseTest : MigrationsInfrastructureTestBase<MigrationsInfrastructureClickHouseTest.MigrationsInfrastructureClickHouseFixture>
{
    public class MigrationsInfrastructureClickHouseFixture : MigrationsInfrastructureFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;
    }

    public MigrationsInfrastructureClickHouseTest(MigrationsInfrastructureClickHouseFixture fixture) : base(fixture)
    {
    }

    public override void Can_diff_against_2_2_model()
    {
        throw new System.NotImplementedException();
    }

    public override void Can_diff_against_3_0_ASP_NET_Identity_model()
    {
        throw new System.NotImplementedException();
    }

    public override void Can_diff_against_2_2_ASP_NET_Identity_model()
    {
        throw new System.NotImplementedException();
    }

    public override void Can_diff_against_2_1_ASP_NET_Identity_model()
    {
        throw new System.NotImplementedException();
    }
}
