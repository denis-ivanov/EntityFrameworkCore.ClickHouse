using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal;

public class ClickHouseTransaction : IDbContextTransaction
{
    public void Dispose()
    {
    }

    public ValueTask DisposeAsync()
    {
        return new ValueTask();
    }

    public void Commit()
    {
    }

    public void Rollback()
    {
    }

    public Task CommitAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.CompletedTask;
    }

    public Task RollbackAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.CompletedTask;
    }

    public Guid TransactionId { get; } = Guid.NewGuid();
}
