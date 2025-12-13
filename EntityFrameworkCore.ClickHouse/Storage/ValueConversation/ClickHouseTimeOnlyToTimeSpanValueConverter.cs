using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation;

public class ClickHouseTimeOnlyToTimeSpanValueConverter : ValueConverter<TimeOnly, TimeSpan>
{
    public ClickHouseTimeOnlyToTimeSpanValueConverter()
        : base(to => to.ToTimeSpan(), ts => TimeOnly.FromTimeSpan(ts))
    {
    }
}
