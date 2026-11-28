using ClickHouse.Driver.ADO.Parameters;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

#if NET11_0_OR_GREATER
using JsonTypeMappingBase = Microsoft.EntityFrameworkCore.Storage.StructuralJsonTypeMapping;
#else
using JsonTypeMappingBase = Microsoft.EntityFrameworkCore.Storage.JsonTypeMapping;
#endif

namespace ClickHouse.EntityFrameworkCore.Storage.Internal.Mapping;

public class ClickHouseJsonTypeMapping : JsonTypeMappingBase
{
    private static readonly MethodInfo s_openJsonStreamMethod = typeof(ClickHouseJsonTypeMapping)
        .GetMethod(nameof(OpenJsonStream), BindingFlags.Public | BindingFlags.Static)!;
    private static readonly MethodInfo s_openJsonTextStreamMethod = typeof(ClickHouseJsonTypeMapping)
        .GetMethod(nameof(OpenJsonTextStream), BindingFlags.Public | BindingFlags.Static)!;
    private static readonly MethodInfo s_readJsonElementMethod = typeof(ClickHouseJsonTypeMapping)
        .GetMethod(nameof(ReadJsonElement), BindingFlags.Public | BindingFlags.Static)!;

    public ClickHouseJsonTypeMapping() : this(typeof(JsonElement))
    {
    }

    internal ClickHouseJsonTypeMapping(Type clrType, string storeType = "Json")
        : base(storeType, clrType, System.Data.DbType.String)
    {
    }

    protected ClickHouseJsonTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
    {
    }

    protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters)
    {
        return new ClickHouseJsonTypeMapping(parameters);
    }

    public override MethodInfo GetDataReaderMethod()
        => GetDataReaderMethod(StoreType == "String" ? typeof(string) : typeof(JsonNode));

    public override Expression CustomizeDataReaderExpression(Expression expression)
    {
        MethodInfo reader = StoreType == "String"
            ? s_openJsonTextStreamMethod
            : ClrType == typeof(JsonTypePlaceholder) ? s_openJsonStreamMethod : s_readJsonElementMethod;

        return Expression.Call(reader, expression);
    }

    public static MemoryStream OpenJsonStream(JsonNode value)
        => OpenUtf8Stream(JsonSerializer.SerializeToUtf8Bytes(value));

    public static MemoryStream OpenJsonTextStream(string value)
        => OpenUtf8Stream(Encoding.UTF8.GetBytes(value));

    private static MemoryStream OpenUtf8Stream(byte[] bytes)
        => new(bytes, 0, bytes.Length, writable: false, publiclyVisible: true);

    public static JsonElement ReadJsonElement(JsonNode value)
        => JsonSerializer.SerializeToElement(value);

    protected override void ConfigureParameter(DbParameter parameter)
    {
        ((ClickHouseDbParameter)parameter).ClickHouseType = GetStoreType(parameter.Value);

        if (StoreType == "Json" && parameter.Value is { } value && value != DBNull.Value)
        {
            // The driver's HTTP JSON formatter sends JSON verbatim. ClickHouse first unescapes the parameter.
            string json = value is string text ? text : JsonSerializer.Serialize(value);
            parameter.Value = json.Replace("\\", "\\\\", StringComparison.Ordinal)
                .Replace("'", "\\'", StringComparison.Ordinal)
                .Replace("\t", "\\t", StringComparison.Ordinal)
                .Replace("\r", "\\r", StringComparison.Ordinal)
                .Replace("\n", "\\n", StringComparison.Ordinal);
        }
    }

    protected virtual string GetStoreType(bool? isNullable)
    {
        return isNullable == true ? $"Nullable({StoreType})" : StoreType;
    }
    
    protected virtual string GetStoreType(object? parameterValue)
    {
        return GetStoreType(parameterValue == null || parameterValue == DBNull.Value);
    }
}
