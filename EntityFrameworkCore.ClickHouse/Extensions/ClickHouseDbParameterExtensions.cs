using ClickHouse.Driver.ADO.Parameters;
using System;
using System.Data.Common;

namespace ClickHouse.EntityFrameworkCore.Extensions;

internal static class ClickHouseDbParameterExtensions
{
    internal static void SetStoreType(this DbParameter parameter, string storeType)
    {
        if (parameter is ClickHouseDbParameter clickHouseDbParameter)
        {
            clickHouseDbParameter.ClickHouseType = clickHouseDbParameter.Value is DBNull
                ? storeType.GetNullableType()
                : storeType;
        }
    }
}