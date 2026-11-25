using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.ClickHouse.Tests.Query;

public sealed class ProviderQueryTranslationTest
{
    [Fact]
    public void Nested_correlated_ordering_ranks_matches_per_account()
    {
        using var context = CreateContext();

        string sql = context.Set<Account>()
            .OrderBy(account => account.Id)
            .Take(3)
            .OrderByDescending(account => account.Invoices
                .OrderByDescending(invoice => 5 + invoice.Lines.Sum(line => line.Amount))
                .Select(invoice => (int?)invoice.Id)
                .FirstOrDefault())
            .Take(1)
            .ToQueryString();

        Assert.Contains("row_number() OVER (PARTITION BY", sql);
        Assert.Contains("SUM(", sql);
        Assert.Contains("LEFT JOIN", sql);
        Assert.Contains("join_use_nulls", sql);
    }

    [Fact]
    public void DateTimeOffset_uses_the_requested_clock_and_offset_in_sql()
    {
        using var context = CreateContext();
        var clock = new DateTime(2026, 1, 2, 12, 0, 0);

        string clocks = context.Set<Invoice>()
            .Where(invoice => invoice.IssuedAt.DateTime == clock
                && invoice.IssuedAt.UtcDateTime == clock
                && invoice.IssuedAt.LocalDateTime == clock)
            .ToQueryString();
        string offsets = context.Set<Invoice>()
            .Where(invoice => invoice.IssuedAt.ToOffset(TimeSpan.FromHours(-2)) == invoice.IssuedAt
                && new DateTimeOffset(invoice.IssuedOn) == invoice.IssuedAt
                && new DateTimeOffset(invoice.IssuedOn, TimeSpan.FromHours(2)) == invoice.IssuedAt)
            .ToQueryString();

        Assert.Contains("parseDateTime64BestEffortOrNull(substring(", clocks);
        Assert.Matches("""parseDateTime64BestEffortOrNull\("[^"]+"\."IssuedAt",\s*7,\s*'UTC'\)""", clocks);
        Assert.Contains("toTimeZone(", clocks);
        Assert.Contains("addMinutes(", offsets);
        Assert.Contains("replaceRegexpOne(", offsets);
        Assert.Contains("'-02:00'", offsets);
        Assert.Contains("'+00:00'", offsets);
        Assert.Contains("'+02:00'", offsets);
    }

#if NET11_0_OR_GREATER
    [Fact]
    public void Complex_json_collection_filter_reads_each_element()
    {
        using var context = CreateContext();

        string sql = context.Set<OrderView>()
            .Where(order => order.Items.Any(item => item.Amount == 3))
            .ToQueryString();

        Assert.Contains("JSONExtractArrayRaw(", sql);
        Assert.Contains("arrayJoin(arrayZip(arrayEnumerate(", sql);
        Assert.Contains("JSONExtract(", sql);
        Assert.Contains("'Amount'", sql);
    }
#endif

    private static TranslationContext CreateContext()
        => new(new DbContextOptionsBuilder<TranslationContext>()
            .UseClickHouse("Host=localhost;Database=default")
            .Options);

    private sealed class TranslationContext(DbContextOptions<TranslationContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasMany(account => account.Invoices).WithOne().HasForeignKey(invoice => invoice.AccountId);
            modelBuilder.Entity<Invoice>().HasMany(invoice => invoice.Lines).WithOne().HasForeignKey(line => line.InvoiceId);
#if NET11_0_OR_GREATER
            modelBuilder.Entity<OrderView>()
                .ToView("OrderView")
                .ComplexCollection(order => order.Items, items => items.ToJson());
#endif
        }
    }

    private sealed class Account
    {
        public int Id { get; set; }
        public List<Invoice> Invoices { get; set; } = [];
    }

    private sealed class Invoice
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTimeOffset IssuedAt { get; set; }
        public List<InvoiceLine> Lines { get; set; } = [];
    }

    private sealed class InvoiceLine
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int Amount { get; set; }
    }

#if NET11_0_OR_GREATER
    private sealed class OrderView
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; } = [];
    }

    private sealed class OrderItem
    {
        public int Amount { get; set; }
    }
#endif
}
