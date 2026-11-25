using System.Threading.Tasks;

using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;

using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.TestUtilities;

using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Migrations;

public class MigrationsInfrastructureClickHouseTest : MigrationsInfrastructureTestBase<MigrationsInfrastructureClickHouseTest.MigrationsInfrastructureClickHouseFixture>
{
    public class MigrationsInfrastructureClickHouseFixture : MigrationsInfrastructureFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;
    }

    public MigrationsInfrastructureClickHouseTest(MigrationsInfrastructureClickHouseFixture fixture) : base(fixture)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_generate_migration_from_initial_database_to_initial()
    {
        await base.Can_generate_migration_from_initial_database_to_initial();

        Assert.Equal(
            """
            CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
                "MigrationId" String,
                "ProductVersion" String
            ) ENGINE = MergeTree()
            PRIMARY KEY ("MigrationId")
            ;


            """,
            Sql,
            ignoreLineEndingDifferences: true);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_generate_no_migration_script()
    {
        await base.Can_generate_no_migration_script();

        Assert.Equal(
            """
            CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
                "MigrationId" String,
                "ProductVersion" String
            ) ENGINE = MergeTree()
            PRIMARY KEY ("MigrationId")
            ;


            """,
            Sql,
            ignoreLineEndingDifferences: true);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Can_diff_against_2_2_model()
    {
        throw new System.NotImplementedException();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Can_diff_against_3_0_ASP_NET_Identity_model()
    {
        throw new System.NotImplementedException();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Can_diff_against_2_2_ASP_NET_Identity_model()
    {
        throw new System.NotImplementedException();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Can_diff_against_2_1_ASP_NET_Identity_model()
    {
        throw new System.NotImplementedException();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Can_apply_all_migrations()
    {
        base.Can_apply_all_migrations();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Can_apply_all_migrations_async()
    {
        return base.Can_apply_all_migrations_async();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Can_apply_one_migration_in_parallel()
    {
        base.Can_apply_one_migration_in_parallel();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Can_apply_one_migration_in_parallel_async()
    {
        return base.Can_apply_one_migration_in_parallel_async();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Can_apply_range_of_migrations()
    {
        base.Can_apply_range_of_migrations();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Can_apply_second_migration_in_parallel()
    {
        base.Can_apply_second_migration_in_parallel();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Can_apply_second_migration_in_parallel_async()
    {
        return base.Can_apply_second_migration_in_parallel_async();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Can_apply_two_migrations_in_transaction()
    {
        base.Can_apply_two_migrations_in_transaction();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Can_apply_two_migrations_in_transaction_async()
    {
        return base.Can_apply_two_migrations_in_transaction_async();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Can_generate_idempotent_up_and_down_scripts()
    {
        return base.Can_generate_idempotent_up_and_down_scripts();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Can_generate_idempotent_up_and_down_scripts_noTransactions()
    {
        return base.Can_generate_idempotent_up_and_down_scripts_noTransactions();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Can_generate_one_up_and_down_script()
    {
        return base.Can_generate_one_up_and_down_script();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Can_generate_up_and_down_script_using_names()
    {
        return base.Can_generate_up_and_down_script_using_names();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Can_generate_up_and_down_scripts()
    {
        return base.Can_generate_up_and_down_scripts();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Can_generate_up_and_down_scripts_noTransactions()
    {
        return base.Can_generate_up_and_down_scripts_noTransactions();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Can_revert_all_migrations()
    {
        base.Can_revert_all_migrations();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Can_revert_one_migrations()
    {
        base.Can_revert_one_migrations();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Can_get_active_provider()
    {
        base.Can_get_active_provider();

        Assert.Equal("EntityFrameworkCore.ClickHouse", ActiveProvider);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Can_apply_one_migration()
    {
        base.Can_apply_one_migration();
    }

    protected override Task ExecuteSqlAsync(string value)
    {
        var testStore = ((ClickHouseTestStore)Fixture.TestStore);
        if (testStore.ConnectionState != System.Data.ConnectionState.Open)
        {
            testStore.OpenConnection();
        }
        testStore.ExecuteNonQuery(value);
        return Task.CompletedTask;
    }
}
