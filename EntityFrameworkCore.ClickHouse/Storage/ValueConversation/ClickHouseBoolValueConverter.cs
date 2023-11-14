using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace ClickHouse.EntityFrameworkCore.Storage.ValueConversation;

public class ClickHouseBoolValueConverter : ValueConverter<bool, byte>
{
    public ClickHouseBoolValueConverter() : base(b => Convert.ToByte(b), b => Convert.ToBoolean(b))
    {
    }
}
