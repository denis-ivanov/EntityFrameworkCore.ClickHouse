using Microsoft.Extensions.Configuration;
using System.IO;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;

public static class TestEnvironment
{
    static TestEnvironment()
    {
        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables();

        Configuration = configBuilder.Build().GetSection("Test:ClickHouse");
    }
        
    public static IConfiguration Configuration { get; private set; }

    public static string DefaultConnection => Configuration["DefaultConnection"];
}
