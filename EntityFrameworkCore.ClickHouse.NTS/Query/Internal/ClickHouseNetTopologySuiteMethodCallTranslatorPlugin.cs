using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.NTS.Query.Internal;

public class ClickHouseNetTopologySuiteMethodCallTranslatorPlugin : IMethodCallTranslatorPlugin
{
    public ClickHouseNetTopologySuiteMethodCallTranslatorPlugin()
    {
        Translators =
        [
            new ClickHouseGeometryMethodTranslator(),
            new ClickHouseGeometryCollectionMethodTranslator(),
            new ClickHouseLineStringMethodTranslator(),
            new ClickHouseNetTopologySuiteDbFunctionsMethodCallTranslator(),
            new ClickHousePolygonMethodTranslator()
        ];
    }

    public IEnumerable<IMethodCallTranslator> Translators { get; }
}
