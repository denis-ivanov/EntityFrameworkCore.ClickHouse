using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal
{
    public class ClickHouseSqlGenerationHelper : RelationalSqlGenerationHelper
    {
        public ClickHouseSqlGenerationHelper(RelationalSqlGenerationHelperDependencies dependencies)
            : base(dependencies)
        {
        }

        public string GenerateParameterNamePlaceholder(string name, string type) => $"{{{name}:{type}}}";

        public override void GenerateParameterName(StringBuilder builder, string name)
        {
            throw new NotImplementedException();
        }

        public override string GenerateParameterName(string name) => name;
    }
}
