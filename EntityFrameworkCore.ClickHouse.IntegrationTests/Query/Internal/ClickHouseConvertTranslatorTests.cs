using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ClickHouse.EntityFrameworkCore.Extensions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace EntityFrameworkCore.ClickHouse.IntegrationTests.Query.Internal
{
    [TestFixture, ExcludeFromCodeCoverage]
    public class ClickHouseConvertTranslatorTests : DatabaseFixture
    {
        private const int Value = 1;

        private const string ValueAsString = "1";

        private static readonly string TodayAsString = DateTime.Now.ToString("yyyy-MM-dd");

        #region Convert.ToXX()
        
        [Test]
        public void ToInt8()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => Convert.ToSByte(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToInt16()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => Convert.ToInt16(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToInt32()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => Convert.ToInt32(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToInt64()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => Convert.ToInt64(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToUInt8()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => Convert.ToByte(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToUInt16()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => Convert.ToUInt16(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToUInt32()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => Convert.ToUInt32(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToUInt64()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => Convert.ToUInt64(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void ToFloat32()
        {
            // Arrange

            // Act
            var v = Context.SimpleEntities.Select(e => Convert.ToSingle(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }

        [Test]
        public void ToFloat64()
        {
            // Arrange

            // Act
            var v = Context.SimpleEntities.Select(e => Convert.ToDouble(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }

        [Test]
        public void ToDateTime()
        {
            // Arrange

            // Act
            var v = Context.SimpleEntities.Select(e => Convert.ToDateTime(TodayAsString)).Single();

            // Assert
            v.Should().Be(DateTime.Today);
        }

        #endregion

        #region Type.Parse()

        [Test]
        public void Int8Parse()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => sbyte.Parse(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void Int16Parse()
        {
            // Arrange

            // Act
            var v = Context.SimpleEntities.Select(e => short.Parse(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void Int32Parse()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => int.Parse(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void Int64Parse()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => long.Parse(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void UInt8Parse()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => byte.Parse(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void UInt16Parse()
        {
            // Arrange

            // Act
            var v = Context.SimpleEntities.Select(e => ushort.Parse(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void UInt32Parse()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => uint.Parse(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void UInt64Parse()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => ulong.Parse(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }
        
        [Test]
        public void FloatParse()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => float.Parse(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }

        [Test]
        public void DoubleParse()
        {
            // Arrange
            
            // Act
            var v = Context.SimpleEntities.Select(e => double.Parse(ValueAsString)).Single();

            // Assert
            v.Should().Be(Value);
        }

        [Test]
        public void DateTimeParse()
        {
            // Arrange

            // Act
            var v = Context.SimpleEntities.Select(e => DateTime.Parse(TodayAsString)).Single();

            // Assert
            v.Should().Be(DateTime.Today);
        }
        
        #endregion
    }
}
