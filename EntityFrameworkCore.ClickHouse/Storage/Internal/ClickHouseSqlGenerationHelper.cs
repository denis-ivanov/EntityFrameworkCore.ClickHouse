using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal
{
    public class ClickHouseSqlGenerationHelper : RelationalSqlGenerationHelper
    {
        public ClickHouseSqlGenerationHelper(RelationalSqlGenerationHelperDependencies dependencies)
            : base(dependencies)
        {
        }

        public void GenerateParameterNamePlaceholder(StringBuilder builder, ColumnModification column) =>
            builder.Append('{').Append($"{column.ParameterName}:{column.ColumnType}").Append('}');

        public override string GenerateParameterName(string name) => name;

        public override void GenerateParameterName(StringBuilder builder, string name)
        {
            base.GenerateParameterName(builder, name);
        }

        public override string DelimitIdentifier(string identifier)
        {
            return base.DelimitIdentifier(identifier);
        }

        public override string DelimitIdentifier(string name, string schema)
        {
            return base.DelimitIdentifier(name, schema);
        }

        public override void DelimitIdentifier(StringBuilder builder, string identifier)
        {
            base.DelimitIdentifier(builder, identifier);
        }

        public override void DelimitIdentifier(StringBuilder builder, string name, string schema)
        {
            base.DelimitIdentifier(builder, name, schema);
        }
    }
}
