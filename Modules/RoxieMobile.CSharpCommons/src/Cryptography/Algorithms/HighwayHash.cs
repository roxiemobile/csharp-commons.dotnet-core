using RoxieMobile.CSharpCommons.Cryptography.Converters;
using RoxieMobile.CSharpCommons.Diagnostics;

namespace RoxieMobile.CSharpCommons.Cryptography.Algorithms
{
    /// <summary>
    /// HighwayHash algorithm. See <a href="https://github.com/google/highwayhash">HighwayHash on GitHub</a>.
    /// </summary>
    public sealed class HighwayHash
    {
// MARK: - Construction

        /// <summary>Initializes a new instance of HighwayHash pseudo-random function using the specified 256-bit key.</summary>
        /// <param name="key"><para>Key for the HighwayHash pseudo-random function.</para><para>Must be exactly 32 bytes long in big-endian order and must not be null or empty.</para></param>
        private HighwayHash(byte[] key)
        {
            Guard.NotNull(key, Funcs.Null(nameof(key)));
            Guard.Equal(key.Length, 32, "HighwayHash key must be exactly 256-bit long (32 bytes).");

            // Init instance
            Reset(key);
        }

// MARK: - Methods

        /// <summary>Computes 64-bit HighwayHash tag for the specified message.</summary>
        /// <param name="key"><para>Key for the HighwayHash pseudo-random function.</para><para>Must be exactly 32 bytes long in big-endian order and must not be null or empty.</para></param>
        /// <param name="data"><para>Array with data bytes.</para><para>Must be null or empty.</para></param>
        /// <param name="offset">Position of first byte of data to read from.</param>
        /// <param name="count">Number of bytes from data to read.</param>
        /// <returns>Returns 64-bit (8 bytes) HighwayHash tag.</returns>
        public static byte[] Hash64(byte[] key, byte[] data, int offset, int count) =>
            new HighwayHash(key).ProcessAll(data, offset, count).Finalize64();

        /// <summary>Computes 64-bit HighwayHash tag for the specified message.</summary>
        /// <param name="key"><para>Key for the HighwayHash pseudo-random function.</para><para>Must be exactly 32 bytes long in big-endian order and must not be null or empty.</para></param>
        /// <param name="data"><para>Array with data bytes.</para><para>Must be null or empty.</para></param>
        /// <returns>Returns 64-bit (8 bytes) HighwayHash tag.</returns>
        public static byte[] Hash64(byte[] key, byte[] data) =>
            Hash64(key, data, 0, data?.Length ?? 0);

        /// <summary>Computes 128-bit HighwayHash tag for the specified message.</summary>
        /// <param name="key"><para>Key for the HighwayHash pseudo-random function.</para><para>Must be exactly 32 bytes long in big-endian order and must not be null or empty.</para></param>
        /// <param name="data"><para>Array with data bytes.</para><para>Must be null or empty.</para></param>
        /// <param name="offset">Position of first byte of data to read from.</param>
        /// <param name="count">Number of bytes from data to read.</param>
        /// <returns>Returns 128-bit (16 bytes) HighwayHash tag.</returns>
        public static byte[] Hash128(byte[] key, byte[] data, int offset, int count) =>
            new HighwayHash(key).ProcessAll(data, offset, count).Finalize128();

        /// <summary>Computes 128-bit HighwayHash tag for the specified message.</summary>
        /// <param name="key"><para>Key for the HighwayHash pseudo-random function.</para><para>Must be exactly 32 bytes long in big-endian order and must not be null or empty.</para></param>
        /// <param name="data"><para>Array with data bytes.</para><para>Must be null or empty.</para></param>
        /// <returns>Returns 128-bit (16 bytes) HighwayHash tag.</returns>
        public static byte[] Hash128(byte[] key, byte[] data) =>
            Hash128(key, data, 0, data?.Length ?? 0);

        /// <summary>Computes 256-bit HighwayHash tag for the specified message.</summary>
        /// <param name="key"><para>Key for the HighwayHash pseudo-random function.</para><para>Must be exactly 32 bytes long in big-endian order and must not be null or empty.</para></param>
        /// <param name="data"><para>Array with data bytes.</para><para>Must be null or empty.</para></param>
        /// <param name="offset">Position of first byte of data to read from.</param>
        /// <param name="count">Number of bytes from data to read.</param>
        /// <returns>Returns 256-bit (32 bytes) HighwayHash tag.</returns>
        public static byte[] Hash256(byte[] key, byte[] data, int offset, int count) =>
            new HighwayHash(key).ProcessAll(data, offset, count).Finalize256();

        /// <summary>Computes 256-bit HighwayHash tag for the specified message.</summary>
        /// <param name="key"><para>Key for the HighwayHash pseudo-random function.</para><para>Must be exactly 32 bytes long in big-endian order and must not be null or empty.</para></param>
        /// <param name="data"><para>Array with data bytes.</para><para>Must be null or empty.</para></param>
        /// <returns>Returns 256-bit (32 bytes) HighwayHash tag.</returns>
        public static byte[] Hash256(byte[] key, byte[] data) =>
            Hash256(key, data, 0, data?.Length ?? 0);

// MARK: - Private Methods

        private void Reset(byte[] key)
        {
            var key0 = BigEndianBitConverter.ToUInt64(key);
            var key1 = BigEndianBitConverter.ToUInt64(key, 8);
            var key2 = BigEndianBitConverter.ToUInt64(key, 16);
            var key3 = BigEndianBitConverter.ToUInt64(key, 24);

            _mul0[0] = 0xdbe6d5d5fe4cce2fL;
            _mul0[1] = 0xa4093822299f31d0L;
            _mul0[2] = 0x13198a2e03707344L;
            _mul0[3] = 0x243f6a8885a308d3L;
            _mul1[0] = 0x3bd39e10cb0ef593L;
            _mul1[1] = 0xc0acf169b5f18a8cL;
            _mul1[2] = 0xbe5466cf34e90c6cL;
            _mul1[3] = 0x452821e638d01377L;
            _v0[0] = _mul0[0] ^ key0;
            _v0[1] = _mul0[1] ^ key1;
            _v0[2] = _mul0[2] ^ key2;
            _v0[3] = _mul0[3] ^ key3;
            _v1[0] = _mul1[0] ^ ((key0 >> 32) | (key0 << 32));
            _v1[1] = _mul1[1] ^ ((key1 >> 32) | (key1 << 32));
            _v1[2] = _mul1[2] ^ ((key2 >> 32) | (key2 << 32));
            _v1[3] = _mul1[3] ^ ((key3 >> 32) | (key3 << 32));
        }

        private HighwayHash ProcessAll(byte[] data, int offset, int count)
        {
            Guard.NotNull(data, Funcs.Null(nameof(data)));
            Guard.GreaterThanOrEqualTo(offset, 0, "Array offset cannot be negative.");
            Guard.GreaterThanOrEqualTo(count, 0, "Number of array elements cannot be negative.");
            Guard.GreaterThanOrEqualTo(data.Length - offset, count,
                () => $"The specified '{nameof(offset)}' and '{nameof(count)}' parameters do not specify a valid range in '{nameof(data)}'.");

            var idx = 0;
            for (; idx + 32 <= count; idx += 32) {
                UpdatePacket(data, offset + idx);
            }
            if ((count & 31) != 0) {
                UpdateRemainder(data, offset + idx, count & 31);
            }

            return this;
        }

        /// <summary>
        /// Updates the hash with 32 bytes of data. If you can read 4 long values from your data efficiently,
        /// prefer using update() instead for more speed.
        /// </summary>
        /// <param name="packet">Data array which has a length of at least pos + 32</param>
        /// <param name="pos">Position in the array to read the first of 32 bytes from</param>
        private void UpdatePacket(byte[] packet, int pos)
        {
            Guard.GreaterThanOrEqualTo(pos, 0, () => $"‘{nameof(pos)}’ ({pos}) must be positive.");
            Guard.GreaterThanOrEqualTo(packet.Length, pos + 32, () => $"‘{nameof(packet)}’ must have at least 32 bytes after ‘{nameof(pos)}’.");

            ulong a0 = Read64(packet, pos + 0);
            ulong a1 = Read64(packet, pos + 8);
            ulong a2 = Read64(packet, pos + 16);
            ulong a3 = Read64(packet, pos + 24);
            Update(a0, a1, a2, a3);
        }

        /// <summary>
        /// Updates the hash with the last 1 to 31 bytes of the data. You must use UpdatePacket first
        /// per 32 bytes of the data, if and only if 1 to 31 bytes of the data are not processed
        /// after that, updateRemainder must be used for those final bytes.
        /// </summary>
        /// <param name="bytes">Data array which has a length of at least pos + size_mod32</param>
        /// <param name="pos">Position in the array to start reading size_mod32 bytes from</param>
        /// <param name="size_mod32">The amount of bytes to read</param>
        public void UpdateRemainder(byte[] bytes, int pos, int size_mod32)
        {
            Guard.GreaterThanOrEqualTo(pos, 0, () => $"‘{nameof(pos)}’ ({pos}) must be positive.");
            Guard.True(size_mod32 >= 0 && size_mod32 < 32, () => $"‘{nameof(size_mod32)}’ ({size_mod32}) must be between 0 and 31.");
            Guard.GreaterThanOrEqualTo(bytes.Length, pos + size_mod32, () => $"‘{nameof(bytes)}’ must have at least ‘{nameof(size_mod32)}’ bytes after ‘{nameof(pos)}’.");

            int size_mod4 = size_mod32 & 3;
            int remainder = size_mod32 & ~3;
            byte[] packet = new byte[32];
            for (int i = 0; i < 4; ++i) {
                _v0[i] += ((ulong) size_mod32 << 32) + (ulong) size_mod32;
            }
            Rotate32By(size_mod32, _v1);
            for (int i = 0; i < remainder; i++) {
                packet[i] = bytes[pos + i];
            }
            if ((size_mod32 & 16) != 0) {
                for (int i = 0; i < 4; i++) {
                    packet[28 + i] = bytes[pos + remainder + i + size_mod4 - 4];
                }
            }
            else {
                if (size_mod4 != 0) {
                    packet[16 + 0] = bytes[pos + remainder + 0];
                    packet[16 + 1] = bytes[pos + remainder + (size_mod4 >> 1)];
                    packet[16 + 2] = bytes[pos + remainder + (size_mod4 - 1)];
                }
            }
            UpdatePacket(packet, 0);
        }

        /// <summary>
        /// Updates the hash with 32 bytes of data given as 4 longs. This function is more efficient
        /// than updatePacket when you can use it.
        /// </summary>
        /// <param name="a0">First 8 bytes in little endian 64-bit long</param>
        /// <param name="a1">Next 8 bytes in little endian 64-bit long</param>
        /// <param name="a2">Next 8 bytes in little endian 64-bit long</param>
        /// <param name="a3">Last 8 bytes in little endian 64-bit long</param>
        private void Update(ulong a0, ulong a1, ulong a2, ulong a3)
        {
            Guard.False(_done, "Can compute a hash only once per instance.");

            _v1[0] += _mul0[0] + a0;
            _v1[1] += _mul0[1] + a1;
            _v1[2] += _mul0[2] + a2;
            _v1[3] += _mul0[3] + a3;
            for (int i = 0; i < 4; ++i) {
                _mul0[i] ^= (_v1[i] & 0xffffffffL) * (_v0[i] >> 32);
                _v0[i] += _mul1[i];
                _mul1[i] ^= (_v0[i] & 0xffffffffL) * (_v1[i] >> 32);
            }
            _v0[0] += ZipperMerge0(_v1[1], _v1[0]);
            _v0[1] += ZipperMerge1(_v1[1], _v1[0]);
            _v0[2] += ZipperMerge0(_v1[3], _v1[2]);
            _v0[3] += ZipperMerge1(_v1[3], _v1[2]);
            _v1[0] += ZipperMerge0(_v0[1], _v0[0]);
            _v1[1] += ZipperMerge1(_v0[1], _v0[0]);
            _v1[2] += ZipperMerge0(_v0[3], _v0[2]);
            _v1[3] += ZipperMerge1(_v0[3], _v0[2]);
        }

        /// <summary>
        /// Computes the hash value after all bytes were processed. Invalidates the state.
        /// </summary>
        /// <returns>Returns 64-bit (8 bytes) HighwayHash tag.</returns>
        private byte[] Finalize64()
        {
            PermuteAndUpdate();
            PermuteAndUpdate();
            PermuteAndUpdate();
            PermuteAndUpdate();
            _done = true;

            var hash = (_v0[0] + _v1[0] + _mul0[0] + _mul1[0]);
            return BigEndianBitConverter.GetBytes(hash);
        }

        /// <summary>
        /// Computes the hash value after all bytes were processed. Invalidates the state.
        /// </summary>
        /// <returns>Returns 128-bit (16 bytes) HighwayHash tag.</returns>
        private byte[] Finalize128()
        {
            PermuteAndUpdate();
            PermuteAndUpdate();
            PermuteAndUpdate();
            PermuteAndUpdate();
            PermuteAndUpdate();
            PermuteAndUpdate();
            _done = true;

            var hash = new[] {
                _v0[0] + _mul0[0] + _v1[2] + _mul1[2],
                _v0[1] + _mul0[1] + _v1[3] + _mul1[3]
            };
            return BigEndianBitConverter.GetBytes(hash);
        }

        /// <summary>
        /// Computes the hash value after all bytes were processed. Invalidates the state.
        /// </summary>
        /// <returns>Returns 256-bit (32 bytes) HighwayHash tag.</returns>
        private byte[] Finalize256()
        {
            PermuteAndUpdate();
            PermuteAndUpdate();
            PermuteAndUpdate();
            PermuteAndUpdate();
            PermuteAndUpdate();
            PermuteAndUpdate();
            PermuteAndUpdate();
            PermuteAndUpdate();
            PermuteAndUpdate();
            PermuteAndUpdate();
            _done = true;

            var hash = new ulong[4];
            ModularReduction(_v1[1] + _mul1[1], _v1[0] + _mul1[0], _v0[1] + _mul0[1], _v0[0] + _mul0[0], hash, 0);
            ModularReduction(_v1[3] + _mul1[3], _v1[2] + _mul1[2], _v0[3] + _mul0[3], _v0[2] + _mul0[2], hash, 2);
            return BigEndianBitConverter.GetBytes(hash);
        }

// MARK: - Private Methods

        private static ulong Read64(byte[] src, int pos)
        {
            // Mask with 0xffL so that it is 0..255 as long (byte can only be -128..127)
            return (ulong) ((src[pos + 0] & 0xffL) | ((src[pos + 1] & 0xffL) << 8) |
                ((src[pos + 2] & 0xffL) << 16) | ((src[pos + 3] & 0xffL) << 24) |
                ((src[pos + 4] & 0xffL) << 32) | ((src[pos + 5] & 0xffL) << 40) |
                ((src[pos + 6] & 0xffL) << 48) | ((src[pos + 7] & 0xffL) << 56));
        }

        private static void Rotate32By(int count, ulong[] lanes)
        {
            for (int i = 0; i < 4; ++i) {
                ulong half0 = (lanes[i] & 0xffffffffL);
                ulong half1 = (lanes[i] >> 32) & 0xffffffffL;
                lanes[i] = ((half0 << count) & 0xffffffffL) | (half0 >> (32 - count));
                lanes[i] |= (((half1 << count) & 0xffffffffL) | (half1 >> (32 - count))) << 32;
            }
        }

        private static ulong ZipperMerge0(ulong v1, ulong v0)
        {
            return (((v0 & 0xff000000L) | (v1 & 0xff00000000L)) >> 24) |
                (((v0 & 0xff0000000000L) | (v1 & 0xff000000000000L)) >> 16) |
                (v0 & 0xff0000L) | ((v0 & 0xff00L) << 32) |
                ((v1 & 0xff00000000000000L) >> 8) | (v0 << 56);
        }

        private static ulong ZipperMerge1(ulong v1, ulong v0)
        {
            return (((v1 & 0xff000000L) | (v0 & 0xff00000000L)) >> 24) |
                (v1 & 0xff0000L) | ((v1 & 0xff0000000000L) >> 16) |
                ((v1 & 0xff00L) << 24) | ((v0 & 0xff000000000000L) >> 8) |
                ((v1 & 0xffL) << 48) | (v0 & 0xff00000000000000L);
        }

        private void PermuteAndUpdate()
        {
            Update((_v0[2] >> 32) | (_v0[2] << 32),
                (_v0[3] >> 32) | (_v0[3] << 32),
                (_v0[0] >> 32) | (_v0[0] << 32),
                (_v0[1] >> 32) | (_v0[1] << 32));
        }

        private static void ModularReduction(ulong a3_unmasked, ulong a2, ulong a1, ulong a0, ulong[] hash, int pos)
        {
            ulong a3 = a3_unmasked & 0x3FFFFFFFFFFFFFFFL;
            hash[pos + 1] = a1 ^ ((a3 << 1) | (a2 >> 63)) ^ ((a3 << 2) | (a2 >> 62));
            hash[pos + 0] = a0 ^ (a2 << 1) ^ (a2 << 2);
        }

// MARK: - Variables

        private readonly ulong[] _v0 = new ulong[4];

        private readonly ulong[] _v1 = new ulong[4];

        private readonly ulong[] _mul0 = new ulong[4];

        private readonly ulong[] _mul1 = new ulong[4];

        private bool _done = false;
    }
}