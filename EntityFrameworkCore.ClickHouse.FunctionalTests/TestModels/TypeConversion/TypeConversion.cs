using System;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.TestModels.TypeConversion;

public class TypeConversion
{
    public int Id { get; set; }

    public string Nan { get; set; }

    public float Int8AsFloat { get; set; }

    public string Int8AsStringValid { get; set; }

    public float Int16AsFloat { get; set; }

    public string Int16AsStringValid { get; set; }

    public float Int32AsFloat { get; set; }

    public string Int32AsStringValid { get; set; }

    public float Int64AsFloat { get; set; }

    public string Int64AsStringValid { get; set; }
    
    public float Int128AsFloat { get; set; }
    
    public string Int128AsStringValid { get; set; }
    
    public float UInt8AsFloat { get; set; }
    
    public string UInt8AsStringValid { get; set; }
    
    public float UInt16AsFloat { get; set; }
    
    public string UInt16AsStringValid { get; set; }
    
    public float UInt32AsFloat { get; set; }
    
    public string UInt32AsStringValid { get; set; }
    
    public float UInt64AsFloat { get; set; }
    
    public string UInt64AsStringValid { get; set; }

    public float UInt128AsFloat { get; set; }
    
    public string UInt128AsStringValid { get; set; }

    public string GuidAsStringValid { get; set; }

    public float DateAsFloat32 { get; set; }

    public string DateAsStringValid { get; set; }
    
    public DateTime DateAsDateTime { get; set; }
}
