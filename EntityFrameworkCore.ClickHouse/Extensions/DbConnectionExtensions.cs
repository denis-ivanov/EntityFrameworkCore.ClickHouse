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
        if (connection == null)
        {
            throw new ArgumentNullException(nameof(connection));
        }

        if (commandText == null)
        {
            throw new ArgumentNullException(nameof(commandText));
        }

        var command = connection.CreateCommand();
        command.CommandText = commandText;
        return command;
    }
}
