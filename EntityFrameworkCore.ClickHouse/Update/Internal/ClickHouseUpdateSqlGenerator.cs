using System.Text;
using Microsoft.EntityFrameworkCore.Update;

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
    }
}