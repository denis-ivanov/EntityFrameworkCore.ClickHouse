using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickHouse.EntityFrameworkCore.Update.Internal;

public class ClickHouseUpdateSqlGenerator : UpdateSqlGenerator
{
    public ClickHouseUpdateSqlGenerator(UpdateSqlGeneratorDependencies dependencies) : base(dependencies)
    {
    }

    protected override void AppendDeleteCommand(
        StringBuilder commandStringBuilder,
        string name,
        string schema,
        IReadOnlyList<IColumnModification> readOperations,
        IReadOnlyList<IColumnModification> conditionOperations,
        bool appendReturningOneClause = false)
    {
        AppendDeleteCommandHeader(commandStringBuilder, name, schema);
        AppendWhereClause(commandStringBuilder, conditionOperations);
        commandStringBuilder.AppendLine(SqlGenerationHelper.StatementTerminator);
    }

    protected override void AppendDeleteCommandHeader(
        StringBuilder commandStringBuilder,
        string name,
        string schema)
    {
        ArgumentNullException.ThrowIfNull(commandStringBuilder);
        ArgumentNullException.ThrowIfNull(name);

        commandStringBuilder.Append("ALTER TABLE ");
        SqlGenerationHelper.DelimitIdentifier(commandStringBuilder, name, schema);
        commandStringBuilder.Append(" DELETE");
    }

    protected override void AppendUpdateCommand(
        StringBuilder commandStringBuilder,
        string name,
        string schema,
        IReadOnlyList<IColumnModification> writeOperations,
        IReadOnlyList<IColumnModification> readOperations,
        IReadOnlyList<IColumnModification> conditionOperations,
        bool appendReturningOneClause = false)
    {
        AppendUpdateCommandHeader(commandStringBuilder, name, schema, writeOperations);
        AppendWhereClause(commandStringBuilder, conditionOperations);
        commandStringBuilder.AppendLine(SqlGenerationHelper.StatementTerminator);
    }

    protected override void AppendUpdateCommandHeader(
        StringBuilder commandStringBuilder,
        string name,
        string schema,
        IReadOnlyList<IColumnModification> operations)
    {
        ArgumentNullException.ThrowIfNull(commandStringBuilder);
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(operations);

        commandStringBuilder.Append("ALTER TABLE ");
        SqlGenerationHelper.DelimitIdentifier(commandStringBuilder, name, schema);
        commandStringBuilder.Append(" UPDATE ")
            .AppendJoin(
                operations,
                (this, name, schema),
                (sb, o, p) =>
                {
                    var (g, n, s) = p;
                    g.SqlGenerationHelper.DelimitIdentifier(sb, o.ColumnName);
                    sb.Append(" = ");
                    if (!o.UseCurrentValueParameter)
                    {

                        g.AppendSqlLiteral(sb, o, n, s);
                    }
                    else
                    {
                        g.SqlGenerationHelper.GenerateParameterNamePlaceholder(sb, o.ParameterName, o.ColumnType);
                    }
                });
    }

    public override ResultSetMapping AppendUpdateOperation(StringBuilder commandStringBuilder, IReadOnlyModificationCommand command,
        int commandPosition, out bool requiresTransaction)
    {
        var name = command.TableName;
        var schema = command.Schema;
        var operations = command.ColumnModifications;

        var writeOperations = operations.Where(o => o.IsWrite).ToList();
        var conditionOperations = operations.Where(o => o.IsCondition).ToList();
        var readOperations = operations.Where(o => o.IsRead).ToList();

        requiresTransaction = false;

        AppendUpdateCommand(commandStringBuilder, name, schema, writeOperations, readOperations, conditionOperations);

        return readOperations.Count > 0 ? ResultSetMapping.LastInResultSet : ResultSetMapping.NoResults;
    }

    protected override void AppendWhereCondition(StringBuilder commandStringBuilder, IColumnModification columnModification, bool useOriginalValue)
    {
        ArgumentNullException.ThrowIfNull(commandStringBuilder);
        ArgumentNullException.ThrowIfNull(columnModification);

        SqlGenerationHelper.DelimitIdentifier(commandStringBuilder, columnModification.ColumnName);

        var parameterValue = useOriginalValue
            ? columnModification.OriginalValue
            : columnModification.Value;

        if (parameterValue == null)
        {
            commandStringBuilder.Append(" IS NULL");
        }
        else
        {
            commandStringBuilder.Append(" = ");
            if (columnModification is { UseCurrentValueParameter: false, UseOriginalValueParameter: false })
            {
                AppendSqlLiteral(commandStringBuilder, columnModification, null, null);
            }
            else
            {
                SqlGenerationHelper.GenerateParameterNamePlaceholder(
                    commandStringBuilder, useOriginalValue
                        ? columnModification.OriginalParameterName
                        : columnModification.ParameterName,
                    columnModification.ColumnType);
            }
        }
    }

    private void AppendSqlLiteral(StringBuilder commandStringBuilder, IColumnModification modification, string tableName, string schema)
    {
        if (modification.TypeMapping == null)
        {
            var columnName = modification.ColumnName;
            if (tableName != null)
            {
                columnName = tableName + "." + columnName;

                if (schema != null)
                {
                    columnName = schema + "." + columnName;
                }
            }

            throw new InvalidOperationException();
        }

        commandStringBuilder.Append(modification.TypeMapping.GenerateProviderValueSqlLiteral(modification.Value));
    }

    protected override void AppendValues(StringBuilder commandStringBuilder, string name, string schema, IReadOnlyList<IColumnModification> operations)
    {
        if (operations.Count > 0)
        {
            commandStringBuilder
                .Append('(')
                .AppendJoin(
                    operations,
                    (this, name, schema),
                    (sb, o, p) =>
                    {
                        if (o.IsWrite)
                        {
                            var (g, n, s) = p;
                            if (!o.UseCurrentValueParameter)
                            {
                                g.AppendSqlLiteral(sb, o, n, s);
                            }
                            else
                            {
                                var clickHouseSqlHelper = (ClickHouseSqlGenerationHelper)g.SqlGenerationHelper;
                                clickHouseSqlHelper.GenerateParameterNamePlaceholder(sb, o);
                            }
                        }
                        else
                        {
                            sb.Append("DEFAULT");
                        }
                    })
                .Append(')');
        }
    }
}
