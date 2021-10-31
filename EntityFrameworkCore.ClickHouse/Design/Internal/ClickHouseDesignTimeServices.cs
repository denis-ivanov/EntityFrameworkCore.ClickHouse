using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ClickHouse.EntityFrameworkCore.Design.Internal
{
    public class ClickHouseDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddEntityFrameworkClickHouse()
                .AddSingleton<IDatabaseModelFactory, ClickHouseDatabaseModelFactory>();
        }
    }
}
