using System;
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

        protected override void AppendRowsAffectedWhereCondition(StringBuilder commandStringBuilder, int expectedRowsAffected)
        {
            throw new System.NotImplementedException();
        }

        protected override void AppendIdentityWhereCondition(StringBuilder commandStringBuilder, ColumnModification columnModification)
        {
            throw new System.NotImplementedException();
        }

        private void AppendSqlLiteral(StringBuilder commandStringBuilder, ColumnModification modification, string tableName, string schema)
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
        
        protected override void AppendValues(StringBuilder commandStringBuilder, string name, string schema, IReadOnlyList<ColumnModification> operations)
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