using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Diagnostics.CodeAnalysis;

namespace ClickHouse.EntityFrameworkCore.Migrations.Operations;

public class ClickHouseCreateDatabaseOperation : MigrationOperation
{
    public string Name { get; [param: NotNull]set; }
}
