using ClickHouse.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace ClickHouse.EntityFrameworkCore.Extensions;

public static class ClickHouseDatabaseFacadeExtensions
{
    public static bool IsClickHouse(this DatabaseFacade database)
        => typeof(ClickHouseOptionsExtension).Assembly.GetName().Name!.Equals(
            database.ProviderName,
            StringComparison.Ordinal);
}
