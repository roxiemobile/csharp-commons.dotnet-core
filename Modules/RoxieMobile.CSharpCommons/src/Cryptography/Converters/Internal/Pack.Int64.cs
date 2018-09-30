namespace RoxieMobile.CSharpCommons.Cryptography.Converters.Internal
{
    internal static partial class Pack
    {
// MARK: - Methods: Big-Indian Order

        internal static byte[] Int64_To_BE(long n) =>
            UInt64_To_BE((ulong) n);

        internal static void Int64_To_BE(long n, byte[] bs, int off = 0) =>
            UInt64_To_BE((ulong) n, bs, off);

        internal static byte[] Int64_To_BE(long[] ns) =>
            UInt64_To_BE((ulong[]) (object) ns);

        internal static void Int64_To_BE(long[] ns, byte[] bs, int off = 0) =>
            UInt64_To_BE((ulong[]) (object) ns, bs, off);

// --

        internal static long BE_To_Int64(byte[] bs, int off = 0) =>
            (long) BE_To_UInt64(bs, off);

        internal static void BE_To_Int64(byte[] bs, int off, long[] ns) =>
            BE_To_UInt64(bs, off, (ulong[]) (object) ns);

// MARK: - Methods: Little-Indian Order

        internal static byte[] Int64_To_LE(long n) =>
            UInt64_To_LE((ulong) n);

        internal static void Int64_To_LE(long n, byte[] bs, int off = 0) =>
            UInt64_To_LE((ulong) n, bs, off);

        internal static byte[] Int64_To_LE(long[] ns) =>
            UInt64_To_LE((ulong[]) (object) ns);

        internal static void Int64_To_LE(long[] ns, byte[] bs, int off = 0) =>
            UInt64_To_LE((ulong[]) (object) ns, bs, off);

// --

        internal static long LE_To_Int64(byte[] bs, int off = 0) =>
            (long) LE_To_UInt64(bs, off);

        internal static void LE_To_Int64(byte[] bs, int off, long[] ns) =>
            LE_To_UInt64(bs, off, (ulong[]) (object) ns);
    }
}