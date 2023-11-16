using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Text;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal;

public class ClickHouseSqlGenerationHelper : RelationalSqlGenerationHelper
{
    private const string ParameterFormat = "{{{0}:{1}}}";

    public ClickHouseSqlGenerationHelper(RelationalSqlGenerationHelperDependencies dependencies)
        : base(dependencies)
    {
    }

    public void GenerateParameterNamePlaceholder(StringBuilder builder, IColumnModification column) =>
        GenerateParameterNamePlaceholder(builder, column.ParameterName, column.IsNullable.GetValueOrDefault() ? $"Nullable({column.ColumnType})" : column.ColumnType);

    public void GenerateParameterNamePlaceholder(StringBuilder builder, string name, string type) =>
        builder.AppendFormat(ParameterFormat, name, type);

    public string GenerateParameterName(string name, string type) =>
        string.Format(ParameterFormat, name, type);

    public override void GenerateParameterName(StringBuilder builder, string name)
    {
        throw new NotImplementedException();
    }

    public override string GenerateParameterName(string name) => name;
}
