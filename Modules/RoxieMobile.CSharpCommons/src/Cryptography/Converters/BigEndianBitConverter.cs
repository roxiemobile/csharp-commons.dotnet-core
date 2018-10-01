using System;
using System.Diagnostics.CodeAnalysis;
using RoxieMobile.CSharpCommons.Cryptography.Converters.Internal;
using RoxieMobile.CSharpCommons.DataAnnotations.Utils;

namespace RoxieMobile.CSharpCommons.Cryptography.Converters
{
    // dotnet/corefx/.../BitConverter.cs
    // @link https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/BitConverter.cs

    /// <summary>
    /// The BigEndianBitConverter class contains methods for converting an array of bytes
    /// in big-indian order to one of the base data types, as well as for converting
    /// a base data type to an array of bytes in big-indian order. 
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class BigEndianBitConverter
    {
// MARK: - Methods: long, ulong

        /// <summary>
        /// Returns a 64-bit signed integer converted from eight bytes in big-indian order at a specified position in a byte array.
        /// </summary>
        /// <param name="value">An array of bytes.</param>
        /// <param name="startIndex">The starting position within <see cref="value"/>.</param>
        /// <returns>A 64-bit signed integer formed by the eight bytes in big-indian order beginning at <see cref="startIndex"/>.</returns>
        public static long ToInt64(byte[] value, int startIndex = 0) =>
            BitConverter.IsLittleEndian ? Pack.BE_To_Int64(value, startIndex) : BitConverter.ToInt64(value, startIndex);

        /// <summary>
        /// Returns a 64-bit unsigned integer converted from eight bytes in big-indian order at a specified position in a byte array.
        /// </summary>
        /// <param name="value">An array of bytes.</param>
        /// <param name="startIndex">The starting position within <see cref="value"/>.</param>
        /// <returns>A 64-bit unsigned integer formed by the eight bytes in big-indian order beginning at <see cref="startIndex"/>.</returns>
        public static ulong ToUInt64(byte[] value, int startIndex = 0) =>
            BitConverter.IsLittleEndian ? Pack.BE_To_UInt64(value, startIndex) : BitConverter.ToUInt64(value, startIndex);

// MARK: -

        /// <summary>
        /// Returns the specified 64-bit signed integer value as an array of bytes in big-indian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 8.</returns>
        public static byte[] ToByteArray(long value) =>
            ToByteArray((ulong) value);

        /// <summary>
        /// Returns the specified 64-bit unsigned integer value as an array of bytes in big-indian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 8.</returns>
        public static byte[] ToByteArray(ulong value) =>
            BitConverter.IsLittleEndian ? Pack.UInt64_To_BE(value) : BitConverter.GetBytes(value);

        /// <summary>
        /// Returns the array of specified 64-bit signed integer values as an array of bytes in big-indian order.
        /// </summary>
        /// <param name="array">The array of numbers to convert.</param>
        /// <returns>An array of bytes.</returns>
        [Obsolete(Messages.WriteADescription)]
        public static byte[] ToByteArray(long[] array) =>
            ToByteArray((ulong[]) (object) array);

        /// <summary>
        /// Returns the array of specified 64-bit unsigned integer values as an array of bytes in big-indian order.
        /// </summary>
        /// <param name="array">The array of numbers to convert.</param>
        /// <returns>An array of bytes.</returns>
        public static byte[] ToByteArray(ulong[] array)
        {
            const int size = sizeof(ulong);
            var bs = new byte[size * array.Length];
            for (int idx = 0, offset = 0; idx < array.Length; idx++, offset += size) {
                Array.Copy(ToByteArray(array[idx]), 0, bs, offset, size);
            }
            return bs;
        }

// MARK: - Methods: int, uint

        /// <summary>
        /// Returns the specified 32-bit signed integer value as an array of bytes in big-indian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 4.</returns>
        public static byte[] ToByteArray(int value) =>
            ToByteArray((uint) value);

        /// <summary>
        /// Returns the specified 32-bit unsigned integer value as an array of bytes in big-indian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 4.</returns>
        public static byte[] ToByteArray(uint value) =>
            BitConverter.IsLittleEndian ? Pack.UInt32_To_BE(value) : BitConverter.GetBytes(value);

        [Obsolete(Messages.WriteADescription)]
        public static byte[] ToByteArray(int[] ns) =>
            ToByteArray((uint[]) (object) ns);

        [Obsolete(Messages.WriteADescription)]
        public static byte[] ToByteArray(uint[] ns)
        {
            const int size = sizeof(uint);
            var bs = new byte[size * ns.Length];
            for (int idx = 0, offset = 0; idx < ns.Length; idx++, offset += size) {
                Array.Copy(ToByteArray(ns[idx]), 0, bs, offset, size);
            }
            return bs;
        }

// MARK: - Methods: short, ushort

        /// <summary>
        /// Returns the specified 16-bit signed integer value as an array of bytes in big-indian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 2.</returns>
        public static byte[] ToByteArray(short value) =>
            ToByteArray((ushort) value);

        /// <summary>
        /// Returns the specified 16-bit unsigned integer value as an array of bytes in big-indian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 2.</returns>
        public static byte[] ToByteArray(ushort value) =>
            BitConverter.IsLittleEndian ? Pack.UInt16_To_BE(value) : BitConverter.GetBytes(value);

        [Obsolete(Messages.WriteADescription)]
        public static byte[] ToByteArray(short[] ns) =>
            ToByteArray((ushort[]) (object) ns);

        [Obsolete(Messages.WriteADescription)]
        public static byte[] ToByteArray(ushort[] ns)
        {
            const short size = sizeof(ushort);
            var bs = new byte[size * ns.Length];
            for (short idx = 0, offset = 0; idx < ns.Length; idx++, offset += size) {
                Array.Copy(ToByteArray(ns[idx]), 0, bs, offset, size);
            }
            return bs;
        }

// MARK: - Methods: float

        /// <summary>
        /// Returns the specified float value as an array of bytes in big-indian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 4.</returns>
        public static byte[] ToByteArray(float value) =>
            BitConverter.IsLittleEndian ? Pack.UInt32_To_BE(SingleToUInt32(value)) : BitConverter.GetBytes(value);

        [Obsolete(Messages.WriteADescription)]
        public static byte[] ToByteArray(float[] ns)
        {
            const short size = sizeof(float);
            var bs = new byte[size * ns.Length];
            for (short idx = 0, offset = 0; idx < ns.Length; idx++, offset += size) {
                Array.Copy(ToByteArray(ns[idx]), 0, bs, offset, size);
            }
            return bs;
        }

// MARK: - Methods: double

        /// <summary>
        /// Returns the specified double value as an array of bytes in big-indian order.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 8.</returns>
        public static byte[] ToByteArray(double value) =>
            BitConverter.IsLittleEndian ? Pack.UInt64_To_BE(DoubleToUInt64(value)) : BitConverter.GetBytes(value);

        [Obsolete(Messages.WriteADescription)]
        public static byte[] ToByteArray(double[] ns)
        {
            const short size = sizeof(double);
            var bs = new byte[size * ns.Length];
            for (short idx = 0, offset = 0; idx < ns.Length; idx++, offset += size) {
                Array.Copy(ToByteArray(ns[idx]), 0, bs, offset, size);
            }
            return bs;
        }

// MARK: - Private Methods

        private static unsafe uint SingleToUInt32(float value) =>
            *((uint*) &value);

        private static unsafe ulong DoubleToUInt64(double value) =>
            *((ulong*) &value);
    }
}