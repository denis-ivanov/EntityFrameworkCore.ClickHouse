using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation;

public class ClickHouseDateValueConverter : ValueConverter<DateOnly, DateTime>
{
    public ClickHouseDateValueConverter() :
        base(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue, DateTimeKind.Unspecified),
            dateTime => DateOnly.FromDateTime(dateTime))
    {
    }
}
