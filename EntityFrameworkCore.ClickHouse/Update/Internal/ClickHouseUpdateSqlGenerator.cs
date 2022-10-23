﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Update;
using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Storage.Internal;

namespace ClickHouse.EntityFrameworkCore.Update.Internal
{
    public class ClickHouseUpdateSqlGenerator : UpdateSqlGenerator
    {
        public ClickHouseUpdateSqlGenerator(UpdateSqlGeneratorDependencies dependencies) : base(dependencies)
        {
        }

        protected override void AppendDeleteCommandHeader(
            StringBuilder commandStringBuilder,
            string name,
            string schema)
        {
            if (commandStringBuilder == null)
            {
                throw new ArgumentNullException(nameof(commandStringBuilder));
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            commandStringBuilder.Append("ALTER TABLE ");
            SqlGenerationHelper.DelimitIdentifier(commandStringBuilder, name, schema);
            commandStringBuilder.Append(" DELETE");
        }

        protected override void AppendUpdateCommandHeader(
            StringBuilder commandStringBuilder,
            string name,
            string schema,
            IReadOnlyList<IColumnModification> operations)
        {
            if (commandStringBuilder == null)
            {
                throw new ArgumentNullException(nameof(commandStringBuilder));
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (operations == null)
            {
                throw new ArgumentNullException(nameof(operations));
            }

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

        protected override void AppendWhereCondition(StringBuilder commandStringBuilder, IColumnModification columnModification, bool useOriginalValue)
        {
            if (commandStringBuilder == null)
            {
                throw new ArgumentNullException(nameof(commandStringBuilder));
            }

            if (columnModification == null)
            {
                throw new ArgumentNullException(nameof(columnModification));
            }

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
                if (!columnModification.UseCurrentValueParameter
                    && !columnModification.UseOriginalValueParameter)
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

        protected override void AppendRowsAffectedWhereCondition(StringBuilder commandStringBuilder, int expectedRowsAffected)
        {
        }

        protected override void AppendIdentityWhereCondition(StringBuilder commandStringBuilder, IColumnModification columnModification)
        {
        }

        protected override void AppendWhereAffectedClause(StringBuilder commandStringBuilder, IReadOnlyList<IColumnModification> operations)
        {
        }

        protected override ResultSetMapping AppendSelectAffectedCommand(
            StringBuilder commandStringBuilder,
            string name,
            string schema,
            IReadOnlyList<IColumnModification> readOperations,
            IReadOnlyList<IColumnModification> conditionOperations,
            int commandPosition)
        {
            return ResultSetMapping.NoResultSet;
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
                    .Append("(")
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
                    .Append(")");
            }
        }
    }
}
