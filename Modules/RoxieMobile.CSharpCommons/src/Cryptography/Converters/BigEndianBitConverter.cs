using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace RoxieMobile.CSharpCommons.Cryptography.Converters
{
    // BitConverter Class
    // @link https://docs.microsoft.com/en-us/dotnet/api/system.bitconverter

    // dotnet/corefx/.../BitConverter.cs
    // @link https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/BitConverter.cs

    // GridProtectionAlliance/gsf/.../GSF.Core.Shared/BigEndian.cs
    // @link https://github.com/GridProtectionAlliance/gsf/blob/master/Source/Libraries/GSF.Core.Shared/BigEndian.cs

    /// <summary>
    /// The BigEndianBitConverter class contains methods for converting an array of bytes
    /// in big-endian order to one of the base data types, as well as for converting
    /// a base data type to an array of bytes in big-endian order.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class BigEndianBitConverter
    {
// MARK: - Methods: long

        /// <summary>
        /// Returns a 64-bit signed integer converted from 8 bytes in big-endian order at a specified position in a byte array.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="startIndex">The starting position within <see cref="buffer"/>.</param>
        /// <returns>A 64-bit signed integer formed by the 8 bytes in big-endian order beginning at <see cref="startIndex"/>.</returns>
        public static long ToInt64(byte[] buffer, int startIndex = 0) =>
            (long) ToUInt64(buffer, startIndex);

        /// <summary>
        /// Returns the specified 64-bit signed integer number as an array of bytes in big-endian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 8.</returns>
        public static byte[] GetBytes(long value) =>
            GetBytes((ulong) value);

        /// <summary>
        /// Returns the array of specified 64-bit signed integer numbers as an array of sequences of bytes in big-endian order.
        /// </summary>
        /// <param name="array">The array of numbers to convert.</param>
        /// <returns>An array of bytes.</returns>
        public static byte[] GetBytes(long[] array) =>
            ToByteArray(array, value => GetBytes((ulong) value));

// MARK: - Methods: ulong

        /// <summary>
        /// Returns a 64-bit unsigned integer converted from 8 bytes in big-endian order at a specified position in a byte array.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="startIndex">The starting position within <see cref="buffer"/>.</param>
        /// <returns>A 64-bit unsigned integer formed by the 8 bytes in big-endian order beginning at <see cref="startIndex"/>.</returns>
        public static unsafe ulong ToUInt64(byte[] buffer, int startIndex = 0)
        {
            ValidateParameters(buffer, startIndex, sizeof(ulong));

            ulong value = 0;
            fixed (byte* data = &buffer[startIndex]) {

                if (BitConverter.IsLittleEndian) {

                    var destination = (byte*) &value;
                    // high double word 
                    destination[0] = data[7];
                    destination[1] = data[6];
                    destination[2] = data[5];
                    destination[3] = data[4];
                    // low double word
                    destination[4] = data[3];
                    destination[5] = data[2];
                    destination[6] = data[1];
                    destination[7] = data[0];
                }
                else {
                    value = *((ulong*) data);
                }
            }
            return value;
        }

        /// <summary>
        /// Returns the specified 64-bit unsigned integer number as an array of bytes in big-endian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 8.</returns>
        public static unsafe byte[] GetBytes(ulong value)
        {
            var array = new byte[sizeof(ulong)];
            fixed (byte* destination = array) {

                if (BitConverter.IsLittleEndian) {

                    var data = (byte*) &value;
                    // high double word
                    destination[0] = data[7];
                    destination[1] = data[6];
                    destination[2] = data[5];
                    destination[3] = data[4];
                    // low double word
                    destination[4] = data[3];
                    destination[5] = data[2];
                    destination[6] = data[1];
                    destination[7] = data[0];
                }
                else {
                    *((ulong*) destination) = value;
                }
            }
            return array;
        }

        /// <summary>
        /// Returns the array of specified 64-bit unsigned integer numbers as an array of sequences of bytes in big-endian order.
        /// </summary>
        /// <param name="array">The array of numbers to convert.</param>
        /// <returns>An array of bytes.</returns>
        public static byte[] GetBytes(ulong[] array) =>
            ToByteArray(array, GetBytes);

// MARK: - Methods: int

        /// <summary>
        /// Returns a 32-bit signed integer converted from 4 bytes in big-endian order at a specified position in a byte array.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="startIndex">The starting position within <see cref="buffer"/>.</param>
        /// <returns>A 32-bit signed integer formed by the 4 bytes in big-endian order beginning at <see cref="startIndex"/>.</returns>
        public static int ToInt32(byte[] buffer, int startIndex = 0) =>
            (int) ToUInt32(buffer, startIndex);

        /// <summary>
        /// Returns the specified 32-bit signed integer number as an array of bytes in big-endian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 4.</returns>
        public static byte[] GetBytes(int value) =>
            GetBytes((uint) value);

        /// <summary>
        /// Returns the array of specified 32-bit signed integer numbers as an array of sequences of bytes in big-endian order.
        /// </summary>
        /// <param name="array">The array of numbers to convert.</param>
        /// <returns>An array of bytes.</returns>
        public static byte[] GetBytes(int[] array) =>
            ToByteArray(array, value => GetBytes((uint) value));

// MARK: - Methods: uint

        /// <summary>
        /// Returns a 32-bit unsigned integer converted from 4 bytes in big-endian order at a specified position in a byte array.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="startIndex">The starting position within <see cref="buffer"/>.</param>
        /// <returns>A 32-bit unsigned integer formed by the 4 bytes in big-endian order beginning at <see cref="startIndex"/>.</returns>
        public static unsafe uint ToUInt32(byte[] buffer, int startIndex = 0)
        {
            ValidateParameters(buffer, startIndex, sizeof(uint));

            uint value = 0;
            fixed (byte* data = &buffer[startIndex]) {

                if (BitConverter.IsLittleEndian) {

                    var destination = (byte*) &value;
                    // high word
                    destination[0] = data[3];
                    destination[1] = data[2];
                    // low word
                    destination[2] = data[1];
                    destination[3] = data[0];
                }
                else {
                    value = *((uint*) data);
                }
            }
            return value;
        }

        /// <summary>
        /// Returns the specified 32-bit unsigned integer number as an array of bytes in big-endian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 4.</returns>
        public static unsafe byte[] GetBytes(uint value)
        {
            var array = new byte[sizeof(uint)];
            fixed (byte* destination = array) {

                if (BitConverter.IsLittleEndian) {

                    var data = (byte*) &value;
                    // high word
                    destination[0] = data[3];
                    destination[1] = data[2];
                    // low word
                    destination[2] = data[1];
                    destination[3] = data[0];
                }
                else {
                    *((uint*) destination) = value;
                }
            }
            return array;
        }

        /// <summary>
        /// Returns the array of specified 32-bit unsigned integer numbers as an array of sequences of bytes in big-endian order.
        /// </summary>
        /// <param name="array">The array of numbers to convert.</param>
        /// <returns>An array of bytes.</returns>
        public static byte[] GetBytes(uint[] array) =>
            ToByteArray(array, GetBytes);

// MARK: - Methods: short

        /// <summary>
        /// Returns a 16-bit signed integer converted from 2 bytes in big-endian order at a specified position in a byte array.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="startIndex">The starting position within <see cref="buffer"/>.</param>
        /// <returns>A 16-bit signed integer formed by the 2 bytes in big-endian order beginning at <see cref="startIndex"/>.</returns>
        public static short ToInt16(byte[] buffer, int startIndex = 0) =>
            (short) ToUInt16(buffer, startIndex);

        /// <summary>
        /// Returns the specified 16-bit signed integer number as an array of bytes in big-endian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 2.</returns>
        public static byte[] GetBytes(short value) =>
            GetBytes((ushort) value);

        /// <summary>
        /// Returns the array of specified 16-bit signed integer numbers as an array of sequences of bytes in big-endian order.
        /// </summary>
        /// <param name="array">The array of numbers to convert.</param>
        /// <returns>An array of bytes.</returns>
        public static byte[] GetBytes(short[] array) =>
            ToByteArray(array, value => GetBytes((ushort) value));

// MARK: - Methods: ushort

        /// <summary>
        /// Returns a 16-bit unsigned integer converted from 2 bytes in big-endian order at a specified position in a byte array.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="startIndex">The starting position within <see cref="buffer"/>.</param>
        /// <returns>A 16-bit unsigned integer formed by the 2 bytes in big-endian order beginning at <see cref="startIndex"/>.</returns>
        public static unsafe ushort ToUInt16(byte[] buffer, int startIndex = 0)
        {
            ValidateParameters(buffer, startIndex, sizeof(ushort));

            ushort value = 0;
            fixed (byte* data = &buffer[startIndex]) {

                if (BitConverter.IsLittleEndian) {

                    var destination = (byte*) &value;
                    // word
                    destination[0] = data[1];
                    destination[1] = data[0];
                }
                else {
                    value = *((ushort*) data);
                }
            }
            return value;
        }

        /// <summary>
        /// Returns the specified 16-bit unsigned integer number as an array of bytes in big-endian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 2.</returns>
        public static unsafe byte[] GetBytes(ushort value)
        {
            var array = new byte[sizeof(ushort)];
            fixed (byte* destination = array) {

                if (BitConverter.IsLittleEndian) {

                    var data = (byte*) &value;
                    // word
                    destination[0] = data[1];
                    destination[1] = data[0];
                }
                else {
                    *((ushort*) destination) = value;
                }
            }
            return array;
        }

        /// <summary>
        /// Returns the array of specified 16-bit unsigned integer numbers as an array of sequences of bytes in big-endian order.
        /// </summary>
        /// <param name="array">The array of numbers to convert.</param>
        /// <returns>An array of bytes.</returns>
        public static byte[] GetBytes(ushort[] array) =>
            ToByteArray(array, GetBytes);

// MARK: - Methods: char

        /// <summary>
        /// Returns a Unicode character converted from 2 bytes in big-endian order at a specified position in a byte array.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="startIndex">The starting position within <see cref="buffer"/>.</param>
        /// <returns>A 16-bit signed integer formed by the 2 bytes in big-endian order beginning at <see cref="startIndex"/>.</returns>
        public static char ToChar(byte[] buffer, int startIndex = 0) =>
            (char) ToUInt16(buffer, startIndex);

        /// <summary>
        /// Returns the specified Unicode character value as an array of bytes in big-endian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 2.</returns>
        public static byte[] GetBytes(char value) =>
            GetBytes((ushort) value);

        /// <summary>
        /// Returns the array of specified Unicode character values as an array of sequences of bytes in big-endian order.
        /// </summary>
        /// <param name="array">The array of numbers to convert.</param>
        /// <returns>An array of bytes.</returns>
        public static byte[] GetBytes(char[] array) =>
            ToByteArray(array, GetBytes);

// MARK: - Methods: bool

        /// <summary>
        /// Returns a <see cref="Boolean"/> value converted from one byte at a specified position in a byte array.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="startIndex">The starting position within <see cref="buffer"/>.</param>
        /// <returns>A 16-bit signed integer formed by the 2 bytes in big-endian order beginning at <see cref="startIndex"/>.</returns>
        /// <returns>true if the byte at <see cref="startIndex"/> in <see cref="buffer"/> is nonzero; otherwise, false.</returns>
        public static bool ToBoolean(byte[] buffer, int startIndex = 0)
        {
            ValidateParameters(buffer, startIndex, sizeof(byte));

            return (buffer[startIndex] != 0);
        }

        /// <summary>
        /// Returns the specified <see cref="Boolean"/> value as an array of bytes in big-endian order.
        /// </summary>
        /// <param name="value">The <see cref="Boolean"/> value to convert.</param>
        /// <returns>An array of bytes with length 1.</returns>
        public static byte[] GetBytes(bool value) =>
            new[] { value ? (byte) 1 : (byte) 0 };

        /// <summary>
        /// Returns the array of specified <see cref="Boolean"/> values as an array of bytes.
        /// </summary>
        /// <param name="array">The array of <see cref="Boolean"/> values to convert.</param>
        /// <returns>An array of bytes.</returns>
        public static byte[] GetBytes(bool[] array) =>
            ToByteArray(array, GetBytes);

// MARK: - Methods: float

        /// <summary>
        /// Returns a single-precision floating point number converted from 4 bytes in big-endian order at a specified position in a byte array.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="startIndex">The starting position within <see cref="buffer"/>.</param>
        /// <returns>A single-precision floating point number formed by 4 bytes beginning at <see cref="startIndex"/>.</returns>
        public static unsafe float ToSingle(byte[] buffer, int startIndex = 0)
        {
            var value = ToUInt32(buffer, startIndex);
            return *(float*) &value;
        }

        /// <summary>
        /// Returns the specified single-precision floating point number as an array of bytes in big-endian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 4.</returns>
        public static unsafe byte[] GetBytes(float value) =>
            GetBytes(*(uint*) &value);

        /// <summary>
        /// Returns the array of specified single-precision floating point numbers as an array of sequences of bytes in big-endian order.
        /// </summary>
        /// <param name="array">The array of numbers to convert.</param>
        /// <returns>An array of bytes.</returns>
        public static byte[] GetBytes(float[] array) =>
            ToByteArray(array, GetBytes);

// MARK: - Methods: double

        /// <summary>
        /// Returns a double-precision floating point number converted from 8 bytes in big-endian order at a specified position in a byte array.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="startIndex">The starting position within <see cref="buffer"/>.</param>
        /// <returns>A double-precision floating point number formed by 8 bytes beginning at <see cref="startIndex"/>.</returns>
        public static unsafe double ToDouble(byte[] buffer, int startIndex = 0)
        {
            var value = ToUInt64(buffer, startIndex);
            return *(double*) &value;
        }

        /// <summary>
        /// Returns the specified double-precision floating point number as an array of bytes in big-endian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 8.</returns>
        public static unsafe byte[] GetBytes(double value) =>
            GetBytes(*(ulong*) &value);

        /// <summary>
        /// Returns the array of specified double-precision floating point numbers as an array of sequences of bytes in big-endian order.
        /// </summary>
        /// <param name="array">The array of numbers to convert.</param>
        /// <returns>An array of bytes.</returns>
        public static byte[] GetBytes(double[] array) =>
            ToByteArray(array, GetBytes);

// MARK: - Methods: decimal

        /// <summary>
        /// Returns a decimal floating-point number converted from 16 bytes in big-endian order at a specified position in a byte array.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="startIndex">The starting position within <see cref="buffer"/>.</param>
        /// <returns>A decimal floating-point number formed by 16 bytes beginning at <see cref="startIndex"/>.</returns>
        public static unsafe decimal ToDecimal(byte[] buffer, int startIndex = 0)
        {
            ValidateParameters(buffer, startIndex, sizeof(decimal));

            decimal value = 0;
            fixed (byte* ptr = &buffer[startIndex]) {

                if (BitConverter.IsLittleEndian) {

                    var destination = (byte*) &value;
                    // flags
                    destination[0] = ptr[3];
                    destination[1] = ptr[2];
                    destination[2] = ptr[1];
                    destination[3] = ptr[0];
                    // high double word
                    destination[4] = ptr[7];
                    destination[5] = ptr[6];
                    destination[6] = ptr[5];
                    destination[7] = ptr[4];
                    // low double word
                    destination[8] = ptr[11];
                    destination[9] = ptr[10];
                    destination[10] = ptr[9];
                    destination[11] = ptr[8];
                    // mid double word
                    destination[12] = ptr[15];
                    destination[13] = ptr[14];
                    destination[14] = ptr[13];
                    destination[15] = ptr[12];
                }
                else {
                    value = *((decimal*) ptr);
                }
            }
            return value;
        }

        /// <summary>
        /// Returns the specified decimal floating-point number as an array of bytes in big-endian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 16.</returns>
        public static unsafe byte[] GetBytes(decimal value)
        {
            var array = new byte[sizeof(decimal)];
            fixed (byte* destination = array) {

                if (BitConverter.IsLittleEndian) {

                    var data = (byte*) &value;
                    // flags
                    destination[0] = data[3];
                    destination[1] = data[2];
                    destination[2] = data[1];
                    destination[3] = data[0];
                    // high double word
                    destination[4] = data[7];
                    destination[5] = data[6];
                    destination[6] = data[5];
                    destination[7] = data[4];
                    // low double word
                    destination[8] = data[11];
                    destination[9] = data[10];
                    destination[10] = data[9];
                    destination[11] = data[8];
                    // mid double word
                    destination[12] = data[15];
                    destination[13] = data[14];
                    destination[14] = data[13];
                    destination[15] = data[12];
                }
                else {
                    *((decimal*) destination) = value;
                }
            }
            return array;
        }

        /// <summary>
        /// Returns the array of specified decimal floating-point numbers as an array of sequences of bytes in big-endian order.
        /// </summary>
        /// <param name="array">The array of numbers to convert.</param>
        /// <returns>An array of bytes.</returns>
        public static byte[] GetBytes(decimal[] array) =>
            ToByteArray(array, GetBytes);

// MARK: - Private Methods

        /// <summary>
        /// Validates that the specified <paramref name="startIndex"/> and <paramref name="count"/> are valid within the given <paramref name="buffer"/>.
        /// </summary>
        /// <param name="buffer">Buffer to validate.</param>
        /// <param name="startIndex">0-based start index into the <paramref name="buffer"/>.</param>
        /// <param name="count">Valid number of bytes within <paramref name="buffer"/> from <paramref name="startIndex"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> or <paramref name="count"/> is less than 0 -or- <paramref name="startIndex"/> and <paramref name="count"/> will exceed <paramref name="buffer"/> length.</exception>
        private static void ValidateParameters(byte[] buffer, int startIndex, int count)
        {
            if (buffer == null) {
                throw new ArgumentNullException(nameof(buffer));
            }
            if (startIndex < 0) {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Buffer parameter cannot be negative.");
            }
            if (count < 0) {
                throw new ArgumentOutOfRangeException(nameof(count), "Buffer parameter cannot be negative.");
            }
            if (startIndex + count > buffer.Length) {
                throw new ArgumentOutOfRangeException(nameof(count), $"Buffer operation with startIndex of {startIndex} and length of {count} will exceed {buffer.Length} bytes of available buffer space.");
            }
        }

        /// <summary>
        /// TODO: Write a description.
        /// </summary>
        private static byte[] ToByteArray<T>(IReadOnlyList<T> array, Converter<T, byte[]> converter)
        {
            var blockSize = Unsafe.SizeOf<T>();
            var buffer = new byte[blockSize * array.Count];

            for (int idx = 0, offset = 0; idx < array.Count; idx++, offset += blockSize) {
                Buffer.BlockCopy(converter(array[idx]), 0, buffer, offset, blockSize);
            }
            return buffer;
        }
    }
}