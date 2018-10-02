using System;
using System.Linq;
using RoxieMobile.CSharpCommons.Cryptography.Converters;
using Xunit;

namespace RoxieMobile.CSharpCommons.Cryptography.UnitTests.Converters
{
    public sealed class BigEndianBitConverterTests
    {
// MARK: - Tests

        [Fact]
        private void TestInt64Conversion()
        {
            const long value = (long) 0x004F003F002F001F;

            var arr_v0 = BitConverter.GetBytes(value);
            var arr_v1 = BigEndianBitConverter.ToByteArray(value);
            Assert.True(BitConverter.IsLittleEndian ? arr_v0.Reverse().SequenceEqual(arr_v1) : arr_v0.SequenceEqual(arr_v1));

            var val_v1 = BigEndianBitConverter.ToInt64(arr_v1);
            Assert.Equal(val_v1, value);

            var arr_v2 = BigEndianBitConverter.ToByteArray(new[] {value, value});
            var val_v2 = BigEndianBitConverter.ToInt64(arr_v2);
            var val_v3 = BigEndianBitConverter.ToInt64(arr_v2, sizeof(long));
            Assert.Equal(val_v2, value);
            Assert.Equal(val_v3, value);
        }

        [Fact]
        private void TestUInt64Conversion()
        {
            const ulong value = (ulong) 0x004F003F002F001F;

            var arr_v0 = BitConverter.GetBytes(value);
            var arr_v1 = BigEndianBitConverter.ToByteArray(value);
            Assert.True(BitConverter.IsLittleEndian ? arr_v0.Reverse().SequenceEqual(arr_v1) : arr_v0.SequenceEqual(arr_v1));

            var val_v1 = BigEndianBitConverter.ToUInt64(arr_v1);
            Assert.Equal(val_v1, value);

            var arr_v2 = BigEndianBitConverter.ToByteArray(new[] {value, value});
            var val_v2 = BigEndianBitConverter.ToUInt64(arr_v2);
            var val_v3 = BigEndianBitConverter.ToUInt64(arr_v2, sizeof(ulong));
            Assert.Equal(val_v2, value);
            Assert.Equal(val_v3, value);
        }

        [Fact]
        private void TestInt32Conversion()
        {
            const int value = (int) 0x002F001F;

            var arr_v0 = BitConverter.GetBytes(value);
            var arr_v1 = BigEndianBitConverter.ToByteArray(value);
            Assert.True(BitConverter.IsLittleEndian ? arr_v0.Reverse().SequenceEqual(arr_v1) : arr_v0.SequenceEqual(arr_v1));

            var val_v1 = BigEndianBitConverter.ToInt32(arr_v1);
            Assert.Equal(val_v1, value);

            var arr_v2 = BigEndianBitConverter.ToByteArray(new[] {value, value});
            var val_v2 = BigEndianBitConverter.ToInt32(arr_v2);
            var val_v3 = BigEndianBitConverter.ToInt32(arr_v2, sizeof(int));
            Assert.Equal(val_v2, value);
            Assert.Equal(val_v3, value);
        }

        [Fact]
        private void TestUInt32Conversion()
        {
            const uint value = (uint) 0x002F001F;

            var arr_v0 = BitConverter.GetBytes(value);
            var arr_v1 = BigEndianBitConverter.ToByteArray(value);
            Assert.True(BitConverter.IsLittleEndian ? arr_v0.Reverse().SequenceEqual(arr_v1) : arr_v0.SequenceEqual(arr_v1));

            var val_v1 = BigEndianBitConverter.ToUInt32(arr_v1);
            Assert.Equal(val_v1, value);

            var arr_v2 = BigEndianBitConverter.ToByteArray(new[] {value, value});
            var val_v2 = BigEndianBitConverter.ToUInt32(arr_v2);
            var val_v3 = BigEndianBitConverter.ToUInt32(arr_v2, sizeof(uint));
            Assert.Equal(val_v2, value);
            Assert.Equal(val_v3, value);
        }

        [Fact]
        private void TestInt16Conversion()
        {
            const short value = (short) 0x001F;

            var arr_v0 = BitConverter.GetBytes(value);
            var arr_v1 = BigEndianBitConverter.ToByteArray(value);
            Assert.True(BitConverter.IsLittleEndian ? arr_v0.Reverse().SequenceEqual(arr_v1) : arr_v0.SequenceEqual(arr_v1));

            var val_v1 = BigEndianBitConverter.ToInt16(arr_v1);
            Assert.Equal(val_v1, value);

            var arr_v2 = BigEndianBitConverter.ToByteArray(new[] {value, value});
            var val_v2 = BigEndianBitConverter.ToInt16(arr_v2);
            var val_v3 = BigEndianBitConverter.ToInt16(arr_v2, sizeof(short));
            Assert.Equal(val_v2, value);
            Assert.Equal(val_v3, value);
        }

        [Fact]
        private void TestUInt16Conversion()
        {
            const ushort value = (ushort) 0x001F;

            var arr_v0 = BitConverter.GetBytes(value);
            var arr_v1 = BigEndianBitConverter.ToByteArray(value);
            Assert.True(BitConverter.IsLittleEndian ? arr_v0.Reverse().SequenceEqual(arr_v1) : arr_v0.SequenceEqual(arr_v1));

            var val_v1 = BigEndianBitConverter.ToUInt16(arr_v1);
            Assert.Equal(val_v1, value);

            var arr_v2 = BigEndianBitConverter.ToByteArray(new[] {value, value});
            var val_v2 = BigEndianBitConverter.ToUInt16(arr_v2);
            var val_v3 = BigEndianBitConverter.ToUInt16(arr_v2, sizeof(ushort));
            Assert.Equal(val_v2, value);
            Assert.Equal(val_v3, value);
        }

        [Fact]
        private void TestCharConversion()
        {
            const char value = (char) 0x001F;

            var arr_v0 = BitConverter.GetBytes(value);
            var arr_v1 = BigEndianBitConverter.ToByteArray(value);
            Assert.True(BitConverter.IsLittleEndian ? arr_v0.Reverse().SequenceEqual(arr_v1) : arr_v0.SequenceEqual(arr_v1));

            var val_v1 = BigEndianBitConverter.ToChar(arr_v1);
            Assert.Equal(val_v1, value);

            var arr_v2 = BigEndianBitConverter.ToByteArray(new[] {value, value});
            var val_v2 = BigEndianBitConverter.ToChar(arr_v2);
            var val_v3 = BigEndianBitConverter.ToChar(arr_v2, sizeof(char));
            Assert.Equal(val_v2, value);
            Assert.Equal(val_v3, value);
        }

        [Fact]
        private void TestSingleConversion()
        {
            const float value = 0x004F003F002F001F;

            var arr_v0 = BitConverter.GetBytes(value);
            var arr_v1 = BigEndianBitConverter.ToByteArray(value);
            Assert.True(BitConverter.IsLittleEndian ? arr_v0.Reverse().SequenceEqual(arr_v1) : arr_v0.SequenceEqual(arr_v1));

            var val_v1 = BigEndianBitConverter.ToSingle(arr_v1);
            Assert.Equal(val_v1, value);

            var arr_v2 = BigEndianBitConverter.ToByteArray(new[] {value, value});
            var val_v2 = BigEndianBitConverter.ToSingle(arr_v2);
            var val_v3 = BigEndianBitConverter.ToSingle(arr_v2, sizeof(float));
            Assert.Equal(val_v2, value);
            Assert.Equal(val_v3, value);
        }

        [Fact]
        private void TestDoubleConversion()
        {
            const double value = 0x004F003F002F001F;

            var arr_v0 = BitConverter.GetBytes(value);
            var arr_v1 = BigEndianBitConverter.ToByteArray(value);
            Assert.True(BitConverter.IsLittleEndian ? arr_v0.Reverse().SequenceEqual(arr_v1) : arr_v0.SequenceEqual(arr_v1));

            var val_v1 = BigEndianBitConverter.ToDouble(arr_v1);
            Assert.Equal(val_v1, value);

            var arr_v2 = BigEndianBitConverter.ToByteArray(new[] {value, value});
            var val_v2 = BigEndianBitConverter.ToDouble(arr_v2);
            var val_v3 = BigEndianBitConverter.ToDouble(arr_v2, sizeof(double));
            Assert.Equal(val_v2, value);
            Assert.Equal(val_v3, value);
        }

        [Fact]
        private void TestDecimalConversion()
        {
            const decimal value = 0x004F003F002F001F;

//            var arr_v0 = BitConverter.GetBytes(value);
//            var arr_v1 = BigEndianBitConverter.ToByteArray(value);
//            Assert.True(BitConverter.IsLittleEndian ? arr_v0.Reverse().SequenceEqual(arr_v1) : arr_v0.SequenceEqual(arr_v1));

            var arr_v1 = BigEndianBitConverter.ToByteArray(value);
            var val_v1 = BigEndianBitConverter.ToDecimal(arr_v1);
            Assert.Equal(val_v1, value);

            var arr_v2 = BigEndianBitConverter.ToByteArray(new[] {value, value});
            var val_v2 = BigEndianBitConverter.ToDecimal(arr_v2);
            var val_v3 = BigEndianBitConverter.ToDecimal(arr_v2, sizeof(decimal));
            Assert.Equal(val_v2, value);
            Assert.Equal(val_v3, value);
        }

        [Fact]
        private void TestBooleanConversion()
        {
            const bool value = true;

            var arr_v0 = BitConverter.GetBytes(value);
            var arr_v1 = BigEndianBitConverter.ToByteArray(value);
            Assert.True(BitConverter.IsLittleEndian ? arr_v0.Reverse().SequenceEqual(arr_v1) : arr_v0.SequenceEqual(arr_v1));

            var val_v1 = BigEndianBitConverter.ToBoolean(arr_v1);
            Assert.Equal(val_v1, value);

            var arr_v2 = BigEndianBitConverter.ToByteArray(new[] {value, value});
            var val_v2 = BigEndianBitConverter.ToBoolean(arr_v2);
            var val_v3 = BigEndianBitConverter.ToBoolean(arr_v2, sizeof(byte));
            Assert.Equal(val_v2, value);
            Assert.Equal(val_v3, value);
        }
    }
}