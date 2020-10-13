using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace ClickHouse.EntityFrameworkCore.Design.Internal
{
    public class ClickHouseDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            throw new System.NotImplementedException();
        }
    }
}