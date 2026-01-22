using ClickHouse.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace ClickHouse.EntityFrameworkCore.Infrastructure.Internal;

public class ClickHouseOptionsExtension : RelationalOptionsExtension
{
    public ClickHouseOptionsExtension()
    {
    }

    protected ClickHouseOptionsExtension(ClickHouseOptionsExtension copyFrom) : base(copyFrom)
    {
        AdminDatabase = copyFrom.AdminDatabase;
    }

    protected override RelationalOptionsExtension Clone()
    {
        return new ClickHouseOptionsExtension(this);
    }

    public override void ApplyServices(IServiceCollection services)
    {
        services.AddEntityFrameworkClickHouse();
    }

    public virtual string AdminDatabase { get; set; } = "default";

    public override int? MaxBatchSize => 1;

    public override DbContextOptionsExtensionInfo Info => field ??= new ExtensionInfo(this);

    public virtual ClickHouseOptionsExtension WithAdminDatabase(string adminDatabase)
    {
        var clone = (ClickHouseOptionsExtension)Clone();
        clone.AdminDatabase = adminDatabase;

        return clone;
    }

    private sealed class ExtensionInfo : RelationalExtensionInfo
    {
        public ExtensionInfo(IDbContextOptionsExtension extension)
            : base(extension)
        {
        }

        private new ClickHouseOptionsExtension Extension => (ClickHouseOptionsExtension)base.Extension;

        public override bool IsDatabaseProvider => true;

        public override string LogFragment => string.Empty;

        public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
        {
        }
    }
}
