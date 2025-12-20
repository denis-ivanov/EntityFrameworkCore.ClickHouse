using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Diagnostics.CodeAnalysis;

namespace ClickHouse.EntityFrameworkCore.Migrations.Operations;

public class ClickHouseDropDatabaseOperation : MigrationOperation
{
    public string Name { get; [param: NotNull]set; }
}
