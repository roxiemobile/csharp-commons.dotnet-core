using System.Diagnostics.CodeAnalysis;
using RoxieMobile.CSharpCommons.Cryptography.Converters;
using RoxieMobile.CSharpCommons.Diagnostics;

namespace RoxieMobile.CSharpCommons.Cryptography.Algorithms
{
    /// <summary>
    /// SipHash algorithm. See <a href="https://github.com/paya-cz/siphash">SipHash on GitHub</a>. This class is immutable and thread-safe.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "SwitchStatementMissingSomeCases")]
    public sealed class SipHash
    {
// MARK: - Construction

        /// <summary>Initializes a new instance of SipHash pseudo-random function using the specified 128-bit key.</summary>
        /// <param name="key"><para>Key for the SipHash pseudo-random function.</para><para>Must be exactly 16 bytes long in big-endian order and must not be null or empty.</para></param>
        private SipHash(byte[] key)
        {
            Guard.NotNull(key, Funcs.Null(nameof(key)));
            Guard.Equal(key.Length, 16, "SipHash key must be exactly 128-bit long (16 bytes).");

            // Init instance
            _initialState0 = 0x736f6d6570736575UL ^ BigEndianBitConverter.ToUInt64(key);
            _initialState1 = 0x646f72616e646f6dUL ^ BigEndianBitConverter.ToUInt64(key, sizeof(ulong));
        }

// MARK: - Methods

        /// <summary>Computes 64-bit SipHash tag for the specified message.</summary>
        /// <param name="key"><para>Key for the SipHash pseudo-random function.</para><para>Must be exactly 16 bytes long in big-endian order and must not be null or empty.</para></param>
        /// <param name="data"><para>Array with data bytes.</para><para>Must be null or empty.</para></param>
        /// <param name="offset">Position of first byte of data to read from.</param>
        /// <param name="count">Number of bytes from data to read.</param>
        /// <returns>Returns 64-bit (8 bytes) SipHash tag.</returns>
        public static byte[] Hash64(byte[] key, byte[] data, int offset, int count) =>
            new SipHash(key).Compute(data, offset, count, HashType.SipHash64);

        /// <summary>Computes 64-bit SipHash tag for the specified message.</summary>
        /// <param name="key"><para>Key for the SipHash pseudo-random function.</para><para>Must be exactly 16 bytes long in big-endian order and must not be null or empty.</para></param>
        /// <param name="data"><para>Array with data bytes.</para><para>Must be null or empty.</para></param>
        /// <returns>Returns 64-bit (8 bytes) SipHash tag.</returns>
        public static byte[] Hash64(byte[] key, byte[] data) =>
            Hash64(key, data, 0, data?.Length ?? 0);

        /// <summary>Computes 128-bit SipHash tag for the specified message.</summary>
        /// <param name="key"><para>Key for the SipHash pseudo-random function.</para><para>Must be exactly 16 bytes long in big-endian order and must not be null or empty.</para></param>
        /// <param name="data"><para>Array with data bytes.</para><para>Must be null or empty.</para></param>
        /// <param name="offset">Position of first byte of data to read from.</param>
        /// <param name="count">Number of bytes from data to read.</param>
        /// <returns>Returns 128-bit (16 bytes) SipHash tag.</returns>
        public static byte[] Hash128(byte[] key, byte[] data, int offset, int count) =>
            new SipHash(key).Compute(data, offset, count, HashType.SipHash128);

        /// <summary>Computes 128-bit SipHash tag for the specified message.</summary>
        /// <param name="key"><para>Key for the SipHash pseudo-random function.</para><para>Must be exactly 16 bytes long in big-endian order and must not be null or empty.</para></param>
        /// <param name="data"><para>Array with data bytes.</para><para>Must be null or empty.</para></param>
        /// <returns>Returns 128-bit (16 bytes) SipHash tag.</returns>
        public static byte[] Hash128(byte[] key, byte[] data) =>
            Hash128(key, data, 0, data?.Length ?? 0);

// MARK: - Private Methods

        /// <summary>Computes 64-bit SipHash tag for the specified message.</summary>
        /// <param name="data"><para>The byte array for which to computer SipHash tag.</para><para>Must be null or empty.</para></param>
        /// <param name="offset"><para>The zero-based index of the first element in the range.</para><para>Must not be negative.</para></param>
        /// <param name="count"><para>The number of elements in the range.</para><para>Must not be negative.</para></param>
        /// <param name="hashType">Type of a SipHash algorithm.</param>
        /// <returns>Returns 64-bit (8 bytes) SipHash tag.</returns>
        private byte[] Compute(byte[] data, int offset, int count, HashType hashType)
        {
            Guard.NotNull(data, Funcs.Null(nameof(data)));
            Guard.GreaterThanOrEqualTo(offset, 0, "Array offset cannot be negative.");
            Guard.GreaterThanOrEqualTo(count, 0, "Number of array elements cannot be negative.");
            Guard.GreaterThanOrEqualTo(data.Length - offset, count,
                () => $"The specified '{nameof(offset)}' and '{nameof(count)}' parameters do not specify a valid range in '{nameof(data)}'.");

            byte[] result = null;

            // SipHash internal state
            var v0 = _initialState0;
            var v1 = _initialState1;
            // It is faster to load the initialStateX fields from memory again than to reference v0 and v1:
            var v2 = 0x1F160A001E161714UL ^ _initialState0;
            var v3 = 0x100A160317100A1EUL ^ _initialState1;

            if (hashType == HashType.SipHash128) {
                v1 ^= 0xee;
            }

            // We process data in 64-bit blocks
            ulong block = 0;
            unsafe {

                // Start of the data to process
                fixed (byte* dataStart = &data[offset]) {

                    // The last 64-bit block of data
                    var finalBlock = dataStart + (count & ~7);

                    // Process the input data in blocks of 64 bits
                    for (var blockPointer = (ulong*) dataStart; blockPointer < finalBlock;) {
                        block = *blockPointer++;

                        v3 ^= block;

                        // Round 1
                        v0 += v1;
                        v2 += v3;
                        v1 = v1 << 13 | v1 >> 51;
                        v3 = v3 << 16 | v3 >> 48;
                        v1 ^= v0;
                        v3 ^= v2;
                        v0 = v0 << 32 | v0 >> 32;
                        v2 += v1;
                        v0 += v3;
                        v1 = v1 << 17 | v1 >> 47;
                        v3 = v3 << 21 | v3 >> 43;
                        v1 ^= v2;
                        v3 ^= v0;
                        v2 = v2 << 32 | v2 >> 32;

                        // Round 2
                        v0 += v1;
                        v2 += v3;
                        v1 = v1 << 13 | v1 >> 51;
                        v3 = v3 << 16 | v3 >> 48;
                        v1 ^= v0;
                        v3 ^= v2;
                        v0 = v0 << 32 | v0 >> 32;
                        v2 += v1;
                        v0 += v3;
                        v1 = v1 << 17 | v1 >> 47;
                        v3 = v3 << 21 | v3 >> 43;
                        v1 ^= v2;
                        v3 ^= v0;
                        v2 = v2 << 32 | v2 >> 32;

                        v0 ^= block;
                    }

                    // Load the remaining bytes
                    block = (ulong) count << 56;
                    switch (count & 7) {
                        case 7:
                            block |= *(uint*) finalBlock | (ulong) *(ushort*) (finalBlock + 4) << 32 | (ulong) *(finalBlock + 6) << 48;
                            break;
                        case 6:
                            block |= *(uint*) finalBlock | (ulong) *(ushort*) (finalBlock + 4) << 32;
                            break;
                        case 5:
                            block |= *(uint*) finalBlock | (ulong) *(finalBlock + 4) << 32;
                            break;
                        case 4:
                            block |= *(uint*) finalBlock;
                            break;
                        case 3:
                            block |= *(ushort*) finalBlock | (ulong) *(finalBlock + 2) << 16;
                            break;
                        case 2:
                            block |= *(ushort*) finalBlock;
                            break;
                        case 1:
                            block |= *finalBlock;
                            break;
                    }
                }
            }

            // Process the final block
            {
                v3 ^= block;

                // Round 1
                v0 += v1;
                v2 += v3;
                v1 = v1 << 13 | v1 >> 51;
                v3 = v3 << 16 | v3 >> 48;
                v1 ^= v0;
                v3 ^= v2;
                v0 = v0 << 32 | v0 >> 32;
                v2 += v1;
                v0 += v3;
                v1 = v1 << 17 | v1 >> 47;
                v3 = v3 << 21 | v3 >> 43;
                v1 ^= v2;
                v3 ^= v0;
                v2 = v2 << 32 | v2 >> 32;

                // Round 2
                v0 += v1;
                v2 += v3;
                v1 = v1 << 13 | v1 >> 51;
                v3 = v3 << 16 | v3 >> 48;
                v1 ^= v0;
                v3 ^= v2;
                v0 = v0 << 32 | v0 >> 32;
                v2 += v1;
                v0 += v3;
                v1 = v1 << 17 | v1 >> 47;
                v3 = v3 << 21 | v3 >> 43;
                v1 ^= v2;
                v3 ^= v0;
                v2 = v2 << 32 | v2 >> 32;

                v0 ^= block;
                v2 ^= (hashType == HashType.SipHash128) ? (ulong) 0xee : 0xff;
            }

            // 4 finalization rounds
            {
                // Round 1
                v0 += v1;
                v2 += v3;
                v1 = v1 << 13 | v1 >> 51;
                v3 = v3 << 16 | v3 >> 48;
                v1 ^= v0;
                v3 ^= v2;
                v0 = v0 << 32 | v0 >> 32;
                v2 += v1;
                v0 += v3;
                v1 = v1 << 17 | v1 >> 47;
                v3 = v3 << 21 | v3 >> 43;
                v1 ^= v2;
                v3 ^= v0;
                v2 = v2 << 32 | v2 >> 32;

                // Round 2
                v0 += v1;
                v2 += v3;
                v1 = v1 << 13 | v1 >> 51;
                v3 = v3 << 16 | v3 >> 48;
                v1 ^= v0;
                v3 ^= v2;
                v0 = v0 << 32 | v0 >> 32;
                v2 += v1;
                v0 += v3;
                v1 = v1 << 17 | v1 >> 47;
                v3 = v3 << 21 | v3 >> 43;
                v1 ^= v2;
                v3 ^= v0;
                v2 = v2 << 32 | v2 >> 32;

                // Round 3
                v0 += v1;
                v2 += v3;
                v1 = v1 << 13 | v1 >> 51;
                v3 = v3 << 16 | v3 >> 48;
                v1 ^= v0;
                v3 ^= v2;
                v0 = v0 << 32 | v0 >> 32;
                v2 += v1;
                v0 += v3;
                v1 = v1 << 17 | v1 >> 47;
                v3 = v3 << 21 | v3 >> 43;
                v1 ^= v2;
                v3 ^= v0;
                v2 = v2 << 32 | v2 >> 32;

                // Round 4
                v0 += v1;
                v2 += v3;
                v1 = v1 << 13 | v1 >> 51;
                v3 = v3 << 16 | v3 >> 48;
                v1 ^= v0;
                v3 ^= v2;
                v0 = v0 << 32 | v0 >> 32;
                v2 += v1;
                v0 += v3;
                v1 = v1 << 17 | v1 >> 47;
                v3 = v3 << 21 | v3 >> 43;
                v1 ^= v2;
                v3 ^= v0;
                v2 = v2 << 32 | v2 >> 32;
            }

            if (hashType == HashType.SipHash64) {

                var hash = (v0 ^ v1 ^ v2 ^ v3);
                result = BigEndianBitConverter.GetBytes(hash);
            }
            else {

                var hashHi = (v0 ^ v1 ^ v2 ^ v3);
                v1 ^= 0xdd;

                // 5 finalization rounds
                {
                    // Round 1
                    v0 += v1;
                    v2 += v3;
                    v1 = v1 << 13 | v1 >> 51;
                    v3 = v3 << 16 | v3 >> 48;
                    v1 ^= v0;
                    v3 ^= v2;
                    v0 = v0 << 32 | v0 >> 32;
                    v2 += v1;
                    v0 += v3;
                    v1 = v1 << 17 | v1 >> 47;
                    v3 = v3 << 21 | v3 >> 43;
                    v1 ^= v2;
                    v3 ^= v0;
                    v2 = v2 << 32 | v2 >> 32;

                    // Round 2
                    v0 += v1;
                    v2 += v3;
                    v1 = v1 << 13 | v1 >> 51;
                    v3 = v3 << 16 | v3 >> 48;
                    v1 ^= v0;
                    v3 ^= v2;
                    v0 = v0 << 32 | v0 >> 32;
                    v2 += v1;
                    v0 += v3;
                    v1 = v1 << 17 | v1 >> 47;
                    v3 = v3 << 21 | v3 >> 43;
                    v1 ^= v2;
                    v3 ^= v0;
                    v2 = v2 << 32 | v2 >> 32;

                    // Round 3
                    v0 += v1;
                    v2 += v3;
                    v1 = v1 << 13 | v1 >> 51;
                    v3 = v3 << 16 | v3 >> 48;
                    v1 ^= v0;
                    v3 ^= v2;
                    v0 = v0 << 32 | v0 >> 32;
                    v2 += v1;
                    v0 += v3;
                    v1 = v1 << 17 | v1 >> 47;
                    v3 = v3 << 21 | v3 >> 43;
                    v1 ^= v2;
                    v3 ^= v0;
                    v2 = v2 << 32 | v2 >> 32;

                    // Round 4
                    v0 += v1;
                    v2 += v3;
                    v1 = v1 << 13 | v1 >> 51;
                    v3 = v3 << 16 | v3 >> 48;
                    v1 ^= v0;
                    v3 ^= v2;
                    v0 = v0 << 32 | v0 >> 32;
                    v2 += v1;
                    v0 += v3;
                    v1 = v1 << 17 | v1 >> 47;
                    v3 = v3 << 21 | v3 >> 43;
                    v1 ^= v2;
                    v3 ^= v0;
                    v2 = v2 << 32 | v2 >> 32;
                }

                var hashLo = (v0 ^ v1 ^ v2 ^ v3);
                result = BigEndianBitConverter.GetBytes(new[] { hashHi, hashLo });
            }

            // Done
            return result;
        }

// MARK: - Inner Types

        private enum HashType
        {
            SipHash64,
            SipHash128
        }

// MARK: - Variables

        /// <summary>
        /// Part of the initial 256-bit internal state.
        /// </summary>
        private readonly ulong _initialState0;

        /// <summary>
        /// Part of the initial 256-bit internal state.
        /// </summary>
        private readonly ulong _initialState1;
    }
}