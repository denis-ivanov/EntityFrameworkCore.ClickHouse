using ClickHouse.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ClickHouse.EntityFrameworkCore.Extensions;

public static class ClickHouseMigrationBuilderExtensions
{
    public static bool IsClickHouse([NotNull] this MigrationBuilder migrationBuilder)
        => string.Equals(
            migrationBuilder.ActiveProvider,
            typeof(ClickHouseOptionsExtension).Assembly.GetName().Name,
            StringComparison.Ordinal);
}
