using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Buffers;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace ClickHouse.EntityFrameworkCore.Storage.Json;

public sealed class JsonInt128ReaderWriter : JsonValueReaderWriter<Int128>
{
    private static readonly PropertyInfo InstanceProperty = typeof(JsonInt128ReaderWriter).GetProperty(nameof(Instance))!;

    public static JsonInt128ReaderWriter Instance { get; } = new();

    private JsonInt128ReaderWriter()
    {
    }

    public override Int128 FromJsonTyped(ref Utf8JsonReaderManager manager, object? existingObject = null)
    {
        var reader = manager.CurrentReader;

        string valueString;

        switch (reader.TokenType)
        {
            case JsonTokenType.Number:
                if (reader.HasValueSequence)
                {
                    var bytes = reader.ValueSequence.ToArray();
                    valueString = Encoding.UTF8.GetString(bytes);
                }
                else
                {
                    valueString = Encoding.UTF8.GetString(reader.ValueSpan);
                }
                break;

            case JsonTokenType.String:
                valueString = reader.GetString()!;
                break;

            default:
                throw new JsonException($"Unexpected token parsing Int128. TokenType: {reader.TokenType}");
        }

        return Int128.Parse(valueString, NumberStyles.Integer, CultureInfo.InvariantCulture);
    }

    public override void ToJsonTyped(Utf8JsonWriter writer, Int128 value)
    {
        var s = value.ToString(CultureInfo.InvariantCulture);
        writer.WriteStringValue(s);
    }

    public override Expression ConstructorExpression
        => Expression.Property(null, InstanceProperty);
}