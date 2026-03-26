using ClickHouse.EntityFrameworkCore.Infrastructure;
using ClickHouse.EntityFrameworkCore.Infrastructure.Internal;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class AdHocQuerySplittingQueryClickHouseTest : AdHocQuerySplittingQueryTestBase
{
    private static readonly FieldInfo _querySplittingBehaviorFieldInfo =
        typeof(RelationalOptionsExtension).GetField("_querySplittingBehavior", BindingFlags.NonPublic | BindingFlags.Instance);

    public AdHocQuerySplittingQueryClickHouseTest(NonSharedFixture fixture) : base(fixture)
    {
    }
    
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;

    protected override DbContextOptionsBuilder SetQuerySplittingBehavior(DbContextOptionsBuilder optionsBuilder,
        QuerySplittingBehavior splittingBehavior)
    {
        new ClickHouseDbContextOptionsBuilder(optionsBuilder).UseQuerySplittingBehavior(splittingBehavior);

        return optionsBuilder;
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SplitQuery_disposes_inner_data_readers()
    {
        await base.SplitQuery_disposes_inner_data_readers();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Using_AsSingleQuery_without_context_configuration_does_not_throw_warning()
    {
        await base.Using_AsSingleQuery_without_context_configuration_does_not_throw_warning();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_configure_SingleQuery_at_context_level()
    {
        await base.Can_configure_SingleQuery_at_context_level();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task NoTracking_split_query_creates_only_required_instances(bool async)
    {
        await base.NoTracking_split_query_creates_only_required_instances(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_with_nav_collection_in_projection_with_split_query_in_parallel_sync()
    {
        await base.Can_query_with_nav_collection_in_projection_with_split_query_in_parallel_sync();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_configure_SplitQuery_at_context_level()
    {
        await base.Can_configure_SplitQuery_at_context_level();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Can_query_with_nav_collection_in_projection_with_split_query_in_parallel_async()
    {
        await base.Can_query_with_nav_collection_in_projection_with_split_query_in_parallel_async();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Unconfigured_query_splitting_behavior_throws_a_warning()
    {
        await base.Unconfigured_query_splitting_behavior_throws_a_warning();
    }

    protected override DbContextOptionsBuilder ClearQuerySplittingBehavior(DbContextOptionsBuilder optionsBuilder)
    {
        var extension = optionsBuilder.Options.FindExtension<ClickHouseOptionsExtension>();
        if (extension == null)
        {
            extension = new ClickHouseOptionsExtension();
        }
        else
        {
            _querySplittingBehaviorFieldInfo.SetValue(extension, null);
        }

        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

        return optionsBuilder;
    }
}
