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

        internal static byte[] UInt64_To_BE(ulong n)
        {
            var bs = new byte[sizeof(ulong)];
            UInt64_To_BE(n, bs);
            return bs;
        }

        internal static void UInt64_To_BE(ulong n, byte[] bs, int off = 0)
        {
            // @formatter:off
            UInt32_To_BE((uint) (n >> 32), bs, off + 0);
            UInt32_To_BE((uint) (n >>  0), bs, off + 4);
            // @formatter:on
        }

        internal static byte[] UInt64_To_BE(ulong[] ns)
        {
            var bs = new byte[sizeof(ulong) * ns.Length];
            UInt64_To_BE(ns, bs);
            return bs;
        }

        internal static void UInt64_To_BE(ulong[] ns, byte[] bs, int off = 0)
        {
            foreach (var n in ns) {
                UInt64_To_BE(n, bs, off);
                off += sizeof(ulong);
            }
        }

// --

        internal static ulong BE_To_UInt64(byte[] bs, int off = 0)
        {
            var hi = BE_To_UInt32(bs, off + 0);
            var lo = BE_To_UInt32(bs, off + 4);
            return ((ulong) hi << 32) | ((ulong) lo);
        }

        internal static void BE_To_UInt64(byte[] bs, int off, ulong[] ns)
        {
            for (var idx = 0; idx < ns.Length; ++idx) {
                ns[idx] = BE_To_UInt64(bs, off);
                off += sizeof(ulong);
            }
        }

// MARK: - Methods: Little-Indian Order

        internal static byte[] UInt64_To_LE(ulong n)
        {
            var bs = new byte[sizeof(ulong)];
            UInt64_To_LE(n, bs);
            return bs;
        }

        internal static void UInt64_To_LE(ulong n, byte[] bs, int off = 0)
        {
            // @formatter:off
            UInt32_To_LE((uint) (n >>  0), bs, off + 0);
            UInt32_To_LE((uint) (n >> 32), bs, off + 4);
            // @formatter:on
        }

        internal static byte[] UInt64_To_LE(ulong[] ns)
        {
            var bs = new byte[sizeof(ulong) * ns.Length];
            UInt64_To_LE(ns, bs);
            return bs;
        }

        internal static void UInt64_To_LE(ulong[] ns, byte[] bs, int off = 0)
        {
            foreach (var n in ns) {
                UInt64_To_LE(n, bs, off);
                off += sizeof(ulong);
            }
        }

// --

        internal static ulong LE_To_UInt64(byte[] bs, int off = 0)
        {
            var lo = LE_To_UInt32(bs, off + 0);
            var hi = LE_To_UInt32(bs, off + 4);
            return ((ulong) hi << 32) | ((ulong) lo);
        }

        internal static void LE_To_UInt64(byte[] bs, int off, ulong[] ns)
        {
            for (var idx = 0; idx < ns.Length; ++idx) {
                ns[idx] = LE_To_UInt64(bs, off);
                off += sizeof(ulong);
            }
        }
    }
}