using ClickHouse.Driver.ADO;
using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Metadata;
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

using ClickHouse.EntityFrameworkCore.Storage.Internal;

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
        var connection = new ClickHouseDbConnection(connectionString);
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
            var comment = reader.GetString("comment");
            var table = isView ? new DatabaseView() : new DatabaseTable();
            table.Database = database;
            table.Name = reader.GetString("name");
            table.Comment = string.IsNullOrEmpty(comment) ? null : comment;

            if (tables.Count > 0 && !tables.Contains(table.Name))
            {
                continue;
            }

            var partitionKey = ParseColumns(reader.GetString("partition_key"));
            var sortingKey = ParseColumns(reader.GetString("sorting_key"));
            var primaryKey = ParseColumns(reader.GetString("primary_key"));
            var samplingKey = ParseColumns(reader.GetString("sampling_key"));

            if (primaryKey != null)
            {
                primaryKeys[table.Name] = primaryKey;
                table.SetPrimaryKey(primaryKey);
            }

            if (partitionKey != null)
            {
                table.SetPartitionBy(partitionKey);
            }

            if (sortingKey != null)
            {
                table.SetOrderBy(sortingKey);
            }

            if (samplingKey != null)
            {
                table.SetSampleBy(samplingKey);
            }

            table.SetTableEngine(reader.GetString("engine"));
            SetTableEngineArgs(table, reader.GetString("engine_full"));

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
            var type = reader.GetString("type");
            var name = reader.GetString("name");
            var (isNullable, storeType) = ParseType(type);

            var numericPrecision = reader.IsDBNull("numeric_precision")
                ? null
                : reader.GetFieldValue<ulong?>("numeric_precision");

            var numericScale = reader.IsDBNull("numeric_scale")
                ? null
                : reader.GetFieldValue<ulong?>("numeric_scale");

            var table = tables.Single(e => e.Name == tableName);

            var column = new DatabaseColumn
            {
                Comment = string.IsNullOrEmpty(comment) ? null : comment,
                StoreType = storeType,
                IsNullable = isNullable,
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

            column.IsStored = defaultKind switch
            {
                "MATERIALIZED" => true,
                "ALIAS" => false,
                _ => column.IsStored
            };

            if (numericPrecision.HasValue)
            {
                column.SetAnnotation(CoreAnnotationNames.Precision, Convert.ToInt32(numericPrecision.Value));
            }

            if (numericScale.HasValue)
            {
                column.SetAnnotation(CoreAnnotationNames.Scale, Convert.ToInt32(numericScale.Value));
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

    private static (bool IsNullable, string StoreType) ParseType(string storeType)
    {
        return storeType.StartsWith("Nullable(")
            ? (true, storeType.Substring(9, storeType.Length - 10))
            : (false, storeType);
    }

    private static bool IsInteger(Type type)
    {
        type = type.UnwrapNullableType();

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

    private static string[] ParseColumns(string columnsSql)
    {
        return string.IsNullOrWhiteSpace(columnsSql) ? null : Array.ConvertAll(columnsSql.Split(','), e => e.Trim());
    }

    private static string[] ParseEngineArgs(string engineFull)
    {
        if (string.IsNullOrWhiteSpace(engineFull))
        {
            return null;
        }

        var openBracePosition = engineFull.IndexOf('(');

        if (openBracePosition < 0)
        {
            return null;
        }

        var closeBracePosition = engineFull.IndexOf(')', openBracePosition);

        if (closeBracePosition < 0)
        {
            return null;
        }

        var args = engineFull.Substring(openBracePosition + 1, closeBracePosition - openBracePosition - 1);

        return ParseColumns(args);
    }

    private static void SetTableEngineArgs(DatabaseTable table, string engineFull)
    {
        var args = ParseEngineArgs(engineFull);

        if (args == null || args.Length == 0)
        {
            return;
        }

        var tableEngine = table.GetTableEngine();

        switch (tableEngine)
        {
            case ClickHouseAnnotationNames.ReplacingMergeTree:
                table.SetReplacingMergeTreeTableEngineVersion(args[0]);

                if (args.Length == 2)
                {
                    table.SetReplacingMergeTreeTableEngineIsDeleted(args[1]);
                }

                break;

            case ClickHouseAnnotationNames.SummingMergeTree:
                table.SetSummingMergeTreeTableEngineColumn(args[0]);
                break;

            case ClickHouseAnnotationNames.CollapsingMergeTree:
                table.SetSummingMergeTreeTableEngineColumn(args[0]);
                break;
        }
    }
}