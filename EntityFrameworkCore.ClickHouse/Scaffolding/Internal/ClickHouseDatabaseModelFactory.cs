using ClickHouse.Client.ADO;
using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace ClickHouse.EntityFrameworkCore.Scaffolding.Internal;

public class ClickHouseDatabaseModelFactory : DatabaseModelFactory
{
    private readonly IRelationalTypeMappingSource _typeMappingSource;

    public ClickHouseDatabaseModelFactory(IRelationalTypeMappingSource typeMappingSource)
    {
        _typeMappingSource = typeMappingSource;
    }

    public override DatabaseModel Create(string connectionString, DatabaseModelFactoryOptions options)
    {
        var connection = new ClickHouseConnection(connectionString);
        return Create(connection, options);
    }

    public override DatabaseModel Create(DbConnection connection, DatabaseModelFactoryOptions options)
    {
        var sb = new ClickHouseConnectionStringBuilder(connection.ConnectionString);
        var result = new DatabaseModel { DatabaseName = sb.Database };
        var tables = LoadTables(connection, result, options.Tables.ToImmutableHashSet(StringComparer.InvariantCultureIgnoreCase));

        tables.ForEach(e => result.Tables.Add(e));
        return result;
    }

    private List<DatabaseTable> LoadTables(DbConnection connection, DatabaseModel database, ISet<string> tables)
    {
        var result = new List<DatabaseTable>();
        var primaryKeys = new Dictionary<string, string[]>();
        var query = $"SELECT * FROM system.tables WHERE database='{database.DatabaseName}';";

        connection.Open();

        using var command = connection.CreateCommand(query);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var isView = !string.IsNullOrWhiteSpace(Convert.ToString(reader["as_select"]));
            var table = isView ? new DatabaseView() : new DatabaseTable();
            table.Database = database;
            table.Name = reader.GetString("name");

            if (tables.Count > 0 && !tables.Contains(table.Name))
            {
                continue;
            }

            var primaryKey = reader.GetString("primary_key");

            if (!string.IsNullOrEmpty(primaryKey))
            {
                var primaryKeyColumns = Array.ConvertAll(primaryKey.Split(','), e => e.Trim());
                primaryKeys[table.Name] = primaryKeyColumns;
            }
                    
            result.Add(table);
        }

        connection.Close();
        LoadColumns(connection, result, database, primaryKeys);
        // TODO LoadConstraints(...);
        return result;
    }

    private void LoadColumns(
        DbConnection connection,
        List<DatabaseTable> tables,
        DatabaseModel database,
        Dictionary<string, string[]> primaryKeys)
    {
        if (tables.Count == 0)
        {
            return;
        }

        connection.Open();
        var tablesQ = string.Join(", ", tables.Select(e => $"'{e.Name}'"));
        var query = $"SELECT * FROM system.columns WHERE database='{database.DatabaseName}' AND table IN ({tablesQ});";

        using var command = connection.CreateCommand(query);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var tableName = reader.GetString("table");
            var defaultKind = reader.GetString("default_kind");
            var defaultExpression = reader.GetString("default_expression");
            var comment = reader.GetString("comment");
            var storeType = reader.GetString("type");
            var name = reader.GetString("name");

            var numericPrecision = reader.IsDBNull("numeric_precision")
                ? null
                : reader.GetFieldValue<ulong?>("numeric_precision");

            var numericScale = reader.IsDBNull("numeric_scale")
                ? null
                : reader.GetFieldValue<ulong?>("numeric_scale");

            var table = tables.Single(e => e.Name == tableName);

            var column = new DatabaseColumn
            {
                Comment = comment,
                StoreType = storeType,
                IsNullable = storeType.StartsWith("Nullable"),
                Name = name,
                Table = table
            };

            if (defaultKind == "DEFAULT")
            {
                column.DefaultValueSql = defaultExpression;
            }
            else if (!string.IsNullOrWhiteSpace(defaultExpression))
            {
                column.ComputedColumnSql = defaultExpression;
            }

            if (defaultKind == "MATERIALIZED")
            {
                column.IsStored = true;
            }

            if (numericPrecision.HasValue)
            {
                column.SetAnnotation(CoreAnnotationNames.Precision, numericPrecision.Value);
            }

            if (numericScale.HasValue)
            {
                column.SetAnnotation(CoreAnnotationNames.Scale, numericScale.Value);
            }

            table.Columns.Add(column);
        }

        connection.Close();

        tables.ForEach(ParseClrDefaults);

        foreach (var primaryKey in primaryKeys)
        {
            var table = tables.Single(e => e.Name == primaryKey.Key);
            table.PrimaryKey = new DatabasePrimaryKey();

            foreach (var columnName in primaryKey.Value)
            {
                var column = table.Columns.Single(e => e.Name == columnName);
                table.PrimaryKey.Columns.Add(column);
            }
        }
    }

    private void ParseClrDefaults(DatabaseTable table)
    {
        foreach (var column in table.Columns)
        {
            var defaultValueSql = column.DefaultValueSql;
            defaultValueSql = defaultValueSql?.Trim();
            if (string.IsNullOrEmpty(defaultValueSql))
            {
                continue;
            }

            var type = _typeMappingSource.FindMapping(column.StoreType!)?.ClrType;

            if (type == null)
            {
                continue;
            }

            Unwrap();

            if (defaultValueSql.Equals("NULL", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (type == typeof(bool)
                && int.TryParse(defaultValueSql, out var intValue))
            {
                column.DefaultValue = intValue != 0;
            }
            else if (IsInteger(type)
                     || type == typeof(float)
                     || type == typeof(double))
            {
                try
                {
                    column.DefaultValue = Convert.ChangeType(defaultValueSql, type);
                }
                catch
                {
                    // Ignored
                }
            }
            else if (defaultValueSql.StartsWith('\'')
                     && defaultValueSql.EndsWith('\''))
            {
                defaultValueSql = defaultValueSql.Substring(1, defaultValueSql.Length - 2);

                if (type == typeof(string))
                {
                    column.DefaultValue = defaultValueSql;
                }
                else if (type == typeof(Guid)
                         && Guid.TryParse(defaultValueSql, out var guid))
                {
                    column.DefaultValue = guid;
                }
                else if (type == typeof(DateTime)
                         && DateTime.TryParse(defaultValueSql, out var dateTime))
                {
                    column.DefaultValue = dateTime;
                }
                else if (type == typeof(DateOnly)
                         && DateOnly.TryParse(defaultValueSql, out var dateOnly))
                {
                    column.DefaultValue = dateOnly;
                }
                else if (type == typeof(TimeOnly)
                         && TimeOnly.TryParse(defaultValueSql, out var timeOnly))
                {
                    column.DefaultValue = timeOnly;
                }
                else if (type == typeof(DateTimeOffset)
                         && DateTimeOffset.TryParse(defaultValueSql, out var dateTimeOffset))
                {
                    column.DefaultValue = dateTimeOffset;
                }
                else if (type == typeof(decimal)
                         && decimal.TryParse(defaultValueSql, out var decimalValue))
                {
                    column.DefaultValue = decimalValue;
                }
            }

            void Unwrap()
            {
                while (defaultValueSql.StartsWith('(') && defaultValueSql.EndsWith(')'))
                {
                    defaultValueSql = (defaultValueSql.Substring(1, defaultValueSql.Length - 2)).Trim();
                }
            }
        }
    }

    private static Type UnwrapNullableType(Type type)
        => Nullable.GetUnderlyingType(type) ?? type;

    private static bool IsInteger(Type type)
    {
        type = UnwrapNullableType(type);

        return type == typeof(int)
               || type == typeof(long)
               || type == typeof(short)
               || type == typeof(byte)
               || type == typeof(uint)
               || type == typeof(ulong)
               || type == typeof(ushort)
               || type == typeof(sbyte)
               || type == typeof(char);
    }
}
