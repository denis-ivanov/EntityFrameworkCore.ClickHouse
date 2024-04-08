using ClickHouse.EntityFrameworkCore.Design.Internal;
using ClickHouse.EntityFrameworkCore.Diagnostics.Internal;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Scaffolding;

public class ClickHouseDatabaseModelFactoryTests : IClassFixture<ClickHouseDatabaseModelFactoryTests.ClickHouseDatabaseModelFixture>
{
    protected ClickHouseDatabaseModelFixture Fixture { get; }

    public ClickHouseDatabaseModelFactoryTests(ClickHouseDatabaseModelFixture fixture)
    {
        Fixture = fixture;
        Fixture.ListLoggerFactory.Clear();
    }

    private void Test(
        string[] createSql,
        IEnumerable<string> tables,
        IEnumerable<string> schemas,
        Action<DatabaseModel> asserter,
        string[] cleanupSql)
    {
        Array.ForEach(createSql, sql => Fixture.TestStore.ExecuteNonQuery(sql));

        try
        {
            // NOTE: You may need to update AddEntityFrameworkDesignTimeServices() too
            var services = new ServiceCollection()
                .AddSingleton<TypeMappingSourceDependencies>()
                .AddSingleton<RelationalTypeMappingSourceDependencies>()
                .AddSingleton<ValueConverterSelectorDependencies>()
                .AddSingleton<DiagnosticSource>(new DiagnosticListener(DbLoggerCategory.Name))
                .AddSingleton<ILoggingOptions, LoggingOptions>()
                .AddSingleton<LoggingDefinitions, ClickHouseLoggingDefinitions>()
                .AddSingleton(typeof(IDiagnosticsLogger<>), typeof(DiagnosticsLogger<>))
                .AddSingleton<IValueConverterSelector, ValueConverterSelector>()
                .AddSingleton<ILoggerFactory>(Fixture.ListLoggerFactory)
                .AddSingleton<IDbContextLogger, NullDbContextLogger>();

            new ClickHouseDesignTimeServices().ConfigureDesignTimeServices(services);
            //new ClickHouseNetTopologySuiteDesignTimeServices().ConfigureDesignTimeServices(services);

            var databaseModelFactory = services
                .BuildServiceProvider() // No scope validation; design services only resolved once
                .GetRequiredService<IDatabaseModelFactory>();

            var databaseModel = databaseModelFactory.Create(
                Fixture.TestStore.ConnectionString,
                new DatabaseModelFactoryOptions(tables, schemas));
            Assert.NotNull(databaseModel);
            asserter(databaseModel);
        }
        finally
        {
            if (cleanupSql != null)
            {
                Array.ForEach(cleanupSql, sql => Fixture.TestStore.ExecuteNonQuery(sql));
            }
        }
    }

    #region FilteringSchemaTable

    [ConditionalFact]
    public void Filter_tables()
        => Test(
            [
            "CREATE TABLE Everest ( id int ) ENGINE = StripeLog;",
            "CREATE TABLE Denali ( id int ) ENGINE StripeLog;"
            ],
            new[] { "Everest" },
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var table = Assert.Single(dbModel.Tables);

                // ReSharper disable once PossibleNullReferenceException
                Assert.Equal("Everest", table.Name);
            },
            [
                "DROP TABLE Everest;",
                "DROP TABLE Denali;"
            ]);

    [ConditionalFact]
    public void Filter_tables_is_case_insensitive()
        => Test(
            [
            "CREATE TABLE Everest ( id int ) ENGINE = StripeLog;",
            "CREATE TABLE Denali ( id int ) ENGINE = StripeLog;"
            ],
            new[] { "eVeReSt" },
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var table = Assert.Single(dbModel.Tables);

                // ReSharper disable once PossibleNullReferenceException
                Assert.Equal("Everest", table.Name);
            },
            [
                "DROP TABLE Everest;",
                "DROP TABLE Denali;"
            ]);

    #endregion

    #region Table

    [ConditionalFact]
    public void Create_tables()
        => Test(
            [
            "CREATE TABLE Everest ( id int ) ENGINE = StripeLog;",
            "CREATE TABLE Denali ( id int ) ENGINE = StripeLog;"
            ],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                Assert.Collection(
                    dbModel.Tables.OrderBy(t => t.Name),
                    d => Assert.Equal("Denali", d.Name),
                    e => Assert.Equal("Everest", e.Name));
            },
            [
                "DROP TABLE Everest;",
                "DROP TABLE Denali;"
            ]);

    [ConditionalFact]
    public void Create_columns()
        => Test(
            ["""
            CREATE TABLE MountainsColumns (
                Id Int32,
                Name String NOT NULL
            ) ENGINE StripeLog;
            """],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var table = dbModel.Tables.Single();

                Assert.Equal(2, table.Columns.Count);
                Assert.All(table.Columns, c => Assert.Equal("MountainsColumns", c.Table.Name));

                Assert.Single(table.Columns.Where(c => c.Name == "Id"));
                Assert.Single(table.Columns.Where(c => c.Name == "Name"));
            },
            ["DROP TABLE MountainsColumns;"]);

    [ConditionalFact]
    public void Create_view_columns()
        => Test(
            ["""
            CREATE VIEW MountainsColumnsView
             AS
            SELECT
             CAST(100 AS integer) AS Id,
             CAST('' AS text) AS Name;
            """],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var table = Assert.IsType<DatabaseView>(dbModel.Tables.Single());

                Assert.Equal(2, table.Columns.Count);
                Assert.Null(table.PrimaryKey);
                Assert.All(
                    table.Columns, c => Assert.Equal("MountainsColumnsView", c.Table.Name));

                Assert.Single((IEnumerable)table.Columns.Where(c => c.Name == "Id"));
                Assert.Single((IEnumerable)table.Columns.Where(c => c.Name == "Name"));
            },
            ["DROP VIEW MountainsColumnsView;"]);

    [ConditionalFact]
    public void Create_primary_key()
        => Test(
            ["CREATE TABLE Place ( Id int ) ENGINE = MergeTree PRIMARY KEY (Id);"],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var pk = dbModel.Tables.Single().PrimaryKey;

                Assert.Equal(["Id"], pk.Columns.Select(ic => ic.Name).ToList());
            },
            ["DROP TABLE Place;"]);

    #endregion

    #region ColumnFacets

    [ConditionalFact]
    public void Column_storetype_is_set()
        => Test(
            ["""
            CREATE TABLE StoreType (
                IntegerProperty Int32,
                RealProperty Float32,
                TextProperty String,
                BlobProperty Blob
            ) ENGINE = StripeLog;
            """],

            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                Assert.Equal("Int32", columns.Single(c => c.Name == "IntegerProperty").StoreType, ignoreCase: true);
                Assert.Equal("Float32", columns.Single(c => c.Name == "RealProperty").StoreType, ignoreCase: true);
                Assert.Equal("String", columns.Single(c => c.Name == "TextProperty").StoreType, ignoreCase: true);
                Assert.Equal("String", columns.Single(c => c.Name == "BlobProperty").StoreType, ignoreCase: true);
            },
            ["DROP TABLE StoreType;"]);

    [ConditionalFact]
    public void Column_nullability_is_set()
        => Test(
            ["""
            CREATE TABLE Nullable (
                Id int,
                NullableInt int NULL,
                NonNullString text NOT NULL
            ) ENGINE = StripeLog;
            """],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                Assert.True(columns.Single(c => c.Name == "NullableInt").IsNullable);
                Assert.False(columns.Single(c => c.Name == "NonNullString").IsNullable);
            },
            ["DROP TABLE Nullable;"]);

    [ConditionalFact]
    public void Column_default_value_is_set()
        => Test(
            ["""
            CREATE TABLE DefaultValue (
                Id int,
                SomeText text DEFAULT 'Something',
                RealColumn real DEFAULT 3.14,
                Created datetime DEFAULT('2020-10-15 11:00:00')
            ) ENGINE StripeLog
            """],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                Assert.Equal("'Something'", columns.Single(c => c.Name == "SomeText").DefaultValueSql);
                Assert.Equal("3.14", columns.Single(c => c.Name == "RealColumn").DefaultValueSql);
                Assert.Equal("'2020-10-15 11:00:00'", columns.Single(c => c.Name == "Created").DefaultValueSql);
            },
            ["DROP TABLE DefaultValue;"]);

    [ConditionalFact]
    public void Column_computed_column_sql_is_set()
        => Test(
            ["""
            CREATE TABLE ComputedColumnSql (
                Id int,
                GeneratedColumn Int32 ALIAS (1 + 2),
                GeneratedColumnStored Int32 MATERIALIZED (1 + 2)
            ) ENGINE = StripeLog;
            """],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                var generatedColumn = columns.Single(c => c.Name == "GeneratedColumn");
                Assert.NotNull(generatedColumn.ComputedColumnSql);
                Assert.Null(generatedColumn.IsStored);

                var generatedColumnStored = columns.Single(c => c.Name == "GeneratedColumnStored");
                Assert.NotNull(generatedColumnStored.ComputedColumnSql);
                Assert.True(generatedColumnStored.IsStored);
            },
            ["DROP TABLE ComputedColumnSql;"]);

    [ConditionalFact]
    public void Simple_int_literals_are_parsed_for_HasDefaultValue()
        => Test(
            ["""
            CREATE TABLE MyTable (
                Id int,
                A int DEFAULT -1,
                B int DEFAULT 0,
                C int DEFAULT (0),
                D int DEFAULT (-2),
                E int DEFAULT ( 2),
                F int DEFAULT (3 ),
                G int DEFAULT ((4))) ENGINE = StripeLog;
            """,

            "INSERT INTO MyTable VALUES (1, 1, 1, 1, 1, 1, 1, 1);"
            ],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                var column = columns.Single(c => c.Name == "A");
                Assert.Equal("-1", column.DefaultValueSql);
                Assert.Equal(-1, column.DefaultValue);

                column = columns.Single(c => c.Name == "B");
                Assert.Equal("0", column.DefaultValueSql);
                Assert.Equal(0, column.DefaultValue);

                column = columns.Single(c => c.Name == "C");
                Assert.Equal("0", column.DefaultValueSql);
                Assert.Equal(0, column.DefaultValue);

                column = columns.Single(c => c.Name == "D");
                Assert.Equal("-2", column.DefaultValueSql);
                Assert.Equal(-2, column.DefaultValue);

                column = columns.Single(c => c.Name == "E");
                Assert.Equal("2", column.DefaultValueSql);
                Assert.Equal(2, column.DefaultValue);

                column = columns.Single(c => c.Name == "F");
                Assert.Equal("3", column.DefaultValueSql);
                Assert.Equal(3, column.DefaultValue);

                column = columns.Single(c => c.Name == "G");
                Assert.Equal("4", column.DefaultValueSql);
                Assert.Equal(4, column.DefaultValue);
            },
            ["DROP TABLE MyTable;"]);

    [ConditionalFact]
    public void Simple_short_literals_are_parsed_for_HasDefaultValue()
        => Test(
            ["""
            CREATE TABLE MyTable (
                Id int,
                A smallint DEFAULT -1,
                B smallint DEFAULT (0)) ENGINE = StripeLog;
            """,

            "INSERT INTO MyTable VALUES (1, 1, 1);"
            ],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                var column = columns.Single(c => c.Name == "A");
                Assert.Equal("-1", column.DefaultValueSql);
                Assert.Equal((short)-1, column.DefaultValue);

                column = columns.Single(c => c.Name == "B");
                Assert.Equal("0", column.DefaultValueSql);
                Assert.Equal((short)0, column.DefaultValue);
            },
            ["DROP TABLE MyTable;"]);

    [ConditionalFact]
    public void Simple_long_literals_are_parsed_for_HasDefaultValue()
        => Test(
            [
                """
                 CREATE TABLE MyTable (
                     Id int,
                     A bigint DEFAULT -1,
                     B bigint DEFAULT (0)) ENGINE = StripeLog;
                """,

                $"INSERT INTO MyTable VALUES (1, {long.MaxValue}, {long.MaxValue});"
            ],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                var column = columns.Single(c => c.Name == "A");
                Assert.Equal("-1", column.DefaultValueSql);
                Assert.Equal((long)-1, column.DefaultValue);

                column = columns.Single(c => c.Name == "B");
                Assert.Equal("0", column.DefaultValueSql);
                Assert.Equal((long)0, column.DefaultValue);
            },
            ["DROP TABLE MyTable;"]);

    [ConditionalFact]
    public void Simple_byte_literals_are_parsed_for_HasDefaultValue()
        => Test(
            ["""
            CREATE TABLE MyTable (
                Id int,
                A tinyint DEFAULT 1,
                B tinyint DEFAULT (0)) ENGINE = StripeLog;
            """,
            "INSERT INTO MyTable VALUES (1, 1, 1);"
            ],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                var column = columns.Single(c => c.Name == "A");
                Assert.Equal("1", column.DefaultValueSql);
                Assert.Equal((sbyte)1, column.DefaultValue);

                column = columns.Single(c => c.Name == "B");
                Assert.Equal("0", column.DefaultValueSql);
                Assert.Equal((sbyte)0, column.DefaultValue);
            },
            ["DROP TABLE MyTable;"]);

    [ConditionalFact]
    public void Simple_double_literals_are_parsed_for_HasDefaultValue()
        => Test(
            ["""
            CREATE TABLE MyTable (
                Id Int32,
                A Float64 DEFAULT -1.1111,
                B Float64 DEFAULT (0.0),
                C Float64 DEFAULT (1.1000000000000001e+000)) ENGINE = StripeLog;
            """,

            "INSERT INTO MyTable VALUES (1, 1.1, 1.2, 1.3);"
            ],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                var column = columns.Single(c => c.Name == "A");
                Assert.Equal("-1.1111", column.DefaultValueSql);
                Assert.Equal(-1.1111, (double)column.DefaultValue, 3);

                column = columns.Single(c => c.Name == "B");
                Assert.Equal("0.", column.DefaultValueSql);
                Assert.Equal(0, (double)column.DefaultValue, 3);

                column = columns.Single(c => c.Name == "C");
                Assert.Equal("1.1", column.DefaultValueSql);
                Assert.Equal(1.1000000000000001e+000, (double)column.DefaultValue, 3);
            },
            ["DROP TABLE MyTable;"]);

    [ConditionalFact]
    public void Simple_float_literals_are_parsed_for_HasDefaultValue()
        => Test(
            ["""
            CREATE TABLE MyTable (
                Id int,
                A single DEFAULT -1.1111,
                B single DEFAULT (0.0),
                C single DEFAULT (1.1000000000000001e+000)) ENGINE = StripeLog;
            """,

            "INSERT INTO MyTable VALUES (1, '1.1', '1.2', '1.3');"
            ],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                var column = columns.Single(c => c.Name == "A");
                Assert.Equal("-1.1111", column.DefaultValueSql);
                Assert.Equal((float)-1.1111, (float)column.DefaultValue, 0.01);

                column = columns.Single(c => c.Name == "B");
                Assert.Equal("0.", column.DefaultValueSql);
                Assert.Equal((float)0, (float)column.DefaultValue, 0.01);

                column = columns.Single(c => c.Name == "C");
                Assert.Equal("1.1", column.DefaultValueSql);
                Assert.Equal((float)1.1000000000000001e+000, (float)column.DefaultValue, 0.01);
            },
            ["DROP TABLE MyTable;"]);

    [ConditionalFact]
    public void Simple_decimal_literals_are_parsed_for_HasDefaultValue()
        => Test(
            ["""
            CREATE TABLE MyTable (
                Id Int32,
                A Decimal DEFAULT '-1.1111',
                B Decimal DEFAULT ('0.0'),
                C Decimal DEFAULT ('0')) ENGINE = StripeLog;
            """,

            "INSERT INTO MyTable VALUES (1, '1.1', '1.2', '1.3');"
            ],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                var column = columns.Single(c => c.Name == "A");
                Assert.Equal("'-1.1111'", column.DefaultValueSql);
                Assert.Equal((decimal)-1.1111, column.DefaultValue);

                column = columns.Single(c => c.Name == "B");
                Assert.Equal("'0.0'", column.DefaultValueSql);
                Assert.Equal((decimal)0, column.DefaultValue);

                column = columns.Single(c => c.Name == "C");
                Assert.Equal("'0'", column.DefaultValueSql);
                Assert.Equal((decimal)0, column.DefaultValue);
            },
            ["DROP TABLE MyTable;"]);

    [ConditionalFact]
    public void Simple_bool_literals_are_parsed_for_HasDefaultValue()
        => Test(
            [
                """
                CREATE TABLE MyTable (
                    Id int,
                    A bit DEFAULT 0,
                    B bit DEFAULT 1,
                    C bit DEFAULT (0),
                    D bit DEFAULT (1)) ENGINE = StripeLog;
                """,
                "INSERT INTO MyTable VALUES (1, 1, 1, 1, 1);"
            ],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                var column = columns.Single(c => c.Name == "A");
                Assert.Equal("0", column.DefaultValueSql);
                Assert.Equal(0UL, column.DefaultValue);

                column = columns.Single(c => c.Name == "B");
                Assert.Equal("1", column.DefaultValueSql);
                Assert.Equal(1UL, column.DefaultValue);

                column = columns.Single(c => c.Name == "C");
                Assert.Equal("0", column.DefaultValueSql);
                Assert.Equal(0UL, column.DefaultValue);

                column = columns.Single(c => c.Name == "D");
                Assert.Equal("1", column.DefaultValueSql);
                Assert.Equal(1UL, column.DefaultValue);
            },
            ["DROP TABLE MyTable;"]);

    [ConditionalFact]
    public void Simple_DateTime_literals_are_parsed_for_HasDefaultValue()
        => Test(
            ["""
            CREATE TABLE MyTable (
                Id int,
                A DateTime64 DEFAULT '1973-09-03T12:00:01.0020000',
                B DateTime64 DEFAULT ('1968-10-23')) ENGINE = StripeLog;
            """,

            "INSERT INTO MyTable VALUES (1, '2023-01-20 13:37:00', '2023-01-20 13:37:00');"
            ],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                var column = columns.Single(c => c.Name == "A");
                Assert.Equal("'1973-09-03T12:00:01.0020000'", column.DefaultValueSql);
                Assert.Equal(new DateTime(1973, 9, 3, 12, 0, 1, 2, DateTimeKind.Unspecified), column.DefaultValue);

                column = columns.Single(c => c.Name == "B");
                Assert.Equal("'1968-10-23'", column.DefaultValueSql);
                Assert.Equal(new DateTime(1968, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), column.DefaultValue);
            },
            ["DROP TABLE MyTable;"]);

    [ConditionalFact]
    public void Non_literal_or_non_parsable_DateTime_default_values_are_passed_through()
        => Test(
            [
            """
            CREATE TABLE MyTable (
            
                Id int,
                A datetime DEFAULT now(),
                B datetime DEFAULT today()) ENGINE = StripeLog;
            """,
            "INSERT INTO MyTable VALUES (1, '2023-01-20 13:37:00', '2023-01-20 13:37:00');"
            ],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                var column = columns.Single(c => c.Name == "A");
                Assert.Equal("now()", column.DefaultValueSql);
                Assert.Null(column.FindAnnotation(RelationalAnnotationNames.DefaultValue));

                column = columns.Single(c => c.Name == "B");
                Assert.Equal("today()", column.DefaultValueSql);
                Assert.Null(column.FindAnnotation(RelationalAnnotationNames.DefaultValue));
            },
            ["DROP TABLE MyTable;"]);

    [ConditionalFact]
    public void Simple_DateOnly_literals_are_parsed_for_HasDefaultValue()
        => Test(
            ["""
            CREATE TABLE MyTable (
                Id int,
                A date DEFAULT ('1968-10-23'),
                B date DEFAULT (('1973-09-03T01:02:03'))) ENGINE = StripeLog;
            """,

            "INSERT INTO MyTable VALUES (1, '2023-01-20', '2023-01-20');"],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                var column = columns.Single(c => c.Name == "A");
                Assert.Equal("'1968-10-23'", column.DefaultValueSql);
                Assert.Equal(new DateOnly(1968, 10, 23), column.DefaultValue);

                column = columns.Single(c => c.Name == "B");
                Assert.Equal("'1973-09-03T01:02:03'", column.DefaultValueSql);
                Assert.Equal(new DateOnly(1973, 9, 3), column.DefaultValue);
            },
            ["DROP TABLE MyTable;"]);

    [ConditionalFact]
    public void Simple_Guid_literals_are_parsed_for_HasDefaultValue()
        => Test(
            ["""
            CREATE TABLE MyTable (
                Id int,
                A UUID DEFAULT ('0E984725-C51C-4BF4-9960-E1C80E27ABA0')) ENGINE = StripeLog;
            """,

            "INSERT INTO MyTable VALUES (1, '993CDD7A-F4DF-4C5E-A810-8F51A11E9B6D');"
            ],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                var column = columns.Single(c => c.Name == "A");
                Assert.Equal("'0E984725-C51C-4BF4-9960-E1C80E27ABA0'", column.DefaultValueSql);
                Assert.Equal(new Guid("0E984725-C51C-4BF4-9960-E1C80E27ABA0"), column.DefaultValue);
            },
            ["DROP TABLE MyTable;"]);

    [ConditionalFact]
    public void Simple_string_literals_are_parsed_for_HasDefaultValue()
        => Test(
            ["""
            CREATE TABLE MyTable (
                Id int,
                A nvarchar DEFAULT 'Hot',
                B varchar DEFAULT ('Buttered'),
                C character(100) DEFAULT (''),
                D text DEFAULT (''),
                E nvarchar(100) DEFAULT  ( ' Toast! ')) ENGINE = StripeLog;
            """,

            "INSERT INTO MyTable VALUES (1, 'A', 'Tale', 'Of', 'Two', 'Cities');"
            ],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var columns = dbModel.Tables.Single().Columns;

                var column = columns.Single(c => c.Name == "A");
                Assert.Equal("'Hot'", column.DefaultValueSql);
                Assert.Equal("Hot", column.DefaultValue);

                column = columns.Single(c => c.Name == "B");
                Assert.Equal("'Buttered'", column.DefaultValueSql);
                Assert.Equal("Buttered", column.DefaultValue);

                column = columns.Single(c => c.Name == "C");
                Assert.Equal("''", column.DefaultValueSql);
                Assert.Equal("", column.DefaultValue);

                column = columns.Single(c => c.Name == "D");
                Assert.Equal("''", column.DefaultValueSql);
                Assert.Equal("", column.DefaultValue);

                column = columns.Single(c => c.Name == "E");
                Assert.Equal("' Toast! '", column.DefaultValueSql);
                Assert.Equal(" Toast! ", column.DefaultValue);
            },
            ["DROP TABLE MyTable;"]);

    #endregion

    #region PrimaryKeyFacets

    [ConditionalFact]
    public void Create_composite_primary_key()
        => Test(
            ["""
            CREATE TABLE CompositePrimaryKey (
                Id1 int,
                Id2 text
            ) ENGINE = MergeTree
            PRIMARY KEY ( Id2, Id1 );
            """],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var pk = dbModel.Tables.Single().PrimaryKey;

                Assert.Equal(["Id2", "Id1"], pk.Columns.Select(ic => ic.Name).ToList());
            },
            ["DROP TABLE CompositePrimaryKey;"]);

    [ConditionalFact]
    public void Create_primary_key_when_integer_primary_key_aliased_to_rowid()
        => Test(
            ["""

            CREATE TABLE RowidPrimaryKey (
                Id Int32
            ) ENGINE MergeTree PRIMARY KEY (Id);
            """],
            Enumerable.Empty<string>(),
            Enumerable.Empty<string>(),
            dbModel =>
            {
                var pk = dbModel.Tables.Single().PrimaryKey;

                //Assert.Equal("RowidPrimaryKey", pk.Table.Name);
                Assert.Equal(["Id"], pk.Columns.Select(ic => ic.Name).ToList());
            },
            ["DROP TABLE RowidPrimaryKey;"]);

    #endregion

    public class ClickHouseDatabaseModelFixture : SharedStoreFixtureBase<PoolableDbContext>
    {
        protected override string StoreName
            => nameof(ClickHouseDatabaseModelFactoryTests);

        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;

        public new ClickHouseTestStore TestStore
            => (ClickHouseTestStore)base.TestStore;

        protected override bool ShouldLogCategory(string logCategory)
            => logCategory == DbLoggerCategory.Scaffolding.Name;
    }
}
