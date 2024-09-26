using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.ClickHouse.NTS.Query.Internal;

public class ClickHouseNetTopologySuiteMemberTranslatorPlugin : IMemberTranslatorPlugin
{
    public ClickHouseNetTopologySuiteMemberTranslatorPlugin(ISqlExpressionFactory sqlExpressionFactory)
    {
        Translators =
        [
            new ClickHouseGeometryMemberTranslator(),
            new ClickHouseGeometryCollectionMemberTranslator(),
            new ClickHouseLineStringMemberTranslator(),
            new ClickHouseMultiLineStringMemberTranslator(),
            new ClickHousePointMemberTranslator(sqlExpressionFactory),
            new ClickHousePolygonMemberTranslator()
        ];
    }

    public IEnumerable<IMemberTranslator> Translators { get; }
}
