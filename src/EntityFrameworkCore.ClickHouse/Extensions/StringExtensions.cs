using System;

namespace ClickHouse.EntityFrameworkCore.Extensions;

internal static class StringExtensions
{
    private const string Json = nameof(Json);

    internal static string? GetNullableType(this string? type)
    {
        return type.IsJson() ? type : $"Nullable({type})";
    }

    private static bool IsJson(this string? type) => Json.Equals(type, StringComparison.InvariantCultureIgnoreCase);
}
