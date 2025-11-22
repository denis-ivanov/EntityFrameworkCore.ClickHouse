using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.NTS.Query.Internal;

public class ClickHouseNetTopologySuiteAggregateMethodCallTranslatorPlugin : IAggregateMethodCallTranslatorPlugin
{
    public ClickHouseNetTopologySuiteAggregateMethodCallTranslatorPlugin()
    {
        Translators =
        [
            new ClickHouseNetTopologySuiteAggregateMethodTranslator()
        ];
    }

    public IEnumerable<IAggregateMethodCallTranslator> Translators { get; }
}
