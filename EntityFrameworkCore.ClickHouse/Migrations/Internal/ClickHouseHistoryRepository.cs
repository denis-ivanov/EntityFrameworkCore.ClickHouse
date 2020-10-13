using Microsoft.EntityFrameworkCore.Migrations;

namespace ClickHouse.EntityFrameworkCore.Migrations.Internal
{
    public class ClickHouseHistoryRepository : HistoryRepository
    {
        public ClickHouseHistoryRepository(HistoryRepositoryDependencies dependencies) : base(dependencies)
        {
        }

        protected override bool InterpretExistsResult(object value)
        {
            throw new System.NotImplementedException();
        }

        public override string GetCreateIfNotExistsScript()
        {
            throw new System.NotImplementedException();
        }

        public override string GetBeginIfNotExistsScript(string migrationId)
        {
            throw new System.NotImplementedException();
        }

        public override string GetBeginIfExistsScript(string migrationId)
        {
            throw new System.NotImplementedException();
        }

        public override string GetEndIfScript()
        {
            throw new System.NotImplementedException();
        }

        protected override string ExistsSql { get; }
    }
}