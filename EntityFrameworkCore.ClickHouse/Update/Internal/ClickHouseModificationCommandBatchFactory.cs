using Microsoft.EntityFrameworkCore.Update;

namespace ClickHouse.EntityFrameworkCore.Update.Internal;

public class ClickHouseModificationCommandBatchFactory : IModificationCommandBatchFactory
{
    private readonly ModificationCommandBatchFactoryDependencies _dependencies;

    public ClickHouseModificationCommandBatchFactory(ModificationCommandBatchFactoryDependencies dependencies)
    {
        _dependencies = dependencies;
    }

    public ModificationCommandBatch Create() => new SingularModificationCommandBatch(_dependencies);
}
