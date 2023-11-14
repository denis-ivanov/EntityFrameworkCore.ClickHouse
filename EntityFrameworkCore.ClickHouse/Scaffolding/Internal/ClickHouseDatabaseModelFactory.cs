using ClickHouse.Client.ADO;
using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace ClickHouse.EntityFrameworkCore.Scaffolding.Internal;

public class ClickHouseDatabaseModelFactory : DatabaseModelFactory
{
    public override DatabaseModel Create(string connectionString, DatabaseModelFactoryOptions options)
    {
        var connection = new ClickHouseConnection(connectionString);
        return Create(connection, options);
    }

    public override DatabaseModel Create(DbConnection connection, DatabaseModelFactoryOptions options)
    {
        var sb = new ClickHouseConnectionStringBuilder(connection.ConnectionString);
        var result = new DatabaseModel { DatabaseName = sb.Database };
        var tables = LoadTables(connection, result);
        tables.ForEach(e => result.Tables.Add(e));
        return result;
    }

    private List<DatabaseTable> LoadTables(DbConnection connection, DatabaseModel database)
    {
        var result = new List<DatabaseTable>();
        var primaryKeys = new Dictionary<string, string[]>();
        var query = $"SELECT * FROM system.tables WHERE database='{database.DatabaseName}';";

        connection.Open();

        using (var command = connection.CreateCommand(query))
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var table = new DatabaseTable
                {
                    Database = database,
                    Name = reader.GetString("name")
                };

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
        var query = $"SELECT * FROM system.columns WHERE database='{database.DatabaseName}' AND name IN ({tablesQ});";

        using (var command = connection.CreateCommand(query))
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var tableName = reader.GetString("name");
                var table = tables.Single(e => e.Name == tableName);
                var column = new DatabaseColumn
                {
                    Comment = reader.GetString("comment"),
                    StoreType = reader.GetString("type"),
                    IsNullable = reader.GetString("type").StartsWith("Nullable"),
                    DefaultValueSql = reader.GetString("default_expression"),
                    Name = reader.GetString("name"),
                    Table = table
                };

                table.Columns.Add(column);
            }

            connection.Close();

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
    }
}
