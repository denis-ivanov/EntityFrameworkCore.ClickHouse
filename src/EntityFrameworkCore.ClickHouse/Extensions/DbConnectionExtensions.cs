using System;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace ClickHouse.EntityFrameworkCore.Extensions;

internal static class DbConnectionExtensions
{
    internal static DbCommand CreateCommand(
        [NotNull] this DbConnection connection,
        [NotNull] string commandText)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ArgumentNullException.ThrowIfNull(commandText);

        var command = connection.CreateCommand();
        command.CommandText = commandText;
        return command;
    }
}
