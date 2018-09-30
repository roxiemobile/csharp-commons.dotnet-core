using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Cryptography.Converters.Internal
{
    [SuppressMessage("ReSharper", "ArrangeRedundantParentheses")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "ParameterTypeCanBeEnumerable.Global")]
    [SuppressMessage("ReSharper", "RedundantCast")]
    internal static partial class Pack
    {
// MARK: - Methods: Big-Indian Order

        internal static byte[] UInt32_To_BE(uint n)
        {
            var bs = new byte[sizeof(uint)];
            UInt32_To_BE(n, bs);
            return bs;
        }

        internal static void UInt32_To_BE(uint n, byte[] bs, int off = 0)
        {
            // @formatter:off
            bs[off + 0] = (byte) (n >> 24);
            bs[off + 1] = (byte) (n >> 16);
            bs[off + 2] = (byte) (n >>  8);
            bs[off + 3] = (byte) (n >>  0);
            // @formatter:on
        }

        internal static byte[] UInt32_To_BE(uint[] ns)
        {
            var bs = new byte[sizeof(uint) * ns.Length];
            UInt32_To_BE(ns, bs);
            return bs;
        }

        internal static void UInt32_To_BE(uint[] ns, byte[] bs, int off = 0)
        {
            foreach (var n in ns) {
                UInt32_To_BE(n, bs, off);
                off += sizeof(uint);
            }
        }

// --

        internal static uint BE_To_UInt32(byte[] bs, int off = 0)
        {
            return (uint) bs[off] << 24
                | (uint) bs[off + 1] << 16
                | (uint) bs[off + 2] << 8
                | (uint) bs[off + 3];
        }

        internal static void BE_To_UInt32(byte[] bs, int off, uint[] ns)
        {
            for (var idx = 0; idx < ns.Length; ++idx) {
                ns[idx] = BE_To_UInt32(bs, off);
                off += sizeof(uint);
            }
        }

// MARK: - Methods: Little-Indian Order

        internal static byte[] UInt32_To_LE(uint n)
        {
            var bs = new byte[sizeof(uint)];
            UInt32_To_LE(n, bs);
            return bs;
        }

        internal static void UInt32_To_LE(uint n, byte[] bs, int off = 0)
        {
            // @formatter:off
            bs[off + 0] = (byte) (n >>  0);
            bs[off + 1] = (byte) (n >>  8);
            bs[off + 2] = (byte) (n >> 16);
            bs[off + 3] = (byte) (n >> 24);
            // @formatter:on
        }

        internal static byte[] UInt32_To_LE(uint[] ns)
        {
            var bs = new byte[sizeof(uint) * ns.Length];
            UInt32_To_LE(ns, bs);
            return bs;
        }

        internal static void UInt32_To_LE(uint[] ns, byte[] bs, int off = 0)
        {
            foreach (var n in ns) {
                UInt32_To_LE(n, bs, off);
                off += sizeof(uint);
            }
        }

// --

        internal static uint LE_To_UInt32(byte[] bs, int off = 0)
        {
            return (uint) bs[off + 0] << 0
                | (uint) bs[off + 1] << 8
                | (uint) bs[off + 2] << 16
                | (uint) bs[off + 3] << 24;
        }

        internal static void LE_To_UInt32(byte[] bs, int off, uint[] ns)
        {
            for (var idx = 0; idx < ns.Length; ++idx) {
                ns[idx] = LE_To_UInt32(bs, off);
                off += sizeof(uint);
            }
        }
    }
}