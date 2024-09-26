using EntityFrameworkCore.ClickHouse.NTS.Extensions;
using EntityFrameworkCore.ClickHouse.NTS.Storage.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.ClickHouse.NTS.Infrastructure.Internal;

public class ClickHouseNetTopologySuiteOptionsExtension : IDbContextOptionsExtension
{
    private DbContextOptionsExtensionInfo? _info;

    public virtual void ApplyServices(IServiceCollection services)
        => services.AddEntityFrameworkClickHouseNetTopologySuite();

    public void Validate(IDbContextOptions options)
    {
        var internalServiceProvider = options.FindExtension<CoreOptionsExtension>()?.InternalServiceProvider;

        if (internalServiceProvider != null)
        {
            using var scope = internalServiceProvider.CreateScope();
            var plugins = scope.ServiceProvider.GetService<IEnumerable<IRelationalTypeMappingSourcePlugin>>();
            if (plugins?.Any(s => s is ClickHouseNetTopologySuiteTypeMappingSourcePlugin) != true)
            {
                throw new InvalidOperationException("UseNetTopologySuite requires AddEntityFrameworkClickHouseNetTopologySuite to be called on the internal service provider used.");
            }
        }
    }

    public DbContextOptionsExtensionInfo Info => _info ??= new ExtensionInfo(this);

    private sealed class ExtensionInfo : DbContextOptionsExtensionInfo
    {
        public ExtensionInfo(IDbContextOptionsExtension extension)
            : base(extension)
        {
        }

        private new ClickHouseNetTopologySuiteOptionsExtension Extension
            => (ClickHouseNetTopologySuiteOptionsExtension)base.Extension;

        public override bool IsDatabaseProvider
            => false;

        public override int GetServiceProviderHashCode()
            => 0;

        public override bool ShouldUseSameServiceProvider(DbContextOptionsExtensionInfo other)
            => other is ExtensionInfo;

        public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
            => debugInfo["ClickHouse:" + nameof(ClickHouseNetTopologySuiteDbContextOptionsBuilderExtensions.UseNetTopologySuite)] = "1";

        public override string LogFragment
            => "using NetTopologySuite ";
    }
}
