<div align="center">
  <img src="https://raw.githubusercontent.com/denis-ivanov/EntityFrameworkCore.ClickHouse/master/Logo.png" />
</div>

# ClickHouse provider for Entity Framework Core

[![GitHub Tag](https://img.shields.io/github/tag/denis-ivanov/EntityFrameworkCore.ClickHouse.svg?style=flat-square)](https://github.com/denis-ivanov/EntityFrameworkCore.ClickHouse/releases)
[![NuGet Count](https://img.shields.io/nuget/dt/EntityFrameworkCore.ClickHouse.svg?style=flat-square)](https://www.nuget.org/packages/EntityFrameworkCore.ClickHouse/)
[![Issues Open](https://img.shields.io/github/issues/denis-ivanov/EntityFrameworkCore.ClickHouse.svg?style=flat-square)](https://github.com/denis-ivanov/EntityFrameworkCore.ClickHouse/issues)

# Quick start

1. Create console app
2. Install the necessary packages

```
dotnet add package EntityFrameworkCore.ClickHouse
dotnet add package Spectre.Console.Cli
```

```csharp
class MyFirstTable
{
    public uint UserId { get; set; }

    public string Message { get; set; }

    public DateTime Timestamp { get; set; }

    public float Metric { get; set; }
}

class QuickStartDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseClickHouse("Host=localhost;Protocol=http;Port=8123;Database=QuickStart");
    }

    public DbSet<MyFirstTable> MyFirstTable { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entityTypeBuilder = modelBuilder.Entity<MyFirstTable>();

        entityTypeBuilder.Property(e => e.UserId).HasColumnName("user_id");
        entityTypeBuilder.Property(e => e.Message).HasColumnName("message");
        entityTypeBuilder.Property(e => e.Timestamp).HasColumnName("timestamp");
        entityTypeBuilder.Property(e => e.Metric).HasColumnName("metric");

        entityTypeBuilder.HasKey(e => new { e.UserId, e.Timestamp });

        entityTypeBuilder.ToTable("my_first_table", table => table
            .HasMergeTreeEngine()
            .WithPrimaryKey("user_id", "timestamp"));
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        await using var context = new QuickStartDbContext();
        await context.Database.EnsureCreatedAsync();

        await context.MyFirstTable.AddRangeAsync(
            new MyFirstTable
            {
                UserId = 101,
                Message = "Hello, ClickHouse!",
                Timestamp = DateTime.Now,
                Metric = -1f
            },
            new MyFirstTable
            {
                UserId = 102,
                Message = "Insert a lot of rows per batch",
                Timestamp = DateTime.Now.AddDays(-1),
                Metric = 1.41421f
            },
            new MyFirstTable
            {
                UserId = 102,
                Message = "Sort your data based on your commonly-used queries",
                Timestamp = DateTime.Today,
                Metric = 2.718f
            },
            new MyFirstTable
            {
                UserId = 101,
                Message = "Granules are the smallest chunks of data read",
                Timestamp = DateTime.Now.AddSeconds(5),
                Metric = 3.14159f
            });

        await context.SaveChangesAsync();

        var data = context.MyFirstTable.OrderBy(e => e.Timestamp).ToArray();

        var table = new Table()
            .AddColumns(
                new TableColumn("user_id").RightAligned(),
                new TableColumn("message").LeftAligned(),
                new TableColumn("timestamp").RightAligned(),
                new TableColumn("metric").RightAligned());

        Array.ForEach(data, d => table.AddRow(
            d.UserId.ToString(),
            d.Message,
            d.Timestamp.ToString(CultureInfo.InvariantCulture),
            d.Metric.ToString(CultureInfo.InvariantCulture)));

        AnsiConsole.Write(table);
    }
}
```

```
┌─────────┬────────────────────────────────────────────────────┬─────────────────────┬─────────┐
│ user_id │ message                                            │           timestamp │  metric │
├─────────┼────────────────────────────────────────────────────┼─────────────────────┼─────────┤
│     102 │ Insert a lot of rows per batch                     │ 04/29/2024 21:05:26 │ 1.41421 │
│     102 │ Sort your data based on your commonly-used queries │ 04/30/2024 00:00:00 │   2.718 │
│     101 │ Hello, ClickHouse!                                 │ 04/30/2024 21:05:26 │      -1 │
│     101 │ Granules are the smallest chunks of data read      │ 04/30/2024 21:05:31 │ 3.14159 │
└─────────┴────────────────────────────────────────────────────┴─────────────────────┴─────────┘
```
