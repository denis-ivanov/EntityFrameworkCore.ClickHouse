using ClickHouse.EntityFrameworkCore.Extensions;
using ClickHouse.EntityFrameworkCore.Metadata;
using ClickHouse.EntityFrameworkCore.Scaffolding.Internal;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Migrations;

public class MigrationsClickHouseTest : MigrationsTestBase<MigrationsClickHouseTest.MigrationsClickHouseFixture>
{
    public MigrationsClickHouseTest(MigrationsClickHouseFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = "TBD")]
    public override async Task Add_required_primitve_collection_with_custom_default_value_sql_to_existing_table()
    {
        await base.Add_required_primitve_collection_with_custom_default_value_sql_to_existing_table_core("'[3, 2, 1]'");

        AssertSql(
            """
            ALTER TABLE "Customers" ADD "Numbers" TEXT NOT NULL DEFAULT ('[3, 2, 1]');
            """);
    }

    [ConditionalFact(Skip = "https://github.com/ClickHouse/ClickHouse/issues/15234#issuecomment-698370062")]
    public override Task Rename_index()
    {
        return base.Rename_index();
    }

    [ConditionalFact(Skip = "ClickHouse does not support foreign keys")]
    public override Task Add_foreign_key()
    {
        return base.Add_foreign_key();
    }

    [ConditionalFact(Skip = "ClickHouse does not support foreign keys")]
    public override Task Add_foreign_key_with_name()
    {
        return base.Add_foreign_key_with_name();
    }

    [ConditionalFact(Skip = "ClickHouse does not support schemas")]
    public override Task Create_schema()
    {
        return base.Create_schema();
    }

    [ConditionalFact(Skip = "ClickHouse does not support sequences")]
    public override Task Create_sequence()
    {
        return base.Create_sequence();
    }

    [ConditionalFact]
    public override Task Add_check_constraint_with_name()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<int>("DriverLicense");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder =>
            {
            },
            builder => builder.Entity("People").ToTable(tb => tb.HasCheckConstraint("CK_People_Foo", $"{DelimitIdentifier("DriverLicense")} > 0")),
            model =>
            {
                // TODO: no scaffolding support for check constraints, https://github.com/aspnet/EntityFrameworkCore/issues/15408
            });

    [ConditionalFact(Skip = "ClickHouse does not support ANSI/not ANSI")]
    public override Task Add_column_with_ansi()
    {
        return base.Add_column_with_ansi();
    }

    [ConditionalFact]
    public override Task Add_column_with_check_constraint()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");
                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => { },
            builder => builder.Entity(
                "People", e =>
                {
                    e.Property<int>("DriverLicense");
                    e.ToTable(tb => tb.HasCheckConstraint("CK_People_Foo", $"{DelimitIdentifier("DriverLicense")} > 0"));
                }),
            model =>
            {
                // TODO: no scaffolding support for check constraints, https://github.com/aspnet/EntityFrameworkCore/issues/15408
            });

    [ConditionalTheory(Skip = "ClickHouse does not support collations")]
    public override Task Add_column_computed_with_collation(bool stored)
    {
        return base.Add_column_computed_with_collation(stored);
    }

    [ConditionalFact(Skip = "ClickHouse does not support collations")]
    public override Task Add_column_with_collation()
    {
        return base.Add_column_with_collation();
    }

    [ConditionalFact]
    public override Task Add_column_with_comment()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.ToTable(table => table
                        .HasMergeTreeEngine()
                        .WithPrimaryKey("Id"));

                entityTypeBuilder.Property<int>("Id");
            },
            builder => { },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.ToTable(table => table
                        .HasMergeTreeEngine()
                        .WithPrimaryKey("Id"));

                entityTypeBuilder.Property<string>("FullName").HasComment("My comment");
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                var column = Assert.Single(table.Columns, c => c.Name == "FullName");
                if (AssertComments)
                {
                    Assert.Equal("My comment", column.Comment);
                }
            });

    [ConditionalTheory]
    public override async Task Add_column_with_computedSql(bool? stored)
    {
        await Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<int>("X");
                entityTypeBuilder.Property<int>("Y");

                entityTypeBuilder.ToTable("People", tableBuilder => tableBuilder
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => { },
            builder => builder.Entity("People").Property<string>("Sum")
                .HasComputedColumnSql($"{DelimitIdentifier("X")} + {DelimitIdentifier("Y")}", stored),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var sumColumn = Assert.Single(table.Columns, c => c.Name == "Sum");
                if (AssertComputedColumns)
                {
                    Assert.Contains("X", sumColumn.ComputedColumnSql);
                    Assert.Contains("Y", sumColumn.ComputedColumnSql);
                    if (stored != null)
                    {
                        Assert.Equal(stored, sumColumn.IsStored);
                    }
                }
            });
    }

    [ConditionalFact]
    public override Task Add_column_with_defaultValue_datetime()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");
                entityTypeBuilder.Property<int>("Id");

                entityTypeBuilder.ToTable(e => e
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            _ => { },
            builder =>
            {
                builder.Entity("People")
                    .Property<DateTime>("Birthday")
                    .HasDefaultValue(new DateTime(2015, 4, 12, 17, 5, 0));
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal(2, table.Columns.Count);
                var birthdayColumn = Assert.Single(table.Columns, c => c.Name == "Birthday");
                Assert.False(birthdayColumn.IsNullable);
            });

    [ConditionalFact]
    public override Task Add_column_with_defaultValue_string()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");
                entityTypeBuilder.Property<int>("Id");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => { },
            builder => builder.Entity("People").Property<string>("Name")
                .IsRequired()
                .HasDefaultValue("John Doe"),
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal(2, table.Columns.Count);
                var nameColumn = Assert.Single(table.Columns, c => c.Name == "Name");
                Assert.False(nameColumn.IsNullable);
                Assert.Contains("John Doe", nameColumn.DefaultValueSql);
            });

    [ConditionalFact]
    public override Task Add_column_with_defaultValueSql()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");
                entityTypeBuilder.Property<int>("Id");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            _ => { },
            builder => builder.Entity("People")
                .Property<int>("Sum")
                .HasDefaultValueSql("1 + 2"),
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal(2, table.Columns.Count);
                var sumColumn = Assert.Single(table.Columns, c => c.Name == "Sum");
                Assert.Contains("1", sumColumn.DefaultValueSql);
                Assert.Contains("+", sumColumn.DefaultValueSql);
                Assert.Contains("2", sumColumn.DefaultValueSql);
            });

    [ConditionalFact]
    public override Task Add_column_with_fixed_length()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");
                entityTypeBuilder.Property<int>("Id");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            _ => { },
            builder => builder.Entity("People")
                .Property<string>("Name")
                .IsFixedLength()
                .HasMaxLength(100),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var column = Assert.Single(table.Columns, c => c.Name == "Name");
                Assert.Equal(
                    TypeMappingSource
                        .FindMapping(typeof(string), storeTypeName: null, fixedLength: true, size: 100)
                        .StoreType,
                    column.StoreType);
            });

    [ConditionalFact]
    public override Task Add_column_with_max_length()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");
                entityTypeBuilder.Property<int>("Id");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            _ => { },
            builder => builder.Entity("People")
                .Property<string>("Name")
                .HasMaxLength(30),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var column = Assert.Single(table.Columns, c => c.Name == "Name");
                Assert.Equal(
                    TypeMappingSource
                        .FindMapping(typeof(string), storeTypeName: null, size: 30)
                        .StoreType,
                    column.StoreType);
            });

    [ConditionalFact]
    public override Task Add_column_with_required()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");
                entityTypeBuilder.Property<int>("Id");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            _ => { },
            builder => builder.Entity("People")
                .Property<string>("Name")
                .IsRequired(),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var column = Assert.Single(table.Columns, c => c.Name == "Name");
                Assert.Equal(TypeMappingSource.FindMapping(typeof(string))!.StoreType, column.StoreType);
                Assert.False(column.IsNullable);
            });

    [ConditionalFact]
    public override Task Add_column_with_unbounded_max_length()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");
                entityTypeBuilder.Property<int>("Id");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => { },
            builder => builder.Entity("People").Property<string>("Name").HasMaxLength(-1),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var column = Assert.Single(table.Columns, c => c.Name == "Name");
                Assert.Equal(
                    TypeMappingSource
                        .FindMapping(typeof(string), storeTypeName: null, size: -1)!
                        .StoreType,
                    column.StoreType);
            });

    [ConditionalFact(Skip = "TBD")]
    public override Task Add_required_primitive_collection_with_custom_default_value_sql_to_existing_table()
    {
        return Task.CompletedTask;
    }

    [ConditionalFact]
    public override Task Add_optional_primitive_collection_to_existing_table()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Customer");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.ToTable("Customers", table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Customer");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.Property<List<string>>("Numbers");

                entityTypeBuilder.ToTable("Customers", table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            model =>
            {
                var customersTable = Assert.Single(model.Tables.Where(t => t.Name == "Customers"));

                Assert.Collection(
                    customersTable.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name),
                    c => Assert.Equal("Numbers", c.Name));
                Assert.Same(
                    customersTable.Columns.Single(c => c.Name == "Id"),
                    Assert.Single(customersTable.PrimaryKey!.Columns));
            });

    [ConditionalFact(Skip = "TBD")]
    public override Task Add_primary_key_composite_with_name()
    {
        return base.Add_primary_key_composite_with_name();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Add_primary_key_int()
    {
        return base.Add_primary_key_int();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Add_primary_key_string()
    {
        return base.Add_primary_key_string();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Add_primary_key_with_name()
    {
        return base.Add_primary_key_with_name();
    }

    [ConditionalFact]
    public override Task Add_required_primitve_collection_to_existing_table()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Customer");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.ToTable("Customers", table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Customer");

                entityTypeBuilder.Property<int>("Id").ValueGeneratedOnAdd();
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.Property<List<int>>("Numbers").IsRequired();
                entityTypeBuilder.ToTable("Customers", table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            model =>
            {
                var customersTable = Assert.Single(model.Tables.Where(t => t.Name == "Customers"));

                Assert.Collection(
                    customersTable.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name),
                    c => Assert.Equal("Numbers", c.Name));
                Assert.Same(
                    customersTable.Columns.Single(c => c.Name == "Id"),
                    Assert.Single(customersTable.PrimaryKey!.Columns));
            });

    [ConditionalFact]
    public override Task Add_required_primitve_collection_with_custom_converter_and_custom_default_value_to_existing_table()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Customer");
                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.ToTable("Customers", table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Customer");

                entityTypeBuilder.Property<int>("Id");

                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.Property<List<int>>("Numbers").HasConversion(new ValueConverter<List<int>, string>(
                        convertToProviderExpression: x => x != null && x.Count > 0 ? "some numbers" : "nothing",
                        convertFromProviderExpression: x =>
                            x == "nothing" ? new List<int> { } : new List<int> { 7, 8, 9 }))
                    .HasDefaultValue(new List<int> { 42 })
                    .IsRequired();

                entityTypeBuilder.ToTable("Customers", table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            model =>
            {
                var customersTable = Assert.Single(model.Tables.Where(t => t.Name == "Customers"));

                Assert.Collection(
                    customersTable.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name),
                    c => Assert.Equal("Numbers", c.Name));
                Assert.Same(
                    customersTable.Columns.Single(c => c.Name == "Id"),
                    Assert.Single(customersTable.PrimaryKey!.Columns));
            });

    [ConditionalFact]
    public override Task Add_required_primitve_collection_with_custom_default_value_to_existing_table()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Customer");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.ToTable("Customers", table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Customer");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.Property<List<int>>("Numbers").IsRequired().HasDefaultValue(new List<int> { 1, 2, 3 });
                entityTypeBuilder.ToTable("Customers", table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            model =>
            {
                var customersTable = Assert.Single(model.Tables.Where(t => t.Name == "Customers"));

                Assert.Collection(
                    customersTable.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name),
                    c => Assert.Equal("Numbers", c.Name));
                Assert.Same(
                    customersTable.Columns.Single(c => c.Name == "Id"),
                    Assert.Single(customersTable.PrimaryKey!.Columns));
            });

    [ConditionalFact(Skip = "ClickHouse does not support unique constraints")]
    public override Task Add_unique_constraint()
    {
        return base.Add_unique_constraint();
    }

    [ConditionalFact(Skip = "ClickHouse does not support unique constraints")]
    public override Task Add_unique_constraint_composite_with_name()
    {
        return base.Add_unique_constraint_composite_with_name();
    }

    [ConditionalFact]
    public override Task Alter_check_constraint()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<int>("DriverLicense");

                entityTypeBuilder.ToTable("People", table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder.Entity("People")
                .ToTable(tb => tb.HasCheckConstraint("CK_People_Foo", $"{DelimitIdentifier("DriverLicense")} > 0")),
            builder => builder.Entity("People")
                .ToTable(tb => tb.HasCheckConstraint("CK_People_Foo", $"{DelimitIdentifier("DriverLicense")} > 1")),
            model =>
            {
                // TODO: no scaffolding support for check constraints, https://github.com/aspnet/EntityFrameworkCore/issues/15408
            });

    [ConditionalFact]
    public override Task Alter_column_add_comment()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id").HasComment("Some comment");
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                var column = Assert.Single(table.Columns);
                if (AssertComments)
                {
                    Assert.Equal("Some comment", column.Comment);
                }
            });

    [ConditionalFact]
    public override Task Alter_column_change_comment()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id").HasComment("Some comment1");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id").HasComment("Some comment2");
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                var column = Assert.Single(table.Columns);
                if (AssertComments)
                {
                    Assert.Equal("Some comment2", column.Comment);
                }
            });

    [ConditionalFact]
    public override Task Alter_column_change_computed()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<int>("X");
                entityTypeBuilder.Property<int>("Y");
                entityTypeBuilder.Property<int>("Sum");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder.Entity("People").Property<int>("Sum")
                .HasComputedColumnSql($"{DelimitIdentifier("X")} + {DelimitIdentifier("Y")}"),
            builder => builder.Entity("People").Property<int>("Sum")
                .HasComputedColumnSql($"{DelimitIdentifier("X")} - {DelimitIdentifier("Y")}"),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var sumColumn = Assert.Single(table.Columns, c => c.Name == "Sum");
                if (AssertComputedColumns)
                {
                    Assert.Contains("X", sumColumn.ComputedColumnSql);
                    Assert.Contains("Y", sumColumn.ComputedColumnSql);
                    Assert.Contains("-", sumColumn.ComputedColumnSql);
                }
            });

    [ConditionalFact]
    public override Task Alter_column_change_computed_recreates_indexes()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<int>("X");
                entityTypeBuilder.Property<int>("Y");
                entityTypeBuilder.Property<int>("Sum");
                entityTypeBuilder.HasIndex("Sum");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder
                .Entity("People")
                .Property<int>("Sum")
                .HasComputedColumnSql($"{DelimitIdentifier("X")} + {DelimitIdentifier("Y")}"),
            builder => builder
                .Entity("People")
                .Property<int>("Sum")
                .HasComputedColumnSql($"{DelimitIdentifier("X")} - {DelimitIdentifier("Y")}"),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var sumColumn = Assert.Single(table.Columns, c => c.Name == "Sum");

                if (AssertComputedColumns)
                {
                    Assert.Contains("X", sumColumn.ComputedColumnSql);
                    Assert.Contains("Y", sumColumn.ComputedColumnSql);
                    Assert.Contains("-", sumColumn.ComputedColumnSql);
                }

                // TODO var sumIndex = Assert.Single(table.Indexes);
                // Assert.Collection(sumIndex.Columns, c => Assert.Equal("Sum", c.Name));
            });

    [ConditionalFact]
    public override Task Alter_column_change_computed_type()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<int>("X");
                entityTypeBuilder.Property<int>("Y");
                entityTypeBuilder.Property<int>("Sum");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder
                .Entity("People")
                .Property<int>("Sum")
                .HasComputedColumnSql($"{DelimitIdentifier("X")} + {DelimitIdentifier("Y")}", stored: false),

            builder => builder
                .Entity("People")
                .Property<int>("Sum")
                .HasComputedColumnSql($"{DelimitIdentifier("X")} + {DelimitIdentifier("Y")}", stored: true),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var sumColumn = Assert.Single(table.Columns, c => c.Name == "Sum");
                if (AssertComputedColumns)
                {
                    Assert.True(sumColumn.IsStored);
                }
            });

    [ConditionalFact]
    public override Task Alter_column_change_type()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder.Entity("People").Property<int>("SomeColumn"),
            builder => builder.Entity("People").Property<long>("SomeColumn"),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var column = Assert.Single(table.Columns, c => c.Name == "SomeColumn");
                Assert.Equal(TypeMappingSource.FindMapping(typeof(long)).StoreType, column.StoreType);
            });

    [ConditionalTheory]
    [InlineData(true)]
    [InlineData(false)]
    [InlineData(null)]
    public override Task Alter_column_make_computed(bool? stored)
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<int>("X");
                entityTypeBuilder.Property<int>("Y");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder.Entity("People").Property<int>("Sum"),
            builder => builder.Entity("People").Property<int>("Sum")
                .HasComputedColumnSql($"{DelimitIdentifier("X")} + {DelimitIdentifier("Y")}", stored),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var sumColumn = Assert.Single(table.Columns, c => c.Name == "Sum");
                if (AssertComputedColumns)
                {
                    Assert.Contains("X", sumColumn.ComputedColumnSql);
                    Assert.Contains("Y", sumColumn.ComputedColumnSql);
                    Assert.Contains("+", sumColumn.ComputedColumnSql);
                    if (stored != null)
                    {
                        Assert.Equal(stored, sumColumn.IsStored);
                    }
                }
            });

    [ConditionalFact]
    public override Task Alter_column_make_non_computed()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<int>("X");
                entityTypeBuilder.Property<int>("Y");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder
                .Entity("People")
                .Property<int>("Sum")
                .HasComputedColumnSql($"{DelimitIdentifier("X")} + {DelimitIdentifier("Y")}", true),
            builder => builder
                .Entity("People")
                .Property<int>("Sum"),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var sumColumn = Assert.Single(table.Columns, c => c.Name == "Sum");
                // TODO Assert.Null(sumColumn.ComputedColumnSql);
                // TODO Assert.NotEqual(true, sumColumn.IsStored);
            });

    [ConditionalFact]
    public override Task Alter_column_make_required()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("SomeColumn");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            _ => { },
            builder => builder.Entity("People").Property<string>("SomeColumn").IsRequired(),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var column = Assert.Single(table.Columns, c => c.Name != "Id");
                Assert.False(column.IsNullable);
            });

    [ConditionalFact]
    public override Task Alter_column_make_required_with_composite_index()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("FirstName");
                entityTypeBuilder.Property<string>("LastName");
                entityTypeBuilder.HasIndex("FirstName", "LastName");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            _ => { },
            builder => builder.Entity("People").Property<string>("FirstName").IsRequired(),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var firstNameColumn = Assert.Single(table.Columns, c => c.Name == "FirstName");
                Assert.False(firstNameColumn.IsNullable);
                // TOOD
                // var index = Assert.Single(table.Indexes);
                // Assert.Equal(2, index.Columns.Count);
                // Assert.Contains(table.Columns.Single(c => c.Name == "FirstName"), index.Columns);
                // Assert.Contains(table.Columns.Single(c => c.Name == "LastName"), index.Columns);
            });

    [ConditionalFact]
    public override Task Alter_column_make_required_with_index()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("SomeColumn");
                entityTypeBuilder.HasIndex("SomeColumn");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            _ => { },
            builder => builder.Entity("People").Property<string>("SomeColumn").IsRequired(),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var column = Assert.Single(table.Columns, c => c.Name != "Id");
                Assert.False(column.IsNullable);

                // TODO
                // var index = Assert.Single(table.Indexes);
                // Assert.Same(column, Assert.Single(index.Columns));
            });

    [ConditionalFact(Skip = "TBD")]
    public override Task Alter_column_make_required_with_null_data()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("SomeColumn");
                entityTypeBuilder.HasData(new Dictionary<string, object> { { "Id", 1 }, { "SomeColumn", null } });

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => { },
            builder => builder.Entity("People").Property<string>("SomeColumn").IsRequired(),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var column = Assert.Single(table.Columns, c => c.Name != "Id");
                Assert.False(column.IsNullable);
            });

    [ConditionalFact]
    public override Task Alter_column_remove_comment()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");
                entityTypeBuilder.Property<int>("Id").HasComment("Some comment");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder.Entity("People").Property<int>("Id"),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var column = Assert.Single(table.Columns);
                Assert.Null(column.Comment);
            });

    [ConditionalFact]
    public override Task Alter_computed_column_add_comment()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<int>("SomeColumn").HasComputedColumnSql("42");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => { },
            builder => builder.Entity("People").Property<int>("SomeColumn").HasComment("Some comment"),
            model =>
            {
                var table = Assert.Single(model.Tables);
                var column = Assert.Single(table.Columns.Where(c => c.Name == "SomeColumn"));
                if (AssertComments)
                {
                    Assert.Equal("Some comment", column.Comment);
                }
            });

    [ConditionalFact(Skip = "TBD")]
    public override Task Alter_index_change_sort_order()
    {
        return base.Alter_index_change_sort_order();
    }

    [ConditionalFact(Skip = "ClickHouse does not support unique indexes")]
    public override Task Alter_index_make_unique()
    {
        return base.Alter_index_make_unique();
    }

    [ConditionalFact(Skip = "ClickHouse does not support sequences")]
    public override Task Alter_sequence_all_settings()
    {
        return base.Alter_sequence_all_settings();
    }

    [ConditionalFact(Skip = "ClickHouse does not support sequences")]
    public override Task Alter_sequence_increment_by()
    {
        return base.Alter_sequence_increment_by();
    }

    [ConditionalFact(Skip = "ClickHouse does not support sequences")]
    public override Task Alter_sequence_restart_with()
    {
        return base.Alter_sequence_restart_with();
    }

    [ConditionalFact(Skip = "ClickHouse does not support table schemas")]
    public override Task Alter_table_add_comment_non_default_schema()
    {
        return base.Alter_table_add_comment_non_default_schema();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Create_index()
    {
        return base.Create_index();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Create_index_descending()
    {
        return base.Create_index_descending();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Create_index_descending_mixed()
    {
        return base.Create_index_descending_mixed();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Create_index_unique()
    {
        return base.Create_index_unique();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Create_index_with_filter()
    {
        return base.Create_index_with_filter();
    }

    [ConditionalFact(Skip = "ClickHouse does not support sequences")]
    public override Task Create_sequence_all_settings()
    {
        return base.Create_sequence_all_settings();
    }

    [ConditionalFact(Skip = "ClickHouse does not support sequences")]
    public override Task Create_sequence_short()
    {
        return base.Create_sequence_short();
    }

    [ConditionalFact(Skip = "ClickHouse does not support sequences")]
    public override Task Create_sequence_long()
    {
        return base.Create_sequence_long();
    }

    [ConditionalFact]
    public override Task Create_table()
        => Test(
            builder => { },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("Name");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Collection(
                    table.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name));
                Assert.Same(
                    table.Columns.Single(c => c.Name == "Id"),
                    Assert.Single(table.PrimaryKey!.Columns));
            });

    [ConditionalFact(Skip = "TBD")]
    public override Task Create_table_all_settings()
    {
        return base.Create_table_all_settings();
    }

    [ConditionalFact]
    public override Task Create_table_with_optional_primitive_collection()
        => Test(
            builder => { },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Customer");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.Property<List<int>>("Numbers");
                entityTypeBuilder.ToTable("Customers", table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            model =>
            {
                var customersTable = Assert.Single(model.Tables.Where(t => t.Name == "Customers"));

                Assert.Collection(
                    customersTable.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name),
                    c => Assert.Equal("Numbers", c.Name));
                Assert.Same(
                    customersTable.Columns.Single(c => c.Name == "Id"),
                    Assert.Single(customersTable.PrimaryKey!.Columns));
            });

    [ConditionalFact]
    public override Task Create_table_with_required_primitive_collection()
        => Test(
            builder => { },
            builder =>
            {
                var tableEntityBuilder = builder.Entity("Customer");

                tableEntityBuilder.Property<int>("Id");
                tableEntityBuilder.HasKey("Id");
                tableEntityBuilder.Property<string>("Name");
                tableEntityBuilder.Property<List<int>>("Numbers").IsRequired();
                tableEntityBuilder.ToTable("Customers", table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            model =>
            {
                var customersTable = Assert.Single(model.Tables.Where(t => t.Name == "Customers"));

                Assert.Collection(
                    customersTable.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name),
                    c => Assert.Equal("Numbers", c.Name));
                Assert.Same(
                    customersTable.Columns.Single(c => c.Name == "Id"),
                    Assert.Single(customersTable.PrimaryKey!.Columns));
            });

    [ConditionalFact(Skip = "ClickHouse does not support unique indexes")]
    public override Task Create_unique_index_with_filter()
    {
        return base.Create_unique_index_with_filter();
    }

    [ConditionalFact]
    public override Task DeleteDataOperation_composite_key()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Person");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<int>("AnotherId");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.HasData(new Person
                {
                    Id = 1,
                    AnotherId = 11,
                    Name = "Daenerys Targaryen"
                });

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id", "AnotherId"));
            },
            builder => builder.Entity("Person").HasData(
                new Person
                {
                    Id = 2,
                    AnotherId = 12,
                    Name = "John Snow"
                }),
            _ => { },
            _ => { });

    [ConditionalFact]
    public override Task DeleteDataOperation_simple_key()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Person");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.HasData(new Person { Id = 1, Name = "Daenerys Targaryen" });

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder.Entity("Person").HasData(new Person { Id = 2, Name = "John Snow" }),
            _ => { },
            _ => { });

    [ConditionalFact]
    public override Task Drop_check_constraint()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<int>("DriverLicense");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder.Entity("People")
                .ToTable(tb => tb.HasCheckConstraint("CK_People_Foo", $"{DelimitIdentifier("DriverLicense")} > 0")),
            builder => { },
            model =>
            {
                // TODO: no scaffolding support for check constraints, https://github.com/aspnet/EntityFrameworkCore/issues/15408
            });

    [ConditionalFact]
    public override Task Drop_column()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");
                entityTypeBuilder.Property<int>("Id");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder.Entity("People").Property<int>("SomeColumn"),
            builder => { },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("Id", Assert.Single(table.Columns).Name);
            });

    [ConditionalFact]
    public override Task Drop_column_computed_and_non_computed_with_dependency()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");

                entityTypeBuilder.Property<int>("Id");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder.Entity(
                "People", e =>
                {
                    e.Property<int>("X");
                    e.Property<int>("Y").HasComputedColumnSql($"{DelimitIdentifier("X")} + 1");
                }),
            builder => { },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("Id", Assert.Single(table.Columns).Name);
            });

    [ConditionalFact(Skip = "TBD")]
    public override Task Drop_column_primary_key()
    {
        return base.Drop_column_primary_key();
    }

    [ConditionalFact(Skip = "ClickHouse does not support foreign keys")]
    public override Task Drop_foreign_key()
    {
        return base.Drop_foreign_key();
    }

    [ConditionalFact(Skip = "ClickHouse does not support sequences")]
    public override Task Move_sequence()
    {
        return base.Move_sequence();
    }

    [ConditionalFact(Skip = "ClickHouse does not support table schemas")]
    public override Task Move_table()
    {
        return base.Move_table();
    }

    [ConditionalFact]
    public override Task Rename_column()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");
                entityTypeBuilder.Property<int>("Id");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder.Entity("People").Property<string>("SomeColumn"),
            builder => builder.Entity("People").Property<string>("SomeColumn").HasColumnName("SomeOtherColumn"),
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal(2, table.Columns.Count);
                Assert.Single(table.Columns, c => c.Name == "SomeOtherColumn");
            });

    [ConditionalFact(Skip = "ClickHouse does not support sequences")]
    public override Task Rename_sequence()
    {
        return base.Rename_sequence();
    }

    [ConditionalFact]
    public override Task Rename_table()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("People");
                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder.Entity("People").ToTable("Persons").Property<int>("Id"),
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("Persons", table.Name);
            });

    [ConditionalFact(Skip = "TBD")]
    public override Task Drop_index()
    {
        return base.Drop_index();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Drop_primary_key_int()
    {
        return base.Drop_primary_key_int();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Drop_primary_key_string()
    {
        return base.Drop_primary_key_string();
    }

    [ConditionalFact(Skip = "ClickHouse does not support sequences")]
    public override Task Drop_sequence()
    {
        return base.Drop_sequence();
    }

    [ConditionalFact(Skip = "ClickHouse does not support unique constraints")]
    public override Task Drop_unique_constraint()
    {
        return base.Drop_unique_constraint();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Rename_table_with_primary_key()
    {
        return base.Rename_table_with_primary_key();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task SqlOperation()
    {
        return base.SqlOperation();
    }

    [ConditionalFact]
    public override Task UpdateDataOperation_composite_key()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Person");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<int>("AnotherId");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.HasData(
                    new Person
                    {
                        Id = 1,
                        AnotherId = 11,
                        Name = "Daenerys Targaryen"
                    });

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id", "AnotherId"));
            },
            builder => builder.Entity("Person").HasData(
                new Person
                {
                    Id = 2,
                    AnotherId = 11,
                    Name = "John Snow"
                }),
            builder => builder.Entity("Person").HasData(
                new Person
                {
                    Id = 2,
                    AnotherId = 11,
                    Name = "Another John Snow"
                }),
            model => { });

    [ConditionalFact]
    public override Task UpdateDataOperation_multiple_columns()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Person");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.Property<int>("Age");
                entityTypeBuilder.HasData(
                    new Person
                    {
                        Id = 1,
                        Name = "Daenerys Targaryen",
                        Age = 18
                    });

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder.Entity("Person").HasData(
                new Person
                {
                    Id = 2,
                    Name = "John Snow",
                    Age = 20
                }),
            builder => builder.Entity("Person").HasData(
                new Person
                {
                    Id = 2,
                    Name = "Another John Snow",
                    Age = 21
                }),
            model => { });

    [ConditionalFact]
    public override Task UpdateDataOperation_simple_key()
        => Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Person");

                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.HasData(new Person { Id = 1, Name = "Daenerys Targaryen" });

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder.Entity("Person").HasData(new Person { Id = 2, Name = "John Snow" }),
            builder => builder.Entity("Person").HasData(new Person { Id = 2, Name = "Another John Snow" }),
            model => { });

    [ConditionalFact]
    public Task MergeTree_with_all_args() =>
        Test(
            builder =>
            {

            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("my_table");
                entityTypeBuilder.Property<uint>("id");
                entityTypeBuilder.Property<string>("name");
                entityTypeBuilder.Property<byte>("age");
                entityTypeBuilder.Property<DateTime>("created_at");
                entityTypeBuilder.Property<float>("score");

                entityTypeBuilder.ToTable(table => table
                    .HasMergeTreeEngine()
                    .WithPartitionBy("toYYYYMM(created_at)")
                    .WithPrimaryKey("id", "age")
                    .WithOrderBy("id", "age", "created_at")
                    .WithSampleBy("id")
                );
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("my_table", table.Name);

                var engine = table.GetTableEngine();
                Assert.Equal(ClickHouseAnnotationNames.MergeTreeEngine, engine);

                var partitionBy = table.GetPartitionBy();
                Assert.Equal(["toYYYYMM(created_at)"], partitionBy);

                var primaryKey = table.GetPrimaryKey();
                Assert.Equal(["id", "age"], primaryKey);

                var orderBy = table.GetOrderBy();
                Assert.Equal(["id", "age", "created_at"], orderBy);

                var sampleBy = table.GetSampleBy();
                Assert.Equal(["id"], sampleBy);
            });

    [ConditionalFact]
    public Task ReplacingMergeTree_with_all_args() =>
        Test(
            builder =>
            {
            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("my_table");
                entityTypeBuilder.Property<uint>("id");
                entityTypeBuilder.Property<string>("name");
                entityTypeBuilder.Property<byte>("age");
                entityTypeBuilder.Property<DateTime>("created_at");
                entityTypeBuilder.Property<uint>("ver");
                entityTypeBuilder.Property<bool>("is_deleted");

                entityTypeBuilder.ToTable(table => table
                    .HasReplacingMergeTreeEngine("ver", "is_deleted")
                    .WithPartitionBy("toYYYYMM(created_at)")
                    .WithPrimaryKey("id")
                    .WithOrderBy("id","created_at")
                    .WithSampleBy("id")
                );
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("my_table", table.Name);

                var engine = table.GetTableEngine();
                Assert.Equal(ClickHouseAnnotationNames.ReplacingMergeTree, engine);

                var version = table.GetReplacingMergeTreeVersion();
                Assert.Equal("ver", version);

                var isDeleted = table.GetReplacingMergeTreeIsDeleted();
                Assert.Equal("is_deleted", isDeleted);

                var partitionBy = table.GetPartitionBy();
                Assert.Equal(["toYYYYMM(created_at)"], partitionBy);

                var primaryKey = table.GetPrimaryKey();
                Assert.Equal(["id"], primaryKey);

                var orderBy = table.GetOrderBy();
                Assert.Equal(["id", "created_at"], orderBy);

                var sampleBy = table.GetSampleBy();
                Assert.Equal(["id"], sampleBy);
            });

    [ConditionalFact]
    public Task SummingMergeTree_with_all_args() =>
        Test(
            builder =>
            {
            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("my_table");
                entityTypeBuilder.Property<ulong>("id");
                entityTypeBuilder.Property<string>("name");
                entityTypeBuilder.Property<string>("category").IsRequired();
                entityTypeBuilder.Property<float>("amount");
                entityTypeBuilder.Property<DateTime>("created_at");

                entityTypeBuilder.ToTable("my_table", table => table
                    .HasSummingMergeTreeEngine("amount")
                    .WithPartitionBy("toYYYYMM(created_at)")
                    .WithPrimaryKey("id")
                    .WithOrderBy("id", "category", "created_at")
                    .WithSampleBy("id")
                );
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("my_table", table.Name);

                var engine = table.GetTableEngine();
                Assert.Equal(ClickHouseAnnotationNames.SummingMergeTree, engine);

                var engineColumn = table.GetSummingMergeTreeColumn();
                Assert.Equal("amount", engineColumn);

                var partitionBy = table.GetPartitionBy();
                Assert.Equal(["toYYYYMM(created_at)"], partitionBy);

                var primaryKey = table.GetPrimaryKey();
                Assert.Equal(["id", "category", "created_at"], primaryKey);

                var orderBy = table.GetOrderBy();
                Assert.Equal(["id", "category", "created_at"], orderBy);

                var sampleBy = table.GetSampleBy();
                Assert.Equal(["id"], sampleBy);
            });

    [ConditionalFact]
    public Task AggregatingMergeTree_with_all_args() =>
        Test(
            builder =>
            {
            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("my_table");
                entityTypeBuilder.Property<ulong>("id");
                entityTypeBuilder.Property<string>("name");
                entityTypeBuilder.Property<string>("category");
                entityTypeBuilder.Property<DateTime>("created_at");
                entityTypeBuilder.Property<float>("amount_state").HasColumnType("AggregateFunction(sum, Float32)");
                entityTypeBuilder.Property<float>("quantity_state").HasColumnType("AggregateFunction(sum, UInt32)");

                entityTypeBuilder.ToTable("my_table", table => table
                    .HasAggregatingMergeTreeEngine()
                    .WithPartitionBy("toYYYYMM(created_at)")
                    .WithOrderBy("id", "created_at")
                    .WithSampleBy("id"));
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("my_table", table.Name);

                var engine = table.GetTableEngine();
                Assert.Equal(ClickHouseAnnotationNames.AggregatingMergeTree, engine);

                var partitionBy = table.GetPartitionBy();
                Assert.Equal(["toYYYYMM(created_at)"], partitionBy);

                var orderBy = table.GetOrderBy();
                Assert.Equal(["id", "created_at"], orderBy);

                var sampleBy = table.GetSampleBy();
                Assert.Equal(["id"], sampleBy);
            });

    [ConditionalFact]
    public Task CollapsingMergeTree_with_all_args() =>
        Test(
            builder =>
            {
            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("my_table");
                entityTypeBuilder.Property<ulong>("id");
                entityTypeBuilder.Property<string>("name");
                entityTypeBuilder.Property<string>("category").IsRequired();
                entityTypeBuilder.Property<DateTime>("created_at");
                entityTypeBuilder.Property<float>("amount");
                entityTypeBuilder.Property<sbyte>("sign");

                entityTypeBuilder.ToTable("my_table", table => table
                    .HasCollapsingMergeTreeEngine("sign")
                    .WithPartitionBy("toYYYYMM(created_at)")
                    .WithOrderBy("id", "category", "created_at")
                    .WithSampleBy("id"));
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("my_table", table.Name);

                var engine = table.GetTableEngine();
                Assert.Equal(ClickHouseAnnotationNames.CollapsingMergeTree, engine);

                var partitionBy = table.GetPartitionBy();
                Assert.Equal(["toYYYYMM(created_at)"], partitionBy);

                var orderBy = table.GetOrderBy();
                Assert.Equal(["id", "category", "created_at"], orderBy);

                var samepleBy = table.GetSampleBy();
                Assert.Equal(["id"], samepleBy);
            });

    [ConditionalFact]
    public Task VersionedCollapsingMergeTree_with_all_args() =>
        Test(
            builder =>
            {
            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("my_table");
                entityTypeBuilder.Property<ulong>("id");
                entityTypeBuilder.Property<string>("name");
                entityTypeBuilder.Property<string>("category").IsRequired();
                entityTypeBuilder.Property<DateTime>("created_at");
                entityTypeBuilder.Property<float>("amount");
                entityTypeBuilder.Property<sbyte>("sign");
                entityTypeBuilder.Property<uint>("version");

                entityTypeBuilder.ToTable("my_table", table => table
                    .HasVersionedCollapsingMergeTreeEngine("sign", "version")
                    .WithPartitionBy("toYYYYMM(created_at)")
                    .WithOrderBy("id", "category", "created_at")
                    .WithSampleBy("id"));
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("my_table", table.Name);

                var engine = table.GetTableEngine();
                Assert.Equal(ClickHouseAnnotationNames.VersionedCollapsingMergeTree, engine);

                var partitionBy = table.GetPartitionBy();
                Assert.Equal(["toYYYYMM(created_at)"], partitionBy);

                var orderBy = table.GetOrderBy();
                Assert.Equal(["id", "category", "created_at", "version"], orderBy);

                var sampleBy = table.GetSampleBy();
                Assert.Equal(["id"], sampleBy);
            });

    [ConditionalFact]
    public Task TinyLog_no_args() =>
        Test(
            _ =>
            {
            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("my_table");
                entityTypeBuilder.Property<ulong>("id");
                entityTypeBuilder.ToTable("my_table", table => table.HasTinyLogEngine());
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("my_table", table.Name);

                var engine = table.GetTableEngine();
                Assert.Equal(ClickHouseAnnotationNames.TinyLogEngine, engine);
            });

    [ConditionalFact]
    public Task StripeLog_no_args() =>
        Test(
            _ =>
            {
            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("my_table");
                entityTypeBuilder.Property<ulong>("id");
                entityTypeBuilder.ToTable("my_table", table => table.HasStripeLogEngine());
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("my_table", table.Name);

                var engine = table.GetTableEngine();
                Assert.Equal(ClickHouseAnnotationNames.StripeLogEngine, engine);
            });

    [ConditionalFact]
    public Task Log_no_args() =>
        Test(
            _ =>
            {
            },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("my_table");
                entityTypeBuilder.Property<ulong>("id");
                entityTypeBuilder.ToTable("my_table", table => table.HasLogEngine());
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("my_table", table.Name);

                var engine = table.GetTableEngine();
                Assert.Equal(ClickHouseAnnotationNames.LogEngine, engine);
            });

    [ConditionalFact]
    public override async Task Add_json_columns_to_existing_table()
    {
        await Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Entity");
                entityTypeBuilder.Property<int>("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.ToTable("Entity", table => table.HasMergeTreeEngine().WithPrimaryKey("Id"));
            },
            builder =>
            {
                builder.Entity(
                    "Entity", e =>
                    {
                        e.Property<int>("Id").ValueGeneratedOnAdd();
                        e.HasKey("Id");
                        e.Property<string>("Name");

                        e.OwnsOne(
                            "Owned", "OwnedReference", o =>
                            {
                                o.OwnsOne(
                                    "Nested", "NestedReference", n =>
                                    {
                                        n.Property<int>("Number");
                                    });
                                o.OwnsMany(
                                    "Nested2", "NestedCollection", n =>
                                    {
                                        n.Property<int>("Number2");
                                    });
                                o.Property<DateTime>("Date");
                                o.ToJson();
                            });

                        e.OwnsOne(
                            "Owned", "OwnedRequiredReference", o =>
                            {
                                o.Property<DateTime>("Date");
                                o.ToJson();
                            });

                        e.Navigation("OwnedRequiredReference").IsRequired();

                        e.OwnsMany(
                            "Owned2", "OwnedCollection", o =>
                            {
                                o.OwnsOne(
                                    "Nested3", "NestedReference2", n =>
                                    {
                                        n.Property<int>("Number3");
                                    });
                                o.OwnsMany(
                                    "Nested4", "NestedCollection2", n =>
                                    {
                                        n.Property<int>("Number4");
                                    });
                                o.Property<DateTime>("Date2");
                                o.ToJson();
                            });
                    });
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("Entity", table.Name);

                Assert.Collection(
                    table.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name),
                    c => Assert.Equal("OwnedCollection", c.Name),
                    c =>
                    {
                        Assert.Equal("OwnedReference", c.Name);
                        // Assert.True(c.IsNullable); ClickHouse does not support nullable JSON columns
                    },
                    c =>
                    {
                        Assert.Equal("OwnedRequiredReference", c.Name);
                        Assert.False(c.IsNullable);
                    });
                Assert.Same(
                    table.Columns.Single(c => c.Name == "Id"),
                    Assert.Single(table.PrimaryKey!.Columns));
            });
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Add_required_primitive_collection_to_existing_table()
    {
        return base.Add_required_primitive_collection_to_existing_table();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Add_required_primitive_collection_with_custom_converter_and_custom_default_value_to_existing_table()
    {
        return base.Add_required_primitive_collection_with_custom_converter_and_custom_default_value_to_existing_table();
    }

    [ConditionalFact(Skip = "TBD")]
    public override Task Add_required_primitive_collection_with_custom_default_value_to_existing_table()
    {
        return base.Add_required_primitive_collection_with_custom_default_value_to_existing_table();
    }

    [ConditionalFact]
    public override async Task Convert_json_entities_to_regular_owned()
    {
        await Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Entity");

                entityTypeBuilder.Property<int>("Id").ValueGeneratedOnAdd();
                entityTypeBuilder.HasKey("Id");
                entityTypeBuilder.Property<string>("Name");

                entityTypeBuilder.ToTable("Entity", tableBuilder => tableBuilder
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));

                entityTypeBuilder.OwnsOne(
                    "Owned", "OwnedReference", o =>
                    {
                        o.OwnsOne(
                            "Nested", "NestedReference", n =>
                            {
                                n.Property<int>("Number");
                            });
                        o.OwnsMany(
                            "Nested2", "NestedCollection", n =>
                            {
                                n.Property<int>("Number2");
                            });
                        o.Property<DateTime>("Date");
                        o.ToJson();
                    });

                entityTypeBuilder.OwnsMany(
                    "Owned2", "OwnedCollection", o =>
                    {
                        o.OwnsOne(
                            "Nested3", "NestedReference2", n =>
                            {
                                n.Property<int>("Number3");
                            });
                        o.OwnsMany(
                            "Nested4", "NestedCollection2", n =>
                            {
                                n.Property<int>("Number4");
                            });
                        o.Property<DateTime>("Date2");
                        o.ToJson();
                    });
            },
            builder =>
            {
                builder.Entity(
                    "Entity", e =>
                    {
                        e.Property<int>("Id").ValueGeneratedOnAdd();
                        e.HasKey("Id");
                        e.Property<string>("Name");

                        e.OwnsOne(
                            "Owned", "OwnedReference", o =>
                            {
                                o.OwnsOne(
                                    "Nested", "NestedReference", n =>
                                    {
                                        n.Property<int>("Number");
                                    });
                                o.OwnsMany(
                                    "Nested2", "NestedCollection", n =>
                                    {
                                        n.Property<int>("Number2");
                                    });
                                o.Property<DateTime>("Date");
                            });

                        e.OwnsMany(
                            "Owned2", "OwnedCollection", o =>
                            {
                                o.OwnsOne(
                                    "Nested3", "NestedReference2", n =>
                                    {
                                        n.Property<int>("Number3");
                                    });
                                o.OwnsMany(
                                    "Nested4", "NestedCollection2", n =>
                                    {
                                        n.Property<int>("Number4");
                                    });
                                o.Property<DateTime>("Date2");
                            });
                    });
            },
            model =>
            {
                Assert.Equal(4, model.Tables.Count());
            });
    }

    [ConditionalFact]
    public override async Task Convert_regular_owned_entities_to_json()
    {
        await Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Entity");

                entityTypeBuilder.Property<int>("Id").ValueGeneratedOnAdd();
                entityTypeBuilder.HasKey("Id");
                entityTypeBuilder.Property<string>("Name");

                entityTypeBuilder.ToTable(tableBuilder => tableBuilder
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));

                entityTypeBuilder.OwnsOne(
                    "Owned", "OwnedReference", o =>
                    {
                        o.OwnsOne(
                            "Nested", "NestedReference", n =>
                            {
                                n.Property<int>("Number");
                            });
                        o.OwnsMany(
                            "Nested2", "NestedCollection", n =>
                            {
                                n.Property<int>("Number2");
                            });
                        o.Property<DateTime>("Date");
                    });

                entityTypeBuilder.OwnsMany(
                    "Owned2", "OwnedCollection", o =>
                    {
                        o.OwnsOne(
                            "Nested3", "NestedReference2", n =>
                            {
                                n.Property<int>("Number3");
                            });
                        o.OwnsMany(
                            "Nested4", "NestedCollection2", n =>
                            {
                                n.Property<int>("Number4");
                            });
                        o.Property<DateTime>("Date2");
                    });
            },
            builder =>
            {
                builder.Entity(
                    "Entity", e =>
                    {
                        e.Property<int>("Id").ValueGeneratedOnAdd();
                        e.HasKey("Id");
                        e.Property<string>("Name");

                        e.OwnsOne(
                            "Owned", "OwnedReference", o =>
                            {
                                o.OwnsOne("Nested", "NestedReference", n => n.Property<int>("Number"));
                                o.OwnsMany("Nested2", "NestedCollection", n => n.Property<int>("Number2"));
                                o.Property<DateTime>("Date");
                                o.ToJson();
                            });

                        e.OwnsMany(
                            "Owned2", "OwnedCollection", o =>
                            {
                                o.OwnsOne("Nested3", "NestedReference2", n => n.Property<int>("Number3"));
                                o.OwnsMany("Nested4", "NestedCollection2", n => n.Property<int>("Number4"));
                                o.Property<DateTime>("Date2");
                                o.ToJson();
                            });
                    });
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("Entity", table.Name);

                Assert.Collection(
                    table.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name),
                    c => Assert.Equal("OwnedCollection", c.Name),
                    c => Assert.Equal("OwnedReference", c.Name));
                Assert.Same(
                    table.Columns.Single(c => c.Name == "Id"),
                    Assert.Single(table.PrimaryKey!.Columns));
            });
    }

    [ConditionalFact]
    public override async Task Convert_string_column_to_a_json_column_containing_collection()
    {
        await Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Entity");

                entityTypeBuilder.Property<int>("Id").ValueGeneratedOnAdd();
                entityTypeBuilder.HasKey("Id");
                entityTypeBuilder.Property<string>("Name");

                entityTypeBuilder.ToTable(tableBuilder => tableBuilder
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder =>
            {
                builder.Entity(
                    "Entity", e =>
                    {
                        e.Property<int>("Id").ValueGeneratedOnAdd();
                        e.HasKey("Id");

                        e.OwnsMany(
                            "Owned2", "OwnedCollection", o =>
                            {
                                o.OwnsOne("Nested3", "NestedReference2", n => n.Property<int>("Number3"));
                                o.OwnsMany("Nested4", "NestedCollection2", n => n.Property<int>("Number4"));
                                o.Property<DateTime>("Date2");
                                o.ToJson("Name");
                            });
                    });
            },
            model =>
            {
                var table = model.Tables.Single();
                Assert.Collection(
                    table.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name));
            });

        // AssertSql();
    }

    [ConditionalFact()]
    public override async Task Convert_string_column_to_a_json_column_containing_reference()
    {
        await Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Entity");

                entityTypeBuilder.Property<int>("Id").ValueGeneratedOnAdd();
                entityTypeBuilder.HasKey("Id");
                entityTypeBuilder.Property<string>("Name");

                entityTypeBuilder.ToTable(tableBuilder => tableBuilder
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder =>
            {
                builder.Entity(
                    "Entity", e =>
                    {
                        e.Property<int>("Id").ValueGeneratedOnAdd();
                        e.HasKey("Id");

                        e.OwnsOne(
                            "Owned", "OwnedReference", o =>
                            {
                                o.ToJson("Name");
                                o.OwnsOne("Nested", "NestedReference", n => n.Property<int>("Number"));
                                o.OwnsMany("Nested2", "NestedCollection", n => n.Property<int>("Number2"));
                                o.Property<DateTime>("Date");
                            });
                    });
            },
            model =>
            {
                var table = model.Tables.Single();
                Assert.Collection(
                    table.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name));
            });

        // AssertSql();
    }

    [ConditionalFact]
    public override async Task Convert_string_column_to_a_json_column_containing_required_reference()
    {
        await Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Entity");

                entityTypeBuilder.Property<int>("Id").ValueGeneratedOnAdd();
                entityTypeBuilder.HasKey("Id");
                entityTypeBuilder.Property<string>("Name");

                entityTypeBuilder.ToTable("Entity", tableBuilder => tableBuilder
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder =>
            {
                builder.Entity(
                    "Entity", e =>
                    {
                        e.Property<int>("Id").ValueGeneratedOnAdd();
                        e.HasKey("Id");

                        e.OwnsOne(
                            "Owned", "OwnedReference", o =>
                            {
                                o.ToJson("Name");
                                o.OwnsOne("Nested", "NestedReference", n => n.Property<int>("Number"));
                                o.OwnsMany("Nested2", "NestedCollection", n => n.Property<int>("Number2"));
                                o.Property<DateTime>("Date");
                            });

                        e.Navigation("OwnedReference").IsRequired();
                    });
            },
            model =>
            {
                var table = model.Tables.Single();
                Assert.Collection(
                    table.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name));
            });
    }

    [ConditionalFact]
    public override async Task Create_table_with_json_column()
    {
        await Test(
            builder => { },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Entity");

                entityTypeBuilder.Property<int>("Id").ValueGeneratedOnAdd();
                entityTypeBuilder.HasKey("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.OwnsOne(
                            "Owned", "OwnedReference", o =>
                            {
                                o.OwnsOne(
                                    "Nested", "NestedReference", n =>
                                    {
                                        n.Property<int>("Number");
                                    });
                                o.OwnsMany(
                                    "Nested2", "NestedCollection", n =>
                                    {
                                        n.Property<int>("Number2");
                                    });
                                o.Property<DateTime>("Date");
                                o.ToJson();
                            });

                entityTypeBuilder.OwnsMany(
                            "Owned2", "OwnedCollection", o =>
                            {
                                o.OwnsOne(
                                    "Nested3", "NestedReference2", n =>
                                    {
                                        n.Property<int>("Number3");
                                    });
                                o.OwnsMany(
                                    "Nested4", "NestedCollection2", n =>
                                    {
                                        n.Property<int>("Number4");
                                    });
                                o.Property<DateTime>("Date2");
                                o.ToJson();
                            });

                entityTypeBuilder.OwnsOne(
                            "Owned", "OwnedRequiredReference", o =>
                            {
                                o.Property<DateTime>("Date");
                                o.ToJson();
                            });

                entityTypeBuilder.Navigation("OwnedRequiredReference").IsRequired();

                entityTypeBuilder.ToTable("Entity", tableBuilder => tableBuilder
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("Entity", table.Name);

                Assert.Collection(
                    table.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name),
                    c => Assert.Equal("OwnedCollection", c.Name),
                    c =>
                    {
                        Assert.Equal("OwnedReference", c.Name);
                        // Assert.True(c.IsNullable);
                    },
                    c =>
                    {
                        Assert.Equal("OwnedRequiredReference", c.Name);
                        Assert.False(c.IsNullable);
                    });
                Assert.Same(
                    table.Columns.Single(c => c.Name == "Id"),
                    Assert.Single(table.PrimaryKey!.Columns));
            });
    }

    [ConditionalFact]
    public override async Task Create_table_with_json_column_explicit_json_column_names()
    {
        await Test(
            builder => { },
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Entity");

                entityTypeBuilder.Property<int>("Id").ValueGeneratedOnAdd();
                entityTypeBuilder.HasKey("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.OwnsOne(
                    "Owned", "json_reference", o =>
                    {
                        o.OwnsOne("Nested", "json_reference", n => n.Property<int>("Number"));
                        o.OwnsMany("Nested2", "NestedCollection", n => n.Property<int>("Number2"));
                        o.Property<DateTime>("Date");
                        o.ToJson();
                    });

                entityTypeBuilder.OwnsMany(
                    "Owned2", "json_collection", o =>
                    {
                        o.OwnsOne("Nested3", "NestedReference2", n => n.Property<int>("Number3"));
                        o.OwnsMany("Nested4", "NestedCollection2", n => n.Property<int>("Number4"));
                        o.Property<DateTime>("Date2");
                        o.ToJson();
                    });

                entityTypeBuilder.ToTable("Entity", tableBuilder => tableBuilder
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("Entity", table.Name);

                Assert.Collection(
                    table.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name),
                    c => Assert.Equal("json_collection", c.Name),
                    c => Assert.Equal("json_reference", c.Name));
                Assert.Same(
                    table.Columns.Single(c => c.Name == "Id"),
                    Assert.Single(table.PrimaryKey!.Columns));
            });
    }

    [ConditionalFact]
    public override async Task Drop_json_columns_from_existing_table()
    {
        await Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Entity");

                entityTypeBuilder.Property<int>("Id").ValueGeneratedOnAdd();
                entityTypeBuilder.HasKey("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.OwnsOne(
                    "Owned", "OwnedReference", o =>
                    {
                        o.OwnsOne(
                            "Nested", "NestedReference", n =>
                            {
                                n.Property<int>("Number");
                            });
                        o.OwnsMany(
                            "Nested2", "NestedCollection", n =>
                            {
                                n.Property<int>("Number2");
                            });
                        o.Property<DateTime>("Date");
                        o.ToJson();
                    });

                entityTypeBuilder.OwnsMany(
                    "Owned2", "OwnedCollection", o =>
                    {
                        o.OwnsOne(
                            "Nested3", "NestedReference2", n =>
                            {
                                n.Property<int>("Number3");
                            });
                        o.OwnsMany(
                            "Nested4", "NestedCollection2", n =>
                            {
                                n.Property<int>("Number4");
                            });
                        o.Property<DateTime>("Date2");
                        o.ToJson();
                    });

                entityTypeBuilder.ToTable("Entity", tableBuilder => tableBuilder
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder => builder.Entity(
                "Entity", e =>
                {
                    e.Property<int>("Id").ValueGeneratedOnAdd();
                    e.HasKey("Id");
                    e.Property<string>("Name");
                }),
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("Entity", table.Name);

                Assert.Collection(
                    table.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name));
                Assert.Same(
                    table.Columns.Single(c => c.Name == "Id"),
                    Assert.Single(table.PrimaryKey!.Columns));
            });
    }

    [ConditionalFact]
    public override async Task Rename_json_column()
    {
        await Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Entity");

                entityTypeBuilder.Property<int>("Id").ValueGeneratedOnAdd();
                entityTypeBuilder.HasKey("Id");
                entityTypeBuilder.Property<string>("Name");

                entityTypeBuilder.OwnsOne(
                    "Owned", "OwnedReference", o =>
                    {
                        o.OwnsOne(
                            "Nested", "NestedReference", n =>
                            {
                                n.Property<int>("Number");
                            });
                        o.OwnsMany(
                            "Nested2", "NestedCollection", n =>
                            {
                                n.Property<int>("Number2");
                            });
                        o.Property<DateTime>("Date");
                        o.ToJson("json_reference");
                    });

                entityTypeBuilder.OwnsMany(
                    "Owned2", "OwnedCollection", o =>
                    {
                        o.OwnsOne(
                            "Nested3", "NestedReference2", n =>
                            {
                                n.Property<int>("Number3");
                            });
                        o.OwnsMany(
                            "Nested4", "NestedCollection2", n =>
                            {
                                n.Property<int>("Number4");
                            });
                        o.Property<DateTime>("Date2");
                        o.ToJson("json_collection");
                    });

                entityTypeBuilder.ToTable("Entity", tableBuilder => tableBuilder
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder =>
            {
                builder.Entity(
                    "Entity", e =>
                    {
                        e.Property<int>("Id").ValueGeneratedOnAdd();
                        e.HasKey("Id");
                        e.Property<string>("Name");

                        e.OwnsOne(
                            "Owned", "OwnedReference", o =>
                            {
                                o.OwnsOne("Nested", "NestedReference", n => n.Property<int>("Number"));
                                o.OwnsMany("Nested2", "NestedCollection", n => n.Property<int>("Number2"));
                                o.Property<DateTime>("Date");
                                o.ToJson("new_json_reference");
                            });

                        e.OwnsMany(
                            "Owned2", "OwnedCollection", o =>
                            {
                                o.OwnsOne("Nested3", "NestedReference2", n => n.Property<int>("Number3"));
                                o.OwnsMany("Nested4", "NestedCollection2", n => n.Property<int>("Number4"));
                                o.Property<DateTime>("Date2");
                                o.ToJson("new_json_collection");
                            });
                    });
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("Entity", table.Name);

                Assert.Collection(
                    table.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name),
                    c => Assert.Equal("new_json_collection", c.Name),
                    c => Assert.Equal("new_json_reference", c.Name));
                Assert.Same(
                    table.Columns.Single(c => c.Name == "Id"),
                    Assert.Single(table.PrimaryKey!.Columns));
            });
    }

    [ConditionalFact]
    public override async Task Rename_table_with_json_column()
    {
        await Test(
            builder =>
            {
                var entityTypeBuilder = builder.Entity("Entity");

                entityTypeBuilder.Property<int>("Id").ValueGeneratedOnAdd();
                entityTypeBuilder.HasKey("Id");
                entityTypeBuilder.Property<string>("Name");
                entityTypeBuilder.ToTable("Entities");

                entityTypeBuilder.OwnsOne(
                    "Owned", "OwnedReference", o =>
                    {
                        o.OwnsOne(
                            "Nested", "NestedReference", n =>
                            {
                                n.Property<int>("Number");
                            });
                        o.OwnsMany(
                            "Nested2", "NestedCollection", n =>
                            {
                                n.Property<int>("Number2");
                            });
                        o.Property<DateTime>("Date");
                        o.ToJson();
                    });

                entityTypeBuilder.OwnsMany(
                    "Owned2", "OwnedCollection", o =>
                    {
                        o.OwnsOne(
                            "Nested3", "NestedReference2", n =>
                            {
                                n.Property<int>("Number3");
                            });
                        o.OwnsMany(
                            "Nested4", "NestedCollection2", n =>
                            {
                                n.Property<int>("Number4");
                            });
                        o.Property<DateTime>("Date2");
                        o.ToJson();
                    });

                entityTypeBuilder.ToTable("Entity", tableBuilder => tableBuilder
                    .HasMergeTreeEngine()
                    .WithPrimaryKey("Id"));
            },
            builder =>
            {
                builder.Entity(
                    "Entity", e =>
                    {
                        e.Property<int>("Id").ValueGeneratedOnAdd();
                        e.HasKey("Id");
                        e.Property<string>("Name");
                        e.ToTable("NewEntities");

                        e.OwnsOne(
                            "Owned", "OwnedReference", o =>
                            {
                                o.OwnsOne("Nested", "NestedReference", n => n.Property<int>("Number"));
                                o.OwnsMany("Nested2", "NestedCollection", n => n.Property<int>("Number2"));
                                o.Property<DateTime>("Date");
                                o.ToJson();
                            });

                        e.OwnsMany(
                            "Owned2", "OwnedCollection", o =>
                            {
                                o.OwnsOne("Nested3", "NestedReference2", n => n.Property<int>("Number3"));
                                o.OwnsMany("Nested4", "NestedCollection2", n => n.Property<int>("Number4"));
                                o.Property<DateTime>("Date2");
                                o.ToJson();
                            });
                    });
            },
            model =>
            {
                var table = Assert.Single(model.Tables);
                Assert.Equal("NewEntities", table.Name);

                Assert.Collection(
                    table.Columns,
                    c => Assert.Equal("Id", c.Name),
                    c => Assert.Equal("Name", c.Name),
                    c => Assert.Equal("OwnedCollection", c.Name),
                    c => Assert.Equal("OwnedReference", c.Name));
                Assert.Same(
                    table.Columns.Single(c => c.Name == "Id"),
                    Assert.Single(table.PrimaryKey!.Columns));
            });
    }

    protected override string NonDefaultCollation { get; }

    public class MigrationsClickHouseFixture : MigrationsFixtureBase
    {
        protected override string StoreName
            => nameof(MigrationsClickHouseTest);

        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;

        public override RelationalTestHelpers TestHelpers
            => ClickHouseTestHelpers.Instance;

        protected override IServiceCollection AddServices(IServiceCollection serviceCollection)
            => base.AddServices(serviceCollection)
                .AddScoped<IDatabaseModelFactory, ClickHouseDatabaseModelFactory>();
    }
}