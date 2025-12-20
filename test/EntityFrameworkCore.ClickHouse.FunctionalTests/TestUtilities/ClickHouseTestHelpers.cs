using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;

public class ClickHouseTestHelpers : RelationalTestHelpers
{
    protected ClickHouseTestHelpers()
    {
    }

    public static ClickHouseTestHelpers Instance = new();

    public override IServiceCollection AddProviderServices(IServiceCollection services)
    {
        return services.AddEntityFrameworkClickHouse();
    }

    public override DbContextOptionsBuilder UseProviderOptions(DbContextOptionsBuilder optionsBuilder)
    {
        return optionsBuilder.UseClickHouse("");
    }
}
