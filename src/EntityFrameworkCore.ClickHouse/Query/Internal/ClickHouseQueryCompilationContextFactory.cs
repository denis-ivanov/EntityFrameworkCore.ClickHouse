using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

internal sealed class ClickHouseQueryCompilationContextFactory(
    QueryCompilationContextDependencies dependencies,
    RelationalQueryCompilationContextDependencies relationalDependencies) : IQueryCompilationContextFactory
{
    public QueryCompilationContext Create(bool async)
        => new ClickHouseQueryCompilationContext(dependencies, relationalDependencies, async, precompiling: false);

    public QueryCompilationContext CreatePrecompiled(bool async)
        => new ClickHouseQueryCompilationContext(dependencies, relationalDependencies, async, precompiling: true);

    private sealed class ClickHouseQueryCompilationContext(
        QueryCompilationContextDependencies dependencies,
        RelationalQueryCompilationContextDependencies relationalDependencies,
        bool async,
        bool precompiling) : RelationalQueryCompilationContext(dependencies, relationalDependencies, async, precompiling)
    {
        public override bool SupportsPrecompiledQuery => IsPrecompiling;
    }
}
