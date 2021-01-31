using ClickHouse.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Update;

namespace ClickHouse.EntityFrameworkCore.Update.Internal
{
    public class ClickHouseModificationCommandBatchFactory : IModificationCommandBatchFactory
    {
        readonly ModificationCommandBatchFactoryDependencies _dependencies;
        readonly IDbContextOptions _options;

        public ClickHouseModificationCommandBatchFactory(
            ModificationCommandBatchFactoryDependencies dependencies,
            IDbContextOptions options)
        {
            _dependencies = dependencies;
            _options = options;
        }

        public ModificationCommandBatch Create()
        {
            var extension = _options.FindExtension<ClickHouseOptionsExtension>();
            return new ClickHouseModificationCommandBatch(_dependencies, extension?.MaxBatchSize);
        }
    }
}
