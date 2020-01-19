using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using RoxieMobile.CSharpCommons.Abstractions.Providers;
using RoxieMobile.CSharpCommons.Data.Converters;
using RoxieMobile.CSharpCommons.Extensions;

namespace RoxieMobile.CSharpCommons.Data.Helpers
{
    // Orleans.Core/.../ByteArrayBuilder.cs
    // @link https://github.com/dotnet/orleans/blob/master/src/Orleans.Core/Messaging/ByteArrayBuilder.cs

    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public sealed class BigEndianByteArrayBuilder :
        IByteArrayProvider
    {
// MARK: - Construction

        public BigEndianByteArrayBuilder(ushort bufferSize = DEFAULT_BUFFER_SIZE)
        {
            // Init instance
            _bufferSize = bufferSize;
            _currentBuffer = new byte[bufferSize];
            _currentOffset = 0;
            _completedBuffers = new List<ArraySegment<byte>>();
            _completedLength = 0;
        }

// MARK: - Properties

        public int Length =>
            _currentOffset + _completedLength;

// MARK: - Methods

        public BigEndianByteArrayBuilder Append(string? value, Encoding? encoding = null)
        {
            return (value?.IsNotEmpty() ?? false)
                ? AppendByteArray((encoding ?? _encodingUtf32BE).GetBytes(value))
                : this;
        }

        public BigEndianByteArrayBuilder Append(Enum? value)
        {
            return (value != null)
                ? Append(value.ToEnumString(), _encodingUtf32BE)
                : this;
        }

// MARK: - Methods: long

        public BigEndianByteArrayBuilder Append(long? value)
        {
            return value.HasValue
                ? AppendByteArray(BigEndianBitConverter.GetBytes(value.Value))
                : this;
        }

        public BigEndianByteArrayBuilder Append(long[]? array)
        {
            return (array?.IsNotEmpty() ?? false)
                ? AppendByteArray(array)
                : this;
        }

// MARK: - Methods: ulong

        public BigEndianByteArrayBuilder Append(ulong? value)
        {
            return value.HasValue
                ? AppendByteArray(BigEndianBitConverter.GetBytes(value.Value))
                : this;
        }

        public BigEndianByteArrayBuilder Append(ulong[]? array)
        {
            return (array?.IsNotEmpty() ?? false)
                ? AppendByteArray(array)
                : this;
        }

// MARK: - Methods: int

        public BigEndianByteArrayBuilder Append(int? value)
        {
            return value.HasValue
                ? AppendByteArray(BigEndianBitConverter.GetBytes(value.Value))
                : this;
        }

        public BigEndianByteArrayBuilder Append(int[]? array)
        {
            return (array?.IsNotEmpty() ?? false)
                ? AppendByteArray(array)
                : this;
        }

// MARK: - Methods: uint

        public BigEndianByteArrayBuilder Append(uint? value)
        {
            return value.HasValue
                ? AppendByteArray(BigEndianBitConverter.GetBytes(value.Value))
                : this;
        }

        public BigEndianByteArrayBuilder Append(uint[]? array)
        {
            return (array?.IsNotEmpty() ?? false)
                ? AppendByteArray(array)
                : this;
        }

// MARK: - Methods: short

        public BigEndianByteArrayBuilder Append(short? value)
        {
            return value.HasValue
                ? AppendByteArray(BigEndianBitConverter.GetBytes(value.Value))
                : this;
        }

        public BigEndianByteArrayBuilder Append(short[]? array)
        {
            return (array?.IsNotEmpty() ?? false)
                ? AppendByteArray(array)
                : this;
        }

// MARK: - Methods: ushort

        public BigEndianByteArrayBuilder Append(ushort? value)
        {
            return value.HasValue
                ? AppendByteArray(BigEndianBitConverter.GetBytes(value.Value))
                : this;
        }

        public BigEndianByteArrayBuilder Append(ushort[]? array)
        {
            return (array?.IsNotEmpty() ?? false)
                ? AppendByteArray(array)
                : this;
        }

// MARK: - Methods: sbyte

        public BigEndianByteArrayBuilder Append(sbyte? value)
        {
            if (value.HasValue) {
                EnsureRoomFor(1);
                _currentBuffer[_currentOffset++] = unchecked((byte) value.Value);
            }
            return this;
        }

        public BigEndianByteArrayBuilder Append(sbyte[]? array)
        {
            return (array?.IsNotEmpty() ?? false)
                ? AppendByteArray(array)
                : this;
        }

// MARK: - Methods: byte

        public BigEndianByteArrayBuilder Append(byte? value)
        {
            if (value.HasValue) {
                EnsureRoomFor(1);
                _currentBuffer[_currentOffset++] = value.Value;
            }
            return this;
        }

        public BigEndianByteArrayBuilder Append(byte[]? array)
        {
            return (array?.IsNotEmpty() ?? false)
                ? AppendByteArray(array)
                : this;
        }

// MARK: - Methods: char

        public BigEndianByteArrayBuilder Append(char? value)
        {
            return value.HasValue
                ? AppendByteArray(BigEndianBitConverter.GetBytes(value.Value))
                : this;
        }

        public BigEndianByteArrayBuilder Append(char[]? array)
        {
            return (array?.IsNotEmpty() ?? false)
                ? AppendByteArray(array)
                : this;
        }

// MARK: - Methods: bool

        public BigEndianByteArrayBuilder Append(bool? value)
        {
            if (value.HasValue) {
                EnsureRoomFor(1);
                _currentBuffer[_currentOffset++] = BoolToByte(value.Value);
            }
            return this;
        }

        public BigEndianByteArrayBuilder Append(bool[]? array)
        {
            return (array?.IsNotEmpty() ?? false)
                ? AppendByteArray(Array.ConvertAll(array, BoolToByte))
                : this;
        }

// MARK: - Methods: float

        public BigEndianByteArrayBuilder Append(float? value)
        {
            return value.HasValue
                ? AppendByteArray(BigEndianBitConverter.GetBytes(value.Value))
                : this;
        }

        public BigEndianByteArrayBuilder Append(float[]? array)
        {
            return (array?.IsNotEmpty() ?? false)
                ? AppendByteArray(array)
                : this;
        }

// MARK: - Methods: double

        public BigEndianByteArrayBuilder Append(double? value)
        {
            return value.HasValue
                ? AppendByteArray(BigEndianBitConverter.GetBytes(value.Value))
                : this;
        }

        public BigEndianByteArrayBuilder Append(double[]? array)
        {
            return (array?.IsNotEmpty() ?? false)
                ? AppendByteArray(array)
                : this;
        }

// MARK: - Methods: decimal

        public BigEndianByteArrayBuilder Append(decimal? value)
        {
            return value.HasValue
                ? AppendByteArray(BigEndianBitConverter.GetBytes(value.Value))
                : this;
        }

        public BigEndianByteArrayBuilder Append(decimal[]? array)
        {
            return (array?.IsNotEmpty() ?? false)
                ? AppendByteArray(array)
                : this;
        }

// MARK: - Methods: IByteArrayProvider

        public BigEndianByteArrayBuilder Append(IByteArrayProvider? source)
        {
            return (source != null)
                ? AppendByteArray(source.ToByteArray())
                : this;
        }

        public BigEndianByteArrayBuilder Append(IEnumerable<IByteArrayProvider?>? collection)
        {
            if (collection != null) {
                foreach (var item in collection) {
                    Append(item);
                }
            }
            return this;
        }

        public byte[] ToByteArray()
        {
            var result = new byte[this.Length];
            var offset = 0;

            foreach (var buffer in _completedBuffers) {
                if (buffer.Array != null) {

                    Array.Copy(buffer.Array, buffer.Offset, result, offset, buffer.Count);
                    offset += buffer.Count;
                }
            }

            if ((_currentOffset > 0) && (_currentBuffer != null)) {
                Array.Copy(_currentBuffer, 0, result, offset, _currentOffset);
            }

            return result;
        }

// MARK: - Private Methods

        private BigEndianByteArrayBuilder AppendByteArray(Array array)
        {
            var n = Buffer.ByteLength(array);
            if (RoomFor(n)) {

                Buffer.BlockCopy(array, 0, _currentBuffer, _currentOffset, n);
                _currentOffset += n;
            }
            else if (n <= _bufferSize) {

                Grow();
                Buffer.BlockCopy(array, 0, _currentBuffer, _currentOffset, n);
                _currentOffset += n;
            }
            else {

                var pos = 0;
                while (pos < n) {

                    EnsureRoomFor(1);
                    var k = Math.Min(n - pos, _bufferSize - _currentOffset);
                    Buffer.BlockCopy(array, pos, _currentBuffer, _currentOffset, k);
                    pos += k;
                    _currentOffset += k;
                }
            }
            return this;
        }

        private bool RoomFor(int n)
        {
            return (_currentBuffer != null) && (_currentOffset + n <= _bufferSize);
        }

        private void Grow()
        {
            if (_currentBuffer != null) {
                _completedBuffers.Add(new ArraySegment<byte>(_currentBuffer, 0, _currentOffset));
                _completedLength += _currentOffset;
            }
            _currentBuffer = new byte[_bufferSize];
            _currentOffset = 0;
        }

        private void EnsureRoomFor(int n)
        {
            if (!RoomFor(n)) {
                Grow();
            }
        }

        private byte BoolToByte(bool value) =>
            value ? (byte) 1 : (byte) 0;

// MARK: - Constants

        private const ushort DEFAULT_BUFFER_SIZE = 4096;

// MARK: - Variables

        private static readonly Encoding _encodingUtf32BE = new UTF32Encoding(bigEndian: true, byteOrderMark: true);

        private readonly ushort _bufferSize;

        private byte[] _currentBuffer;

        private int _currentOffset;

        private readonly ICollection<ArraySegment<byte>> _completedBuffers;

        private int _completedLength;
    }
}
