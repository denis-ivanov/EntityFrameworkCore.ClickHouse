using Microsoft.EntityFrameworkCore.Query;

namespace ClickHouse.EntityFrameworkCore.Query.Internal;

public class ClickHouseQueryCompilationContextFactory: IQueryCompilationContextFactory
{
    private readonly QueryCompilationContextDependencies _dependencies;
    private readonly RelationalQueryCompilationContextDependencies _relationalDependencies;

    public ClickHouseQueryCompilationContextFactory(
        QueryCompilationContextDependencies dependencies,
        RelationalQueryCompilationContextDependencies relationalDependencies)
    {
        _dependencies = dependencies;
        _relationalDependencies = relationalDependencies;
    }

    public QueryCompilationContext Create(bool async)
        => new ClickHouseQueryCompilationContext(_dependencies, _relationalDependencies, async, precompiling: false);

    public QueryCompilationContext CreatePrecompiled(bool async)
        => new ClickHouseQueryCompilationContext(_dependencies, _relationalDependencies, async, precompiling: true);

    private sealed class ClickHouseQueryCompilationContext(
        QueryCompilationContextDependencies dependencies,
        RelationalQueryCompilationContextDependencies relationalDependencies,
        bool async,
        bool precompiling) : RelationalQueryCompilationContext(dependencies, relationalDependencies, async, precompiling)
    {
        public override bool SupportsPrecompiledQuery => IsPrecompiling;
    }
}
