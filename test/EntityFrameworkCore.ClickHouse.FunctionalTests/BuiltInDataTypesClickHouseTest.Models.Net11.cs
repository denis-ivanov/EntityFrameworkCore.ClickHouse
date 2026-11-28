using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests;

public partial class BuiltInDataTypesClickHouseTest
{
    private class BuiltInDataTypesShadow : BuiltInDataTypesBase;

    // These models cover provider round-trips that were formerly provided by the EF Core test base.
    private class BuiltInNullableDataTypes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int PartitionId { get; set; }
        public string? TestString { get; set; }
        public short? TestNullableInt16 { get; set; }
        public int? TestNullableInt32 { get; set; }
        public long? TestNullableInt64 { get; set; }
        public double? TestNullableDouble { get; set; }
        public decimal? TestNullableDecimal { get; set; }
        public DateTime? TestNullableDateTime { get; set; }
        public DateTimeOffset? TestNullableDateTimeOffset { get; set; }
        public TimeSpan? TestNullableTimeSpan { get; set; }
        public float? TestNullableSingle { get; set; }
        public bool? TestNullableBoolean { get; set; }
        public byte? TestNullableByte { get; set; }
        public ushort? TestNullableUnsignedInt16 { get; set; }
        public uint? TestNullableUnsignedInt32 { get; set; }
        public ulong? TestNullableUnsignedInt64 { get; set; }
        public char? TestNullableCharacter { get; set; }
        public sbyte? TestNullableSignedByte { get; set; }
        public Enum64? Enum64 { get; set; }
        public Enum32? Enum32 { get; set; }
        public Enum16? Enum16 { get; set; }
        public Enum8? Enum8 { get; set; }
        public EnumU64? EnumU64 { get; set; }
        public EnumU32? EnumU32 { get; set; }
        public EnumU16? EnumU16 { get; set; }
        public EnumS8? EnumS8 { get; set; }
    }

    private class NonNullableBackedDataTypes
    {
        private short _int16;
        private int _int32;
        private long _int64;
        private double _double;
        private decimal _decimal;
        private DateTime _dateTime;
        private DateTimeOffset _dateTimeOffset;
        private TimeSpan _timeSpan;
        private float _single;
        private bool _boolean;
        private byte _byte;
        private ushort _unsignedInt16;
        private uint _unsignedInt32;
        private ulong _unsignedInt64;
        private char _character;
        private sbyte _signedByte;
        private Enum64 _enum64;
        private Enum32 _enum32;
        private Enum16 _enum16;
        private Enum8 _enum8;
        private EnumU64 _enumU64;
        private EnumU32 _enumU32;
        private EnumU16 _enumU16;
        private EnumS8 _enumS8;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int PartitionId { get; set; }

        public short? Int16
        {
            get => _int16;
            set => _int16 = value!.Value;
        }

        public int? Int32
        {
            get => _int32;
            set => _int32 = value!.Value;
        }

        public long? Int64
        {
            get => _int64;
            set => _int64 = value!.Value;
        }

        public double? Double
        {
            get => _double;
            set => _double = value!.Value;
        }

        public decimal? Decimal
        {
            get => _decimal;
            set => _decimal = value!.Value;
        }

        public DateTime? DateTime
        {
            get => _dateTime;
            set => _dateTime = value!.Value;
        }

        public DateTimeOffset? DateTimeOffset
        {
            get => _dateTimeOffset;
            set => _dateTimeOffset = value!.Value;
        }

        public TimeSpan? TimeSpan
        {
            get => _timeSpan;
            set => _timeSpan = value!.Value;
        }

        public float? Single
        {
            get => _single;
            set => _single = value!.Value;
        }

        public bool? Boolean
        {
            get => _boolean;
            set => _boolean = value!.Value;
        }

        public byte? Byte
        {
            get => _byte;
            set => _byte = value!.Value;
        }

        public ushort? UnsignedInt16
        {
            get => _unsignedInt16;
            set => _unsignedInt16 = value!.Value;
        }

        public uint? UnsignedInt32
        {
            get => _unsignedInt32;
            set => _unsignedInt32 = value!.Value;
        }

        public ulong? UnsignedInt64
        {
            get => _unsignedInt64;
            set => _unsignedInt64 = value!.Value;
        }

        public char? Character
        {
            get => _character;
            set => _character = value!.Value;
        }

        public sbyte? SignedByte
        {
            get => _signedByte;
            set => _signedByte = value!.Value;
        }

        public Enum64? Enum64
        {
            get => _enum64;
            set => _enum64 = value!.Value;
        }

        public Enum32? Enum32
        {
            get => _enum32;
            set => _enum32 = value!.Value;
        }

        public Enum16? Enum16
        {
            get => _enum16;
            set => _enum16 = value!.Value;
        }

        public Enum8? Enum8
        {
            get => _enum8;
            set => _enum8 = value!.Value;
        }

        public EnumU64? EnumU64
        {
            get => _enumU64;
            set => _enumU64 = value!.Value;
        }

        public EnumU32? EnumU32
        {
            get => _enumU32;
            set => _enumU32 = value!.Value;
        }

        public EnumU16? EnumU16
        {
            get => _enumU16;
            set => _enumU16 = value!.Value;
        }

        public EnumS8? EnumS8
        {
            get => _enumS8;
            set => _enumS8 = value!.Value;
        }
    }

    private class NullableBackedDataTypes
    {
        private short? _int16;
        private int? _int32;
        private long? _int64;
        private double? _double;
        private decimal? _decimal;
        private DateTime? _dateTime;
        private DateTimeOffset? _dateTimeOffset;
        private TimeSpan? _timeSpan;
        private float? _single;
        private bool? _boolean;
        private byte? _byte;
        private ushort? _unsignedInt16;
        private uint? _unsignedInt32;
        private ulong? _unsignedInt64;
        private char? _character;
        private sbyte? _signedByte;
        private Enum64? _enum64;
        private Enum32? _enum32;
        private Enum16? _enum16;
        private Enum8? _enum8;
        private EnumU64? _enumU64;
        private EnumU32? _enumU32;
        private EnumU16? _enumU16;
        private EnumS8? _enumS8;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int PartitionId { get; set; }

        public short Int16
        {
            get => _int16!.Value;
            set => _int16 = value;
        }

        public int Int32
        {
            get => _int32!.Value;
            set => _int32 = value;
        }

        public long Int64
        {
            get => _int64!.Value;
            set => _int64 = value;
        }

        public double Double
        {
            get => _double!.Value;
            set => _double = value;
        }

        public decimal Decimal
        {
            get => _decimal!.Value;
            set => _decimal = value;
        }

        public DateTime DateTime
        {
            get => _dateTime!.Value;
            set => _dateTime = value;
        }

        public DateTimeOffset DateTimeOffset
        {
            get => _dateTimeOffset!.Value;
            set => _dateTimeOffset = value;
        }

        public TimeSpan TimeSpan
        {
            get => _timeSpan!.Value;
            set => _timeSpan = value;
        }

        public float Single
        {
            get => _single!.Value;
            set => _single = value;
        }

        public bool Boolean
        {
            get => _boolean!.Value;
            set => _boolean = value;
        }

        public byte Byte
        {
            get => _byte!.Value;
            set => _byte = value;
        }

        public ushort UnsignedInt16
        {
            get => _unsignedInt16!.Value;
            set => _unsignedInt16 = value;
        }

        public uint UnsignedInt32
        {
            get => _unsignedInt32!.Value;
            set => _unsignedInt32 = value;
        }

        public ulong UnsignedInt64
        {
            get => _unsignedInt64!.Value;
            set => _unsignedInt64 = value;
        }

        public char Character
        {
            get => _character!.Value;
            set => _character = value;
        }

        public sbyte SignedByte
        {
            get => _signedByte!.Value;
            set => _signedByte = value;
        }

        public Enum64 Enum64
        {
            get => _enum64!.Value;
            set => _enum64 = value;
        }

        public Enum32 Enum32
        {
            get => _enum32!.Value;
            set => _enum32 = value;
        }

        public Enum16 Enum16
        {
            get => _enum16!.Value;
            set => _enum16 = value;
        }

        public Enum8 Enum8
        {
            get => _enum8!.Value;
            set => _enum8 = value;
        }

        public EnumU64 EnumU64
        {
            get => _enumU64!.Value;
            set => _enumU64 = value;
        }

        public EnumU32 EnumU32
        {
            get => _enumU32!.Value;
            set => _enumU32 = value;
        }

        public EnumU16 EnumU16
        {
            get => _enumU16!.Value;
            set => _enumU16 = value;
        }

        public EnumS8 EnumS8
        {
            get => _enumS8!.Value;
            set => _enumS8 = value;
        }
    }
}
