using ClickHouse.Driver.ADO;
using System.Data;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests;

public class ProviderTests
{
    [Fact]
    public void Fact()
    {
        const string connectionStringBase = "Host=localhost;Protocol=http;Port=8123;Username=default;Password=changeme";

        var connection = new ClickHouseConnection(connectionStringBase);
        connection.SetFormDataParameters(true);

        var command = connection.CreateCommand();
        command.CommandText = """
                              CREATE DATABASE IF NOT EXISTS array_with_null_item;
                              """;

        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();

        connection.ConnectionString = $"{connectionStringBase};Database=array_with_null_item";
        connection.Open();

        command.CommandText = """
                              CREATE TABLE IF NOT EXISTS my_table
                              (
                                  Id Int32,
                                  Value Array(Nullable(String))
                              )
                              ENGINE = MergeTree()
                              ORDER BY Id;
                              """;
        command.ExecuteNonQuery();

        command.CommandText = "INSERT INTO my_table VALUES (1, {p0:Array(Nullable(String))})";
        var array = new string[] { "1", "2", "3", null };
        var arrayParameter = command.CreateParameter();
        arrayParameter.ParameterName = "p0";
        arrayParameter.Value = array;
        arrayParameter.DbType = DbType.Object;
        arrayParameter.ClickHouseType = "Array(Nullable(String))";
        command.Parameters.Add(arrayParameter);

        command.ExecuteNonQuery();
    }
}