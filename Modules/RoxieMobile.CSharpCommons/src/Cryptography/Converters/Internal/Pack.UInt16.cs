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

        internal static byte[] UInt16_To_BE(ushort n)
        {
            var bs = new byte[sizeof(ushort)];
            UInt16_To_BE(n, bs);
            return bs;
        }

        internal static void UInt16_To_BE(ushort n, byte[] bs, int off = 0)
        {
            // @formatter:off
            bs[off + 0] = (byte) (n >> 8);
            bs[off + 1] = (byte) (n >> 0);
            // @formatter:on
        }

        internal static byte[] UInt16_To_BE(ushort[] ns)
        {
            var bs = new byte[sizeof(ushort) * ns.Length];
            UInt16_To_BE(ns, bs);
            return bs;
        }

        internal static void UInt16_To_BE(ushort[] ns, byte[] bs, int off = 0)
        {
            foreach (var n in ns) {
                UInt16_To_BE(n, bs, off);
                off += sizeof(ushort);
            }
        }

// --

        internal static ushort BE_To_UInt16(byte[] bs, int off = 0)
        {
            uint n = 0;
            n |= (uint) bs[off + 0] << 8;
            n |= (uint) bs[off + 1] << 0;
            return (ushort) n;
        }

        internal static void BE_To_UInt16(byte[] bs, int off, ushort[] ns)
        {
            for (var idx = 0; idx < ns.Length; ++idx) {
                ns[idx] = BE_To_UInt16(bs, off);
                off += sizeof(ushort);
            }
        }

// MARK: - Methods: Little-Indian Order

        internal static byte[] UInt16_To_LE(ushort n)
        {
            var bs = new byte[sizeof(ushort)];
            UInt16_To_LE(n, bs);
            return bs;
        }

        internal static void UInt16_To_LE(ushort n, byte[] bs, int off = 0)
        {
            // @formatter:off
            bs[off + 0] = (byte) (n >> 0);
            bs[off + 1] = (byte) (n >> 8);
            // @formatter:on
        }

        internal static byte[] UInt16_To_LE(ushort[] ns)
        {
            var bs = new byte[sizeof(ushort) * ns.Length];
            UInt16_To_LE(ns, bs);
            return bs;
        }

        internal static void UInt16_To_LE(ushort[] ns, byte[] bs, int off = 0)
        {
            foreach (var n in ns) {
                UInt16_To_LE(n, bs, off);
                off += sizeof(ushort);
            }
        }

// --

        internal static ushort LE_To_UInt16(byte[] bs, int off = 0)
        {
            uint n = 0;
            n |= (uint) bs[off + 0] << 0;
            n |= (uint) bs[off + 1] << 8;
            return (ushort) n;
        }

        internal static void LE_To_UInt16(byte[] bs, int off, ushort[] ns)
        {
            for (var idx = 0; idx < ns.Length; ++idx) {
                ns[idx] = LE_To_UInt16(bs, off);
                off += sizeof(ushort);
            }
        }
    }
}