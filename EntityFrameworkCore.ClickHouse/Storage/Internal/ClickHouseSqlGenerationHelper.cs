using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using System;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal
{
    public class ClickHouseSqlGenerationHelper : RelationalSqlGenerationHelper
    {
        public ClickHouseSqlGenerationHelper(RelationalSqlGenerationHelperDependencies dependencies)
            : base(dependencies)
        {
        }

        public void GenerateParameterNamePlaceholder(StringBuilder builder, ColumnModification column) =>
            this.GenerateParameterNamePlaceholder(builder, column.ParameterName, column.ColumnType);

        public void GenerateParameterNamePlaceholder(StringBuilder builder, string name, string type) =>
            builder.Append('{').Append($"{name}:{type}").Append('}');

        public override void GenerateParameterName(StringBuilder builder, string name)
        {
            throw new NotImplementedException();
        }

        public override string GenerateParameterName(string name) => name;
    }
}
